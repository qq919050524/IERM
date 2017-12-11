using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.DAL
{
    public class AlarmElevatorDAL
    {
        /// <summary>
        /// 获取电梯最新的报警记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Model.AlarmElevatorModel> GetCurrentAlarmElevator(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select * from( ");
            sql.Append("  select a.aId, a.registrationCode, a.customCode, a.errorCodeType, a.errorCodeMean, a.alarmState, a.insertTime, ");
            sql.Append("  e.elevatorPosition, e.communityId, c.communityName ");
            sql.Append("  from alarmelevator a ");
            sql.Append("  left join elevatorinfo e on a.registrationCode = e.registrationCode ");
            sql.Append("  left join communityinfo c on c.communityID = e.communityID ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" where {0} ", strWhere);
            }
            sql.Append("  order by insertTime desc ");
            sql.Append(" ) temp ");
            sql.Append(" group by registrationCode, customCode ");

            return MySQLHelper.ExecuteToList<Model.AlarmElevatorModel>(sql.ToString(), null);

        }
    }
}
