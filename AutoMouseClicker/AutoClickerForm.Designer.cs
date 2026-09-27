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
            delayGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // randomDelayRadioButton
            // 
            randomDelayRadioButton.AutoSize = true;
            randomDelayRadioButton.Location = new Point(28, 22);
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
            fixedDelayRadioButton.Location = new Point(58, 66);
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
            baseIntervalLabel.Location = new Point(28, 110);
            baseIntervalLabel.Name = "baseIntervalLabel";
            baseIntervalLabel.Size = new Size(110, 15);
            baseIntervalLabel.TabIndex = 2;
            baseIntervalLabel.Text = "Base Interval (ms):";
            // 
            // baseIntervalNumericUpDown
            // 
            baseIntervalNumericUpDown.Location = new Point(28, 130);
            baseIntervalNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            baseIntervalNumericUpDown.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            baseIntervalNumericUpDown.Name = "baseIntervalNumericUpDown";
            baseIntervalNumericUpDown.Size = new Size(120, 23);
            baseIntervalNumericUpDown.TabIndex = 3;
            baseIntervalNumericUpDown.Value = new decimal(new int[] { 250, 0, 0, 0 });
            // 
            // varianceLabel
            // 
            varianceLabel.AutoSize = true;
            varianceLabel.Location = new Point(200, 110);
            varianceLabel.Name = "varianceLabel";
            varianceLabel.Size = new Size(96, 15);
            varianceLabel.TabIndex = 4;
            varianceLabel.Text = "Variance (ms):";
            // 
            // varianceNumericUpDown
            // 
            varianceNumericUpDown.Location = new Point(200, 130);
            varianceNumericUpDown.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            varianceNumericUpDown.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            varianceNumericUpDown.Name = "varianceNumericUpDown";
            varianceNumericUpDown.Size = new Size(120, 23);
            varianceNumericUpDown.TabIndex = 5;
            varianceNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // delayGroupBox
            // 
            delayGroupBox.Controls.Add(fixedDelayRadioButton);
            delayGroupBox.Controls.Add(randomDelayRadioButton);
            delayGroupBox.Controls.Add(baseIntervalLabel);
            delayGroupBox.Controls.Add(baseIntervalNumericUpDown);
            delayGroupBox.Controls.Add(varianceLabel);
            delayGroupBox.Controls.Add(varianceNumericUpDown);
            delayGroupBox.Location = new Point(223, 181);
            delayGroupBox.Name = "delayGroupBox";
            delayGroupBox.Size = new Size(385, 197);
            delayGroupBox.TabIndex = 3;
            delayGroupBox.TabStop = false;
            delayGroupBox.Text = "Delay Settings";
            // 
            // AutoClickerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(delayGroupBox);
            Name = "AutoClickerForm";
            Text = "Auto Mouse Clicker";
            Load += AutoClickerForm_Load;
            delayGroupBox.ResumeLayout(false);
            delayGroupBox.PerformLayout();
            ResumeLayout(false);
        }
        private RadioButton randomDelayRadioButton;
        private RadioButton fixedDelayRadioButton;
        private GroupBox delayGroupBox;
        private Label baseIntervalLabel;
        private Label varianceLabel;
        private NumericUpDown baseIntervalNumericUpDown;
        private NumericUpDown varianceNumericUpDown;
    }
}
