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
    public partial class AlarmLog : System.Web.UI.Page
    {
        protected List<SystemTypeModel> systypelist = null;
        protected DataTable dtb_ppi = null;
        private readonly SystemTypeBLL devtype_bll = new SystemTypeBLL();
        private readonly PropertyInfoBLL ppi_bll = new PropertyInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                systypelist = devtype_bll.GetSystemType();
                dtb_ppi = ppi_bll.GetAllPropertyinfo();
            }
        }
    }
}