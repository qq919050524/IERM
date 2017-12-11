
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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private readonly SysMenuBLL menu_bll = new SysMenuBLL();
        protected List<SysMenuModel> menus = null;
        public DataTable propertyList = null;
        protected override void OnInit(EventArgs e)
        {
            GetUserInfo();
            //menus = menu_bll.GetMenuList(string.Empty);

            propertyList = new PropertyInfoBLL().GetAuthorizePropertyinfo(0);
            if (propertyList.Rows.Count == 0)
            {
                propertyList.Columns.Add("propertyID");
                propertyList.Columns.Add("propertyName");

                DataRow dr = propertyList.NewRow();
                dr["propertyID"] = "0";
                dr["propertyName"] = "未选择";
                propertyList.Rows.InsertAt(dr, 0);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //  var currentUser = Session["EccmUserinfo"] as MODEL.userinfo;
            if (!IsPostBack)
            {

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
                lbl_user.Text = loginname;
                //权限菜单
                if (decodeCookie.Values["loginname"] == "admin")
                {
                    menus = menu_bll.GetMenuList(string.Empty);
                }
                else
                {
                    menus = menu_bll.GetRoleMenuByUserId(decodeCookie.Values["userid"]);
                }
            }
            else
            {
                Response.Redirect("/login.html");
            }
        }
    }
}