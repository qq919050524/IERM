using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class ElevatorInfoDAL
    {
        /// <summary>
        /// 获取绑定信息
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<ElevatorInfoModel> GetList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) from elevatorinfo ");
            sqlCount.Append(" where isDel=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select eID,communityID,registrationCode,elevatorPosition ");
            sql.Append(" from elevatorinfo ");
            sql.Append(" where isDel=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<ElevatorInfoModel>(sql.ToString(), null);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ElevatorInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into elevatorinfo(communityID,registrationCode,elevatorPosition) ");
            strSql.Append(" value(@communityID,@registrationCode,@elevatorPosition)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@communityID", model.communityID),
                    new MySqlParameter("@registrationCode", model.registrationCode),
                    new MySqlParameter("@elevatorPosition", model.elevatorPosition),
            };

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ElevatorInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update elevatorinfo set ");
            strSql.Append(" registrationCode=@registrationCode ");
            strSql.Append(" ,elevatorPosition=@elevatorPosition ");
            strSql.Append(" where eID=@eID; ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@registrationCode", model.registrationCode),
                    new MySqlParameter("@elevatorPosition", model.elevatorPosition),
                    new MySqlParameter("@eID", model.eID)
            };

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 删除,假删除
        /// </summary>
        /// <param name="eID"></param>
        /// <returns></returns>
        public bool Delete(int eID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update elevatorinfo set ");
            strSql.Append(" isDel=@isDel ");
            strSql.Append(" where eID=@eID; ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@isDel", 1),
                    new MySqlParameter("@eID", eID)
            };

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 注册码是否存在
        /// </summary>
        /// <returns></returns>
        public bool Exists(string registrationCode,int eID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select count(1) ");
            sql.Append(" from elevatorinfo ");
            sql.Append(" where isDel=0 and registrationCode=@registrationCode and eID != @eID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@registrationCode", registrationCode),
                    new MySqlParameter("@eID", eID),
            };

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(sql.ToString(), parameters)) > 0;
        }

        /// <summary>
        /// 获取小区和电梯信息列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ElevatorInfoModel> GetListElevatorInfo(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) from elevatorinfo e ");
            sqlCount.Append(" left join communityinfo c on c.communityID=e.communityID ");
            sqlCount.Append(" where e.isDel = 0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and  {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select e.eID,e.communityID,e.registrationCode,e.elevatorPosition ");
            sql.Append(" ,c.communityName ");
            sql.Append(" from elevatorinfo e");
            sql.Append(" left join communityinfo c on c.communityID=e.communityID ");
            sql.Append(" where e.isDel = 0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<ElevatorInfoModel>(sql.ToString(), null);
        }
    }
}
