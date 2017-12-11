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
    public partial class UserInfoDAL
    {
        public UserInfoDAL()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from userinfo");
            strSql.Append(" where uid=@uid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@uid", MySqlDbType.Int32)
            };
            parameters[0].Value = uid;

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(strSql.ToString(), parameters)) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一个新用户
        /// </summary>
        public bool Add(string maincmdstr, List<string> subcmdlist)
        {
            return MySQLHelper.ExecuteMasterslaveByTran(maincmdstr, subcmdlist) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(List<string> cmdstrlist)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdstrlist) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int uid)
        {
            string strcmd = "update userinfo set isDel=1 where uid=@uid";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@uid", MySqlDbType.Int32)
            };
            parameters[0].Value = uid;
            return MySQLHelper.ExecuteNonQuery(strcmd, parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfoModel GetModel(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,loginName,password,nickName,mobile,headimg,companyName,departmentName,remark,isDel from userinfo ");
            strSql.Append(" where uid=@uid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@uid", MySqlDbType.Int32)
            };
            parameters[0].Value = uid;
            return MySQLHelper.ExecuteToList<UserInfoModel>(strSql.ToString(), parameters).FirstOrDefault();
        }

        /// <summary>
        /// 根据查询条件返回结果
        /// </summary>
        public List<UserInfoModel> GetList(string strWhere)
        {
            return MySQLHelper.ExecuteToList<UserInfoModel>("select * from userinfo where " + strWhere, null);
        }

        /// <summary>
        /// 获取分页用户权限信息
        /// </summary>
        public DataTable GetPagingUserinfoWithRole(string strWhere, int pageIndex, int pageSize, out int userCount)
        {
            StringBuilder strcmd = new StringBuilder("select * from view_userinfowithrole ");
            StringBuilder strcmd2 = new StringBuilder("select count(1) from view_userinfowithrole ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strcmd.Append(strWhere);
                strcmd2.Append(strWhere);
            }

            //获取用户总数
            userCount = Convert.ToInt32(MySQLHelper.ExecuteScalar(strcmd2.ToString(), null));
            //起始数据编号
            int startIndex = (pageIndex - 1) * pageSize;

            strcmd.AppendFormat(" LIMIT {0},{1}", startIndex, pageSize);
            return MySQLHelper.ExecuteToDataTable(strcmd.ToString(), null);
        }

        /// <summary>
        /// 获取用户授权小区列表
        /// </summary>
        public List<AuthCommunityModel> GetAuthCommunity(int userid)
        {
            MySqlParameter pms = new MySqlParameter("@uid", MySqlDbType.Int32);
            pms.Value = userid;
            return MySQLHelper.ExecuteToList<AuthCommunityModel>("usp_authcommunity", CommandType.StoredProcedure, pms);
        }

        /// <summary>
        /// 获取用户可访问行为列表
        /// </summary>
        public List<ActionInfoModel> GetAuthAction(int userid)
        {
            MySqlParameter pms = new MySqlParameter("@userid", MySqlDbType.Int32);
            pms.Value = userid;
            return MySQLHelper.ExecuteToList<ActionInfoModel>("usp_authaction", CommandType.StoredProcedure, pms);
        }

        /// <summary>
        /// 批量执行SQL语句
        /// </summary>
        public int ExecuteCmdList(List<string> cmdlist)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdlist);
        }

        /// <summary>
        /// 根据小区获取用户
        /// </summary>
        /// <param name="communityID"></param>
        /// <returns></returns>
        public List<UserInfoModel> GetUserByCommunity(int communityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DISTINCT uid,loginName,nickName,communityID from userinfo u ");
            strSql.Append(" left join usercommunityrelative r on u.uid = r.userID ");
            strSql.Append(" where u.isDel = 0  and communityID=@communityID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@communityID",communityID)
            };
            return MySQLHelper.ExecuteToList<UserInfoModel>(strSql.ToString(), parameters);
        }
    }
}
