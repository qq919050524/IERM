using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class AlarmLogDAL
    {
        Random rd = new Random();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MODEL.AlarmLogModel model)
        {

            if (model == null) return false;
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into alarmlog(devID,alarmCode,alarmValue,alarmState,insertTime)");
            strSql.Append(" values (");
            strSql.AppendFormat("{0},'{1}',{2},{3},'{4}')", model.devID, model.alarmCode, model.alarmValue, model.alarmState, DateTime.Now);
            cmdlist.Add(strSql.ToString());

            //异常,插入工单记录
            //strSql.Clear();
            //var t=GetOrderinfo(model);
            //strSql.Append("insert into maintenancelog(");
            //strSql.Append("settingID,devhouseID,orderCode,orderContent,orderType,createTime,status)");
            //strSql.Append(" values (");
            //strSql.AppendFormat("0,{0},'{1}','{2}',1,'{3}',1)",model.devID,t[0],t[1],DateTime.Now);
            //cmdlist.Add(strSql.ToString());
            return Common.MySQLHelper.ExecuteSqlByTran(cmdlist)> 0 ? true : false;
        }

        /// <summary>
        /// 添加一条报警复位记录
        /// </summary>
        /// <param name="model"></param>
        public bool ReSet(MODEL.AlarmLogModel model)
        {
            if (model == null) return false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into alarmlog(devID,alarmCode,alarmValue,alarmState,insertTime)");
            strSql.Append(" values (");
            strSql.AppendFormat("{0},'{1}',{2},{3},'{4}')", model.devID, model.alarmCode, model.alarmValue, model.alarmState, DateTime.Now);
            return Common.MySQLHelper.ExecuteNonQuery(strSql.ToString(), null) > 0 ? true : false;
        }

        private string[] GetOrderinfo(MODEL.AlarmLogModel model)
        {
            string[] oinfo = new string[2];
            oinfo[0] = DateTime.Now.ToString("yyMMddHHmmssfff") + (System.Text.Encoding.ASCII.GetBytes(model.alarmCode).Sum(k => k / rd.NextDouble()) % 1000).ToString("000");
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
            switch(alarmstate)
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
    }
}
