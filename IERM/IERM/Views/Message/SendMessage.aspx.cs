
using IERM.BLL;
using IERM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.Message
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            //设置配置文件为启动状态
            //ConfigerHelper.SetAppSetting("SendMessage", "true");
            SendMessageBLL sendMsg = new SendMessageBLL();
            System.Threading.Timer bktimer = new System.Threading.Timer(o =>
            {
                sendMsg.GetAlarmInfo();
            }, this, 0, 60 * 1000);
            //dueTime：调用 callback 之前延迟的时间量（以毫秒为单位）。指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。
            //Period：调用 callback 的时间间隔（以毫秒为单位）。指定 Timeout.Infinite 可以禁用定期终止。
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            //设置配置文件为启动状态
            ConfigerHelper.SetAppSetting("SendMessage", "false");
        }
    }
}