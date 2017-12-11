using IERM.Common;
using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IERM.BLL
{
    public class SendMessageBLL
    {
        private readonly SendMessageDAL dal = new SendMessageDAL();
        public SendMessageBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sendmsgID)
        {
            return dal.Exists(sendmsgID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SendMessageModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SendMessageModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更改发送状态为正常
        /// </summary>
        public bool UpdateStatus(string alarmCode, string devID)
        {
            return dal.UpdateStatus(alarmCode, devID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sendmsgID)
        {

            return dal.Delete(sendmsgID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string sendmsgIDlist)
        {
            return dal.DeleteList(sendmsgIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SendMessageModel GetModel(int sendmsgID)
        {

            return dal.GetModel(sendmsgID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SendMessageModel> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SendMessageModel> DataTableToList(DataTable dt)
        {
            List<SendMessageModel> modelList = new List<SendMessageModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SendMessageModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public void GetAlarmInfo()
        {
            //判断当前是否启用发送短信
            AlarmLogBLL log = new AlarmLogBLL();

            string strWhere = string.Format(" insertTime>now()", DateTime.Now);
            DataTable logDt = log.GetList(strWhere);
            //取得报警信息

            foreach (DataRow dr in logDt.Rows)
            {
                SendAlarmMsg(dr);
            }
        }

        public void SendAlarmMsg(DataRow dr)
        {
            AlarmSettingBLL setting = new AlarmSettingBLL();
            SendMessageBLL msg = new SendMessageBLL();

            //判断是否有发送短信记录
            string alarmCode = dr["alarmCode"].ToString();
            string devID = dr["devID"].ToString();
            string strMsgWhere = string.Format(" alarmState<>1 and devID={0} and alarmCode='{1}'", devID, alarmCode);
            DataTable dtMsg = msg.GetList(strMsgWhere);
            if (dtMsg.Rows.Count == 0)
            {
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
                    string strMsg = string.Format("'{0}','{1}',{2}", dr["devName"].ToString(), dr["alarmName"].ToString(), stateName);

                    //判断当前报警编码是否发送短信
                    if (setting.GetAlarmSettingSendMessage(alarmCode))
                    {
                        #region 发送信息
                        SendUserMessage(dr, strMsg);
                        #endregion
                    }

                    #region 增加工单记录
                    MainTenanceLogBLL maintenance = new MainTenanceLogBLL();
                    MainTenanceLogModel modelLog = new MainTenanceLogModel();
                    modelLog.settingID = 0;
                    modelLog.devhouseID = Convert.ToInt32(devID);
                    modelLog.orderCode = alarmCode + DateTime.Now.ToString("yyMMddHHmmssfff") + (Encoding.ASCII.GetBytes(alarmCode).Sum(k => k / new Random().NextDouble()) % 1000).ToString("000");
                    modelLog.orderContent = strMsg;
                    modelLog.orderType = 1;
                    modelLog.createTime = DateTime.Now;
                    modelLog.status = 1;
                    maintenance.Add(modelLog);
                    #endregion
                }
                else
                {
                    //将发送状态改为正常
                    msg.UpdateStatus(devID, alarmCode);
                }
            }

        }

        private static void SendUserMessage(DataRow dr, string strMsg)
        {
            Action send = (() =>
            {
                //根据设备 编号取得对应小区的发送人
                //string strPhone = "13476116775";
                DevInfoBLL devinfo = new DevInfoBLL();
                DataTable userDt = devinfo.GetUserByDev(dr["devID"].ToString());

                if (userDt != null && userDt.Rows.Count > 0)
                {
                    string strPhones = string.Empty;
                    foreach (DataRow userDr in userDt.Rows)
                    {
                        strPhones += userDr["mobile"].ToString() + ",";
                    }
                    strPhones = strPhones.TrimEnd(',');
                    Dictionary<string, object> resultDic = YunRongSDK.SendBatchSMS(strPhones, strMsg);
                    SendMessageBLL msg = new SendMessageBLL();
                    SendMessageModel model = new SendMessageModel();
                    model.devID = Convert.ToInt32(dr["devID"].ToString());
                    model.alarmCode = dr["alarmCode"].ToString();
                    model.alarmState = Convert.ToInt32(dr["alarmState"]);
                    model.content = strMsg;
                    model.mobile = strPhones;
                    if (resultDic != null && resultDic["statusCode"].ToString() == "0")
                    {
                        model.sendResult = "发送成功";
                    }
                    else
                    {
                        model.sendResult = resultDic["statusMsg"].ToString();
                    }
                    model.createTime = DateTime.Now;
                    msg.Add(model);
                }
            });

            Task.Factory.StartNew(send);
        }

        #endregion  BasicMethod
    }
}
