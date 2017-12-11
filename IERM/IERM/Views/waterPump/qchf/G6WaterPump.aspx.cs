﻿using IERM.BLL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.waterPump.qchf
{
    public partial class G6WaterPump : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DevTypeBLL bll = new DevTypeBLL();
                DevTypeModel model = bll.GetTypeByCode("paishui");
                this.hidden_Attribute.Value = model.dtID.ToString();
            }
        }
    }
}