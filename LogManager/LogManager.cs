﻿using System;
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
        private DirectoryInfo logSaveDi;
        private DateTime currentForderPath;
        private int minuite = 30;


        public LogManager()
        {
            //Thread AutoSaveThread = new Thread(AutoCreateFileTimer); //로그 파일 자동 저장
            //AutoSaveThread.IsBackground = true;
            //AutoSaveThread.Start();

            Thread AutoDeleteThread = new Thread(AutoDeleteTimer); //오래된 폴더, 파일 자동 삭제
            AutoDeleteThread.IsBackground = true;
            AutoDeleteThread.Start();

            Thread LogFormThread = new Thread(LogFormTimer); //로그폼 UI 자동 갱신
            LogFormThread.IsBackground = true;
            LogFormThread.Start();

            Thread TestLogAddThread = new Thread(TestAddLogTimer); //테스트 로그 추가 
            TestLogAddThread.IsBackground = true;
            TestLogAddThread.Start();

            //Thread AutoWriteThread = new Thread(AutoWriteTimer); //로그 파일 자동 쓰기
            //AutoWriteThread.IsBackground = true;
            //AutoWriteThread.Start();
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

        //private void AutoCreateFileTimer() //자동저장 타이머
        //{
        //    while (true)
        //    {
        //        if (TestStart == false)
        //            continue;


        //        string dateTime = DateTime.Today.AddMinutes(-minuite).ToString("yyyyMMdd");
        //        if (dateTime.CompareTo(saveDataTime.ToString("yyyyMMdd")) > 0)
        //        {
        //            saveDataTime = DateTime.Now;
        //            CreateFile();
        //        }

        //        Thread.Sleep(100); //0.1초
        //    }
        //}

        private void AutoWriteTimer()
        {
            while (true)
            {
                if (TestStart == false)
                    continue;

                WriteOrCreateFile();

                Thread.Sleep(100);
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
            CreateForder();
            WriteOrCreateFile();
        }

        public void AddLog() //test
        {
            LogDataQueue.Enqueue($"{GetCurrentDateTime()}, {queueCountName}.log");
            queueCountName++;

            SetCurrentForderPath();
            CreateForder();
            WriteOrCreateFile();
        }

        private void SetCurrentForderPath()
        {
            string currentMinute = DateTime.Now.ToString("mm");
            currentForderPath = DateTime.Now;

            if (Int32.Parse(currentMinute) > 29) //29분이 넘어간다면 30분으로 수정 // 뜻 : 30분부터 시작됐다.
            {
                currentForderPath = Convert.ToDateTime($"{currentForderPath.Hour}시 30분");
            }

            else//30분이 안넘어간다면 0분으로 수정
            {
                currentForderPath = Convert.ToDateTime($"{currentForderPath.Hour}시 0분");
            }
        }

        private void CreateForder() //폴더 만들기
        {
            //String path = Application.StartupPath;
            //현재 시간 날짜 폴더가 있는지 확인하고 없으면 새로 만듦.
            string folderPath = $"{Application.StartupPath}\\Log\\{currentForderPath.Year}년\\{currentForderPath.Month}월";
            logSaveDi = new DirectoryInfo(folderPath);
            if (logSaveDi.Exists == false)
            {
                logSaveDi.Create();
            }
        }


        private void WriteOrCreateFile()
        {
            //위 경로에 파일을 만듦. //이미 있는 파일이라면 덮어쓰기
            if (logSaveDi == null)
                return;

            if (currentForderPath == null)
                return;

            try
            {
                StreamWriter writer;
                string strFilePath = logSaveDi.ToString();
                writer = File.CreateText($"{strFilePath}\\{currentForderPath.ToString("yyyy MM dd HH mm")} Log.txt");

                Queue<string> flashQueue = LogDataQueue;
                string[] flashArray = flashQueue.ToArray();
                for (int i = 0; i < LogDataQueue.Count; i++)
                {
                    writer.WriteLine(flashArray[i]);
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
            return DateTime.Now.ToString("yyyy MM dd HH mm");
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

                for (int i = 0; i < 5; i++)
                {
                    AddLog();
                }
            }
        }
    }
}
