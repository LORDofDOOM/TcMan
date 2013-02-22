using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogThis;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;


namespace TcMan
{
    public partial class Form1 : Form
    {
        /* UI and others */
        private bool min;

        /* Fonts */
        private System.Drawing.Text.PrivateFontCollection pfc;
        private List<int> fontList;

        public Form1()
        {
            min = false;
            pfc = new System.Drawing.Text.PrivateFontCollection();
            fontList = new List<int>();
            registerFonts(Properties.Resources.bwrath);
            registerFonts(Properties.Resources.folkard);
            registerFonts(Properties.Resources.morpheus);

            InitializeComponent();

            ServerMonitor.getInstance();
            ServerMonitor.setForm(this);

            clTxtBox();

            startBtn.Font = GetResoruceFont(Properties.Resources.folkard, 14);
            stopBtn.Font = GetResoruceFont(Properties.Resources.folkard, 14);
            label1.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            label2.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            label3.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            label4.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            apsLbl.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            mysLbl.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            ausLbl.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
            wosLbl.Font = GetResoruceFont(Properties.Resources.morpheus, 10);
        }

        private void registerFonts(byte[] bytes)
        {
            IntPtr MeAdd = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, MeAdd, bytes.Length);
            pfc.AddMemoryFont(MeAdd, bytes.Length);
            fontList.Add(bytes.Count());
        }

        private Font GetResoruceFont(byte[] fontfile, uint size)
        {

            return new Font(pfc.Families[fontList.IndexOf(fontfile.Count())], size, FontStyle.Regular);
        }

        private void resizePicBtn_Click(object sender, EventArgs e)
        {
            miniSizePanel();
        }

