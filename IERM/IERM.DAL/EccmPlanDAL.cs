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
    public class EccmPlanDAL
    {
        /// <summary>
        /// 根据小区id 获取计划列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetPlanList(string strwhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_plan p ");
            sqlCount.AppendFormat(" where {0}", strwhere);
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select plan_id,plan_cycle,plan_role,execution_frequency,execution_time,plan_build_time,unix_timestamp(plan_stime) as plan_stime,unix_timestamp(plan_etime) as plan_etime,term_day,uid,unix_timestamp(plan_creat_time) as plan_creat_time,plan_stats,plan_type,choose_type,is_delete,ext1,ext2,ext3,communityID ");
            sql.Append(" from eccm_plan p ");
            sql.AppendFormat(" where {0}", strwhere);
            sql.Append(" order by p.plan_creat_time desc");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);

            DataTable dt = MySQLHelper.ExecuteToDataTable(sql.ToString(), null);

            return dt;
        }



        /// <summary>
        /// 增加一条计划数据
        /// </summary>
        public int Add(EccmPlanModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_plan(");
            strSql.Append("plan_cycle,plan_role,execution_frequency,execution_time,plan_build_time,plan_stime,plan_etime,term_day,uid,plan_creat_time,plan_stats,plan_type,choose_type,is_delete,ext1,ext2,ext3,communityID)");
            strSql.Append(" values (");
            strSql.Append("@plan_cycle,@plan_role,@execution_frequency,@execution_time,@plan_build_time,@plan_stime,@plan_etime,@term_day,@uid,@plan_creat_time,@plan_stats,@plan_type,@choose_type,@is_delete,@ext1,@ext2,@ext3,@communityID)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@plan_cycle", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_role", MySqlDbType.VarChar,20),
                    new MySqlParameter("@execution_frequency", MySqlDbType.Int32,11),
                    new MySqlParameter("@execution_time", MySqlDbType.Time),
                    new MySqlParameter("@plan_build_time", MySqlDbType.Time),
                    new MySqlParameter("@plan_stime", MySqlDbType.DateTime),
                    new MySqlParameter("@plan_etime", MySqlDbType.DateTime),
                    new MySqlParameter("@term_day", MySqlDbType.Int32,11),
                    new MySqlParameter("@uid", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_creat_time", MySqlDbType.DateTime),
                    new MySqlParameter("@plan_stats", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@choose_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@is_delete", MySqlDbType.Int32,11),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,50),
                    new MySqlParameter("@communityID", MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.plan_cycle;
            parameters[1].Value = model.plan_role;
            parameters[2].Value = model.execution_frequency;
            parameters[3].Value = model.execution_time;
            parameters[4].Value = model.plan_build_time;
            parameters[5].Value = model.plan_stime;
            parameters[6].Value = model.plan_etime;
            parameters[7].Value = model.term_day;
            parameters[8].Value = model.uid;
            parameters[9].Value = model.plan_creat_time;
            parameters[10].Value = model.plan_stats;
            parameters[11].Value = model.plan_type;
            parameters[12].Value = model.choose_type;
            parameters[13].Value = model.is_delete;
            parameters[14].Value = model.ext1;
            parameters[15].Value = model.ext2;
            parameters[16].Value = model.ext3;
            parameters[17].Value = model.communityID;
            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                string sql = "select max(plan_id) from eccm_plan;";//获取计划id
                int i = Convert.ToInt32(MySQLHelper.ExecuteScalar(sql, null));
                return i;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EccmPlanModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_plan set ");
            strSql.Append("plan_cycle=@plan_cycle,");
            strSql.Append("plan_role=@plan_role,");
            strSql.Append("execution_frequency=@execution_frequency,");
            strSql.Append("execution_time=@execution_time,");
            strSql.Append("plan_build_time=@plan_build_time,");
            strSql.Append("plan_stime=@plan_stime,");
            strSql.Append("plan_etime=@plan_etime,");
            strSql.Append("term_day=@term_day,");
            strSql.Append("uid=@uid,");
            strSql.Append("plan_stats=@plan_stats,");
            strSql.Append("plan_type=@plan_type,");
            strSql.Append("choose_type=@choose_type,");
            strSql.Append("is_delete=@is_delete,");
            strSql.Append("ext1=@ext1,");
            strSql.Append("ext2=@ext2,");
            strSql.Append("ext3=@ext3,");
            strSql.Append("communityID=@communityID");
            strSql.Append(" where plan_id=@plan_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@plan_cycle", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_role", MySqlDbType.VarChar,20),
                    new MySqlParameter("@execution_frequency", MySqlDbType.Int32,11),
                    new MySqlParameter("@execution_time", MySqlDbType.Time),
                    new MySqlParameter("@plan_build_time", MySqlDbType.Time),
                    new MySqlParameter("@plan_stime", MySqlDbType.DateTime),
                    new MySqlParameter("@plan_etime", MySqlDbType.DateTime),
                    new MySqlParameter("@term_day", MySqlDbType.Int32,11),
                    new MySqlParameter("@uid", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_stats", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@choose_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@is_delete", MySqlDbType.Int32,11),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,50),
                    new MySqlParameter("@communityID", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_id", MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.plan_cycle;
            parameters[1].Value = model.plan_role;
            parameters[2].Value = model.execution_frequency;
            parameters[3].Value = model.execution_time;
            parameters[4].Value = model.plan_build_time;
            parameters[5].Value = model.plan_stime;
            parameters[6].Value = model.plan_etime;
            parameters[7].Value = model.term_day;
            parameters[8].Value = model.uid;
            parameters[9].Value = model.plan_stats;
            parameters[10].Value = model.plan_type;
            parameters[11].Value = model.choose_type;
            parameters[12].Value = model.is_delete;
            parameters[13].Value = model.ext1;
            parameters[14].Value = model.ext2;
            parameters[15].Value = model.ext3;
            parameters[16].Value = model.communityID;
            parameters[17].Value = model.plan_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(EccmPlanModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_plan set ");
            strSql.Append("is_delete=@is_delete");
            strSql.Append(" where plan_id=@plan_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@is_delete", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.is_delete;
            parameters[1].Value = model.plan_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
		/// 更改计划状态
		/// </summary>
		public bool UpdataStates(EccmPlanModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_plan set ");
            strSql.Append("plan_stats=@plan_stats");
            strSql.Append(" where plan_id=@plan_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@plan_stats", MySqlDbType.Int32,11),
                    new MySqlParameter("@plan_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.plan_stats;
            parameters[1].Value = model.plan_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
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
