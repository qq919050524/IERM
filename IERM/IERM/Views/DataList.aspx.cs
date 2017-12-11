using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.Services;
using IERM.Model;
using IERM.BLL;

namespace IERM.Views
{
    public partial class DataList : System.Web.UI.Page
    {
        protected List<DevTypeModel> dtypelsit = null;
        protected DataTable dtb_ppi = null;
        protected List<PropertyInfoModel> lstproperty = null;
        protected List<DataAnalysisModel> lst_da = null;
        private readonly DevTypeBLL devtype_bll = new DevTypeBLL();
        private readonly PropertyInfoBLL ppi_bll = new PropertyInfoBLL();
        private readonly DataListBLL dl_Bll = new DataListBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstproperty = ppi_bll.GetAllPropertyinfoList();
                dtypelsit = devtype_bll.GetAllType();
                dtb_ppi = ppi_bll.GetAllPropertyinfo();
            }
        }
    }
}