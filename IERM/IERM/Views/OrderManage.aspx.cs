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
    public partial class OrderManage : System.Web.UI.Page
    {
        protected DataTable propertyList = null;

        private void InitParams()
        {
            propertyList = new PropertyInfoBLL().GetAllPropertyinfo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitParams();
            }
        }
    }
}