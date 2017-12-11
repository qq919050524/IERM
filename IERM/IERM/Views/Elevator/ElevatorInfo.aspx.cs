
using IERM.BLL;
using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.Elevator
{
    public partial class ElevatorInfo : System.Web.UI.Page
    {
        private readonly CommunityInfoBLL community_bll = new CommunityInfoBLL();

        private CommunityInfoModel _dfcommunity = null;
        /// <summary>
        /// 默认小区
        /// </summary>
        protected CommunityInfoModel defaultCommunity
        {

            get
            {
                HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
                if (cook != null)
                {
                    //解密Cookie 
                    HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                    string uid = decodeCookie.Values["userid"];
                    _dfcommunity = community_bll.GetDefaultModel(" and isdel=0 ", int.Parse(uid));
                }
                return _dfcommunity;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}