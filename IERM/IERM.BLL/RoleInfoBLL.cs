using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class RoleInfoBLL
    {
        private readonly RoleInfoDAL role_dal = new RoleInfoDAL();
        /// <summary>
        /// 获取指定角色
        /// </summary>
        public RoleInfoModel GetModel(int roleid)
        {
            return role_dal.GetModel(roleid);
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetPagingRoles(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            return role_dal.GetPagingRoles(strWhere, pageIndex, pageSize, out rowCount);
        }


        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetRoles(string strWhere)
        {
            return role_dal.GetRoles(strWhere);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RoleInfoModel model, string rights)
        {
            int i = role_dal.Add(model);//添加角色
            if (i > 0)//当角色添加成功时，插入俞雨以前做的权限，防止影响其他地方
            {
                int rid = role_dal.GetMaxId();
                List<string> cmdlist = new List<string>();
                cmdlist.Add(string.Format("delete from rolerightrelative where roleID={0}", rid));
                cmdlist.AddRange(rights.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into rolerightrelative(roleID,rightID) values ({0},{1})", rid, s)));
                role_dal.Update(cmdlist);
            }
            return i;
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RoleInfoModel model, string rights)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update roleinfo set ");
            strSql.AppendFormat("roleCode='{0}',", model.roleCode);
            strSql.AppendFormat("roleName='{0}',", model.roleName);
            strSql.AppendFormat("intro='{0}'", model.intro);
            strSql.AppendFormat(" where rid={0}", model.rid);
            cmdlist.Add(strSql.ToString());

            cmdlist.Add(string.Format("delete from rolerightrelative where roleID={0}", model.rid));
            cmdlist.AddRange(rights.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into rolerightrelative(roleID,rightID) values ({0},{1})", model.rid, s)));


            return role_dal.Update(cmdlist) > 0 ? true : false;
        }

        /// <summary>
		/// 删除一条数据(软删除)
		/// </summary>
		public int Delete(int rid)
        {
            return role_dal.Delete(rid);
        }


    }
}
