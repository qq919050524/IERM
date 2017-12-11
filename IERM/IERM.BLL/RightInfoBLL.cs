using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class RightInfoBLL
    {
        private readonly RightInfoDAL right_dal = new RightInfoDAL();

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public List<RightInfoModel> GetAllRight()
        {
            return right_dal.GetAllRight();
        }

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<RightInfoModel> GetRightByRoleID(int roleid)
        {
            return right_dal.GetRightByRoleID(roleid);
        }

        /// <summary>
        /// 删除角色所有权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public int DeleteRightByRoleID(int roleid)
        {
            return right_dal.DeleteRightByRoleID(roleid);
        }

        /// <summary>
        /// 为指定角色添加权限
        /// </summary>
        public int AddRightsToRole(int roleid, string rights)
        {
            string[] rs = rights.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return right_dal.AddRightsToRole(roleid, rs);
        }


    }
}
