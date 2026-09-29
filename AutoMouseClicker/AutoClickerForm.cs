using AutoMouseClicker.Infrastructure;
using AutoMouseClicker.Infrastructure.Enums;
using System.Text.Json;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Forms;

namespace AutoMouseClicker
{
    public partial class AutoClickerForm : Form
    {
        private readonly Timer _timer = new();
        private readonly Random _random = new();
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _trayMenu;
        private bool _continueClickEvent = false;
        private int _completedClicks;
        private bool _stopAfterClickCount;
        private DelayType _delayType = DelayType.Random;
        private Keys _hotkeyKey = Keys.F6;
        private int _hotkeyModifiers;
        private bool _hotkeyRegistered;
        private bool _isInitializing;

        private static string SettingsFilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AutoMouseClicker",
            "settings.json");

        public static void LeftMouseClick(int xPosition, int yPosition)
        {
            DllHelper.SetCursorPos(xPosition, yPosition);
            DllHelper.MouseEvent(Constants.MOUSEEVENTF_LEFTDOWN, xPosition, yPosition, 0, 0);
            DllHelper.MouseEvent(Constants.MOUSEEVENTF_LEFTUP, xPosition, yPosition, 0, 0);
        }

        public static void RightMouseClick(int xPosition, int yPosition)
        {
            DllHelper.SetCursorPos(xPosition, yPosition);
            DllHelper.MouseEvent(Constants.MOUSEEVENTF_RIGHTDOWN, xPosition, yPosition, 0, 0);
            DllHelper.MouseEvent(Constants.MOUSEEVENTF_RIGHTUP, xPosition, yPosition, 0, 0);
        }

        public AutoClickerForm()
        {
            InitializeComponent();

            _trayMenu = new ContextMenuStrip();
            _trayMenu.Items.Add("Show", null, (_, _) => RestoreFromTray());
            _trayMenu.Items.Add("Exit", null, (_, _) => Close());
            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Text = "Auto Mouse Clicker",
                ContextMenuStrip = _trayMenu
            };
            _notifyIcon.DoubleClick += (_, _) => RestoreFromTray();

            var settings = LoadSettings();
            _delayType = Enum.IsDefined(settings.DelayType) ? settings.DelayType : DelayType.Random;
            _hotkeyKey = Enum.IsDefined(typeof(Keys), settings.HotkeyKey)
                ? (Keys)settings.HotkeyKey
                : Keys.F6;
            if (_hotkeyKey is Keys.ControlKey or Keys.ShiftKey or Keys.Menu or Keys.None)
            {
                _hotkeyKey = Keys.F6;
            }
            _hotkeyModifiers = settings.HotkeyModifiers &
                (Constants.MOD_ALT | Constants.MOD_CONTROL | Constants.MOD_SHIFT);
            _stopAfterClickCount = settings.StopAfterClickCount;

            _isInitializing = true;
            baseIntervalNumericUpDown.Value = Math.Clamp(
                settings.BaseInterval,
                baseIntervalNumericUpDown.Minimum,
                baseIntervalNumericUpDown.Maximum);
            varianceNumericUpDown.Value = Math.Clamp(
                settings.Variance,
                varianceNumericUpDown.Minimum,
                varianceNumericUpDown.Maximum);
            rightMouseButtonRadioButton.Checked = settings.RightMouseButton;
            leftMouseButtonRadioButton.Checked = !settings.RightMouseButton;
            randomDelayRadioButton.Checked = _delayType == DelayType.Random;
            fixedDelayRadioButton.Checked = _delayType == DelayType.Fixed;
            startStopHotkeyTextBox.Text = FormatHotkey(_hotkeyKey, _hotkeyModifiers);
            stopAfterCountRadioButton.Checked = _stopAfterClickCount;
            stopWithHotkeyRadioButton.Checked = !_stopAfterClickCount;
            clickCountNumericUpDown.Value = Math.Clamp(
                settings.ClickCount,
                clickCountNumericUpDown.Minimum,
                clickCountNumericUpDown.Maximum);
            clickCountNumericUpDown.Enabled = _stopAfterClickCount;
            _isInitializing = false;

