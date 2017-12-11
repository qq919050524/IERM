using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class AlarmSettingBLL
    {
        private readonly DAL.AlarmSettingDAL alarmsetting_dal = new DAL.AlarmSettingDAL();
        /// <summary>
        /// 报警设置
        /// </summary>
        /// <returns></returns>
        public List<MODEL.AlarmSettingModel> GetAllAlarmSetting()
        {
            return alarmsetting_dal.GetAllAlarmSetting();
        }
    }
}
