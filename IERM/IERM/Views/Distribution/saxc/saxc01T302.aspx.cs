using IERM.BLL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.saxc
{
    public partial class saxc01T302 : System.Web.UI.Page
    {
        protected System.Text.StringBuilder urls = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string pageurls = Request.Params["pageUrls"];
            //if (!string.IsNullOrEmpty(pageurls))
            //{
            //    foreach (var item in pageurls.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        if (item.Contains("saxc01T302.aspx"))
            //        {
            //            urls.AppendFormat("<option selected value='" + item + "'>" + item.Substring(item.LastIndexOf('/') + 1, item.LastIndexOf('.') - item.LastIndexOf('/') - 1) + "</option>");
            //        }
            //        else
            //        {
            //            urls.AppendFormat("<option value='" + item + "'>" + item.Substring(item.LastIndexOf('/') + 1, item.LastIndexOf('.') - item.LastIndexOf('/') - 1) + "</option>");
            //        }
            //    }
            //}
            //设置读取设备类型
            DevTypeBLL bll = new DevTypeBLL();
            DevTypeModel model = bll.GetTypeByCode("peidian");
            this.hidden_Attribute.Value = model.dtID.ToString();
        }
    }
}