            _hotkeyRegistered = DllHelper.RegisterHotKey(Handle, Constants.HOTKEY_ID, _hotkeyModifiers, (int)_hotkeyKey);
            hotkeyStatusLabel.Text = _hotkeyRegistered ? "Shortcut registered" : "Shortcut unavailable";
            _timer.SynchronizingObject = this;
            _timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);

            baseIntervalNumericUpDown.ValueChanged += SettingsControl_Changed;
            varianceNumericUpDown.ValueChanged += SettingsControl_Changed;
            leftMouseButtonRadioButton.CheckedChanged += SettingsControl_Changed;
            rightMouseButtonRadioButton.CheckedChanged += SettingsControl_Changed;
            clickCountNumericUpDown.ValueChanged += SettingsControl_Changed;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SaveSettings();
            _timer.Stop();
            _timer.Dispose();
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            _trayMenu.Dispose();
            if (_hotkeyRegistered)
            {
                DllHelper.UnregisterHotKey(Handle, Constants.HOTKEY_ID);
            }
            base.OnFormClosed(e);
        }

        private void hideToTrayButton_Click(object? sender, EventArgs e)
        {
            _notifyIcon.Visible = true;
            Hide();
        }

        private void RestoreFromTray()
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            _notifyIcon.Visible = false;
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == Constants.KEY_EVENT && message.WParam.ToInt32() == Constants.HOTKEY_ID)
            {
                ToggleClicking();
            }
            base.WndProc(ref message);
        }

        private void startStopHotkeyTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;

            if (e.KeyCode is Keys.ControlKey or Keys.ShiftKey or Keys.Menu)
            {
                return;
            }

            int modifiers = 0;
            if ((e.Modifiers & Keys.Alt) != 0) modifiers |= Constants.MOD_ALT;
            if ((e.Modifiers & Keys.Control) != 0) modifiers |= Constants.MOD_CONTROL;
            if ((e.Modifiers & Keys.Shift) != 0) modifiers |= Constants.MOD_SHIFT;

            if (!TryRegisterHotkey(e.KeyCode, modifiers))
            {
                hotkeyStatusLabel.Text = "Shortcut unavailable";
                return;
            }

            _hotkeyKey = e.KeyCode;
            _hotkeyModifiers = modifiers;
            startStopHotkeyTextBox.Text = FormatHotkey(_hotkeyKey, _hotkeyModifiers);
            hotkeyStatusLabel.Text = "Shortcut registered";
            SaveSettings();
        }

        private bool TryRegisterHotkey(Keys key, int modifiers)
        {
            if (_hotkeyRegistered)
            {
                DllHelper.UnregisterHotKey(Handle, Constants.HOTKEY_ID);
            }

            if (DllHelper.RegisterHotKey(Handle, Constants.HOTKEY_ID, modifiers, (int)key))
            {
                _hotkeyRegistered = true;
                return true;
            }

            _hotkeyRegistered = _hotkeyRegistered && DllHelper.RegisterHotKey(
                Handle,
                Constants.HOTKEY_ID,
                _hotkeyModifiers,
                (int)_hotkeyKey);
            return false;
        }

        private static string FormatHotkey(Keys key, int modifiers)
        {
            var parts = new List<string>();
            if ((modifiers & Constants.MOD_CONTROL) != 0) parts.Add("Ctrl");
            if ((modifiers & Constants.MOD_ALT) != 0) parts.Add("Alt");
            if ((modifiers & Constants.MOD_SHIFT) != 0) parts.Add("Shift");
            parts.Add(key.ToString());
            return string.Join("+", parts);
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs? e)
        {
            if (_continueClickEvent)
            {
                if (rightMouseButtonRadioButton.Checked)
                {
                    RightMouseClick(Cursor.Position.X, Cursor.Position.Y);
                }
                else
                {
                    LeftMouseClick(Cursor.Position.X, Cursor.Position.Y);
                }

                _completedClicks++;
                if (_stopAfterClickCount && _completedClicks >= clickCountNumericUpDown.Value)
                {
                    _continueClickEvent = false;
                    _timer.Stop();
                    return;
                }

                _timer.Interval = GetNextInterval();
            }
        }

        private void ToggleClicking()
        {
            _continueClickEvent = !_continueClickEvent;

            if (_continueClickEvent)
            {
                _completedClicks = 0;
                _timer.Interval = GetNextInterval();
                _timer.Start();
            }
            else
            {
                _timer.Stop();
            }
        }

        private void stopAfterCountRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (!stopAfterCountRadioButton.Checked)
            {
                return;
            }

            _stopAfterClickCount = true;
            clickCountNumericUpDown.Enabled = true;
            SaveSettings();
        }

        private void stopWithHotkeyRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (!stopWithHotkeyRadioButton.Checked)
            {
                return;
            }

            _stopAfterClickCount = false;
            clickCountNumericUpDown.Enabled = false;
            SaveSettings();
        }

        private double GetNextInterval()
        {
            int baseMs = (int)baseIntervalNumericUpDown.Value;
            int variance = (int)varianceNumericUpDown.Value;

            if (randomDelayRadioButton.Checked && variance > 0)
            {
                int offset = _random.Next(-variance, variance + 1);
                int result = baseMs + offset;
                return Math.Max(1, result);
            }

            return Math.Max(1, baseMs);
        }

        private void randomDelayRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (randomDelayRadioButton.Checked)
            {
                _delayType = DelayType.Random;
                varianceNumericUpDown.Enabled = true;
                SaveSettings();
            }
        }

        private void fixedDelayRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (fixedDelayRadioButton.Checked)
            {
                _delayType = DelayType.Fixed;
                varianceNumericUpDown.Enabled = false;
                SaveSettings();
            }
        }

        private void SettingsControl_Changed(object? sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            if (_isInitializing)
            {
                return;
            }

            var settings = new AppSettings
            {
                DelayType = _delayType,
                BaseInterval = baseIntervalNumericUpDown.Value,
                Variance = varianceNumericUpDown.Value,
                RightMouseButton = rightMouseButtonRadioButton.Checked,
                StopAfterClickCount = _stopAfterClickCount,
                ClickCount = clickCountNumericUpDown.Value,
                HotkeyKey = (int)_hotkeyKey,
                HotkeyModifiers = _hotkeyModifiers
            };

            try
            {
                var directory = Path.GetDirectoryName(SettingsFilePath)!;
                Directory.CreateDirectory(directory);
                File.WriteAllText(SettingsFilePath, JsonSerializer.Serialize(settings));
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        private static AppSettings LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(SettingsFilePath)) ?? new AppSettings();
                }
            }
            catch (JsonException)
            {
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }

            return new AppSettings();
        }

        private sealed class AppSettings
        {
            public DelayType DelayType { get; set; } = DelayType.Random;
            public decimal BaseInterval { get; set; } = 250;
            public decimal Variance { get; set; } = 50;
            public bool RightMouseButton { get; set; }
            public bool StopAfterClickCount { get; set; }
            public decimal ClickCount { get; set; } = 100;
            public int HotkeyKey { get; set; } = (int)Keys.F6;
            public int HotkeyModifiers { get; set; }
        }
    }
}