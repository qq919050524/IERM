using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public partial class OperationLogDAL
    {
        /// <summary>
        /// 获取系统日志
        /// </summary>
        public List<OperationLogModel> GetSysLog(int typeid, string partname, DateTime[] ts, int pagesize, int pageindex, out int logCount)
        {
            StringBuilder strWhere = new StringBuilder();
            try
            {
                if (typeid > 0)
                {
                    strWhere.AppendFormat(" where typeID={0}", typeid);
                }
                if (!string.IsNullOrEmpty(partname))
                {
                    if (strWhere.Length > 4)
                    {
                        strWhere.AppendFormat(" and nickName like '%{0}%'", partname);
                    }
                    else
                    {
                        strWhere.AppendFormat(" where nickName like '%{0}%'", partname);
                    }

                }
                if (strWhere.Length > 4)
                {
                    strWhere.AppendFormat(" and opTime >'{0}' and opTime<'{1}'", ts[0], ts[1]);
                }
                else
                {
                    strWhere.AppendFormat(" where opTime >'{0}' and opTime<'{1}'", ts[0], ts[1]);
                }
                


                //获取用户总数
                logCount = Convert.ToInt32(MySQLHelper.ExecuteScalar(string.Format("select count(1) from view_syslog {0}", strWhere), null));

                strWhere.AppendFormat(" LIMIT {0},{1}", (pageindex - 1) * pagesize, pagesize);
                return MySQLHelper.ExecuteToList<OperationLogModel>(string.Format("select * from view_syslog {0}", strWhere), null);
            }
            catch (Exception err)
            {
                LogHelper.Error(string.Format("IERM.DAL.operationlog.GetSysLog------{0}", err.Message));
                throw err;
            }
        }

        /// <summary>
        /// 获取一条系统日志实体
        /// </summary>
        public OperationLogModel GetLogModel(int oid)
        {
            return MySQLHelper.ExecuteToList<OperationLogModel>(string.Format("select * from operationlog where oid={0}", oid), null).FirstOrDefault();
        }

        /// <summary>
        /// 记录系统日志
        /// </summary>
        public int RecordLog(OperationLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into operationlog(");
            strSql.Append("typeID,userID,ipAddress,opTime,details)");
            strSql.Append(" values (");
            strSql.Append("@typeID,@userID,@ipAddress,@opTime,@details)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@typeID", MySqlDbType.Int32,10),
                    new MySqlParameter("@userID", MySqlDbType.Int32,10),
                    new MySqlParameter("@ipAddress", MySqlDbType.VarChar,30),
                    new MySqlParameter("@opTime", MySqlDbType.DateTime),
                    new MySqlParameter("@details", MySqlDbType.VarChar,2000)};
            parameters[0].Value = model.typeID;
            parameters[1].Value = model.userID;
            parameters[2].Value = model.ipAddress;
            parameters[3].Value = model.opTime;
            parameters[4].Value = model.details;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
    }
}
