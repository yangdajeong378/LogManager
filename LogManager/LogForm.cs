using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LogManager
{
    public partial class LogForm : Form
    {
        private bool stopChangeUI = false;
        private int startQueueCount = 0;
        private int clearPointUnit = 30;
        private bool start = false;

        public LogForm()
        {
            InitializeComponent();
        }

        public void ChangeUI(Queue<string> logQueue, StringBuilder sb)
        {
            if (stopChangeUI)
                return;

            try //이미 클로즈되거나 디스포즈 된 로그폼 빠져나가게 하기
            {
                if (sb == null)
                {
                    sb = new StringBuilder();

                    if (logQueue.Count > startQueueCount + clearPointUnit)
                    {
                        startQueueCount = startQueueCount + clearPointUnit;
                    }
                    string[] logArray = logQueue.ToArray();
                    for (int i = startQueueCount; i < logQueue.Count; i++)
                    {
                        sb.AppendLine(logArray[i]);
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
                    LogTextBox.Select(LogTextBox.Text.Length, 0); //현재 텍스트 전부 선택
                    LogTextBox.ScrollToCaret(); //스크롤를 텍스트 커서까지 내림
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            stopChangeUI = false;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            stopChangeUI = true;
        }
    }
}
