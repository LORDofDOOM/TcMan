using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogThis;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace TcMan
{
    class ServerMonitor
    {
        /* Read Configuration */
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(string section, string key, int def, string filePath);

        private static Object conflock = new Object();
        private const string conFile = "tcMan.conf";

        private static string apacheBin = System.Environment.CurrentDirectory + "\\apache\\bin\\httpd.exe";
        private static string mysqlBin = System.Environment.CurrentDirectory + "\\mysql\\bin\\mysqld.exe";
        private static string authBin = System.Environment.CurrentDirectory + "\\authserver.exe";
        private static string worldBin = System.Environment.CurrentDirectory + "\\worldserver.exe";
        private static int MON_APACHE = 1;
        private static int MON_MYSQL = 2;
        private static int MON_AUTH = 4;
        private static int MON_WORLD = 8;
        private static int procSelMon = (MON_APACHE | MON_MYSQL | MON_AUTH | MON_WORLD);
        private static bool autoRestart = true;

        /* Process Handle & Monitoring */
        private Process apacheProc;
        private Process mysqlProc;
        private Process authProc;
        private Process worldProc;
        private int apacheStatus;
        private int mysqlStatus;
        private int authStatus;
        private int worldStatus;
        private string apacheName;
        private string mysqlName;
        private string authName;
        private string worldName;

        /* UI */
        private Form1 handle;
        private static Object stdLock = new Object();

        /* Singleton */
        private static ServerMonitor _instance;

        public static ServerMonitor getInstance()
        {
            if (_instance == null)
                _instance = new ServerMonitor();
            return _instance;
        }
        public static void setForm(Form1 ct)
        {
            ServerMonitor.getInstance().handle = ct;
        }

        private ServerMonitor()
        {
            initialization();
        }

        private void writeConf()
        {
            //WritePrivateProfileString(Section, Key, Value, conFile);
            lock (conflock)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(conFile, FileMode.OpenOrCreate & FileMode.Truncate);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("##########################################");
                    sw.WriteLine("#                                        #");
                    sw.WriteLine("#        TcMan Configuration File        #");
                    sw.WriteLine("#                                        #");
                    sw.WriteLine("##########################################");
                    sw.WriteLine("");
                    sw.WriteLine("# All Binaries are set here, USE Absolute Path with single \\");
                    sw.WriteLine("[Binaries]");
                    sw.WriteLine("apache = \"" + apacheBin + "\"");
                    sw.WriteLine("mysql = \"" + mysqlBin + "\"");
                    sw.WriteLine("auth = \"" + authBin + "\"");
                    sw.WriteLine("world = \"" + worldBin + "\"");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("# Monitoring Setting");
                    sw.WriteLine("[Monitoring]");
                    sw.WriteLine("");
                    sw.WriteLine("# Apache: 1, MySQL = 2, Auth = 4, World = 8");
                    sw.WriteLine("# Default value = 15 which means 15 = 1 + 2 + 4 + 8 = Apache & MySQL & Auth & World");
                    sw.WriteLine("ProcessMonitoring = " + procSelMon);
                    sw.WriteLine("");
                    sw.WriteLine("# Auto restart servers on crash? using True & False");
                    sw.WriteLine("AutoRestart = " + autoRestart.ToString());
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("# End of Configuration File");
                    sw.Flush();
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Catched Exception: " + e.Message);
                    handle.appendError("Exception when writing config: " + e.Message + Environment.NewLine);
                    Log.LogThis("Exception when writing config: " + e.Message, eloglevel.error);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                    if (fs != null)
                        fs.Close();
                }
            }
        }

        private void readConf()
        {
            string conFilePath = ".\\" + conFile;
            StringBuilder temp = new StringBuilder(512);

            GetPrivateProfileString("Binaries", "apache", "null", temp, 1024, conFilePath);
            apacheBin = (temp.ToString().ToLower() == "null") ? apacheBin : temp.ToString().ToLower();
            apacheName = apacheBin.Substring(apacheBin.LastIndexOf('\\') + 1, (apacheBin.LastIndexOf('.') < 0 ? apacheBin.Length : apacheBin.LastIndexOf('.') - apacheBin.LastIndexOf('\\') - 1));
            
            GetPrivateProfileString("Binaries", "mysql", "null", temp, 1024, conFilePath);
            mysqlBin = (temp.ToString().ToLower() == "null") ? mysqlBin : temp.ToString().ToLower();
            mysqlName = mysqlBin.Substring(mysqlBin.LastIndexOf('\\') + 1, (mysqlBin.LastIndexOf('.') < 0 ? mysqlBin.Length : mysqlBin.LastIndexOf('.') - mysqlBin.LastIndexOf('\\') - 1));
            
            GetPrivateProfileString("Binaries", "auth", "null", temp, 1024, conFilePath);
            authBin = (temp.ToString().ToLower() == "null") ? authBin : temp.ToString().ToLower();
            authName = authBin.Substring(authBin.LastIndexOf('\\') + 1, (authBin.LastIndexOf('.') < 0 ? authBin.Length : authBin.LastIndexOf('.') - authBin.LastIndexOf('\\') - 1));
            
            GetPrivateProfileString("Binaries", "world", "null", temp, 1024, conFilePath);
            worldBin = (temp.ToString().ToLower() == "null") ? worldBin : temp.ToString().ToLower();
            worldName = worldBin.Substring(worldBin.LastIndexOf('\\') + 1, (worldBin.LastIndexOf('.') < 0 ? worldBin.Length : worldBin.LastIndexOf('.') - worldBin.LastIndexOf('\\') - 1));
            
            int tmp = GetPrivateProfileInt("Monitoring", "ProcessMonitoring", -1, conFilePath);
            if ((tmp > 0) && (tmp < 16))
                procSelMon = tmp;

            GetPrivateProfileString("Monitoring", "AutoRestart", "null", temp, 1024, conFilePath);
            autoRestart = (temp.ToString().ToLower() == "true") ? true : ((temp.ToString().ToLower() == "false") ? false : autoRestart);
        }

        private void initialization()
        {
            /* Read Configuration File */
            if (!File.Exists(conFile))
                File.Create(conFile);
            else
                readConf();
            writeConf();

            /* Launch Monitor Thread */
            Thread monThread = new Thread(new ThreadStart(monitor));
            monThread.IsBackground = true;
            monThread.Name = "Monitor Thread";
            try
            {
                monThread.Start();
            }
            catch (ThreadStateException te)
            {
                handle.appendError("Exception when creating monitor thread: " + te.Message + Environment.NewLine);
                //Console.WriteLine(te.ToString());
            }
            Thread.Sleep(10);
        }

        private void monitor()
        {
            while (handle == null)
                Thread.Sleep(1000);
            while (true)
            {
                // Stopped = 0, Running = 1, Replaced = 2;
                apacheStatus = 0;
                mysqlStatus = 0;
                authStatus = 0;
                worldStatus = 0;
                //Console.WriteLine("Server Monitor is running on own thread - [" + Thread.CurrentThread.Name + "]");

                /* Check all proc status: RUNNING, STOPPED & REPLACED */
                foreach (Process pp in Process.GetProcesses())
                {
                    //Console.WriteLine(pp.ProcessName + " ?= " + apacheName + "/" + mysqlName);
                    if ((apacheStatus != 1) && (pp.ProcessName == apacheName))
                        apacheStatus = ((apacheProc != null) && (!apacheProc.HasExited) && (pp.Id == apacheProc.Id)) ? 1 : 2;
                    if ((mysqlStatus != 1) && (pp.ProcessName == mysqlName))
                        mysqlStatus = ((mysqlProc != null) && (!mysqlProc.HasExited) && (pp.Id == mysqlProc.Id)) ? 1 : 2;
                    if ((authStatus != 1) && (pp.ProcessName == authName))
                        authStatus = ((authProc != null) && (!authProc.HasExited) && (pp.Id == authProc.Id)) ? 1 : 2;
                    if ((worldStatus != 1) && (pp.ProcessName == worldName))
                        worldStatus = ((worldProc != null) && (!worldProc.HasExited) && (pp.Id == worldProc.Id)) ? 1 : 2;
                }

                /* Output Procs Status */
                handle.updateStatus(apacheStatus, mysqlStatus, authStatus, worldStatus);

                /* Handle AutoRestart */
                if (apacheStatus == 0)
                    runProcess(apacheProc, apacheBin);
                if (mysqlStatus == 0)
                    runProcess(mysqlProc, mysqlBin);
                if (authStatus == 0)
                    runProcess(authProc, authBin);
                if (worldStatus == 0)
                    runProcess(worldProc, worldBin);

                Thread.Sleep(5000);
            }
        }

        public void runAll()
        {
            if ((procSelMon & 1) == 1)
                runProcess(apacheProc, apacheBin);
            if ((procSelMon & 2) == 2)
                runProcess(mysqlProc, mysqlBin);
            if ((procSelMon & 4) == 4)
                runProcess(authProc, authBin);
            if ((procSelMon & 8) == 8)
                runProcess(worldProc, worldBin);

        }

        private void runProcess(Process proc, string binStr)
        {
            if ((proc != null) && (!proc.HasExited))
            {
                // Console.WriteLine("Process: " + proc.ProcessName + " is already running");
                handle.appendCritical("Starting process " + proc.ProcessName + " error: Process already running!" + Environment.NewLine);
                Log.LogThis("Starting process " + proc.ProcessName + " error: Process already running!", eloglevel.error);
                return;
            }
            if (proc != null)
                proc.Close();

            proc = new Process();
            proc.StartInfo.FileName = binStr;
            proc.StartInfo.WorkingDirectory = binStr.Substring(0, binStr.Length - (binStr.Length - binStr.LastIndexOf('\\')));
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.RedirectStandardError = true;
            proc.OutputDataReceived += (o, e) => 
            {
                lock (stdLock)
                {
                    if (e.Data != null)
                    {
                        string eee = ((Process)o).ProcessName.ToLower();

                        if (eee == authName)
                            handle.appendError("Auth Server - " + e.Data + Environment.NewLine);
                        else if (eee == worldName)
                            handle.appendError("World Server - " + e.Data + Environment.NewLine);
                        else if (eee == apacheName)
                            handle.appendError("Apache Server - " + e.Data + Environment.NewLine);
                        else if (eee == mysqlName)
                            handle.appendError("MySQL Server - " + e.Data + Environment.NewLine);
                    }
                }
            };
            //proc.ErrorDataReceived += proc_DataReceived;
            //proc.Exited += proc_HasExited;
            //proc.EnableRaisingEvents = true;
            try
            {
                proc.Start();
                proc.BeginOutputReadLine();
                //proc.BeginErrorReadLine();
            }
            catch (System.InvalidOperationException err)
            {
                handle.appendCritical("Starting process " + proc.StartInfo.FileName + " error: " + err.Message + Environment.NewLine);
                Log.LogThis("Starting process " + proc.StartInfo.FileName + " error: " + err.Message, eloglevel.error);
                proc.Close();
                return;
            }
            catch (System.ComponentModel.Win32Exception err)
            {
                handle.appendError("Starting process " + proc.StartInfo.FileName + " error: " + err.Message + Environment.NewLine);
                Log.LogThis("Starting process " + proc.StartInfo.FileName + " error: " + err.Message, eloglevel.error);
                proc.Close();
                return;
            }
        }

        public void killAll()
        {
            killProcess(apacheProc);
            killProcess(mysqlProc);
            killProcess(authProc);
            killProcess(worldProc);
        }

        private void killProcess(Process proc)
        {
            if ((proc!=null) && (!proc.HasExited))
                proc.Kill();
        }
    }
}
