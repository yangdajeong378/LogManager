using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogManager
{
    public partial class LogForm : Form
    {
        private bool stopChangeUI = false;
        private int clearPointUnit = 30;
        private bool start = false;

        public LogForm()
        {
            InitializeComponent();
        }

        public void ChangeUI(Queue<string> queue, StringBuilder sb)
        {
            if (stopChangeUI)
                return;

            try //이미 클로즈되거나 디스포즈 된 로그폼 빠져나가게 하기
            {
                if (sb == null) //UI 스레드일때는 건너뛰기
                {
                    if (queue.Count > clearPointUnit) //큐가 30을 넘을 경우
                    {
                        for (int i = 0; i < clearPointUnit; i++) //큐에서 30만큼 디큐해준다.
                        {
                            queue.Dequeue();
                        }
                    }

                    sb = new StringBuilder();
                    foreach (string log in queue.ToArray())
                    {
                        sb.AppendLine(log); 
                    }
                }

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        ChangeUI(queue, sb);
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
