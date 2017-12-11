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
    public partial class MaintenanceManage : System.Web.UI.Page
    {
        protected List<SystemTypeModel> systemList = null;
        protected DataTable propertyList = null;

        private void InitParams()
        {
            systemList = new SystemTypeBLL().GetSystemType();
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