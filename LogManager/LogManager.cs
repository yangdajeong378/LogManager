using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LogManager
{
    public class LogManager
    {
        public Queue<string> LogDataQueue { get; } = new Queue<string>();

        private LogForm logForm = new LogForm();

        //private bool formIsDispose = false;
        public LogManager()
        {
            Thread AutoSaveThread = new Thread(AutoSaveTimer);
            AutoSaveThread.Start();

            Thread AutoDeleteThread = new Thread(AutoDeleteTimer);
            AutoDeleteThread.Start();

            Thread LogFormThread = new Thread(LogFormTimer);
            LogFormThread.Start();
        }

        private void LogFormTimer()
        {
            while (true)
            {
                Thread.Sleep(500); //0.5초
                if (logForm.Disposing)
                    continue;

                if (logForm.IsDisposed)
                    continue;

                logForm.ChangeUI(LogDataQueue, null);
            }
        }

        private void AutoSaveTimer() //자동저장 타이머
        {
            while (true)
            {
                //Thread.Sleep(5000); //5초 Test 
                Thread.Sleep(1800000); //30분

                FileSave();
            }
        }

        private void AutoDeleteTimer() //자동삭제 타이머
        {
            while (true)
            {
                //Thread.Sleep(5000); //5초 Test 
                if (GetCurrentMinute() == "00")
                {
                    FileDelete();
                    Thread.Sleep(3500000); //59분 쉬기
                }
            }
        }

        public void AddLog(string log) //큐에 로그 넣기
        {
            LogDataQueue.Enqueue(log);
        }

        public void FileSave() //파일 저장
        {
            //현재 시간 날짜 폴더가 있는지 확인하고 없으면 새로 만듦.
            string folderPath = $"C:\\실행파일\\Log\\{GetCurrentYear()}\\{GetCurrentMonth()}";
            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (di.Exists == false)
            {
                di.Create();
            }


            //위 경로에 파일을 만듦. //이미 있는 파일이라면 덮어쓰기
            StreamWriter writer;
            string strFilePath = di.ToString();
            writer = File.CreateText($"{strFilePath}\\{GetCurrentDateTime()}Log.txt");
            foreach (string log in LogDataQueue)
            {
                writer.WriteLine(log);
            }
            writer.Close();
        }

        private string GetCurrentDateTime() //현재 날짜와 시간 세밀히 반환
        {
            return DateTime.Now.ToString("yyyyMMddHHmm");
        }

        private string GetCurrentYear() //현재 연도 반환
        {
            return DateTime.Now.ToString("yyyy");
        }

        private string GetCurrentMonth() //현재 월 반환
        {
            return DateTime.Now.ToString("MMMM");
        }

        private string GetCurrentMinute()
        {
            return DateTime.Now.ToString("mm");
        }


        public void FileDelete() //파일 지우기 (6개월 단위)
        {
            DeleteOldFilesTest($"C:\\실행파일\\Log", 6);
        }

        private void DeleteOldFilesTest(string deletePath, int month) //오래된 파일 삭제
        {
            try
            {
                DirectoryInfo logDir = new DirectoryInfo(deletePath);

                if (logDir.Exists)
                {
                    DirectoryInfo[] yearDirs = logDir.GetDirectories();

                    string data = DateTime.Today.AddMonths(-month).ToString("yyyyMMdd");

                    foreach (DirectoryInfo yearDir in yearDirs) //각 연도 돌기
                    {
                        foreach (DirectoryInfo monthDir in yearDir.GetDirectories()) //각 월들 돌기
                        {
                            if (data.CompareTo(monthDir.CreationTime.ToString("yyyyMMdd")) > 0)
                            {
                                //dir.Attributes = FileAttributes.Normal; //읽기 쓰기 파일같은 특별전용은 필요함
                                monthDir.Delete(true);

                                if (yearDir.GetDirectories().Length == 0) //월 파일이 지워진 후 연도 파일 안에 월 파일이 하나도 없으면 연도 파일 자체를 지운다.
                                {
                                    yearDir.Delete();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        public void LogFormShow()
        {
            logForm.Dispose();

            logForm = new LogForm();
            
            logForm.Show();
        }
    }
}
