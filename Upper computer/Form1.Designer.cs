namespace Wiscam
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGVscan = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonScan = new System.Windows.Forms.Button();
            this.timersearch = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxadmin = new System.Windows.Forms.TextBox();
            this.textBoxpsk = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxUpgrade = new System.Windows.Forms.GroupBox();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonimport = new System.Windows.Forms.Button();
            this.textBoximport = new System.Windows.Forms.TextBox();
            this.buttonupgrade = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.close = new System.Windows.Forms.Button();
            this.Received = new System.Windows.Forms.Button();
            this.textrec = new System.Windows.Forms.TextBox();
            this.open = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVscan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxUpgrade.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Location = new System.Drawing.Point(40, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 269);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(456, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 25);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "close";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGVscan
            // 
            this.dataGVscan.AllowDrop = true;
            this.dataGVscan.AllowUserToResizeRows = false;
            this.dataGVscan.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGVscan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGVscan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGVscan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.ModuleIP,
            this.MAC,
            this.Version,
            this.progress,
            this.select});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGVscan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGVscan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGVscan.Enabled = false;
            this.dataGVscan.Location = new System.Drawing.Point(133, 8);
            this.dataGVscan.Name = "dataGVscan";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGVscan.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGVscan.RowHeadersVisible = false;
            this.dataGVscan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGVscan.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGVscan.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGVscan.RowTemplate.Height = 23;
            this.dataGVscan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGVscan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGVscan.Size = new System.Drawing.Size(765, 157);
            this.dataGVscan.TabIndex = 71;
            this.dataGVscan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVscan_CellContentClick);
            // 
            // num
            // 
            this.num.HeaderText = "SID";
            this.num.Name = "num";
            this.num.Width = 50;
            // 
            // ModuleIP
            // 
            this.ModuleIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ModuleIP.DefaultCellStyle = dataGridViewCellStyle2;
            this.ModuleIP.FillWeight = 18.7647F;
            this.ModuleIP.HeaderText = "Module IP";
            this.ModuleIP.Name = "ModuleIP";
            this.ModuleIP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModuleIP.Width = 120;
            // 
            // MAC
            // 
            this.MAC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MAC.DefaultCellStyle = dataGridViewCellStyle3;
            this.MAC.FillWeight = 142.3099F;
            this.MAC.HeaderText = "Nabto ID";
            this.MAC.Name = "MAC";
            this.MAC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MAC.Width = 220;
            // 
            // Version
            // 
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.Width = 170;
            // 
            // progress
            // 
            this.progress.HeaderText = "want to set ?";
            this.progress.Name = "progress";
            this.progress.Width = 150;
            // 
            // select
            // 
            this.select.HeaderText = "Select";
            this.select.Name = "select";
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select.Width = 50;
            // 
            // buttonScan
            // 
            this.buttonScan.BackColor = System.Drawing.Color.Transparent;
            this.buttonScan.Location = new System.Drawing.Point(12, 55);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(103, 69);
            this.buttonScan.TabIndex = 64;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = false;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // timersearch
            // 
            this.timersearch.Interval = 50;
            this.timersearch.Tick += new System.EventHandler(this.timersearch_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 496);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "rtsp://admin:admin@192.168.1.116/cam1/h264";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "RTSP Url 1:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 34);
            this.button3.TabIndex = 79;
            this.button3.Text = "Reboot";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 68;
            this.label4.Text = "Pass word：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 67;
            this.label3.Text = "User :";
            // 
            // textBoxadmin
            // 
            this.textBoxadmin.Location = new System.Drawing.Point(77, 31);
            this.textBoxadmin.Name = "textBoxadmin";
            this.textBoxadmin.Size = new System.Drawing.Size(92, 21);
            this.textBoxadmin.TabIndex = 69;
            this.textBoxadmin.Text = "admin";
            // 
            // textBoxpsk
            // 
            this.textBoxpsk.Location = new System.Drawing.Point(77, 71);
            this.textBoxpsk.Name = "textBoxpsk";
            this.textBoxpsk.Size = new System.Drawing.Size(92, 21);
            this.textBoxpsk.TabIndex = 70;
            this.textBoxpsk.Text = "admin";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxpsk);
            this.groupBox1.Controls.Add(this.textBoxadmin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(570, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 125);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication information";
            // 
            // groupBoxUpgrade
            // 
            this.groupBoxUpgrade.Controls.Add(this.textBoxVersion);
            this.groupBoxUpgrade.Controls.Add(this.label23);
            this.groupBoxUpgrade.Controls.Add(this.label24);
            this.groupBoxUpgrade.Controls.Add(this.buttonimport);
            this.groupBoxUpgrade.Controls.Add(this.textBoximport);
            this.groupBoxUpgrade.Controls.Add(this.buttonupgrade);
            this.groupBoxUpgrade.Enabled = false;
            this.groupBoxUpgrade.Location = new System.Drawing.Point(1353, 25);
            this.groupBoxUpgrade.Name = "groupBoxUpgrade";
            this.groupBoxUpgrade.Size = new System.Drawing.Size(10, 67);
            this.groupBoxUpgrade.TabIndex = 108;
            this.groupBoxUpgrade.TabStop = false;
            this.groupBoxUpgrade.Visible = false;
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Location = new System.Drawing.Point(568, 28);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(171, 21);
            this.textBoxVersion.TabIndex = 71;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 23);
            this.label23.TabIndex = 72;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 23);
            this.label24.TabIndex = 73;
            // 
            // buttonimport
            // 
            this.buttonimport.Location = new System.Drawing.Point(0, 0);
            this.buttonimport.Name = "buttonimport";
            this.buttonimport.Size = new System.Drawing.Size(75, 23);
            this.buttonimport.TabIndex = 74;
            // 
            // textBoximport
            // 
            this.textBoximport.Location = new System.Drawing.Point(0, 0);
            this.textBoximport.Name = "textBoximport";
            this.textBoximport.Size = new System.Drawing.Size(100, 21);
            this.textBoximport.TabIndex = 75;
            // 
            // buttonupgrade
            // 
            this.buttonupgrade.Location = new System.Drawing.Point(0, 0);
            this.buttonupgrade.Name = "buttonupgrade";
            this.buttonupgrade.Size = new System.Drawing.Size(75, 23);
            this.buttonupgrade.TabIndex = 76;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.close);
            this.groupBox4.Controls.Add(this.Received);
            this.groupBox4.Controls.Add(this.textrec);
            this.groupBox4.Controls.Add(this.open);
            this.groupBox4.Location = new System.Drawing.Point(568, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(330, 159);
            this.groupBox4.TabIndex = 112;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Open request";
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(10, 104);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 36);
            this.close.TabIndex = 5;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Received
            // 
            this.Received.Location = new System.Drawing.Point(10, 20);
            this.Received.Name = "Received";
            this.Received.Size = new System.Drawing.Size(75, 36);
            this.Received.TabIndex = 4;
            this.Received.Text = "Received";
            this.Received.UseVisualStyleBackColor = true;
            this.Received.Click += new System.EventHandler(this.Received_Click);
            // 
            // textrec
            // 
            this.textrec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textrec.Location = new System.Drawing.Point(121, 25);
            this.textrec.Multiline = true;
            this.textrec.Name = "textrec";
            this.textrec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textrec.Size = new System.Drawing.Size(200, 120);
            this.textrec.TabIndex = 3;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(10, 62);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 36);
            this.open.TabIndex = 0;
            this.open.Text = "open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 34);
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxUpgrade);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGVscan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "wiscam Intelligent_building";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVscan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxUpgrade.ResumeLayout(false);
            this.groupBoxUpgrade.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReset;
        //private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timersearch;
        private System.Windows.Forms.Button buttonScan;
        public System.Windows.Forms.DataGridView dataGVscan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxadmin;
        private System.Windows.Forms.TextBox textBoxpsk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxUpgrade;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonimport;
        private System.Windows.Forms.TextBox textBoximport;
        private System.Windows.Forms.Button buttonupgrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn progress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.TextBox textrec;
        private System.Windows.Forms.Button Received;
        private System.Windows.Forms.Button close;
    }
}

