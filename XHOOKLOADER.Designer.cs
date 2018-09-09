namespace UnityLoader {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.userlabel = new System.Windows.Forms.Label();
            this.listmotd = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoadProgress = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CheckProc = new System.Windows.Forms.Timer(this.components);
            this.Cheatinfo = new System.Windows.Forms.Label();
            this.IndexList = new System.Windows.Forms.TextBox();
            this.letsego = new System.Windows.Forms.Timer(this.components);
            this.copyright = new System.Windows.Forms.LinkLabel();
            this.welcomelabel = new System.Windows.Forms.Label();
            this.IndexCoder = new System.Windows.Forms.TextBox();
            this.detectionindex = new System.Windows.Forms.TextBox();
            this.IndexCheat = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Check = new System.Windows.Forms.Timer(this.components);
            this.detectionindex2 = new System.Windows.Forms.TextBox();
            this.detectionindex3 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.DelayInjection = new System.Windows.Forms.CheckBox();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InjectionIntervall = new System.Windows.Forms.NumericUpDown();
            this.AutoInjectionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InjectionIntervall)).BeginInit();
            this.SuspendLayout();
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.userlabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.userlabel.Location = new System.Drawing.Point(88, 520);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(47, 13);
            this.userlabel.TabIndex = 2;
            this.userlabel.Text = "Unknow";
            // 
            // listmotd
            // 
            this.listmotd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.listmotd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listmotd.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.listmotd.FormattingEnabled = true;
            this.listmotd.Items.AddRange(new object[] {
            "Message of the day: Welcome to X-LOADER."});
            this.listmotd.Location = new System.Drawing.Point(14, 536);
            this.listmotd.Name = "listmotd";
            this.listmotd.Size = new System.Drawing.Size(446, 15);
            this.listmotd.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Location = new System.Drawing.Point(319, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(316, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Detection status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(14, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select a game:";
            // 
            // LoadProgress
            // 
            this.LoadProgress.Location = new System.Drawing.Point(14, 502);
            this.LoadProgress.Name = "LoadProgress";
            this.LoadProgress.Size = new System.Drawing.Size(446, 15);
            this.LoadProgress.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.StatusLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatusLabel.Location = new System.Drawing.Point(13, 486);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 9;
            this.StatusLabel.Text = "Status:";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.ProgressLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ProgressLabel.Location = new System.Drawing.Point(59, 486);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(31, 13);
            this.ProgressLabel.TabIndex = 10;
            this.ProgressLabel.Text = "IDLE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(316, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Coder:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.linkLabel1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel1.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel1.Location = new System.Drawing.Point(365, 520);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(90, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X-HOOK GROUP";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.linkLabel2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel2.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel2.Location = new System.Drawing.Point(273, 520);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(78, 13);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "X-HOOK SITE ";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.button3.Location = new System.Drawing.Point(14, 439);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(296, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Inject";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(494, 106);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // CheckProc
            // 
            this.CheckProc.Interval = 10000;
            this.CheckProc.Tick += new System.EventHandler(this.CheckProc_Tick);
            // 
            // Cheatinfo
            // 
            this.Cheatinfo.AutoSize = true;
            this.Cheatinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.Cheatinfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Cheatinfo.Location = new System.Drawing.Point(316, 231);
            this.Cheatinfo.Name = "Cheatinfo";
            this.Cheatinfo.Size = new System.Drawing.Size(58, 13);
            this.Cheatinfo.TabIndex = 20;
            this.Cheatinfo.Text = "Cheat info:";
            // 
            // IndexList
            // 
            this.IndexList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.IndexList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndexList.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.IndexList.Location = new System.Drawing.Point(319, 247);
            this.IndexList.Multiline = true;
            this.IndexList.Name = "IndexList";
            this.IndexList.ReadOnly = true;
            this.IndexList.Size = new System.Drawing.Size(141, 100);
            this.IndexList.TabIndex = 22;
            // 
            // letsego
            // 
            this.letsego.Tick += new System.EventHandler(this.letsego_Tick);
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyright.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.copyright.Location = new System.Drawing.Point(146, 554);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(194, 18);
            this.copyright.TabIndex = 24;
            this.copyright.TabStop = true;
            this.copyright.Text = "X-HOOK ™ All right reserved";
            // 
            // welcomelabel
            // 
            this.welcomelabel.AutoSize = true;
            this.welcomelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.welcomelabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.welcomelabel.Location = new System.Drawing.Point(11, 520);
            this.welcomelabel.Name = "welcomelabel";
            this.welcomelabel.Size = new System.Drawing.Size(71, 13);
            this.welcomelabel.TabIndex = 25;
            this.welcomelabel.Text = "Logged in as:";
            // 
            // IndexCoder
            // 
            this.IndexCoder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.IndexCoder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndexCoder.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.IndexCoder.Location = new System.Drawing.Point(319, 137);
            this.IndexCoder.Multiline = true;
            this.IndexCoder.Name = "IndexCoder";
            this.IndexCoder.ReadOnly = true;
            this.IndexCoder.Size = new System.Drawing.Size(138, 19);
            this.IndexCoder.TabIndex = 26;
            this.IndexCoder.TextChanged += new System.EventHandler(this.IndexCoder_TextChanged);
            // 
            // detectionindex
            // 
            this.detectionindex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.detectionindex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detectionindex.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.detectionindex.Location = new System.Drawing.Point(319, 175);
            this.detectionindex.Multiline = true;
            this.detectionindex.Name = "detectionindex";
            this.detectionindex.ReadOnly = true;
            this.detectionindex.Size = new System.Drawing.Size(139, 21);
            this.detectionindex.TabIndex = 27;
            // 
            // IndexCheat
            // 
            this.IndexCheat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.IndexCheat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IndexCheat.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.IndexCheat.FormattingEnabled = true;
            this.IndexCheat.Location = new System.Drawing.Point(14, 137);
            this.IndexCheat.Name = "IndexCheat";
            this.IndexCheat.Size = new System.Drawing.Size(296, 288);
            this.IndexCheat.TabIndex = 0;
            this.IndexCheat.SelectedIndexChanged += new System.EventHandler(this.CheatIndex_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-52, 468);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(615, 15);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // Check
            // 
            this.Check.Enabled = true;
            this.Check.Interval = 600000;
            this.Check.Tick += new System.EventHandler(this.Check_Tick_1);
            // 
            // detectionindex2
            // 
            this.detectionindex2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.detectionindex2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detectionindex2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.detectionindex2.Location = new System.Drawing.Point(319, 193);
            this.detectionindex2.Multiline = true;
            this.detectionindex2.Name = "detectionindex2";
            this.detectionindex2.ReadOnly = true;
            this.detectionindex2.Size = new System.Drawing.Size(139, 21);
            this.detectionindex2.TabIndex = 29;
            // 
            // detectionindex3
            // 
            this.detectionindex3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.detectionindex3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detectionindex3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.detectionindex3.Location = new System.Drawing.Point(319, 211);
            this.detectionindex3.Multiline = true;
            this.detectionindex3.Name = "detectionindex3";
            this.detectionindex3.ReadOnly = true;
            this.detectionindex3.Size = new System.Drawing.Size(139, 17);
            this.detectionindex3.TabIndex = 30;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-97, 103);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(615, 15);
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // DelayInjection
            // 
            this.DelayInjection.AutoSize = true;
            this.DelayInjection.Enabled = false;
            this.DelayInjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelayInjection.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.DelayInjection.Location = new System.Drawing.Point(9, 19);
            this.DelayInjection.Name = "DelayInjection";
            this.DelayInjection.Size = new System.Drawing.Size(87, 17);
            this.DelayInjection.TabIndex = 32;
            this.DelayInjection.Text = "Auto injection";
            this.DelayInjection.UseVisualStyleBackColor = true;
            this.DelayInjection.CheckedChanged += new System.EventHandler(this.DelayInjection_CheckedChanged);
            // 
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Enabled = false;
            this.DelayLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.DelayLabel.Location = new System.Drawing.Point(6, 44);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(56, 13);
            this.DelayLabel.TabIndex = 34;
            this.DelayLabel.Text = "Delay MS:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.InjectionIntervall);
            this.groupBox1.Controls.Add(this.DelayInjection);
            this.groupBox1.Controls.Add(this.DelayLabel);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(319, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 72);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Injection Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // InjectionIntervall
            // 
            this.InjectionIntervall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.InjectionIntervall.Enabled = false;
            this.InjectionIntervall.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.InjectionIntervall.Location = new System.Drawing.Point(82, 42);
            this.InjectionIntervall.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.InjectionIntervall.Minimum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.InjectionIntervall.Name = "InjectionIntervall";
            this.InjectionIntervall.Size = new System.Drawing.Size(53, 20);
            this.InjectionIntervall.TabIndex = 35;
            this.InjectionIntervall.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // AutoInjectionTimer
            // 
            this.AutoInjectionTimer.Interval = 2500;
            this.AutoInjectionTimer.Tick += new System.EventHandler(this.AutoInjectionTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(487, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.detectionindex3);
            this.Controls.Add(this.detectionindex2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.detectionindex);
            this.Controls.Add(this.IndexCoder);
            this.Controls.Add(this.welcomelabel);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.IndexList);
            this.Controls.Add(this.Cheatinfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.LoadProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listmotd);
            this.Controls.Add(this.userlabel);
            this.Controls.Add(this.IndexCheat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "X-HOOK Loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InjectionIntervall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.ListBox listmotd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar LoadProgress;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer CheckProc;
        private System.Windows.Forms.Label Cheatinfo;
        private System.Windows.Forms.TextBox IndexList;
        private System.Windows.Forms.Timer letsego;
        private System.Windows.Forms.LinkLabel copyright;
        private System.Windows.Forms.Label welcomelabel;
        private System.Windows.Forms.TextBox IndexCoder;
        private System.Windows.Forms.TextBox detectionindex;
        private System.Windows.Forms.ListBox IndexCheat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer Check;
        private System.Windows.Forms.TextBox detectionindex2;
        private System.Windows.Forms.TextBox detectionindex3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox DelayInjection;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown InjectionIntervall;
        private System.Windows.Forms.Timer AutoInjectionTimer;
    }
}

