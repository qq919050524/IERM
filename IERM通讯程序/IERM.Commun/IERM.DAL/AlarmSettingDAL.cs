using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class AlarmSettingDAL
    {
        /// <summary>
        /// 报警设置
        /// </summary>
        /// <returns></returns>
        public List<MODEL.AlarmSettingModel> GetAllAlarmSetting()
        {
            return Common.MySQLHelper.ExecuteToList<MODEL.AlarmSettingModel>(string.Format("select ast.*,di.devName,alt.alarmName from alarmsetting as ast LEFT JOIN devinfo as di on di.devID = ast.devID LEFT JOIN alarmtype as alt on alt.alarmCode = ast.alarmCode where ast.isWork = 1"), null);
        }
    }
}
