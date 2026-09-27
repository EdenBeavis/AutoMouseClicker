using AutoMouseClicker.Infrastructure;
using AutoMouseClicker.Infrastructure.Enums;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Forms;

namespace AutoMouseClicker
{
    public partial class AutoClickerForm : Form
    {
        private readonly Timer _timer = new();
        private readonly Random _random = new();
        private bool _continueClickEvent = false;
        private DelayType _delayType = DelayType.Random;

        public static void LeftMouseClick(int xPosition, int yPosition)
        {
            DllHelper.SetCursorPos(xPosition, yPosition);
            DllHelper.MouseEvent(Constants.MOUSEEVENTF_LEFTDOWN, xPosition, yPosition, 0, 0);
            DllHelper.MouseEvent(Constants.MOUSEEVENTF_LEFTUP, xPosition, yPosition, 0, 0);
        }

        public AutoClickerForm()
        {
            InitializeComponent();

            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            DllHelper.RegisterHotKey(this.Handle, Constants.HOTKEY_ID, 0, (int)Keys.F6);
            _timer.SynchronizingObject = this;
            _timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
        }

        private void AutoClickerForm_Load(object sender, EventArgs e)
        {
            switch (_delayType)
            {
                case DelayType.Random:
                    randomDelayRadioButton.Checked = true;
                    break;

                case DelayType.Fixed:
                default:
                    fixedDelayRadioButton.Checked = true;
                    break;
            }
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == Constants.KEY_EVENT && message.WParam.ToInt32() == Constants.HOTKEY_ID)
            {
                _continueClickEvent = !_continueClickEvent;

                if (_continueClickEvent)
                {
                    _timer.Interval = GetNextInterval();
                    _timer.Start();
                }
                else
                {
                    _timer.Stop();
                }
            }
            base.WndProc(ref message);
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs? e)
        {
            if (_continueClickEvent)
            {
                LeftMouseClick(Cursor.Position.X, Cursor.Position.Y);
                _timer.Interval = GetNextInterval();
            }
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
            }
        }

        private void fixedDelayRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (fixedDelayRadioButton.Checked)
            {
                _delayType = DelayType.Fixed;
                varianceNumericUpDown.Enabled = false;
            }
        }
    }
}