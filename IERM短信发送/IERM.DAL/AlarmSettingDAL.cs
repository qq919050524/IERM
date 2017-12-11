using IERM.Message.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.DAL
{
    public class AlarmSettingDAL
    {
        /// <summary>
        /// 报警设置
        /// </summary>
        /// <returns></returns>
        public List<AlarmSettingModel> GetAllAlarmSetting()
        {
            string strSql = string.Format("select ast.*,di.devName,alt.alarmName from alarmsetting as ast LEFT JOIN devinfo as di on di.devID = ast.devID LEFT JOIN alarmtype as alt on alt.alarmCode = ast.alarmCode where ast.isWork = 1");
            return MySQLHelper.ExecuteToList<AlarmSettingModel>(strSql, null);
        }

        /// <summary>
        /// 判断是否发送短信
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <param name="alarmCode">预警编号</param>
        /// <returns></returns>
        public bool GetAlarmSettingSendMessage(string devID, string alarmCode)
        {
            string strSql = string.Format(" select isSend from alarmsetting where devID={0} and   alarmCode='{1}'", devID, alarmCode);

            object obj = MySQLHelper.ExecuteScalar(strSql);
            if (obj != null && obj.ToString() == "1")
            //    if (obj != null)   //liuli :设备凡是发生了变化就发送短信
                {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
