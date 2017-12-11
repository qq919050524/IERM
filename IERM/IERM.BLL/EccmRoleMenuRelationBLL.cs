using IERM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class EccmRoleMenuRelationBLL
    {
        private readonly EccmRoleMenuRelationDAL role_dal = new EccmRoleMenuRelationDAL();

        /// <summary>
		/// 添加角色权限
		/// </summary>
		public int Add(int rid, string ids)
        {
            return role_dal.Add(rid, ids);
        }
    }
}
