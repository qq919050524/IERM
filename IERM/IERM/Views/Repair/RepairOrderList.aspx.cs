
using IERM.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.Repair
{
    public partial class RepairOrderList : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
                if (cook != null)
                {
                    //解密Cookie 
                    HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                    this.userID.Value = decodeCookie.Values["userid"];
                }
            }
        }
    }
}