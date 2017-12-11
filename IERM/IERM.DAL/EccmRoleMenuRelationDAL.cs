using IERM.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
    /// 角色权限DAL
    /// </summary>
    public partial class EccmRoleMenuRelationDAL
    {
        public EccmRoleMenuRelationDAL()
        {}
        

        /// <summary>
		/// 添加角色权限
		/// </summary>
		public int Add(int rid,string ids)
        {
            List<string> cmdlist = new List<string>();
            cmdlist.Add(string.Format("delete from eccm_role_menu_relation where rid={0}", rid));
            cmdlist.AddRange(ids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into eccm_role_menu_relation(rid,mid) values ({0},{1})", rid, s)));
            return MySQLHelper.ExecuteSqlByTran(cmdlist);
        }
       
    }
}
