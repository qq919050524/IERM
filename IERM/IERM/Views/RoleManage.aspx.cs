using IERM.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views
{
    public partial class RoleManage : System.Web.UI.Page
    {
        protected DataTable propertyList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        }
    }
}