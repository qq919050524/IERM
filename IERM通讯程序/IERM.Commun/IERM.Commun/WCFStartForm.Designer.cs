namespace IERM.WCFService
{
    partial class WCFStartForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("运行监控", 2, 2);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("电梯监控", 5, 5);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("数据查询", 3, 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WCFStartForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tp_run = new System.Windows.Forms.TabPage();
            this.listbox_comm_log = new System.Windows.Forms.ListBox();
            this.tp_qur = new System.Windows.Forms.TabPage();
            this.dgv_errlog = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_errlog = new System.Windows.Forms.DateTimePicker();
            this.btn_errlog = new System.Windows.Forms.Button();
            this.tp_db = new System.Windows.Forms.TabPage();
            this.loading_dbtest = new IERM.WCFService.LoadingPanel();
            this.btn_db_connect = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.tbx_db_pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_db_user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_db_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_db_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tp_comm = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_addcomm = new System.Windows.Forms.Button();
            this.combox_cyc = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_comm_port = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbx_comm_ip = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tp_elevator = new System.Windows.Forms.TabPage();
            this.listbox_elevator_log = new System.Windows.Forms.ListBox();
            this.btn_start_commun = new System.Windows.Forms.Button();
            this.btn_start_wcf = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_EXIT = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_start_elevator = new System.Windows.Forms.Button();
            this.start_plan = new System.Windows.Forms.Button();
            this.tabControl_main.SuspendLayout();
            this.tp_run.SuspendLayout();
            this.tp_qur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_errlog)).BeginInit();
            this.panel1.SuspendLayout();
            this.tp_db.SuspendLayout();
            this.tp_comm.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tp_elevator.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 35;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "tree_monitor";
            treeNode1.SelectedImageIndex = 2;
            treeNode1.Text = "运行监控";
            treeNode2.ImageIndex = 5;
            treeNode2.Name = "tree_elevator";
            treeNode2.SelectedImageIndex = 5;
            treeNode2.Text = "电梯监控";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "tree_query";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Text = "数据查询";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(882, 456);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "common.png");
            this.imageList1.Images.SetKeyName(1, "database.png");
            this.imageList1.Images.SetKeyName(2, "monitor.png");
            this.imageList1.Images.SetKeyName(3, "query.png");
            this.imageList1.Images.SetKeyName(4, "setting.png");
            this.imageList1.Images.SetKeyName(5, "Elevator.ico");
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tp_run);
            this.tabControl_main.Controls.Add(this.tp_qur);
            this.tabControl_main.Controls.Add(this.tp_db);
            this.tabControl_main.Controls.Add(this.tp_comm);
            this.tabControl_main.Controls.Add(this.tp_elevator);
            this.tabControl_main.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl_main.Location = new System.Drawing.Point(178, 10);
            this.tabControl_main.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.Padding = new System.Drawing.Point(0, 0);
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(694, 425);
            this.tabControl_main.TabIndex = 1;
            // 
            // tp_run
            // 
            this.tp_run.Controls.Add(this.listbox_comm_log);
            this.tp_run.Location = new System.Drawing.Point(4, 5);
            this.tp_run.Margin = new System.Windows.Forms.Padding(1);
            this.tp_run.Name = "tp_run";
            this.tp_run.Padding = new System.Windows.Forms.Padding(1);
            this.tp_run.Size = new System.Drawing.Size(686, 416);
            this.tp_run.TabIndex = 0;
            this.tp_run.UseVisualStyleBackColor = true;
            // 
            // listbox_comm_log
            // 
            this.listbox_comm_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox_comm_log.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listbox_comm_log.FormattingEnabled = true;
            this.listbox_comm_log.HorizontalScrollbar = true;
            this.listbox_comm_log.ItemHeight = 16;
            this.listbox_comm_log.Location = new System.Drawing.Point(1, 1);
            this.listbox_comm_log.Name = "listbox_comm_log";
            this.listbox_comm_log.ScrollAlwaysVisible = true;
            this.listbox_comm_log.Size = new System.Drawing.Size(684, 414);
            this.listbox_comm_log.TabIndex = 0;
            // 
            // tp_qur
            // 
            this.tp_qur.Controls.Add(this.dgv_errlog);
            this.tp_qur.Controls.Add(this.panel1);
            this.tp_qur.Location = new System.Drawing.Point(4, 5);
            this.tp_qur.Name = "tp_qur";
            this.tp_qur.Padding = new System.Windows.Forms.Padding(3);
            this.tp_qur.Size = new System.Drawing.Size(686, 416);
            this.tp_qur.TabIndex = 1;
            this.tp_qur.UseVisualStyleBackColor = true;
            // 
            // dgv_errlog
            // 
            this.dgv_errlog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_errlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_errlog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_errlog.Location = new System.Drawing.Point(3, 89);
            this.dgv_errlog.Name = "dgv_errlog";
            this.dgv_errlog.RowTemplate.Height = 23;
            this.dgv_errlog.Size = new System.Drawing.Size(680, 324);
            this.dgv_errlog.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtp_errlog);
            this.panel1.Controls.Add(this.btn_errlog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 74);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "显示异常通讯日志";
            // 
            // dtp_errlog
            // 
            this.dtp_errlog.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_errlog.Location = new System.Drawing.Point(196, 23);
            this.dtp_errlog.Name = "dtp_errlog";
            this.dtp_errlog.Size = new System.Drawing.Size(200, 29);
            this.dtp_errlog.TabIndex = 1;
            // 
            // btn_errlog
            // 
            this.btn_errlog.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_errlog.Location = new System.Drawing.Point(420, 24);
            this.btn_errlog.Name = "btn_errlog";
            this.btn_errlog.Size = new System.Drawing.Size(162, 28);
            this.btn_errlog.TabIndex = 0;
            this.btn_errlog.Text = "查询";
            this.btn_errlog.UseVisualStyleBackColor = true;
            this.btn_errlog.Click += new System.EventHandler(this.btn_errlog_Click);
            // 
            // tp_db
            // 
            this.tp_db.BackColor = System.Drawing.SystemColors.Control;
            this.tp_db.Controls.Add(this.loading_dbtest);
            this.tp_db.Controls.Add(this.btn_db_connect);
            this.tp_db.Controls.Add(this.btn_save);
            this.tp_db.Controls.Add(this.tbx_db_pwd);
            this.tp_db.Controls.Add(this.label4);
            this.tp_db.Controls.Add(this.tbx_db_user);
            this.tp_db.Controls.Add(this.label3);
            this.tp_db.Controls.Add(this.tbx_db_name);
            this.tp_db.Controls.Add(this.label2);
            this.tp_db.Controls.Add(this.tbx_db_ip);
            this.tp_db.Controls.Add(this.label1);
            this.tp_db.Location = new System.Drawing.Point(4, 5);
            this.tp_db.Name = "tp_db";
            this.tp_db.Padding = new System.Windows.Forms.Padding(3);
            this.tp_db.Size = new System.Drawing.Size(686, 416);
            this.tp_db.TabIndex = 2;
            // 
            // loading_dbtest
            // 
            this.loading_dbtest.Alpha = 125;
            this.loading_dbtest.Location = new System.Drawing.Point(144, 62);
            this.loading_dbtest.Name = "loading_dbtest";
            this.loading_dbtest.Size = new System.Drawing.Size(341, 282);
            this.loading_dbtest.TabIndex = 10;
            this.loading_dbtest.Text = "loading_panel";
            this.loading_dbtest.TransparentBG = true;
            // 
            // btn_db_connect
            // 
            this.btn_db_connect.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_db_connect.Location = new System.Drawing.Point(338, 294);
            this.btn_db_connect.Name = "btn_db_connect";
            this.btn_db_connect.Size = new System.Drawing.Size(135, 41);
            this.btn_db_connect.TabIndex = 9;
            this.btn_db_connect.Text = "测试连接";
            this.btn_db_connect.UseVisualStyleBackColor = true;
            this.btn_db_connect.Click += new System.EventHandler(this.btn_db_connect_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.Location = new System.Drawing.Point(166, 294);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(135, 41);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存设置";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // tbx_db_pwd
            // 
            this.tbx_db_pwd.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_db_pwd.Location = new System.Drawing.Point(233, 216);
            this.tbx_db_pwd.Name = "tbx_db_pwd";
            this.tbx_db_pwd.PasswordChar = '*';
            this.tbx_db_pwd.Size = new System.Drawing.Size(221, 30);
            this.tbx_db_pwd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(149, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "登录密码:";
            // 
            // tbx_db_user
            // 
            this.tbx_db_user.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_db_user.Location = new System.Drawing.Point(233, 170);
            this.tbx_db_user.Name = "tbx_db_user";
            this.tbx_db_user.Size = new System.Drawing.Size(221, 30);
            this.tbx_db_user.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(163, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "登录名:";
            // 
            // tbx_db_name
            // 
            this.tbx_db_name.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_db_name.Location = new System.Drawing.Point(233, 119);
            this.tbx_db_name.Name = "tbx_db_name";
            this.tbx_db_name.Size = new System.Drawing.Size(221, 30);
            this.tbx_db_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(149, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名:";
            // 
            // tbx_db_ip
            // 
            this.tbx_db_ip.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_db_ip.Location = new System.Drawing.Point(233, 71);
            this.tbx_db_ip.Name = "tbx_db_ip";
            this.tbx_db_ip.Size = new System.Drawing.Size(221, 30);
            this.tbx_db_ip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(149, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库IP:";
            // 
            // tp_comm
            // 
            this.tp_comm.Controls.Add(this.groupBox2);
            this.tp_comm.Location = new System.Drawing.Point(4, 5);
            this.tp_comm.Name = "tp_comm";
            this.tp_comm.Padding = new System.Windows.Forms.Padding(3);
            this.tp_comm.Size = new System.Drawing.Size(686, 416);
            this.tp_comm.TabIndex = 3;
            this.tp_comm.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_addcomm);
            this.groupBox2.Controls.Add(this.combox_cyc);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbx_comm_port);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbx_comm_ip);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(113, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(390, 400);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "小区通信设置";
            // 
            // btn_addcomm
            // 
            this.btn_addcomm.Location = new System.Drawing.Point(167, 290);
            this.btn_addcomm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addcomm.Name = "btn_addcomm";
            this.btn_addcomm.Size = new System.Drawing.Size(139, 35);
            this.btn_addcomm.TabIndex = 13;
            this.btn_addcomm.Text = "保存";
            this.btn_addcomm.UseVisualStyleBackColor = true;
            // 
            // combox_cyc
            // 
            this.combox_cyc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_cyc.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combox_cyc.FormattingEnabled = true;
            this.combox_cyc.Items.AddRange(new object[] {
            "100毫秒",
            "300毫秒",
            "500毫秒",
            "1秒",
            "3秒",
            "5秒"});
            this.combox_cyc.Location = new System.Drawing.Point(143, 183);
            this.combox_cyc.Margin = new System.Windows.Forms.Padding(2);
            this.combox_cyc.Name = "combox_cyc";
            this.combox_cyc.Size = new System.Drawing.Size(197, 33);
            this.combox_cyc.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 188);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 11;
            this.label10.Text = "通信周期：";
            // 
            // tbx_comm_port
            // 
            this.tbx_comm_port.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.tbx_comm_port.Location = new System.Drawing.Point(143, 124);
            this.tbx_comm_port.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_comm_port.Name = "tbx_comm_port";
            this.tbx_comm_port.Size = new System.Drawing.Size(197, 32);
            this.tbx_comm_port.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 130);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "端口号：";
            // 
            // tbx_comm_ip
            // 
            this.tbx_comm_ip.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.tbx_comm_ip.Location = new System.Drawing.Point(143, 66);
            this.tbx_comm_ip.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_comm_ip.Name = "tbx_comm_ip";
            this.tbx_comm_ip.Size = new System.Drawing.Size(197, 32);
            this.tbx_comm_ip.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "通信地址：";
            // 
            // tp_elevator
            // 
            this.tp_elevator.Controls.Add(this.listbox_elevator_log);
            this.tp_elevator.Location = new System.Drawing.Point(4, 5);
            this.tp_elevator.Name = "tp_elevator";
            this.tp_elevator.Size = new System.Drawing.Size(686, 416);
            this.tp_elevator.TabIndex = 4;
            this.tp_elevator.UseVisualStyleBackColor = true;
            // 
            // listbox_elevator_log
            // 
            this.listbox_elevator_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox_elevator_log.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listbox_elevator_log.FormattingEnabled = true;
            this.listbox_elevator_log.ItemHeight = 16;
            this.listbox_elevator_log.Location = new System.Drawing.Point(0, 0);
            this.listbox_elevator_log.Name = "listbox_elevator_log";
            this.listbox_elevator_log.Size = new System.Drawing.Size(686, 416);
            this.listbox_elevator_log.TabIndex = 0;
            // 
            // btn_start_commun
            // 
            this.btn_start_commun.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start_commun.Location = new System.Drawing.Point(50, 293);
            this.btn_start_commun.Name = "btn_start_commun";
            this.btn_start_commun.Size = new System.Drawing.Size(112, 31);
            this.btn_start_commun.TabIndex = 1;
            this.btn_start_commun.Text = "启动通讯";
            this.btn_start_commun.UseVisualStyleBackColor = true;
            this.btn_start_commun.Click += new System.EventHandler(this.btn_start_commun_Click);
            // 
            // btn_start_wcf
            // 
            this.btn_start_wcf.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start_wcf.Location = new System.Drawing.Point(50, 367);
            this.btn_start_wcf.Name = "btn_start_wcf";
            this.btn_start_wcf.Size = new System.Drawing.Size(112, 34);
            this.btn_start_wcf.TabIndex = 2;
            this.btn_start_wcf.Text = "启动WCF";
            this.btn_start_wcf.UseVisualStyleBackColor = true;
            this.btn_start_wcf.Click += new System.EventHandler(this.btn_start_wcf_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "后台运行中....";
            this.notifyIcon1.BalloonTipTitle = "ECCM数据通信程序";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ECCM数据通信程序";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_EXIT});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // TSMI_EXIT
            // 
            this.TSMI_EXIT.Name = "TSMI_EXIT";
            this.TSMI_EXIT.Size = new System.Drawing.Size(100, 22);
            this.TSMI_EXIT.Text = "退出";
            this.TSMI_EXIT.Click += new System.EventHandler(this.TSMI_EXIT_Click);
            // 
            // btn_start_elevator
            // 
            this.btn_start_elevator.Font = new System.Drawing.Font("黑体", 14.25F);
            this.btn_start_elevator.Location = new System.Drawing.Point(50, 330);
            this.btn_start_elevator.Name = "btn_start_elevator";
            this.btn_start_elevator.Size = new System.Drawing.Size(112, 31);
            this.btn_start_elevator.TabIndex = 3;
            this.btn_start_elevator.Text = "电梯监控";
            this.btn_start_elevator.UseVisualStyleBackColor = true;
            this.btn_start_elevator.Click += new System.EventHandler(this.btn_start_elevator_Click);
            // 
            // start_plan
            // 
            this.start_plan.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start_plan.Location = new System.Drawing.Point(50, 407);
            this.start_plan.Name = "start_plan";
            this.start_plan.Size = new System.Drawing.Size(112, 31);
            this.start_plan.TabIndex = 4;
            this.start_plan.Text = "启动计划";
            this.start_plan.UseVisualStyleBackColor = true;
            this.start_plan.Click += new System.EventHandler(this.start_plan_Click);
            // 
            // WCFStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(882, 456);
            this.Controls.Add(this.start_plan);
            this.Controls.Add(this.btn_start_elevator);
            this.Controls.Add(this.btn_start_wcf);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.btn_start_commun);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(898, 494);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(869, 494);
            this.Name = "WCFStartForm";
            this.ShowInTaskbar = false;
            this.Text = "ECCM数据通讯系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl_main.ResumeLayout(false);
            this.tp_run.ResumeLayout(false);
            this.tp_qur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_errlog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tp_db.ResumeLayout(false);
            this.tp_db.PerformLayout();
            this.tp_comm.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tp_elevator.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tp_run;
        private System.Windows.Forms.TabPage tp_qur;
        private System.Windows.Forms.TabPage tp_db;
        private System.Windows.Forms.TabPage tp_comm;
        private System.Windows.Forms.Button btn_db_connect;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tbx_db_pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_db_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_db_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_db_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private LoadingPanel loading_dbtest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_addcomm;
        private System.Windows.Forms.ComboBox combox_cyc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbx_comm_port;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbx_comm_ip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listbox_comm_log;
        private System.Windows.Forms.Button btn_start_wcf;
        private System.Windows.Forms.Button btn_start_commun;
        private System.Windows.Forms.DataGridView dgv_errlog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_errlog;
        private System.Windows.Forms.Button btn_errlog;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_EXIT;
        private System.Windows.Forms.Button btn_start_elevator;
        private System.Windows.Forms.TabPage tp_elevator;
        private System.Windows.Forms.ListBox listbox_elevator_log;
        private System.Windows.Forms.Button start_plan;
    }
}

