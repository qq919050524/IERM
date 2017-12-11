using IERM.BLL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.waterPump.cshy
{
    public partial class liveWaterPump : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DevTypeBLL bll = new DevTypeBLL();
                DevTypeModel model = bll.GetTypeByCode("xiaofang");
                this.hidden_Attribute.Value = model.dtID.ToString();
            }
        }
    }
}