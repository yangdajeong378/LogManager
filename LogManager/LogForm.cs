using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LogManager
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void ChangeUI(Queue<string> logQueue, StringBuilder sb)
        {
            try
            {
                if (sb == null)
                {
                    sb = new StringBuilder();
                    foreach (string item in logQueue)
                    {
                        sb.AppendLine(item);
                    }
                }

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        ChangeUI(logQueue, sb);
                    }));
                }
                else
                {
                    LogTextBox.Text = sb.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
