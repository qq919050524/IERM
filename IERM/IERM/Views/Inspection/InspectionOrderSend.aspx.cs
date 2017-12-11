using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.Inspection
{
    public partial class InspectionOrderSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orderID = string.IsNullOrEmpty(Request.Params["orderID"]) ? 0 : int.Parse(Request.Params["orderID"]);
                int communityID = string.IsNullOrEmpty(Request.Params["communityID"]) ? 0 : int.Parse(Request.Params["communityID"]);
                string orderSN = Request.Params["orderSN"];
                if (orderID == 0 || communityID == 0)
                {
                    Response.Write("参数错误");
                    Response.End();
                }

                this.ordersn.Value = orderSN;
                this.orderid.Value = orderID.ToString();
                this.communityid.Value = communityID.ToString();
            }
        }
    }
}