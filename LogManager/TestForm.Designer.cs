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
            this.FileSaveBtn = new System.Windows.Forms.Button();
            this.FileDeletBtn = new System.Windows.Forms.Button();
            this.LogformBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogAdd
            // 
            this.LogAdd.Location = new System.Drawing.Point(208, 117);
            this.LogAdd.Name = "LogAdd";
            this.LogAdd.Size = new System.Drawing.Size(309, 94);
            this.LogAdd.TabIndex = 0;
            this.LogAdd.Text = "LogAdd";
            this.LogAdd.UseVisualStyleBackColor = true;
            this.LogAdd.Click += new System.EventHandler(this.LogAdd_Click);
            // 
            // FileSaveBtn
            // 
            this.FileSaveBtn.Location = new System.Drawing.Point(46, 255);
            this.FileSaveBtn.Name = "FileSaveBtn";
            this.FileSaveBtn.Size = new System.Drawing.Size(309, 94);
            this.FileSaveBtn.TabIndex = 1;
            this.FileSaveBtn.Text = "FileSave";
            this.FileSaveBtn.UseVisualStyleBackColor = true;
            this.FileSaveBtn.Click += new System.EventHandler(this.FileSaveBtn_Click);
            // 
            // FileDeletBtn
            // 
            this.FileDeletBtn.Location = new System.Drawing.Point(379, 255);
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
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 455);
            this.Controls.Add(this.LogformBtn);
            this.Controls.Add(this.FileDeletBtn);
            this.Controls.Add(this.FileSaveBtn);
            this.Controls.Add(this.LogAdd);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogAdd;
        private System.Windows.Forms.Button FileSaveBtn;
        private System.Windows.Forms.Button FileDeletBtn;
        private System.Windows.Forms.Button LogformBtn;
    }
}