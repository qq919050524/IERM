using IERM.Message.BLL;
using IERM.Message.Common;
using IERM.Message.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IERM.Message
{
    /// <summary>
    /// 发送消息类
    /// </summary>
    public class AlarmMessage
    {

        public void GetAlarmInfo()
        {
            //判断当前是否启用发送短信
            AlarmLogBLL log = new AlarmLogBLL();

            string strWhere = string.Format(" insertTime>date_add(now(), interval -1 minute)", DateTime.Now);
            DataTable logDt = log.GetList(strWhere);
            //取得报警信息

            foreach (DataRow dr in logDt.Rows)
            {
                //判断上次消息状态是否变化
                strWhere = string.Format(" l.devID={0} AND l.alarmCode='{1}'", dr["devID"].ToString(), dr["alarmCode"].ToString());
                DataTable alarmTable = log.GetList(2, strWhere);
                if (alarmTable.Rows.Count == 2)
                {
                    /*
                    1.当最新两条记录状态相同时，不发送短信
                    2.状态发生变化则发送短信
                    */
                    if (alarmTable.Rows[0]["alarmState"].ToString() != alarmTable.Rows[1]["alarmState"].ToString())
                    {
                        SendAlarmMsg(dr);
                    }
                }
                else
                {
                    //小于两条记录且有警告消息时，发送消息
                    if (alarmTable.Rows[0]["alarmState"].ToString() != "1")
                    {
                        SendAlarmMsg(dr);
                    }
                }

            }
        }

        /// <summary>
        /// 发送异常消息
        /// </summary>
        /// <param name="dr"></param>
        public void SendAlarmMsg(DataRow dr)
        {
            AlarmSettingBLL setting = new AlarmSettingBLL();
            SendMessageBLL msg = new SendMessageBLL();
            string alarmCode = dr["alarmCode"].ToString();
            string devID = dr["devID"].ToString();

            ////判断是否有发送短信记录
            //string strMsgWhere = string.Format(" alarmState<>1 and devID={0} and alarmCode='{1}'", devID, alarmCode);
            //DataTable dtMsg = msg.GetList(strMsgWhere);

            //if (dtMsg.Rows.Count == 0)
            //{
            //当为异常信息时发送短信
            if (dr["alarmState"].ToString() != "1")
            {
                //由设备名字，报警名字，报警信息
                string stateName = string.Empty;
                #region 取得报警信息
                switch (dr["alarmState"].ToString())
                {
                    case "-2":
                        stateName = "过低";
                        break;
                    case "2":
                        stateName = "过高";
                        break;
                    case "-1":
                        stateName = "异常";
                        break;
                    case "1":
                        stateName = "正常";
                        break;
                    default:
                        stateName = "正常";
                        break;
                }
                #endregion
                string strMsg = string.Format("小区名称：{0},设备名称：{1},{2},状态：{3}", dr["communityName"].ToString(), dr["devName"].ToString(), dr["alarmName"].ToString(), stateName);

                //判断当前报警编码是否发送短信
                if (setting.GetAlarmSettingSendMessage(devID, alarmCode))
                {
                    #region 发送信息
                    SendUserMessage(dr, strMsg);
                    #endregion
                }
                else
                {
                    LogHelper.Info("GetAlarmSettingSendMessage", "设备编号：" + devID + "\t预警编码：" + alarmCode + "\t不发送短信");
                }

                #region 增加工单记录
                //MainTenanceLogBLL maintenance = new MainTenanceLogBLL();
                //MainTenanceLogModel modelLog = new MainTenanceLogModel();
                //modelLog.settingID = 0;
                //modelLog.devhouseID = Convert.ToInt32(devID);
                //modelLog.orderCode = alarmCode + DateTime.Now.ToString("yyyyMMddHHmmssfff") + (Encoding.ASCII.GetBytes(alarmCode).Sum(k => k / new Random().NextDouble()) % 1000).ToString("000");
                //modelLog.orderContent = strMsg;
                //modelLog.orderType = 1;
                //modelLog.createTime = DateTime.Now;
                //modelLog.status = 1;
                //maintenance.Add(modelLog);
                #endregion
            }
            else
            {
                //将发送状态改为正常
                msg.UpdateStatus(Convert.ToInt32(devID), alarmCode);
            }
            //}

        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strMsg"></param>
        private static void SendUserMessage(DataRow dr, string strMsg)
        {
            Action send = (() =>
            {
                //根据设备 编号取得对应小区的发送人
                DevinfoBLL devinfo = new DevinfoBLL();
                DataTable userDt = devinfo.GetUserByDev(dr["devID"].ToString());

                if (userDt != null && userDt.Rows.Count > 0)
                {
                    SendMessageBLL msg = new SendMessageBLL();
                    SendMessageModel sendModel = new SendMessageModel();
                    sendModel.createTime = DateTime.Now;
                    foreach (DataRow userDr in userDt.Rows)
                    {
                        string strPhone = userDr["mobile"].ToString();
                        SMSReceiveModel resultModel = YunRongSDK.SendSMS(strPhone, strMsg);
                        if (resultModel != null)
                        {
                            sendModel.sendResult = resultModel.statusMsg;
                        }
                        else
                        {
                            sendModel.sendResult = "";
                        }
                        sendModel.devID = Convert.ToInt32(dr["devID"].ToString());
                        sendModel.alarmCode = dr["alarmCode"].ToString();
                        sendModel.alarmState = Convert.ToInt32(dr["alarmState"]);
                        sendModel.content = strMsg;
                        sendModel.mobile = strPhone;
                        msg.Add(sendModel);
                    }
                }
            });

            Task.Factory.StartNew(send);
        }
    }
}
