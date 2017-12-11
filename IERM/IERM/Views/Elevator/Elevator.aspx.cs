using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.Elevator
{
    public partial class Elevator : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FieldInfo field = this.Master.GetType().GetField("propertyList");
                object obj = field.GetValue(this.Master);
                this.property.DataSource = obj;
                this.property.DataValueField = "propertyID";
                this.property.DataTextField = "propertyName";
                this.property.DataBind();
            }
        }
    }
}