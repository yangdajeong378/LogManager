using LogManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LogManager
{
    public class LogManager
    {
        private Queue<string> LogDataQueue = new Queue<string>();

        private int queueCountName = 0;
        private LogForm logForm = new LogForm();
        public bool TestStart { get; set; } //test용
        private DirectoryInfo currentForderPath;
        private DateTime currentFileNameData; 
        private int minuite = 30;


        public LogManager()
        {
            Thread AutoDeleteThread = new Thread(AutoDeleteTimer); //오래된 폴더, 파일 자동 삭제
            AutoDeleteThread.IsBackground = true;
            AutoDeleteThread.Start();

            Thread LogFormThread = new Thread(LogFormTimer); //로그폼 UI 자동 갱신
            LogFormThread.IsBackground = true;
            LogFormThread.Start();

            Thread TestLogAddThread = new Thread(TestAddLogTimer); //테스트 로그 추가 
            TestLogAddThread.IsBackground = true;
            TestLogAddThread.Start();
        }

        private void LogFormTimer()
        {
            while (true)
            {
                if (logForm.Disposing)
                    continue;

                if (logForm.IsDisposed)
                    continue;

                logForm.ChangeUI(LogDataQueue, null);

                Thread.Sleep(500); //0.5초
            }
        }


        private void AutoDeleteTimer() //자동삭제 타이머
        {
            while (true)
            {
                Thread.Sleep(1000);
                //Thread.Sleep(5000); //5초 Test 
                if (GetCurrentMinute() == "00")
                {
                    FileDelete();
                }
            }
        }
        public void AddLog(string log) //큐에 로그 넣기
        {
            LogDataQueue.Enqueue($"{GetCurrentDateTime()}, {log}");

            SetCurrentForderPath();
            TryCreateForder();
            WriteFile(log);
        }

        private int testNum = 0;
        public void TestAddLog(int count) //test
        {
            SetCurrentForderPath();
            TryCreateForder();

            for (int i = testNum; i < testNum + count; i++)
            {
                WriteFile($"Log{i}");
                LogDataQueue.Enqueue($"{GetCurrentDateTime()}, {queueCountName}.log");
                queueCountName++;
            }
            testNum = testNum + count;

        }


        private void SetCurrentForderPath()
        {
            string currentMinute = DateTime.Now.ToString("mm");
            currentFileNameData = DateTime.Now;

            if (Int32.Parse(currentMinute) > 29) //29분이 넘어간다면 30분으로 수정 // 뜻 : 30분부터 시작됐다.
            {
                currentFileNameData = Convert.ToDateTime($"{currentFileNameData.Hour}시 30분");
            }

            else//29분이 안넘어간다면 0분으로 수정
            {
                currentFileNameData = Convert.ToDateTime($"{currentFileNameData.Hour}시 0분");
            }
        }

        private void TryCreateForder() //폴더 만들기
        {
            //String path = Application.StartupPath;
            //현재 시간 날짜 폴더가 있는지 확인하고 없으면 새로 만듦.
            string folderPath = $"{Application.StartupPath}\\Log\\{currentFileNameData.Year}년\\{currentFileNameData.Month}월";
            currentForderPath = new DirectoryInfo(folderPath);
            if (currentForderPath.Exists == false)
            {
                currentForderPath.Create();
            }
        }

        private void WriteFile(string log)
        {
            //위 경로에 파일을 만듦. //이미 있는 파일이라면 덮어쓰기
            //if (logSaveDi == null)
            //    return;

            if (currentFileNameData == null)
                return;

            if (currentForderPath == null)
                return;

            try
            {
                StreamWriter writer;
                string currentFilePath = $"{currentForderPath.ToString()}\\{currentFileNameData.ToString("yyyy_MM_dd_HH_mm")}_Log.txt";


                if (File.Exists(currentFilePath)) //파일 존재
                {
                    writer = File.AppendText(currentFilePath);
                    writer.WriteLine($"{GetCurrentDateTime()} : {log}");
                }
                else //파일 미존재 파일 열기
                {
                    writer = File.CreateText(currentFilePath);
                    writer.WriteLine($"{GetCurrentDateTime()} : {log}");
                }

                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private string GetCurrentDateTime() //현재 날짜와 시간 세밀히 반환
        {
            return DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
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
            DeleteOldFilesTest($"{Application.StartupPath}\\Log", 6);
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
                        //yearDir.Attributes = FileAttributes.Normal;
                        foreach (DirectoryInfo monthDir in yearDir.GetDirectories()) //각 월들 돌기
                        {
                            //monthDir.Attributes = FileAttributes.Normal;
                            foreach (FileInfo log in monthDir.GetFiles()) //각 로그들 돌기
                            {
                                if (data.CompareTo(log.CreationTime.ToString("yyyyMMdd")) > 0)
                                {
                                    //dir.Attributes = FileAttributes.Normal; //읽기 쓰기 파일같은 특별전용은 필요함
                                    log.Delete();
                                }
                            }
                            if (monthDir.GetFiles().Length == 0) //로그 파일이 지워진 후 월 파일 안에 로그 파일이 하나도 없으면 월 파일 자체를 지운다.
                            {
                                monthDir.Delete(true);
                            }
                        }
                        if (yearDir.GetDirectories().Length == 0) //월 파일이 지워진 후 연도 파일 안에 월 파일이 하나도 없으면 연도 파일 자체를 지운다.
                        {
                            yearDir.Delete(true);
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
            logForm.Dispose(); //메모리 상에서 전부 해제

            logForm = new LogForm();

            logForm.Show();
        }

        private void TestAddLogTimer()
        {
            while (true)
            {
                Thread.Sleep(1000); //1초

                if (TestStart == false)
                    continue;


                TestAddLog(5);

            }
        }
    }
}

