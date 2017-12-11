using IERM.BLL;
using IERM.Common;
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
    public partial class Monitoring : System.Web.UI.UserControl
    {
        private readonly SysMenuBLL menu_bll = new SysMenuBLL();
        private readonly MonitorContentBLL moncontent_bll = new MonitorContentBLL();

        protected List<SysMenuModel> menus = null;
        protected DataTable propertyList = null;
        protected string footerContent = string.Empty;

        private int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["EccmUserinfo"];
                if (cookie != null)
                {
                    //解密Cookie 
                    HttpCookie decodeCookie = HttpSecureCookie.Decode(cookie);

                    //显示用户登录名
                    string loginname = decodeCookie.Values["loginname"];
                    //lbl_user.Text = loginname;
                    UserID = Convert.ToInt32(decodeCookie.Values["userid"]);
                }
                //menus = menu_bll.GetMenuList(string.Empty);
                propertyList = new PropertyInfoBLL().GetAuthorizePropertyinfo(UserID);
                if (propertyList.Rows.Count == 0)
                {
                    propertyList.Columns.Add("propertyID");
                    propertyList.Columns.Add("propertyName");

                    DataRow dr = propertyList.NewRow();
                    dr["propertyID"] = "0";
                    dr["propertyName"] = "未选择";
                    propertyList.Rows.InsertAt(dr, 0);
                }
                else
                {
                    this.property.DataSource = propertyList;
                    this.property.DataValueField = "propertyID";
                    this.property.DataTextField = "propertyName";
                    this.property.DataBind();
                }


                this.mID.Value = Request.Params["mid"];
                int mid = string.IsNullOrEmpty(Request.Params["mid"]) ? 0 : Convert.ToInt32(Request.Params["mid"]);
                this.devhouseID.Value = Request.Params["devhouseID"];
                this.systypeID.Value = Request.Params["systypeID"];
                this.communityID.Value = Request.Params["communityID"];
                this.pageUrls.Value = Request.Params["pageUrls"];
                footerContent = moncontent_bll.GetFooterContent(mid);

            }

        }


        private void GetUserInfo()
        {
            HttpCookie cookie = Request.Cookies["EccmUserinfo"];
            if (cookie != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cookie);

                //显示用户登录名
                string loginname = decodeCookie.Values["loginname"];
                //lbl_user.Text = loginname;
                string UserID = decodeCookie.Values["userid"].ToString();
                //权限菜单
                if (loginname == "admin")
                {
                    menus = menu_bll.GetMenuList(string.Empty);
                }
                else
                {
                    menus = menu_bll.GetRoleMenuByUserId(UserID);
                }
            }
            else
            {
                Response.Redirect("/login.html");
            }
        }
    }
}