        private void resizePicBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (min)
                resizePicBtn.BackgroundImage = ((System.Drawing.Image)Properties.Resources.down24pressed);
            else
                resizePicBtn.BackgroundImage = ((System.Drawing.Image)Properties.Resources.up24pressed);
        }

        private void resizePicBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (min)
                resizePicBtn.BackgroundImage = ((System.Drawing.Image)Properties.Resources.down24);
            else
                resizePicBtn.BackgroundImage = ((System.Drawing.Image)Properties.Resources.up24);
        }

        private void startBtn_MouseDown(object sender, MouseEventArgs e)
        {
            startBtn.Image = ((System.Drawing.Image)Properties.Resources.btn_pressed);
        } 

        private void startBtn_MouseUp(object sender, MouseEventArgs e)
        {
            startBtn.Image = ((System.Drawing.Image)Properties.Resources.btn);
        }

        private void startBtn_MouseEnter(object sender, EventArgs e)
        {
            startBtn.Image = ((System.Drawing.Image)Properties.Resources.btn_hl);
        }

        private void startBtn_MouseLeave(object sender, EventArgs e)
        {
            startBtn.Image = ((System.Drawing.Image)Properties.Resources.btn);
        }

        private void stopBtn_MouseDown(object sender, MouseEventArgs e)
        {
            stopBtn.Image = ((System.Drawing.Image)Properties.Resources.btn_pressed);
        }

        private void stopBtn_MouseUp(object sender, MouseEventArgs e)
        {
            stopBtn.Image = ((System.Drawing.Image)Properties.Resources.btn);
        }

        private void stopBtn_MouseEnter(object sender, EventArgs e)
        {
            stopBtn.Image = ((System.Drawing.Image)Properties.Resources.btn_hl);
        }

        private void stopBtn_MouseLeave(object sender, EventArgs e)
        {
            stopBtn.Image = ((System.Drawing.Image)Properties.Resources.btn);
        }

        private void miniSizePanel()
        {
            if (!min)
            {
                panel2.Hide();
                resizePicBtn.BackgroundImage = ((System.Drawing.Image)Properties.Resources.down24);
                min = !min;
            }
            else
            {
                panel2.Show();
                resizePicBtn.BackgroundImage = ((System.Drawing.Image)Properties.Resources.up24);
                min = !min;
            }
        }

        private Color getPicBoxColor()
        {
            if (!min)
                return System.Drawing.SystemColors.Control;
            else
                return Color.Gray;
        }

        private void resizePicBtn_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                        resizePicBtn.ClientRectangle,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed,
                                        getPicBoxColor(),
                                        1,
                                        ButtonBorderStyle.Dashed); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                        panel2.ClientRectangle,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed,
                                        Color.Gray,
                                        1,
                                        ButtonBorderStyle.Dashed); 
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit? All running servers will be killed!", "Quit Application", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
            else
            {
                ServerMonitor.getInstance().killAll();
                Application.ExitThread();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.Visible)
                    this.Show();
                else
                    this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_Closing);
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                           label1.ClientRectangle,
                                           Color.LightGoldenrodYellow,
                                           0,
                                           ButtonBorderStyle.Solid,
                                           Color.LightGoldenrodYellow,
                                           0,
                                           ButtonBorderStyle.Solid,
                                           Color.LightGoldenrodYellow,
                                           0,
                                           ButtonBorderStyle.Solid,
                                           Color.LightGray,
                                           1,
                                           ButtonBorderStyle.Solid); 

        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                           label2.ClientRectangle,
                                           Color.LightGray,
                                           0,
                                           ButtonBorderStyle.Inset,
                                           Color.LightGray,
                                           0,
                                           ButtonBorderStyle.Inset,
                                           Color.LightGray,
                                           0,
                                           ButtonBorderStyle.Inset,
                                           Color.LightGray,
                                           1,
                                           ButtonBorderStyle.Solid);

        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                           label3.ClientRectangle,
                                           Color.LightGray,
                                           0,
                                           ButtonBorderStyle.Inset,
                                           Color.LightGray,
                                           0,
                                           ButtonBorderStyle.Inset,
                                           Color.LightGray,
                                           0,
                                           ButtonBorderStyle.Inset,
                                           Color.LightGray,
                                           1,
                                           ButtonBorderStyle.Solid);

        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            ServerMonitor.getInstance().killAll();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            clTxtBox();
            ServerMonitor.getInstance().killAll();
            ServerMonitor.getInstance().runAll();
        }

        public void appendError(string err)
        {
            Invoke(new MethodInvoker(delegate { errorTxt.AppendText(err); })); 
        }

        public void appendCritical(string err)
        {
            Invoke(new MethodInvoker(delegate { errorTxt.AppendText(err); MessageBox.Show(err); }));
        }

        public void updateStatus(int aps, int mys, int aus, int wos)
        {
            switch (aps)
            {
                case 0:
                    Invoke(new MethodInvoker(delegate { apsLbl.ForeColor = System.Drawing.Color.DarkRed; apsLbl.Text = "Stopped"; }));
                    break;
                case 1:
                    Invoke(new MethodInvoker(delegate { apsLbl.ForeColor = System.Drawing.Color.DarkGreen; apsLbl.Text = "Running"; }));
                    break;
                case 2:
                    Invoke(new MethodInvoker(delegate { apsLbl.ForeColor = System.Drawing.Color.DarkOrange; apsLbl.Text = "Replaced"; }));
                    break;
                default:
                    break;
            }
            switch (mys)
            {
                case 0:
                    Invoke(new MethodInvoker(delegate { mysLbl.ForeColor = System.Drawing.Color.DarkRed; mysLbl.Text = "Stopped"; }));
                    break;
                case 1:
                    Invoke(new MethodInvoker(delegate { mysLbl.ForeColor = System.Drawing.Color.DarkGreen; mysLbl.Text = "Running"; }));
                    break;
                case 2:
                    Invoke(new MethodInvoker(delegate { mysLbl.ForeColor = System.Drawing.Color.DarkOrange; mysLbl.Text = "Replaced"; }));
                    break;
                default:
                    break;
            }
            switch (aus)
            {
                case 0:
                    Invoke(new MethodInvoker(delegate { ausLbl.ForeColor = System.Drawing.Color.DarkRed; ausLbl.Text = "Stopped"; }));
                    break;
                case 1:
                    Invoke(new MethodInvoker(delegate { ausLbl.ForeColor = System.Drawing.Color.DarkGreen; ausLbl.Text = "Running"; }));
                    break;
                case 2:
                    Invoke(new MethodInvoker(delegate { ausLbl.ForeColor = System.Drawing.Color.DarkOrange; ausLbl.Text = "Replaced"; }));
                    break;
                default:
                    break;
            }
            switch (wos)
            {
                case 0:
                    Invoke(new MethodInvoker(delegate { wosLbl.ForeColor = System.Drawing.Color.DarkRed; wosLbl.Text = "Stopped"; }));
                    break;
                case 1:
                    Invoke(new MethodInvoker(delegate { wosLbl.ForeColor = System.Drawing.Color.DarkGreen; wosLbl.Text = "Running"; }));
                    break;
                case 2:
                    Invoke(new MethodInvoker(delegate { wosLbl.ForeColor = System.Drawing.Color.DarkOrange; wosLbl.Text = "Replaced"; }));
                    break;
                default:
                    break;
            }
        }
        /**
        private void killProcess(string binStr)
        {
            string tmp = binString(binStr);
            foreach (Process p in Process.GetProcesses())
            {

                if (p.ProcessName.ToLower().Contains(tmp))
                {
                    if (MessageBox.Show("Found running " + tmp + " instance. Kill it(recommended)?", "Found running server", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return;
                    else
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Error occurred while killing process " + tmp +", check error log or log file.");
                            Invoke(new MethodInvoker(delegate { errorTxt.AppendText( "ERROR STACKTRACE on killing process - " + tmp + " :" + err.Message + Environment.NewLine); }));
                            Log.LogHeader("ERROR STACKTRACE on killing process - " + tmp + " :" + err.Message, elogheaderlevel.Level_3);
                            Log.LogThis(err.StackTrace, eloglevel.error);
                        }
                    }
                }
            }
        }
        
        private string binString(string path)
        {
            return path.Substring(path.LastIndexOf("\\") + 1, (path.LastIndexOf(".") - 1 - path.LastIndexOf("\\"))).ToLower();
        }
        **/
        private void clTxtBox()
        {
            errorTxt.Text = "Server Errors :" + Environment.NewLine;
        }
        /**
        private bool runProcess(string binStr)
        {
            Process proc = new Process();

            proc.StartInfo.FileName = binStr;
            proc.StartInfo.WorkingDirectory = binStr.Substring(0, binStr.Length - (binStr.Length - binStr.LastIndexOf('\\')));
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.RedirectStandardError = true;
            //proc.ErrorDataReceived += proc_DataReceived;
            proc.OutputDataReceived += proc_DataReceived;
            proc.Exited += proc_HasExited;
            proc.EnableRaisingEvents = true;
            try
            {
                proc.Start();
                //proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                //proc.Kill();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error occurred while creating process\"" + binString(binStr) + "\", check error log or log file.");
                Invoke(new MethodInvoker(delegate { errorTxt.AppendText( "ERROR STACKTRACE on creating process - " + binString(binStr) + " :" + err.Message + Environment.NewLine); }));
                Log.LogHeader("ERROR STACKTRACE on creating process - " + binString(binStr) + " : " + err.Message, elogheaderlevel.Level_3);
                Log.LogThis(err.StackTrace, eloglevel.error);
                return false;
            }
            return true;
        }
        
        public void proc_HasExited(object sender, EventArgs e)
        {
            bool authLive = false;
            bool worldLive=false;
            bool apacheLive=false;
            bool mysqlLive=false;

			string proc = "";
            try
			{
				proc = ((Process)sender).ProcessName.ToLower();
			}
			catch (InvalidOperationException ioe)
			{
				Log.LogHeader("ERROR STACKTRACE:" + ioe.Message.ToString(), elogheaderlevel.Level_3);
                Log.LogThis(ioe.StackTrace.ToString(), eloglevel.error);
			}
            int code = 0;
            foreach (Process p in Process.GetProcesses())
            {
                if (!authLive && p.ProcessName.ToLower().Contains(binString(authBin)))
                {
                    authLive = true;
                    //proc += binString(authBin);
                    code += 1;
                }
                else if (!worldLive && p.ProcessName.ToLower().Contains(binString(worldBin)))
                {
                    worldLive = true;
                    //proc += binString(worldBin);
                    code += 2;
                }
                else if (!apacheLive && p.ProcessName.ToLower().Contains(binString(apacheBin)))
                {
                    apacheLive = true;
                    //proc += binString(apacheBin);
                    code += 4;
                }
                else if (!mysqlLive && p.ProcessName.ToLower().Contains(binString(mysqlBin)))
                {
                    mysqlLive = true;
                    code += 8;
                    //proc += binString(mysqlBin);
                }
            }

            if ((code & 1) == 0)
                proc += binString(authBin);
            if ((code & 2) == 0)
                proc += binString(worldBin);
            if ((code & 4) == 0)
                proc += binString(apacheBin);
            if ((code & 8) == 0)
                proc += binString(mysqlBin);

            if (proc.Contains(binString(authBin)))
            {
                Invoke(new MethodInvoker(delegate { errorTxt.AppendText(">>Auth Server - stopped<<" + Environment.NewLine); }));
                ausLbl.ForeColor = System.Drawing.Color.DarkRed;
                Invoke(new MethodInvoker(delegate { ausLbl.Text = "Stopped"; }));
            }
            if (proc.Contains(binString(worldBin)))
            {
                Invoke(new MethodInvoker(delegate { errorTxt.AppendText(">>World Server - stopped<<" + Environment.NewLine); }));
                wosLbl.ForeColor = System.Drawing.Color.DarkRed;
                Invoke(new MethodInvoker(delegate { wosLbl.Text = "Stopped"; }));
            }
            if (proc.Contains(binString(apacheBin)))
            {
                Invoke(new MethodInvoker(delegate { errorTxt.AppendText(">>Apache Server - stopped<<" + Environment.NewLine); }));
                apsLbl.ForeColor = System.Drawing.Color.DarkRed;
                Invoke(new MethodInvoker(delegate { apsLbl.Text = "Stopped"; }));
            }
            if (proc.Contains(binString(mysqlBin)))
            {
                Invoke(new MethodInvoker(delegate { errorTxt.AppendText(">>MySQL Server - stopped<<" + Environment.NewLine); }));
                mysLbl.ForeColor = System.Drawing.Color.DarkRed;
                Invoke(new MethodInvoker(delegate { mysLbl.Text = "Stopped"; }));
            }
        }
        
        public void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            lock (stdLock)
            {
                if (e.Data != null)
                {
                    string proc = ((Process)sender).ProcessName.ToLower();

                    if (proc == binString(authBin))
                        Invoke(new MethodInvoker(delegate { errorTxt.AppendText("Auth Server - " + e.Data + Environment.NewLine); }));
                    else if (proc == binString(worldBin))
                        Invoke(new MethodInvoker(delegate { errorTxt.AppendText("World Server - "+e.Data + Environment.NewLine); }));
                    else if (proc == binString(apacheBin))
                        Invoke(new MethodInvoker(delegate { errorTxt.AppendText("Apache Server - "+e.Data + Environment.NewLine); }));
                    else if (proc == binString(mysqlBin))
                        Invoke(new MethodInvoker(delegate { errorTxt.AppendText("MySQL Server - "+e.Data + Environment.NewLine); }));
                }
            }
        }
        **/
        private void errorTxt_TextChanged(object sender, EventArgs e)
        {
            errorTxt.ScrollToCaret();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
