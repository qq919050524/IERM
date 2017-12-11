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
    public partial class monitorcontentManager : System.Web.UI.Page
    {
        protected List<DevInfoModel> lstdevinfo = new List<DevInfoModel>();
        protected  List<SystemTypeModel> lstsystype = new List<SystemTypeModel>();
        protected List<CodeInformationModel> lstcode = new List<CodeInformationModel>();
        private readonly DevInfoBLL devinfo_bll = new DevInfoBLL();
        private readonly SystemTypeBLL systype_bll = new SystemTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstdevinfo = devinfo_bll.GetAllDevinfo();
                lstsystype = systype_bll.GetAllSysType();
                lstcode = systype_bll.GetAllCode();
            }
        }
    }
}