using IERM.Message.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class AlarmSettingBLL
    {
        private readonly DAL.AlarmSettingDAL alarmsetting_dal = new DAL.AlarmSettingDAL();
        /// <summary>
        /// 报警设置
        /// </summary>
        /// <returns></returns>
        public List<AlarmSettingModel> GetAllAlarmSetting()
        {
            return alarmsetting_dal.GetAllAlarmSetting();
        }

        /// <summary>
        /// 判断是否发送短信
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <param name="alarmCode">预警编号</param>
        /// <returns></returns>
        public bool GetAlarmSettingSendMessage(string devID, string alarmCode)
        {

            return alarmsetting_dal.GetAlarmSettingSendMessage(devID, alarmCode);

        }
    }
}
