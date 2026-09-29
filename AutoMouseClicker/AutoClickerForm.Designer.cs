using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace AutoMouseClicker
{
    partial class AutoClickerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            randomDelayRadioButton = new RadioButton();
            fixedDelayRadioButton = new RadioButton();
            delayGroupBox = new GroupBox();
            baseIntervalLabel = new Label();
            varianceLabel = new Label();
            baseIntervalNumericUpDown = new NumericUpDown();
            varianceNumericUpDown = new NumericUpDown();
            hotkeyGroupBox = new GroupBox();
            startStopHotkeyLabel = new Label();
            startStopHotkeyTextBox = new TextBox();
            hotkeyStatusLabel = new Label();
            mouseClickGroupBox = new GroupBox();
            leftMouseButtonRadioButton = new RadioButton();
            rightMouseButtonRadioButton = new RadioButton();
            stopConditionGroupBox = new GroupBox();
            stopAfterCountRadioButton = new RadioButton();
            stopWithHotkeyRadioButton = new RadioButton();
            clickCountNumericUpDown = new NumericUpDown();
            hideToTrayButton = new Button();
            var mainLayoutPanel = new TableLayoutPanel();
            delayGroupBox.SuspendLayout();
            hotkeyGroupBox.SuspendLayout();
            mouseClickGroupBox.SuspendLayout();
            stopConditionGroupBox.SuspendLayout();
            mainLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // randomDelayRadioButton
            // 
            randomDelayRadioButton.AutoSize = true;
            randomDelayRadioButton.Location = new Point(20, 25);
            randomDelayRadioButton.Name = "randomDelayRadioButton";
            randomDelayRadioButton.Size = new Size(184, 19);
            randomDelayRadioButton.TabIndex = 0;
            randomDelayRadioButton.TabStop = true;
            randomDelayRadioButton.Text = "Random Delay Between Clicks";
            randomDelayRadioButton.UseVisualStyleBackColor = true;
            randomDelayRadioButton.CheckedChanged += new EventHandler(randomDelayRadioButton_CheckedChanged);
            // 
            // fixedDelayRadioButton
            // 
            fixedDelayRadioButton.AutoSize = true;
            fixedDelayRadioButton.Location = new Point(20, 54);
            fixedDelayRadioButton.Name = "fixedDelayRadioButton";
            fixedDelayRadioButton.Size = new Size(166, 19);
            fixedDelayRadioButton.TabIndex = 1;
            fixedDelayRadioButton.TabStop = true;
            fixedDelayRadioButton.Text = "Fixed Delay Between Clicks";
            fixedDelayRadioButton.UseVisualStyleBackColor = true;
            fixedDelayRadioButton.CheckedChanged += new EventHandler(fixedDelayRadioButton_CheckedChanged);
            // 
            // baseIntervalLabel
            // 
            baseIntervalLabel.AutoSize = true;
            baseIntervalLabel.Location = new Point(20, 105);
            baseIntervalLabel.Name = "baseIntervalLabel";
            baseIntervalLabel.Size = new Size(110, 15);
            baseIntervalLabel.TabIndex = 2;
            baseIntervalLabel.Text = "Base Interval (ms):";
            // 
            // baseIntervalNumericUpDown
            // 
            baseIntervalNumericUpDown.Location = new Point(20, 125);
            baseIntervalNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            baseIntervalNumericUpDown.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            baseIntervalNumericUpDown.Name = "baseIntervalNumericUpDown";
            baseIntervalNumericUpDown.Size = new Size(150, 23);
            baseIntervalNumericUpDown.TabIndex = 3;
            baseIntervalNumericUpDown.Value = new decimal(new int[] { 250, 0, 0, 0 });
            // 
            // varianceLabel
            // 
            varianceLabel.AutoSize = true;
            varianceLabel.Location = new Point(210, 105);
            varianceLabel.Name = "varianceLabel";
            varianceLabel.Size = new Size(96, 15);
            varianceLabel.TabIndex = 4;
            varianceLabel.Text = "Variance (ms):";
            // 
            // varianceNumericUpDown
            // 
            varianceNumericUpDown.Location = new Point(210, 125);
            varianceNumericUpDown.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            varianceNumericUpDown.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            varianceNumericUpDown.Name = "varianceNumericUpDown";
            varianceNumericUpDown.Size = new Size(150, 23);
            varianceNumericUpDown.TabIndex = 5;
            varianceNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            //
            // hotkeyGroupBox
            //
            hotkeyGroupBox.Controls.Add(startStopHotkeyLabel);
            hotkeyGroupBox.Controls.Add(startStopHotkeyTextBox);
            hotkeyGroupBox.Controls.Add(hotkeyStatusLabel);
            hotkeyGroupBox.Dock = DockStyle.Fill;
            hotkeyGroupBox.Margin = new Padding(0);
            hotkeyGroupBox.Name = "hotkeyGroupBox";
            hotkeyGroupBox.Size = new Size(648, 100);
            hotkeyGroupBox.TabIndex = 6;
            hotkeyGroupBox.TabStop = false;
            hotkeyGroupBox.Text = "Start/Stop Hotkey";
            //
            // startStopHotkeyLabel
            //
            startStopHotkeyLabel.AutoSize = true;
            startStopHotkeyLabel.Location = new Point(20, 25);
            startStopHotkeyLabel.Name = "startStopHotkeyLabel";
            startStopHotkeyLabel.Size = new Size(178, 15);
            startStopHotkeyLabel.TabIndex = 0;
            startStopHotkeyLabel.Text = "Press a key or key combination:";
            //
            // startStopHotkeyTextBox
            //
            startStopHotkeyTextBox.Location = new Point(20, 49);
            startStopHotkeyTextBox.Name = "startStopHotkeyTextBox";
            startStopHotkeyTextBox.ReadOnly = true;
            startStopHotkeyTextBox.Size = new Size(170, 23);
            startStopHotkeyTextBox.TabIndex = 1;
            startStopHotkeyTextBox.KeyDown += startStopHotkeyTextBox_KeyDown;
            //
            // hotkeyStatusLabel
            //
            hotkeyStatusLabel.AutoSize = true;
            hotkeyStatusLabel.Location = new Point(210, 53);
            hotkeyStatusLabel.Name = "hotkeyStatusLabel";
            hotkeyStatusLabel.Size = new Size(0, 15);
            hotkeyStatusLabel.TabIndex = 2;
            //
            // mouseClickGroupBox
            //
            mouseClickGroupBox.Controls.Add(leftMouseButtonRadioButton);
            mouseClickGroupBox.Controls.Add(rightMouseButtonRadioButton);
            mouseClickGroupBox.Dock = DockStyle.Fill;
            mouseClickGroupBox.Margin = new Padding(0);
            mouseClickGroupBox.Location = new Point(16, 108);
            mouseClickGroupBox.Name = "mouseClickGroupBox";
            mouseClickGroupBox.Size = new Size(220, 102);
            mouseClickGroupBox.TabIndex = 7;
            mouseClickGroupBox.TabStop = false;
            mouseClickGroupBox.Text = "Mouse Click";
            //
            // leftMouseButtonRadioButton
            //
            leftMouseButtonRadioButton.AutoSize = true;
            leftMouseButtonRadioButton.Checked = true;
            leftMouseButtonRadioButton.Location = new Point(20, 28);
            leftMouseButtonRadioButton.Name = "leftMouseButtonRadioButton";
            leftMouseButtonRadioButton.Size = new Size(76, 19);
            leftMouseButtonRadioButton.TabIndex = 0;
            leftMouseButtonRadioButton.TabStop = true;
            leftMouseButtonRadioButton.Text = "Left click";
            leftMouseButtonRadioButton.UseVisualStyleBackColor = true;
            //
            // rightMouseButtonRadioButton
            //
            rightMouseButtonRadioButton.AutoSize = true;
            rightMouseButtonRadioButton.Location = new Point(20, 58);
            rightMouseButtonRadioButton.Name = "rightMouseButtonRadioButton";
            rightMouseButtonRadioButton.Size = new Size(83, 19);
            rightMouseButtonRadioButton.TabIndex = 1;
            rightMouseButtonRadioButton.TabStop = true;
            rightMouseButtonRadioButton.Text = "Right click";
            rightMouseButtonRadioButton.UseVisualStyleBackColor = true;
            //
            // stopConditionGroupBox
            //
            stopConditionGroupBox.Controls.Add(stopAfterCountRadioButton);
            stopConditionGroupBox.Controls.Add(clickCountNumericUpDown);
            stopConditionGroupBox.Controls.Add(stopWithHotkeyRadioButton);
            stopConditionGroupBox.Dock = DockStyle.Fill;
            stopConditionGroupBox.Margin = new Padding(0);
            stopConditionGroupBox.Location = new Point(16, 218);
            stopConditionGroupBox.Name = "stopConditionGroupBox";
            stopConditionGroupBox.Size = new Size(220, 144);
            stopConditionGroupBox.TabIndex = 8;
            stopConditionGroupBox.TabStop = false;
            stopConditionGroupBox.Text = "Stop Condition";
            //
            // stopAfterCountRadioButton
            //
            stopAfterCountRadioButton.AutoSize = true;
            stopAfterCountRadioButton.Location = new Point(20, 28);
            stopAfterCountRadioButton.Name = "stopAfterCountRadioButton";
            stopAfterCountRadioButton.Size = new Size(118, 19);
            stopAfterCountRadioButton.TabIndex = 0;
            stopAfterCountRadioButton.Text = "Stop after clicks:";
            stopAfterCountRadioButton.UseVisualStyleBackColor = true;
            stopAfterCountRadioButton.CheckedChanged += stopAfterCountRadioButton_CheckedChanged;
            //
            // clickCountNumericUpDown
            //
            clickCountNumericUpDown.Location = new Point(20, 54);
            clickCountNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            clickCountNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            clickCountNumericUpDown.Name = "clickCountNumericUpDown";
            clickCountNumericUpDown.Size = new Size(120, 23);
            clickCountNumericUpDown.TabIndex = 1;
            clickCountNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            //
            // stopWithHotkeyRadioButton
            //
            stopWithHotkeyRadioButton.AutoSize = true;
            stopWithHotkeyRadioButton.Location = new Point(20, 94);
            stopWithHotkeyRadioButton.Name = "stopWithHotkeyRadioButton";
            stopWithHotkeyRadioButton.Size = new Size(108, 19);
            stopWithHotkeyRadioButton.TabIndex = 2;
            stopWithHotkeyRadioButton.Text = "Stop with hotkey";
            stopWithHotkeyRadioButton.UseVisualStyleBackColor = true;
            stopWithHotkeyRadioButton.CheckedChanged += stopWithHotkeyRadioButton_CheckedChanged;
            //
            // delayGroupBox
            //
            delayGroupBox.Controls.Add(fixedDelayRadioButton);
            delayGroupBox.Controls.Add(randomDelayRadioButton);
            delayGroupBox.Controls.Add(baseIntervalLabel);
            delayGroupBox.Controls.Add(baseIntervalNumericUpDown);
            delayGroupBox.Controls.Add(varianceLabel);
            delayGroupBox.Controls.Add(varianceNumericUpDown);
            delayGroupBox.Dock = DockStyle.Fill;
            delayGroupBox.Margin = new Padding(0);
            delayGroupBox.Location = new Point(252, 108);
            delayGroupBox.Name = "delayGroupBox";
            delayGroupBox.Size = new Size(412, 262);
            delayGroupBox.TabIndex = 3;
            delayGroupBox.TabStop = false;
            delayGroupBox.Text = "Delay Settings";
            //
            // hideToTrayButton
            //
            hideToTrayButton.Anchor = AnchorStyles.Right;
            hideToTrayButton.Margin = new Padding(0);
            hideToTrayButton.Location = new Point(550, 376);
            hideToTrayButton.Name = "hideToTrayButton";
            hideToTrayButton.Size = new Size(114, 30);
            hideToTrayButton.TabIndex = 9;
            hideToTrayButton.Text = "Hide to tray";
            hideToTrayButton.UseVisualStyleBackColor = true;
            hideToTrayButton.Click += hideToTrayButton_Click;
            // 
            // AutoClickerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 420);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;
            mainLayoutPanel.ColumnCount = 2;
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            mainLayoutPanel.Controls.Add(hotkeyGroupBox, 0, 0);
            mainLayoutPanel.SetColumnSpan(hotkeyGroupBox, 2);
            mainLayoutPanel.Controls.Add(mouseClickGroupBox, 0, 1);
            mainLayoutPanel.Controls.Add(stopConditionGroupBox, 0, 2);
            mainLayoutPanel.Controls.Add(delayGroupBox, 1, 1);
            mainLayoutPanel.SetRowSpan(delayGroupBox, 2);
            mainLayoutPanel.Controls.Add(hideToTrayButton, 0, 3);
            mainLayoutPanel.SetColumnSpan(hideToTrayButton, 2);
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Padding = new Padding(16);
            mainLayoutPanel.RowCount = 4;
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 102F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 144F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            mainLayoutPanel.Name = "mainLayoutPanel";
            Controls.Add(mainLayoutPanel);
            Name = "AutoClickerForm";
            Text = "Auto Mouse Clicker";
            mainLayoutPanel.ResumeLayout(false);
            delayGroupBox.ResumeLayout(false);
            delayGroupBox.PerformLayout();
            hotkeyGroupBox.ResumeLayout(false);
            hotkeyGroupBox.PerformLayout();
            mouseClickGroupBox.ResumeLayout(false);
            mouseClickGroupBox.PerformLayout();
            stopConditionGroupBox.ResumeLayout(false);
            stopConditionGroupBox.PerformLayout();
            ResumeLayout(false);
        }
        private RadioButton randomDelayRadioButton;
        private RadioButton fixedDelayRadioButton;
        private GroupBox delayGroupBox;
        private Label baseIntervalLabel;
        private Label varianceLabel;
        private NumericUpDown baseIntervalNumericUpDown;
        private NumericUpDown varianceNumericUpDown;
        private GroupBox hotkeyGroupBox;
        private Label startStopHotkeyLabel;
        private TextBox startStopHotkeyTextBox;
        private Label hotkeyStatusLabel;
        private GroupBox mouseClickGroupBox;
        private RadioButton leftMouseButtonRadioButton;
        private RadioButton rightMouseButtonRadioButton;
        private GroupBox stopConditionGroupBox;
        private RadioButton stopAfterCountRadioButton;
        private RadioButton stopWithHotkeyRadioButton;
        private NumericUpDown clickCountNumericUpDown;
        private Button hideToTrayButton;
    }
}
