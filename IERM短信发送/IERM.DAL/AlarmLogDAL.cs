using IERM.Message.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.DAL
{
    public class AlarmLogDAL
    {


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AlarmLogModel model)
        {

            if (model == null) return false;
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into alarmlog(devID,alarmCode,alarmValue,alarmState,insertTime)");
            strSql.Append(" values (");
            strSql.AppendFormat("{0},'{1}',{2},{3},'{4}')", model.devID, model.alarmCode, model.alarmValue, model.alarmState, DateTime.Now);
            cmdlist.Add(strSql.ToString());

            strSql.Clear();
            string[] orderInfo = GetOrderinfo(model);
            strSql.Append("insert into maintenancelog(");
            strSql.Append("settingID,devhouseID,orderCode,orderContent,orderType,createTime,status)");
            strSql.Append(" values (");
            strSql.AppendFormat("0,{0},'{1}','{2}',1,'{3}',1)", model.devID, orderInfo[0], orderInfo[1], DateTime.Now);
            cmdlist.Add(strSql.ToString());
            return MySQLHelper.ExecuteSqlByTran(cmdlist) > 0 ? true : false;
        }

        /// <summary>
        /// 添加一条报警复位记录
        /// </summary>
        /// <param name="model"></param>
        public bool ReSet(AlarmLogModel model)
        {
            if (model == null) return false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into alarmlog(devID,alarmCode,alarmValue,alarmState,insertTime)");
            strSql.Append(" values (");
            strSql.AppendFormat("{0},'{1}',{2},{3},'{4}')", model.devID, model.alarmCode, model.alarmValue, model.alarmState, DateTime.Now);
            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), null) > 0 ? true : false;
        }

        private string[] GetOrderinfo(AlarmLogModel model)
        {
            Random rd = new Random();
            string[] oinfo = new string[2];
            oinfo[0] = model.alarmCode + DateTime.Now.ToString("yyMMddHHmmssfff");
            oinfo[1] = string.Format("{0},{1},{2}", model.devName, model.alarmName, GetAlarmStateName(model.alarmState));
            return oinfo;
        }

        /// <summary>
        /// 获取报警类型
        /// </summary>
        /// <param name="alarmstate"></param>
        /// <returns></returns>
        private string GetAlarmStateName(int alarmstate)
        {
            string statename = string.Empty;
            switch (alarmstate)
            {
                case -2:
                    statename = "过低";
                    break;
                case 2:
                    statename = "过高";
                    break;
                case -1:
                    statename = "异常";
                    break;
                default:
                    statename = "正常";
                    break;
            }
            return statename;
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="top">查询数量</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(int top,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select  aID,  c.communityName, l.devID, devName, l.alarmCode, alarmName,alarmValue,alarmState,insertTime ");
            strSql.Append(" from alarmlog l ");
            strSql.Append(" left join devinfo d on d.devid = l.devid ");
            strSql.Append(" left join communityinfo c on c.communityID = d.communityID ");
            strSql.Append(" left join alarmtype a on a.alarmcode = l.alarmcode ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by insertTime desc LIMIT 0,"+ top);

            DataTable dt = MySQLHelper.ExecuteToDataTable(strSql.ToString());

            return dt;
        }

        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select aID,  c.communityName, l.devID, devName, l.alarmCode, alarmName,alarmValue,alarmState,insertTime ");
            strSql.Append(" from alarmlog l ");
            strSql.Append(" left join devinfo d on d.devid = l.devid ");
            strSql.Append(" left join communityinfo c on c.communityID = d.communityID ");
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
