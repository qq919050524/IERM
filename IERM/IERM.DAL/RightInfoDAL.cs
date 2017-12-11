using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public partial class RightInfoDAL
    {
        /// <summary>
        /// 获取全部权限列表
        /// </summary>
        /// <returns></returns>
        public List<RightInfoModel> GetAllRight()
        {
            return MySQLHelper.ExecuteToList<RightInfoModel>("select * from rightinfo where isDel=0", null);
        }

        /// <summary>
        /// 根据角色id获取该角色的权限列表
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<RightInfoModel> GetRightByRoleID(int roleid)
        {
            return MySQLHelper.ExecuteToList<RightInfoModel>(string.Format("select * from view_rolewithright where roleID={0}", roleid), null);

        }

        /// <summary>
        /// 删除角色所有权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public int DeleteRightByRoleID(int roleid)
        {
            return MySQLHelper.ExecuteNonQuery(string.Format("delete from rolerightrelative where roleID={0}", roleid), null);
        }

        /// <summary>
        /// 
        /// </summary>
        public int AddRightsToRole(int roleid,string[] rights)
        {
            if (rights.Length == 0) return 0;

            List<string> cmdlist = new List<string>();
            cmdlist.Add(string.Format("delete from rolerightrelative where roleID={0}", roleid));

            foreach(string item in rights)
            {
                cmdlist.Add(string.Format("insert into rolerightrelative(roleID,rigthID) values ({0},'{1}')", roleid, item));
            }
            return MySQLHelper.ExecuteSqlByTran(cmdlist);
        }
    }
}
