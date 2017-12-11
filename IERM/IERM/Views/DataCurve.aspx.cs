using IERM.BLL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views
{
    public partial class DataCurve : System.Web.UI.Page
    {
        protected List<DevTypeModel> dtypelsit = null;
        protected List<PropertyInfoModel> lstproperty = null;
        protected List<DataAnalysisModel> lst_da = null;
        private readonly DevTypeBLL devtype_bll = new DevTypeBLL();
        private readonly PropertyInfoBLL ppi_bll = new PropertyInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstproperty = ppi_bll.GetAllPropertyinfoList();
                dtypelsit = devtype_bll.GetAllType();
            }
        }
    }
}