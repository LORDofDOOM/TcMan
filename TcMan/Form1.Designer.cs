namespace TcMan
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorTxt = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wosLbl = new System.Windows.Forms.Label();
            this.ausLbl = new System.Windows.Forms.Label();
            this.mysLbl = new System.Windows.Forms.Label();
            this.apsLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.allyImg = new System.Windows.Forms.PictureBox();
            this.hordeImg = new System.Windows.Forms.PictureBox();
            this.stopBtn = new System.Windows.Forms.Label();
            this.wowlogo = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Label();
            this.resizePicBtn = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allyImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hordeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wowlogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePicBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.errorTxt);
            this.panel2.Location = new System.Drawing.Point(10, 145);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 160);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // errorTxt
            // 
            this.errorTxt.BackColor = System.Drawing.Color.Black;
            this.errorTxt.ForeColor = System.Drawing.Color.Goldenrod;
            this.errorTxt.Location = new System.Drawing.Point(10, 10);
            this.errorTxt.Multiline = true;
            this.errorTxt.Name = "errorTxt";
            this.errorTxt.ReadOnly = true;
            this.errorTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorTxt.Size = new System.Drawing.Size(430, 140);
            this.errorTxt.TabIndex = 2;
            this.errorTxt.TextChanged += new System.EventHandler(this.errorTxt_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(163, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(139, 25);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(131, 21);
            this.hideToolStripMenuItem.Text = "Run in Background";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Apache";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "MySQL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(35, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Auth";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(35, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "World";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wosLbl
            // 
            this.wosLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.wosLbl.Location = new System.Drawing.Point(80, 95);
            this.wosLbl.Name = "wosLbl";
            this.wosLbl.Size = new System.Drawing.Size(60, 16);
            this.wosLbl.TabIndex = 15;
            this.wosLbl.Text = "Stopped";
            this.wosLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ausLbl
            // 
            this.ausLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.ausLbl.Location = new System.Drawing.Point(80, 73);
            this.ausLbl.Name = "ausLbl";
            this.ausLbl.Size = new System.Drawing.Size(60, 16);
            this.ausLbl.TabIndex = 14;
            this.ausLbl.Text = "Stopped";
            this.ausLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mysLbl
            // 
            this.mysLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.mysLbl.Location = new System.Drawing.Point(80, 51);
            this.mysLbl.Name = "mysLbl";
            this.mysLbl.Size = new System.Drawing.Size(60, 16);
            this.mysLbl.TabIndex = 13;
            this.mysLbl.Text = "Stopped";
            this.mysLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apsLbl
            // 
            this.apsLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.apsLbl.Location = new System.Drawing.Point(80, 29);
            this.apsLbl.Name = "apsLbl";
            this.apsLbl.Size = new System.Drawing.Size(60, 16);
            this.apsLbl.TabIndex = 12;
            this.apsLbl.Text = "Stopped";
            this.apsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.allyImg);
            this.panel1.Controls.Add(this.hordeImg);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(474, 146);
            this.panel1.TabIndex = 22;
            // 
            // allyImg
            // 
            this.allyImg.BackgroundImage = global::TcMan.Properties.Resources.ally;
            this.allyImg.Location = new System.Drawing.Point(156, 84);
            this.allyImg.Name = "allyImg";
            this.allyImg.Size = new System.Drawing.Size(80, 20);
            this.allyImg.TabIndex = 1;
            this.allyImg.TabStop = false;
            // 
            // hordeImg
            // 
            this.hordeImg.BackgroundImage = global::TcMan.Properties.Resources.horde;
            this.hordeImg.Location = new System.Drawing.Point(156, 84);
            this.hordeImg.Name = "hordeImg";
            this.hordeImg.Size = new System.Drawing.Size(160, 20);
            this.hordeImg.TabIndex = 0;
            this.hordeImg.TabStop = false;
            // 
            // stopBtn
            // 
            this.stopBtn.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.stopBtn.Image = global::TcMan.Properties.Resources.btn;
            this.stopBtn.Location = new System.Drawing.Point(338, 84);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(100, 26);
            this.stopBtn.TabIndex = 21;
            this.stopBtn.Text = "Stop";
            this.stopBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            this.stopBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stopBtn_MouseDown);
            this.stopBtn.MouseEnter += new System.EventHandler(this.stopBtn_MouseEnter);
            this.stopBtn.MouseLeave += new System.EventHandler(this.stopBtn_MouseLeave);
            this.stopBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stopBtn_MouseUp);
            // 
            // wowlogo
            // 
            this.wowlogo.BackgroundImage = global::TcMan.Properties.Resources.wowlogo;
            this.wowlogo.Location = new System.Drawing.Point(155, 25);
            this.wowlogo.Margin = new System.Windows.Forms.Padding(0);
            this.wowlogo.Name = "wowlogo";
            this.wowlogo.Size = new System.Drawing.Size(160, 46);
            this.wowlogo.TabIndex = 17;
            this.wowlogo.TabStop = false;
            // 
            // startBtn
            // 
            this.startBtn.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.startBtn.Image = global::TcMan.Properties.Resources.btn;
            this.startBtn.Location = new System.Drawing.Point(338, 37);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(100, 26);
            this.startBtn.TabIndex = 20;
            this.startBtn.Text = "Start";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            this.startBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startBtn_MouseDown);
            this.startBtn.MouseEnter += new System.EventHandler(this.startBtn_MouseEnter);
            this.startBtn.MouseLeave += new System.EventHandler(this.startBtn_MouseLeave);
            this.startBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startBtn_MouseUp);
            // 
            // resizePicBtn
            // 
            this.resizePicBtn.BackgroundImage = global::TcMan.Properties.Resources.up24;
            this.resizePicBtn.Location = new System.Drawing.Point(223, 122);
            this.resizePicBtn.Name = "resizePicBtn";
            this.resizePicBtn.Size = new System.Drawing.Size(24, 24);
            this.resizePicBtn.TabIndex = 4;
            this.resizePicBtn.TabStop = false;
            this.resizePicBtn.Click += new System.EventHandler(this.resizePicBtn_Click);
            this.resizePicBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.resizePicBtn_Paint);
            this.resizePicBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resizePicBtn_MouseDown);
            this.resizePicBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resizePicBtn_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(472, 316);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.wowlogo);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.wosLbl);
            this.Controls.Add(this.ausLbl);
            this.Controls.Add(this.mysLbl);
            this.Controls.Add(this.apsLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resizePicBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcMan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allyImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hordeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wowlogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePicBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox resizePicBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox errorTxt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label wosLbl;
        private System.Windows.Forms.Label ausLbl;
        private System.Windows.Forms.Label mysLbl;
        private System.Windows.Forms.Label apsLbl;
        private System.Windows.Forms.PictureBox wowlogo;
        private System.Windows.Forms.Label startBtn;
        private System.Windows.Forms.Label stopBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox hordeImg;
        private System.Windows.Forms.PictureBox allyImg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

