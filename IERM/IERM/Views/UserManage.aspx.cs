using IERM.BLL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views
{
    public partial class UserManage : System.Web.UI.Page
    {
        private readonly RoleInfoBLL role_bll = new RoleInfoBLL();
        protected DataTable propertyList = null;
        /// <summary>
        /// 角色集合
        /// </summary>
        protected List<RoleInfoModel> rolelist = new List<RoleInfoModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitData();

            }
        }
        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            propertyList = new PropertyInfoBLL().GetAllPropertyinfo();
            rolelist = role_bll.GetRoles(string.Empty);
            RoleInfoModel allinfo = new RoleInfoModel();
            allinfo.rid = 0;
            allinfo.roleName = "全部";
            rolelist.Insert(0, allinfo);
            this.roleselect.DataTextField = "roleName";
            this.roleselect.DataValueField = "rid";
            this.roleselect.DataSource = rolelist;
            this.roleselect.DataBind();

        }

    }
}