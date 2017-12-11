
using IERM.BLL;
using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views
{
    public partial class AlarmSetting : System.Web.UI.Page
    {
        private readonly DevTypeBLL devtype_bll = new DevTypeBLL();
        private readonly CommunityInfoBLL community_bll = new CommunityInfoBLL();
        private readonly SystemTypeBLL systype_bll = new SystemTypeBLL();

        /// <summary>
        /// 设备类型列表
        /// </summary>
        protected List<DevTypeModel> devtypelist = null;
        /// <summary>
        /// 系统类型列表
        /// </summary>
        protected List<SystemTypeModel> systypelist = null;

        private CommunityInfoModel _dfcommunity = null;
        /// <summary>
        /// 默认小区
        /// </summary>
        protected CommunityInfoModel defaultCommunity
        {

            get
            {
                //if (_dfcommunity == null)
                //{
                //    string df_communityid = Server.HtmlEncode(Request.Cookies["df_communityid"].Value);
                //    if(!string.IsNullOrEmpty(df_communityid))
                //    {
                //        var communitylist = CacheHelper.GetCache("community") as List<communityinfo>;
                //        if(communitylist==null)
                //        {
                //            communitylist = community_bll.GetCommunity(" where isDel=0");
                //        }
                //        _dfcommunity = communitylist.Where(c=>c.communityID==int.Parse(df_communityid)).FirstOrDefault();
                //    }                   
                //}
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
                devtypelist = devtype_bll.GetAllType();
                systypelist = systype_bll.GetSystemType();
            }
        }

    }
}