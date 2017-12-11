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
    public partial class RoleInfoDAL
    {
        public RoleInfoDAL()
        {}

        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("rid", "roleinfo");
        }

        /// <summary>
        /// 获取指定角色
        /// </summary>
        public RoleInfoModel GetModel(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select rid,roleCode,roleName,intro,isDel from roleinfo ");
            strSql.Append(" where rid=@rid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@rid", MySqlDbType.Int32)
            };
            parameters[0].Value = roleid;

            return MySQLHelper.ExecuteToList<RoleInfoModel>(strSql.ToString(), parameters).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetRoles(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select rid,roleCode,roleName,intro,isDel ");
            strSql.Append(" FROM roleinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySQLHelper.ExecuteToList<RoleInfoModel>(strSql.ToString(), null);
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public List<RoleInfoModel> GetPagingRoles(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            StringBuilder strcmd = new StringBuilder("select rid,roleCode,roleName,intro,isDel FROM roleinfo ");
            string strqur = "select count(1) from roleinfo ";
            if (strWhere.Trim() != "")
            {
                strcmd.Append(" where " + strWhere);
                strqur = strqur + " where " + strWhere;
            }
            rowCount =Convert.ToInt32(MySQLHelper.ExecuteScalar(strqur,null));

            int startIndex = (pageIndex - 1) * pageSize;
            strcmd.AppendFormat(" LIMIT {0},{1}", startIndex, pageSize);
            return MySQLHelper.ExecuteToList<RoleInfoModel>(strcmd.ToString(), null);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RoleInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into roleinfo(");
            strSql.Append("roleCode,roleName,intro,isDel,propertyID)");
            strSql.Append(" values (");
            strSql.Append("@roleCode,@roleName,@intro,@isDel,@propertyID)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@roleCode", MySqlDbType.VarChar,30),
                    new MySqlParameter("@roleName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@intro", MySqlDbType.VarChar,200),
                    new MySqlParameter("@isDel", MySqlDbType.Bit),
                    new MySqlParameter("@propertyID", MySqlDbType.Int32)
            };
            parameters[0].Value = model.roleCode;
            parameters[1].Value = model.roleName;
            parameters[2].Value = model.intro;
            parameters[3].Value = model.isDel;
            parameters[4].Value = model.propertyID;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
		/// 更新角色信息
		/// </summary>
		public int Update(List<string> cmdlist)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdlist);
           
        }

        /// <summary>
		/// 删除一条数据(软删除)
		/// </summary>
		public int Delete(int rid)
        {
            string strcmd = "update roleinfo set isDel=1 where rid=@rid";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@rid", MySqlDbType.Int32)
            };
            parameters[0].Value = rid;
            return MySQLHelper.ExecuteNonQuery(strcmd, parameters);
        }
       
    }
}
