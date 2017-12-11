
using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public partial class AlarmSettingDAL
    {
        /// <summary>
        /// 获取指定设备类型的报警类型
        /// </summary>
        /// <param name="devtype"></param>
        /// <returns></returns>
        public List<AlarmSettingModel> GetAlarmTypeListByDevType(int devtype)
        {
            return MySQLHelper.ExecuteToList<AlarmSettingModel>(string.Format("SELECT * from alarmtype where isDel=0 and (devType=0 or devType={0}) ORDER BY isDigital,alarmCode", devtype), null);
        }

        /// <summary>
        /// 获取指定设备的报警设置
        /// </summary>
        /// <param name="devtype"></param>
        /// <returns></returns>
        public List<AlarmSettingModel> GetAlarmListByDevID(int devid)
        {
            StringBuilder cmdstr = new StringBuilder();
            cmdstr.Append("SELECT alt.alarmCode,alt.alarmName,alt.devType,alt.isDigital,alt.isDel,");
            cmdstr.Append("als.sid,als.devID,als.`maxValue`,als.minValue,als.isWork,als.`delayed`,als.isSend");
            cmdstr.Append(" from alarmtype as alt");
            cmdstr.Append(" LEFT JOIN alarmsetting as als on als.alarmCode = alt.alarmCode");
            cmdstr.AppendFormat(" where alt.isDel = 0 and als.devID={0}", devid);
            cmdstr.Append(" ORDER BY isDigital,alarmCode");
            return MySQLHelper.ExecuteToList<AlarmSettingModel>(cmdstr.ToString(), null);
        }

        /// <summary>
        /// 保存报警设置
        /// </summary>
        /// <param name="cmdlist"></param>
        /// <returns></returns>
        public int SaveAlarmSetting(List<string> cmdlist)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdlist);
        }

        /// <summary>
        /// 删除报警
        /// </summary>
        /// <param name="cmdstr"></param>
        /// <returns></returns>
        public int DeleteAlarmSetting(List<string> cmdstr)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdstr);
        }

        public bool GetAlarmSettingSendMessage(string alarmCode)
        {
            string strSql = string.Format(" select isSend from alarmsetting where  alarmCode='{0}'", alarmCode);

            object obj = MySQLHelper.ExecuteScalar(strSql);
            if (obj != null && obj.ToString() == "1")
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
