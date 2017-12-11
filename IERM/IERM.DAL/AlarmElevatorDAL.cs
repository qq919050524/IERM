using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class AlarmElevatorDAL
    {
        /// <summary>
        /// 实时报警记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ViewAlarmelevatorModel> GetCurrentAlarmElevator(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) from  view_alarmelevator a ");
            sqlCount.Append(" inner join( ");
            sqlCount.Append(" select max(aid) as aid from alarmelevator ");
            sqlCount.Append(" where insertTime > date_add(now(), interval -90 day) ");
            sqlCount.Append(" group by registrationcode,customcode) x ");
            sqlCount.Append(" on a.aid = x.aid ");
            sqlCount.Append(" where alarmState = -1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select aId, registrationCode, customCode, errorCodeType, errorCodeMean, alarmState, insertTime  ");
            sql.Append(" , elevatorPosition, communityId, communityName, propertyID, propertyName, cityID, cityName ");
            sql.Append(" , provinceID, provinceName ");
            sql.Append(" from  view_alarmelevator a ");
            sql.Append(" inner join( ");
            sql.Append(" select max(aid) as aid from alarmelevator ");
            sql.Append(" where insertTime > date_add(now(), interval -90 day) ");
            sql.Append(" group by registrationcode,customcode) x ");
            sql.Append(" on a.aid = x.aid ");
            sql.Append(" where alarmState = -1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by communityId,registrationCode,insertTime desc");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);

            return MySQLHelper.ExecuteToList<ViewAlarmelevatorModel>(sql.ToString(), null);

        }

        /// <summary>
        /// 历史报警记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ViewAlarmelevatorModel> GetHistoryAlarmElevator(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) from view_alarmelevator ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" where {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select aId, registrationCode, customCode, errorCodeType, errorCodeMean, alarmState, insertTime ");
            sql.Append(" , elevatorPosition, communityId, communityName, propertyID, propertyName, cityID, cityName ");
            sql.Append(" , provinceID, provinceName ");
            sql.Append(" from view_alarmelevator ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" where {0} ", strWhere);
            }
            sql.Append(" order by insertTime desc");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<ViewAlarmelevatorModel>(sql.ToString(), null);

        }
    }
}
