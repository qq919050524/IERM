
using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
    /// 报警日志
    /// </summary>
    public partial class AlarmLogDAL
    {
        /// <summary>
        /// 获取实时报警记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<ViewAlarmlogModel> GetCurrentAlarmLog(string strWhere, int pageindex, int pagesize, out int alarmCount)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) from  view_alarmlog a ");
            sqlCount.Append(" inner join( ");
            sqlCount.Append(" select max(aid) as aid from view_alarmlog ");
            sqlCount.Append(" where insertTime > date_add(now(), interval -90 day) ");
            sqlCount.Append(" group by communityName,alarmCode) x ");
            sqlCount.Append(" on a.aid = x.aid ");
            sqlCount.Append(" where alarmState != 1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            alarmCount = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select a.aid,alarmCode,insertTime,alarmValue,alarmState,alarmName,devName ");
            sql.Append(" ,communityName,propertyName,cityName,provinceName, devTypeName,systypeID,systypeName ");
            sql.Append(" from  view_alarmlog a ");
            sql.Append(" inner join( ");
            sql.Append(" select max(aid) as aid from view_alarmlog ");
            sql.Append(" where insertTime > date_add(now(), interval -90 day) ");
            sql.Append(" group by communityName,alarmCode) x ");
            sql.Append(" on a.aid = x.aid ");
            sql.Append(" where alarmState != 1 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by communityName,insertTime desc ");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<ViewAlarmlogModel>(string.Format(sql.ToString(), strWhere, (pageindex - 1) * pagesize, pagesize), null);
        }


        /// <summary>
        /// 获取报警记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<ViewAlarmlogModel> GetAlarmLog(string strWhere, int pageindex, int pagesize, out int alarmCount)
        {
            alarmCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) FROM view_alarmlog " + strWhere, null));

            return MySQLHelper.ExecuteToList<ViewAlarmlogModel>(string.Format("SELECT aid,alarmCode,insertTime,alarmValue, alarmState, alarmName,devName, communityName, propertyName,cityName, provinceName, devTypeName,systypeID,systypeName FROM view_alarmlog {0} order by insertTime desc LIMIT {1},{2}", strWhere, (pageindex - 1) * pagesize, pagesize), null);
        }

        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select aID, l.devID, devName, l.alarmCode, alarmName,alarmValue,alarmState,insertTime ");
            strSql.Append(" from alarmlog l ");
            strSql.Append(" left join devinfo d on d.devid = l.devid ");
            strSql.Append(" left join alarmtype a on a.alarmcode = l.alarmcode ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by devID desc");

            DataTable dt = MySQLHelper.ExecuteToDataTable(strSql.ToString());

            return dt;
        }
    }
}
