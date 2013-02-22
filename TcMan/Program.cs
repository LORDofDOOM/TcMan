using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using LogThis;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;

namespace TcMan
{
    static class Program
    {
        /* Single Instance Check */
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        private const int SW_HIDE = 0;           //隐藏窗口，活动状态给另一个窗口 
        private const int SW_SHOWNORMAL = 1;     //用原来的大小和位置显示一个窗口，同时令其进入活动状态 
        private const int SW_SHOWMINIMIZED = 2;  //最小化窗口，并将其激活 
        private const int SW_SHOWMAXIMIZED = 3;  //最大化窗口，并将其激活 
        private const int SW_SHOWNOACTIVATE = 4; //用最近的大小和位置显示一个窗口，同时不改变活动窗口 
        private const int SW_RESTORE = 9;        //用原来的大小和位置显示一个窗口，同时令其进入活动状态 
        private const int SW_SHOWDEFAULT = 10;   //根据默认创建窗口时的样式来显示

        /* Configuration File relevant */
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,StringBuilder retVal,int size,string filePath);
        private static Object conflock = new Object();
        private const string conFile = "tcMan.conf";
        private static string apacheBin = System.Environment.CurrentDirectory + "\\apache\\bin\\httpd.exe";
        private static string mysqlBin = System.Environment.CurrentDirectory + "\\mysql\\bin\\mysqld.exe";
        private static string authBin = System.Environment.CurrentDirectory + "\\authserver.exe";
        private static string worldBin = System.Environment.CurrentDirectory + "\\worldserver.exe";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetCompatibleTextRenderingDefault(true);
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "MyApplicationName", out createdNew))
            {
                if (createdNew)
                {
                    Log.UseSensibleDefaults();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    if (MessageBox.Show("TcMan is already running, switch to？or Cancel to quit.", "Found Running TcMan", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process current = Process.GetCurrentProcess();
                        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        {
                            if (process.Id != current.Id)
                            {
                                SetForegroundWindow(process.MainWindowHandle);
                                ShowWindowAsync(process.MainWindowHandle, SW_RESTORE);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
