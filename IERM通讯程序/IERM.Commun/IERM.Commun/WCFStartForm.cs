
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IERM.WCFService
{
    public partial class WCFStartForm : Form
    {
        private readonly BLL.CommunicationLogBLL commlog_bll = new BLL.CommunicationLogBLL();

        private ServiceHost host = null;

        /// <summary>
        /// 通讯实体模型
        /// </summary>
        public static ComunicationModel commModel;

        /// <summary>
        /// 电梯实体模型
        /// </summary>
        public static ElevatorModel elevatorModel;

        public WCFStartForm()
        {
            InitializeComponent();
            this.loading_dbtest.CloseWaitingPanel();
            combox_cyc.SelectedIndex = 2;
            InitCommunModel();
            InitElevatorModel();

        }

        #region -------------------数据库配置------------------
        private void btn_db_connect_Click(object sender, EventArgs e)
        {
            string connstr = string.Format("Server={0};Database={1};User={2};Password={3};Use Procedure Bodies=false;Charset=utf8;Allow Zero Datetime=True;Pooling=false;Max Pool Size=100;port=3306", tbx_db_ip.Text.Trim(), tbx_db_name.Text.Trim(), tbx_db_user.Text.Trim(), tbx_db_pwd.Text.Trim());

            this.loading_dbtest.ShowWaitingPanel();
            var func = new Func<string, bool>(Common.MySQLHelper.StringConnTest);
            var asynResult = func.BeginInvoke(connstr, (result) =>
            {
                bool ret = func.EndInvoke(result);
                this.loading_dbtest.CloseWaitingPanel();
                if (ret) { MessageBox.Show("连接测试成功！"); } else { MessageBox.Show("连接测试失败！"); }
            }, null);

        }
        private void InitConnectstr()
        {
            string connstr = Common.ConfigerHelper.GetConnectionString();
            if (string.IsNullOrEmpty(connstr))
            {
                this.tbx_db_ip.Text = string.Empty;
                this.tbx_db_name.Text = string.Empty;
                this.tbx_db_user.Text = string.Empty;
                this.tbx_db_pwd.Text = string.Empty;
            }
            else
            {
                var matche = Regex.Match(connstr, "Server=(.+?);Database=(.+?);User=(.+?);Password=(.+?);.+", RegexOptions.IgnoreCase);
                this.tbx_db_ip.Text = matche.Groups[1].Value;
                this.tbx_db_name.Text = matche.Groups[2].Value;
                this.tbx_db_user.Text = matche.Groups[3].Value;
                this.tbx_db_pwd.Text = matche.Groups[4].Value;
            }
        }
        #endregion

        #region ------------运行监控通信------------------

        /// <summary>
        /// 获取通讯周期
        /// </summary>
        /// <returns></returns>
        private int GetSecond()
        {
            int msecond = 0;
            switch (combox_cyc.SelectedIndex)
            {
                case 0:
                    msecond = 100;
                    break;
                case 1:
                    msecond = 300;
                    break;
                case 2:
                    msecond = 500;
                    break;
                case 3:
                    msecond = 1000;
                    break;
                case 4:
                    msecond = 3000;
                    break;
                case 5:
                    msecond = 5000;
                    break;
                default:
                    msecond = 10000;
                    break;
            }
            return msecond;
        }

        private void SelSecond(int msec)
        {
            switch (msec)
            {
                case 100:
                    combox_cyc.SelectedIndex = 0;
                    break;
                case 300:
                    combox_cyc.SelectedIndex = 1;
                    break;
                case 500:
                    combox_cyc.SelectedIndex = 2;
                    break;
                case 1000:
                    combox_cyc.SelectedIndex = 3;
                    break;
                case 3000:
                    combox_cyc.SelectedIndex = 4;
                    break;
                default:
                    combox_cyc.SelectedIndex = 5;
                    break;
            }
        }

        /// <summary>
        /// 显示通讯日志
        /// </summary>
        /// <param name="logmsg"></param>
        private void ShowCommLog(string logmsg)
        {
            this.listbox_comm_log.Invoke(new Action<string>(m =>
            {
                if (this.listbox_comm_log.Items.Count > 1000)
                {
                    this.listbox_comm_log.Items.Clear();
                }
                this.listbox_comm_log.Items.Insert(0, m);
            }), logmsg);
        }
        /// <summary>
        /// 初始化通讯实体
        /// </summary>
        private void InitCommunModel()
        {
            var dict = Common.ConfigerHelper.GetAppSettings();
            if (dict.Count == 0) return;
            var match = Regex.Match(dict[0], "ip:(.+?),port:(.+?),cyc:(.+)", RegexOptions.IgnoreCase);
            if (match.Groups.Count < 4) return;

            commModel = new ComunicationModel()
            {
                CommunityID = 0,
                CommunityName = "通信总服务器",
                CommIP = match.Groups[1].Value,
                CommPort = Convert.ToInt32(match.Groups[2].Value),
                CommCyc = Convert.ToInt32(match.Groups[3].Value),
                SkClient = null,
                ShowMsg = ShowCommLog,
                //DictDevHouse = LoadAllDevhouse()
            };
        }

        /// <summary>
        /// 载入通讯配置
        /// </summary>
        private void LoadCommunConfig()
        {
            var dict = Common.ConfigerHelper.GetAppSettings();
            if (dict.Count == 0) return;
            var match = Regex.Match(dict[0], "ip:(.+?),port:(.+?),cyc:(.+)", RegexOptions.IgnoreCase);
            if (match.Groups.Count < 4) return;
            tbx_comm_ip.Text = match.Groups[1].Value;
            tbx_comm_port.Text = match.Groups[2].Value;
            SelSecond(int.Parse(match.Groups[3].Value));
        }

        /// <summary>
        /// 启动通讯程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_commun_Click(object sender, EventArgs e)
        {
            this.btn_start_commun.Enabled = false;
            if (commModel != null)
            {
                try
                {
                    Task.Factory.StartNew(commModel.StartClient);
                }
                catch (Exception err)
                {
                    MessageBox.Show("通信程序启动失败！" + err.Message);
                    Common.LogHelper.Dbbug("通信程序启动失败！" + err.Message);
                    this.btn_start_commun.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("尚未配置通讯，无法启动！");
                Common.LogHelper.Dbbug("尚未配置通讯，无法启动！");
                this.btn_start_commun.Enabled = true;
            }

        }

        #endregion

        #region 电梯

        /// <summary>
        /// 初始化电梯实体
        /// </summary>
        private void InitElevatorModel()
        {

            elevatorModel = new ElevatorModel()
            {
                ShowMsg = ShowElevatorLog,
            };
        }
        /// <summary>
        /// 启动电梯监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_elevator_Click(object sender, EventArgs e)
        {
            this.btn_start_elevator.Enabled = false;
            if (elevatorModel.elevatorList.Count > 0)
            {
                try
                {
                    Task.Factory.StartNew(elevatorModel.StartClient);
                }
                catch (Exception err)
                {
                    MessageBox.Show("电梯监控启动失败！" + err.Message);
                    Common.LogHelper.Dbbug("通电梯监控启动失败！" + err.Message);
                    this.btn_start_elevator.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("电梯监控，无法启动，没有绑定电梯注册码");
                Common.LogHelper.Dbbug("电梯监控，无法启动,没有绑定电梯注册码");
                this.btn_start_elevator.Enabled = true;
            }
        }
        /// <summary>
        /// 显示电梯日志
        /// </summary>
        /// <param name="logmsg"></param>
        private void ShowElevatorLog(string logmsg)
        {
            this.listbox_elevator_log.Invoke(new Action<string>(m =>
            {
                if (this.listbox_elevator_log.Items.Count > 1000)
                {
                    this.listbox_elevator_log.Items.Clear();
                }
                this.listbox_elevator_log.Items.Insert(0, m);
            }), logmsg);
        }
        #endregion

        /// <summary>
        /// 启动WCF服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_wcf_Click(object sender, EventArgs e)
        {
            try
            {
                host = new ServiceHost(typeof(IERMService));
                host.Open();
                this.btn_start_wcf.Enabled = false;
                ShowCommLog(string.Format("{0} WCF服务于启动", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch (Exception err)
            {
                host = null;
                MessageBox.Show(err.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "运行监控":
                    tabControl_main.SelectTab("tp_run");
                    break;
                case "电梯监控":
                    tabControl_main.SelectTab("tp_elevator");
                    break;
                case "数据查询":
                    tabControl_main.SelectTab("tp_qur");
                    break;
                case "数据库":
                    tabControl_main.SelectTab("tp_db");
                    InitConnectstr();
                    break;
                case "通讯":
                    tabControl_main.SelectTab("tp_comm");
                    LoadCommunConfig();
                    break;
                default:
                    tabControl_main.SelectTab("tp_comm");
                    LoadCommunConfig();
                    break;
            }
        }

        private void btn_errlog_Click(object sender, EventArgs e)
        {
            var data = commlog_bll.GetCommLog(dtp_errlog.Value);

            dgv_errlog.DataSource = data.Select(s => new
            {
                cid = s.cid,
                dataSize = s.dataSize,
                data = Common.BinaryHelper.byteToHexStr(s.data, s.data.Count()),
                InsertTime = s.InsertTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(2000);
        }

        private void TSMI_EXIT_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

            this.notifyIcon1.Visible = false;
        }

        /// <summary>
        /// 启动定时计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_plan_Click(object sender, EventArgs e)
        {
            this.start_plan.Enabled = false;
            try
            {
                Task.Factory.StartNew(PlanToOrder.StartClient);
            }
            catch (Exception err)
            {
                Common.LogHelper.Dbbug("定时计划启动失败！" + err.Message);
                this.start_plan.Enabled = true;
            }
        }
    }
}
