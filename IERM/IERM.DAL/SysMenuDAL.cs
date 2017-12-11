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
    public class SysMenuDAL
    {
        /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetSysMenu(string strWhere)
        {
            string strcmd = "SELECT * from view_sysmenu";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strcmd = strcmd + " where " + strWhere;
            }
            return MySQLHelper.ExecuteToDataTable(strcmd + " order by mSort asc", null);
        }

        /// <summary>
        /// 根据用户id获取角色菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleMenuByUserId(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.mid, mPID ,menuName_p,menuIco_p,menuName,menuIco,menuUrl,a.isdel,mSort ");
            strSql.Append(" from view_sysmenu a ");
            strSql.Append("  left join eccm_role_menu_relation b ON a.mid = b.mid ");
            strSql.Append("  left join userrolerelative c ON c.roleID = b.rid ");
            strSql.AppendFormat("  where c.userID ={0} ", userid);
            strSql.Append("  order by mSort ");
            return MySQLHelper.ExecuteToDataTable(strSql.ToString(), null);
        }



        /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenu(string strWhere)
        {
            string strcmd = "SELECT * from sysmenu where isDel=0";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strcmd = strcmd + " and " + strWhere;
            }
            return MySQLHelper.ExecuteToDataTable(strcmd + " order by mSort asc", null);
        }

        /// <summary>
        /// 修改系统菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(SysMenuModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sysmenu set ");
            strSql.Append(" menuName=@menuName, ");
            strSql.Append(" menuIco=@menuIco,");
            strSql.Append(" menuUrl=@menuUrl,");
            //strSql.Append(" mPID=@mPID,");
            strSql.Append(" mSort=@mSort ");
            strSql.Append(" where mid=@mid ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@menuName", MySqlDbType.VarChar,30),
                    new MySqlParameter("@menuIco", MySqlDbType.VarChar,200),
                    new MySqlParameter("@menuUrl", MySqlDbType.VarChar,200),
                    //new MySqlParameter("@mPID", MySqlDbType.Int32),
                    new MySqlParameter("@mSort", MySqlDbType.Int32),
                    new MySqlParameter("@mid", MySqlDbType.Int32)
            };
            parameters[0].Value = model.menuName;
            parameters[1].Value = model.menuIco;
            parameters[2].Value = model.menuUrl;
            //parameters[3].Value = model.mPID;
            parameters[3].Value = model.mSort;
            parameters[4].Value = model.mid;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条菜单(逻辑删除)
        /// </summary>
        public int Delete(int mid)
        {
            string strcmd = "update sysmenu set isDel=1 where mid=@mid";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@mid", MySqlDbType.Int32)
            };
            parameters[0].Value = mid;
            return MySQLHelper.ExecuteNonQuery(strcmd, parameters);
        }


        /// <summary>
        /// 增加菜单
        /// </summary>
        public int Add(SysMenuModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sysmenu(");
            strSql.Append("menuName,menuIco,menuUrl,mPID,isDel,mSort)");
            strSql.Append(" values (");
            strSql.Append("@menuName,@menuIco,@menuUrl,@mPID,@isDel,@mSor)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@menuName", MySqlDbType.VarChar,30),
                    new MySqlParameter("@menuIco", MySqlDbType.VarChar,200),
                    new MySqlParameter("@menuUrl", MySqlDbType.VarChar,200),
                    new MySqlParameter("@mPID", MySqlDbType.Int32,10),
                    new MySqlParameter("@isDel", MySqlDbType.Bit),
                    new MySqlParameter("@mSor", MySqlDbType.Int32,10)
            };
            parameters[0].Value = model.menuName;
            parameters[1].Value = model.menuIco;
            parameters[2].Value = model.menuUrl;
            parameters[3].Value = model.mPID;
            parameters[4].Value = model.isDel;
            parameters[5].Value = model.mSort;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
    }
}
