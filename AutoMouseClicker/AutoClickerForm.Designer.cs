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
            // 
            // delayGroupBox
            // 
            delayGroupBox.Controls.Add(fixedDelayRadioButton);
            delayGroupBox.Controls.Add(randomDelayRadioButton);
            delayGroupBox.Location = new Point(223, 181);
            delayGroupBox.Name = "delayGroupBox";
            delayGroupBox.Size = new Size(385, 197);
            delayGroupBox.TabIndex = 3;
            delayGroupBox.TabStop = false;
            delayGroupBox.Text = "box";
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
    }
}
