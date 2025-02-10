namespace LogManager
{
    partial class TestForm
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
            this.LogAdd = new System.Windows.Forms.Button();
            this.FileDeletBtn = new System.Windows.Forms.Button();
            this.LogformBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogAdd
            // 
            this.LogAdd.Location = new System.Drawing.Point(392, 197);
            this.LogAdd.Name = "LogAdd";
            this.LogAdd.Size = new System.Drawing.Size(309, 94);
            this.LogAdd.TabIndex = 0;
            this.LogAdd.Text = "LogAdd";
            this.LogAdd.UseVisualStyleBackColor = true;
            this.LogAdd.Click += new System.EventHandler(this.LogAdd_Click);
            // 
            // FileDeletBtn
            // 
            this.FileDeletBtn.Location = new System.Drawing.Point(220, 324);
            this.FileDeletBtn.Name = "FileDeletBtn";
            this.FileDeletBtn.Size = new System.Drawing.Size(309, 94);
            this.FileDeletBtn.TabIndex = 2;
            this.FileDeletBtn.Text = "FileDelete";
            this.FileDeletBtn.UseVisualStyleBackColor = true;
            this.FileDeletBtn.Click += new System.EventHandler(this.FileDeletBtn_Click);
            // 
            // LogformBtn
            // 
            this.LogformBtn.Location = new System.Drawing.Point(59, 26);
            this.LogformBtn.Name = "LogformBtn";
            this.LogformBtn.Size = new System.Drawing.Size(209, 68);
            this.LogformBtn.TabIndex = 3;
            this.LogformBtn.Text = "Logform";
            this.LogformBtn.UseVisualStyleBackColor = true;
            this.LogformBtn.Click += new System.EventHandler(this.LogformBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("굴림", 9F);
            this.StartBtn.Location = new System.Drawing.Point(59, 197);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(309, 94);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "1초당 log5개 추가";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.LogformBtn);
            this.Controls.Add(this.FileDeletBtn);
            this.Controls.Add(this.LogAdd);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogAdd;
        private System.Windows.Forms.Button FileDeletBtn;
        private System.Windows.Forms.Button LogformBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
    }
}