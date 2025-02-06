using System;
using System.Windows.Forms;

namespace LogManager
{
    public partial class TestForm : Form
    {
        public LogManager logManager { get; } = new LogManager();
        private int count = 0;
        public TestForm()
        {
            InitializeComponent();
        }

        private void LogAdd_Click(object sender, EventArgs e)
        {
            logManager.AddLog($"Log {count++}");
        }

        private void FileSaveBtn_Click(object sender, EventArgs e)
        {
            logManager.FileSave();
        }

        private void FileDeletBtn_Click(object sender, EventArgs e)
        {
            logManager.FileDelete();
        }

        private void LogformBtn_Click(object sender, EventArgs e)
        {
            logManager.LogFormShow();
        }
    }
}
