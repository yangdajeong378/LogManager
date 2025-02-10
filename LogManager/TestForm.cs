using System;
using System.Windows.Forms;

namespace LogManager
{
    public partial class TestForm : Form
    {
        public LogManager logManager { get; } = new LogManager();

        public TestForm()
        {
            InitializeComponent();
        }

        private void LogAdd_Click(object sender, EventArgs e)
        {
            logManager.AddLog();
        }

        private void FileDeletBtn_Click(object sender, EventArgs e)
        {
            logManager.FileDelete();
        }

        private void LogformBtn_Click(object sender, EventArgs e)
        {
            logManager.LogFormShow();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            logManager.TestStart = true;
        }
    }
}
