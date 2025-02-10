namespace LogManager
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.LogFormLabel = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Location = new System.Drawing.Point(145, 71);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(354, 71);
            this.ContinueBtn.TabIndex = 1;
            this.ContinueBtn.Text = "Continue";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(550, 71);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(354, 71);
            this.StopBtn.TabIndex = 2;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogTextBox.Location = new System.Drawing.Point(76, 217);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(916, 385);
            this.LogTextBox.TabIndex = 3;
            // 
            // LogFormLabel
            // 
            this.LogFormLabel.AutoSize = true;
            this.LogFormLabel.Location = new System.Drawing.Point(71, 171);
            this.LogFormLabel.Name = "LogFormLabel";
            this.LogFormLabel.Size = new System.Drawing.Size(118, 30);
            this.LogFormLabel.TabIndex = 4;
            this.LogFormLabel.Text = "LogBox";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(515, 171);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(477, 30);
            this.warningLabel.TabIndex = 5;
            this.warningLabel.Text = "30줄이 넘어가면 자동 삭제됩니다.";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 671);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.LogFormLabel);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.ContinueBtn);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Label LogFormLabel;
        private System.Windows.Forms.Label warningLabel;
    }
}