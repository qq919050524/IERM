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
    public class ElevatorAlarmMessage
    {
        private BLL.AlarmElevatorBLL _alarmBLL = new BLL.AlarmElevatorBLL();
        private BLL.ElevatorInfoBLL _infoBLL = new BLL.ElevatorInfoBLL();
        private BLL.SendMessageElevatorBLL _sendBLL = new BLL.SendMessageElevatorBLL();
        /// <summary>
        /// 发送电梯报警短信
        /// </summary>
        public void SendElevatorAlarm()
        {
            try
            {
                string strWhere = " insertTime > date_add(now(),interval -1 day)";
                List<Model.AlarmElevatorModel> list = _alarmBLL.GetCurrentAlarmElevator(strWhere);
                foreach (Model.AlarmElevatorModel model in list)
                {
                    if (model.alarmState == -1 && model.customCode != "other")
                    {
                        Model.SendMessageElevatorModel sendMessageModel = _sendBLL.getModel(model.aID, model.registrationCode);
                        if (sendMessageModel == null)
                        {
                            string strMsg = string.Format("小区名称：{0}。电梯：{1} - 异常。报警信息：{3}", model.communityName, model.elevatorPosition, model, model.errorCodeMean);
                            SendUserMessage(model, strMsg);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.Info("SendElevatorAlarm", "电梯异常发送短信失败：" + e.Message);
            }
        }



        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strMsg"></param>
        private void SendUserMessage(Model.AlarmElevatorModel model, string strMsg)
        {
            Action send = (() =>
            {
                BLL.ElevatorInfoBLL _infoBLL = new BLL.ElevatorInfoBLL();
                DataTable userDt = _infoBLL.GetUserMobile(model.registrationCode);
                if (userDt != null && userDt.Rows.Count > 0)
                {
                    foreach (DataRow userDr in userDt.Rows)
                    {
                        Model.SendMessageElevatorModel sendModel = new Model.SendMessageElevatorModel();
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
                       
                        sendModel.aID = model.aID;
                        sendModel.registrationCode = model.registrationCode;
                        sendModel.errorCodeType = model.errorCodeType;
                        sendModel.customCode = model.customCode;
                        sendModel.content = strMsg;
                        sendModel.mobile = strPhone;
                        sendModel.createTime = DateTime.Now;
                        _sendBLL.Add(sendModel);
                    }
                }
            });

            Task.Factory.StartNew(send);
        }
    }
}
