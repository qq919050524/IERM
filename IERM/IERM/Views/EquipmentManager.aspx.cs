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
    public partial class EquipmentManager : System.Web.UI.Page
    {

        protected List<SystemTypeModel> systemList = null;
        protected DataTable propertyList = null;
        protected DataTable devicetypelist = null;//设备类型列表

        private void InitParams()
        {
            int rowcount = 0;
            systemList = new SystemTypeBLL().GetSystemType();
            propertyList = new PropertyInfoBLL().GetAllPropertyinfo();
            devicetypelist = new EccmDeviceTypeBLL().GetList("", 1, 9999,out rowcount);
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