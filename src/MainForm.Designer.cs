namespace FFXINAVBUILDER
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.SearchBoxTB = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DumpAllBtn = new System.Windows.Forms.Button();
            this.ZoneListMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpSelectedMapDatBtn = new System.Windows.Forms.Button();
            this.mapLB = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DsM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.DSD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.vPP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.EmE = new System.Windows.Forms.TextBox();
            this.CSTB = new System.Windows.Forms.TextBox();
            this.EMaxL = new System.Windows.Forms.TextBox();
            this.CHTB = new System.Windows.Forms.TextBox();
            this.RMS = new System.Windows.Forms.TextBox();
            this.AHTB = new System.Windows.Forms.TextBox();
            this.RMinS = new System.Windows.Forms.TextBox();
            this.ARTB = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.MCTB = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.MSTB = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TSTB = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rtbDebug = new System.Windows.Forms.RichTextBox();
            this.DumpDatWorker = new System.ComponentModel.BackgroundWorker();
            this.DumpMeshes = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ZoneListMenuStrip.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 330);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.SearchBoxTB);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DumpAllBtn);
            this.tabPage1.Controls.Add(this.ZoneListMenuStrip);
            this.tabPage1.Controls.Add(this.DumpSelectedMapDatBtn);
            this.tabPage1.Controls.Add(this.mapLB);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1020, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label30.Location = new System.Drawing.Point(267, 191);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(146, 17);
            this.label30.TabIndex = 30;
            this.label30.Text = "<-- Search the list box";
            // 
            // SearchBoxTB
            // 
            this.SearchBoxTB.Location = new System.Drawing.Point(31, 191);
            this.SearchBoxTB.Name = "SearchBoxTB";
            this.SearchBoxTB.Size = new System.Drawing.Size(227, 22);
            this.SearchBoxTB.TabIndex = 29;
            this.SearchBoxTB.TextChanged += new System.EventHandler(this.SearchBoxTB_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label25.Location = new System.Drawing.Point(0, 257);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(19, 20);
            this.label25.TabIndex = 28;
            this.label25.Text = "3";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label24.Location = new System.Drawing.Point(4, 223);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 20);
            this.label24.TabIndex = 27;
            this.label24.Text = "2.1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label14.Location = new System.Drawing.Point(0, 44);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label13.Location = new System.Drawing.Point(0, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(173, 11);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 17);
            this.label17.TabIndex = 24;
            this.label17.Text = "<-- Load zonelist.xml first.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(267, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "<-- Use this if you only want to dump selected file from the listbox";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(267, 260);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "<-- This will take a few min and around 10gb of storage.  ";
            // 
            // DumpAllBtn
            // 
            this.DumpAllBtn.Location = new System.Drawing.Point(31, 254);
            this.DumpAllBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DumpAllBtn.Name = "DumpAllBtn";
            this.DumpAllBtn.Size = new System.Drawing.Size(228, 28);
            this.DumpAllBtn.TabIndex = 21;
            this.DumpAllBtn.Text = "Dump all map.dats";
            this.DumpAllBtn.UseVisualStyleBackColor = true;
            this.DumpAllBtn.Click += new System.EventHandler(this.DumpAllBtn_Click);
            // 
            // ZoneListMenuStrip
            // 
            this.ZoneListMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ZoneListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.ZoneListMenuStrip.Location = new System.Drawing.Point(4, 4);
            this.ZoneListMenuStrip.Name = "ZoneListMenuStrip";
            this.ZoneListMenuStrip.Size = new System.Drawing.Size(1012, 28);
            this.ZoneListMenuStrip.TabIndex = 17;
            this.ZoneListMenuStrip.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 24);
            this.toolStripMenuItem1.Text = "Load Zones";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // DumpSelectedMapDatBtn
            // 
            this.DumpSelectedMapDatBtn.Location = new System.Drawing.Point(31, 223);
            this.DumpSelectedMapDatBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DumpSelectedMapDatBtn.Name = "DumpSelectedMapDatBtn";
            this.DumpSelectedMapDatBtn.Size = new System.Drawing.Size(228, 28);
            this.DumpSelectedMapDatBtn.TabIndex = 20;
            this.DumpSelectedMapDatBtn.Text = "Dump selected map.dat ";
            this.DumpSelectedMapDatBtn.UseVisualStyleBackColor = true;
            this.DumpSelectedMapDatBtn.Click += new System.EventHandler(this.DumpSelectedMapDatBtn_Click);
            // 
            // mapLB
            // 
            this.mapLB.FormattingEnabled = true;
            this.mapLB.ItemHeight = 16;
            this.mapLB.Location = new System.Drawing.Point(31, 38);
            this.mapLB.Margin = new System.Windows.Forms.Padding(4);
            this.mapLB.Name = "mapLB";
            this.mapLB.Size = new System.Drawing.Size(227, 148);
            this.mapLB.TabIndex = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1020, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "NavMesh";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Blue;
            this.label29.Location = new System.Drawing.Point(4, 266);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(19, 20);
            this.label29.TabIndex = 56;
            this.label29.Text = "4";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Blue;
            this.label28.Location = new System.Drawing.Point(1, 230);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(19, 20);
            this.label28.TabIndex = 51;
            this.label28.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(341, 281);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(499, 17);
            this.label9.TabIndex = 55;
            this.label9.Text = "<--  When you click stop, it will finish off building the mesh then exit the thre" +
    "ad.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(341, 261);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(669, 17);
            this.label16.TabIndex = 54;
            this.label16.Text = "<-- This will build and dump navmeshes for all obj files in the Map Collision obj" +
    " folder... this will take 10min";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 262);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(320, 28);
            this.button5.TabIndex = 53;
            this.button5.Text = "Start dumping all zone.obj file navmeshes";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(373, 233);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "<-- This will take a couple of min depending on size of zone.";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 226);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(348, 28);
            this.button3.TabIndex = 51;
            this.button3.Text = "Select an OBJ file to build and dump a NavMesh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DsM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DSD);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.vPP);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.EmE);
            this.groupBox1.Controls.Add(this.CSTB);
            this.groupBox1.Controls.Add(this.EMaxL);
            this.groupBox1.Controls.Add(this.CHTB);
            this.groupBox1.Controls.Add(this.RMS);
            this.groupBox1.Controls.Add(this.AHTB);
            this.groupBox1.Controls.Add(this.RMinS);
            this.groupBox1.Controls.Add(this.ARTB);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.MCTB);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.MSTB);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.TSTB);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1012, 218);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "These are the default settings i dumped meshes with";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Blue;
            this.label27.Location = new System.Drawing.Point(0, 182);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(19, 20);
            this.label27.TabIndex = 50;
            this.label27.Text = "2";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Blue;
            this.label26.Location = new System.Drawing.Point(-4, 11);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 20);
            this.label26.TabIndex = 49;
            this.label26.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "CellSize     = ";
            // 
            // DsM
            // 
            this.DsM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DsM.ForeColor = System.Drawing.Color.Black;
            this.DsM.Location = new System.Drawing.Point(889, 59);
            this.DsM.Margin = new System.Windows.Forms.Padding(4);
            this.DsM.MaxLength = 6;
            this.DsM.Name = "DsM";
            this.DsM.Size = new System.Drawing.Size(60, 23);
            this.DsM.TabIndex = 48;
            this.DsM.Text = "1.0";
            this.DsM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "CellHeight = ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(213, 187);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(547, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "<< CLICK ME FIRST. this sets the Settings the DLL needs to dump meshes";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(697, 60);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(184, 17);
            this.label23.TabIndex = 47;
            this.label23.Text = "Detail Sample MaxError    = ";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(12, 180);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(193, 28);
            this.button4.TabIndex = 16;
            this.button4.Text = "Change NavMesh Settings";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(209, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "AgentHeight  = ";
            // 
            // DSD
            // 
            this.DSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DSD.ForeColor = System.Drawing.Color.Black;
            this.DSD.Location = new System.Drawing.Point(889, 30);
            this.DSD.Margin = new System.Windows.Forms.Padding(4);
            this.DSD.MaxLength = 6;
            this.DSD.Name = "DSD";
            this.DSD.Size = new System.Drawing.Size(60, 23);
            this.DSD.TabIndex = 46;
            this.DSD.Text = "6.0";
            this.DSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(211, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "AgentRadius = ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(697, 33);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(182, 17);
            this.label22.TabIndex = 45;
            this.label22.Text = "Detail Sample Distance    = ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(211, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "MaxClimb      =";
            // 
            // vPP
            // 
            this.vPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vPP.ForeColor = System.Drawing.Color.Black;
            this.vPP.Location = new System.Drawing.Point(609, 151);
            this.vPP.Margin = new System.Windows.Forms.Padding(4);
            this.vPP.MaxLength = 6;
            this.vPP.Name = "vPP";
            this.vPP.Size = new System.Drawing.Size(60, 23);
            this.vPP.TabIndex = 44;
            this.vPP.Text = "6.0";
            this.vPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(213, 128);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "MaxSlope    = ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(439, 155);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 17);
            this.label15.TabIndex = 43;
            this.label15.Text = "Verts Per Poly        = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "TileSize     = ";
            // 
            // EmE
            // 
            this.EmE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmE.ForeColor = System.Drawing.Color.Black;
            this.EmE.Location = new System.Drawing.Point(609, 121);
            this.EmE.Margin = new System.Windows.Forms.Padding(4);
            this.EmE.MaxLength = 6;
            this.EmE.Name = "EmE";
            this.EmE.Size = new System.Drawing.Size(60, 23);
            this.EmE.TabIndex = 42;
            this.EmE.Text = "1.3";
            this.EmE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CSTB
            // 
            this.CSTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSTB.ForeColor = System.Drawing.Color.Black;
            this.CSTB.Location = new System.Drawing.Point(104, 28);
            this.CSTB.Margin = new System.Windows.Forms.Padding(4);
            this.CSTB.MaxLength = 6;
            this.CSTB.Name = "CSTB";
            this.CSTB.Size = new System.Drawing.Size(60, 23);
            this.CSTB.TabIndex = 24;
            this.CSTB.Text = "0.40";
            this.CSTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EMaxL
            // 
            this.EMaxL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EMaxL.ForeColor = System.Drawing.Color.Black;
            this.EMaxL.Location = new System.Drawing.Point(609, 91);
            this.EMaxL.Margin = new System.Windows.Forms.Padding(4);
            this.EMaxL.MaxLength = 6;
            this.EMaxL.Name = "EMaxL";
            this.EMaxL.Size = new System.Drawing.Size(60, 23);
            this.EMaxL.TabIndex = 41;
            this.EMaxL.Text = "12.0";
            this.EMaxL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CHTB
            // 
            this.CHTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHTB.ForeColor = System.Drawing.Color.Black;
            this.CHTB.Location = new System.Drawing.Point(104, 60);
            this.CHTB.Margin = new System.Windows.Forms.Padding(4);
            this.CHTB.MaxLength = 6;
            this.CHTB.Name = "CHTB";
            this.CHTB.Size = new System.Drawing.Size(60, 23);
            this.CHTB.TabIndex = 25;
            this.CHTB.Text = "0.20";
            this.CHTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RMS
            // 
            this.RMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RMS.ForeColor = System.Drawing.Color.Black;
            this.RMS.Location = new System.Drawing.Point(609, 60);
            this.RMS.Margin = new System.Windows.Forms.Padding(4);
            this.RMS.MaxLength = 6;
            this.RMS.Name = "RMS";
            this.RMS.Size = new System.Drawing.Size(60, 23);
            this.RMS.TabIndex = 40;
            this.RMS.Text = "20";
            this.RMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AHTB
            // 
            this.AHTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AHTB.ForeColor = System.Drawing.Color.Black;
            this.AHTB.Location = new System.Drawing.Point(325, 28);
            this.AHTB.Margin = new System.Windows.Forms.Padding(4);
            this.AHTB.MaxLength = 6;
            this.AHTB.Name = "AHTB";
            this.AHTB.Size = new System.Drawing.Size(60, 23);
            this.AHTB.TabIndex = 26;
            this.AHTB.Text = "1.8";
            this.AHTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RMinS
            // 
            this.RMinS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RMinS.ForeColor = System.Drawing.Color.Black;
            this.RMinS.Location = new System.Drawing.Point(609, 28);
            this.RMinS.Margin = new System.Windows.Forms.Padding(4);
            this.RMinS.MaxLength = 6;
            this.RMinS.Name = "RMinS";
            this.RMinS.Size = new System.Drawing.Size(60, 23);
            this.RMinS.TabIndex = 39;
            this.RMinS.Text = "8";
            this.RMinS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ARTB
            // 
            this.ARTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARTB.ForeColor = System.Drawing.Color.Black;
            this.ARTB.Location = new System.Drawing.Point(325, 60);
            this.ARTB.Margin = new System.Windows.Forms.Padding(4);
            this.ARTB.MaxLength = 5;
            this.ARTB.Name = "ARTB";
            this.ARTB.Size = new System.Drawing.Size(60, 23);
            this.ARTB.TabIndex = 27;
            this.ARTB.Text = "0.3";
            this.ARTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(436, 126);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(154, 17);
            this.label21.TabIndex = 38;
            this.label21.Text = "Edge MaxError          = ";
            // 
            // MCTB
            // 
            this.MCTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MCTB.ForeColor = System.Drawing.Color.Black;
            this.MCTB.Location = new System.Drawing.Point(325, 92);
            this.MCTB.Margin = new System.Windows.Forms.Padding(4);
            this.MCTB.MaxLength = 6;
            this.MCTB.Name = "MCTB";
            this.MCTB.Size = new System.Drawing.Size(60, 23);
            this.MCTB.TabIndex = 28;
            this.MCTB.Text = "0.5";
            this.MCTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(436, 96);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(150, 17);
            this.label20.TabIndex = 37;
            this.label20.Text = "Edge MaxLen           = ";
            // 
            // MSTB
            // 
            this.MSTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSTB.ForeColor = System.Drawing.Color.Black;
            this.MSTB.Location = new System.Drawing.Point(325, 124);
            this.MSTB.Margin = new System.Windows.Forms.Padding(4);
            this.MSTB.MaxLength = 6;
            this.MSTB.Name = "MSTB";
            this.MSTB.Size = new System.Drawing.Size(60, 23);
            this.MSTB.TabIndex = 29;
            this.MSTB.Text = "46";
            this.MSTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(436, 65);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 17);
            this.label19.TabIndex = 36;
            this.label19.Text = "Region Merge Size   = ";
            // 
            // TSTB
            // 
            this.TSTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSTB.ForeColor = System.Drawing.Color.Black;
            this.TSTB.Location = new System.Drawing.Point(104, 92);
            this.TSTB.Margin = new System.Windows.Forms.Padding(4);
            this.TSTB.MaxLength = 6;
            this.TSTB.Name = "TSTB";
            this.TSTB.Size = new System.Drawing.Size(60, 23);
            this.TSTB.TabIndex = 30;
            this.TSTB.Text = "256";
            this.TSTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(436, 34);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(150, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "Region MinSize        = ";
            // 
            // rtbDebug
            // 
            this.rtbDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rtbDebug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDebug.CausesValidation = false;
            this.rtbDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDebug.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDebug.ForeColor = System.Drawing.Color.Yellow;
            this.rtbDebug.Location = new System.Drawing.Point(0, 330);
            this.rtbDebug.Margin = new System.Windows.Forms.Padding(5);
            this.rtbDebug.Name = "rtbDebug";
            this.rtbDebug.Size = new System.Drawing.Size(1028, 209);
            this.rtbDebug.TabIndex = 4;
            this.rtbDebug.Text = "";
            // 
            // DumpDatWorker
            // 
            this.DumpDatWorker.WorkerSupportsCancellation = true;
            this.DumpDatWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DumpDatWorker_DoWork);
            // 
            // DumpMeshes
            // 
            this.DumpMeshes.WorkerSupportsCancellation = true;
            this.DumpMeshes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DumpMeshes_DoWork);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(4, 287);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1012, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 31;
            this.progressBar1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 539);
            this.Controls.Add(this.rtbDebug);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "FFXINAVBUILDER";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ZoneListMenuStrip.ResumeLayout(false);
            this.ZoneListMenuStrip.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button DumpAllBtn;
        public System.Windows.Forms.MenuStrip ZoneListMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.Button DumpSelectedMapDatBtn;
        public System.Windows.Forms.ListBox mapLB;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.RichTextBox rtbDebug;
        private System.ComponentModel.BackgroundWorker DumpDatWorker;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox DsM;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox DSD;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox vPP;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox EmE;
        public System.Windows.Forms.TextBox CSTB;
        public System.Windows.Forms.TextBox EMaxL;
        public System.Windows.Forms.TextBox CHTB;
        public System.Windows.Forms.TextBox RMS;
        public System.Windows.Forms.TextBox AHTB;
        public System.Windows.Forms.TextBox RMinS;
        public System.Windows.Forms.TextBox ARTB;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox MCTB;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox MSTB;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox TSTB;
        public System.Windows.Forms.Label label18;
        public System.ComponentModel.BackgroundWorker DumpMeshes;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox SearchBoxTB;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

