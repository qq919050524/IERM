using IERM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// MonitorController 的摘要说明
    /// </summary>
    public class MonitorController : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private readonly DevInfoBLL devinfo_bll = new DevInfoBLL();
        private readonly MonitorPageBLL mopage_bll = new MonitorPageBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string systypeStr = context.Request.Params["systypeID"];
            int systypeID = string.IsNullOrEmpty(systypeStr) || systypeStr == "undefined" ? 0 : Convert.ToInt32(systypeStr);

            int communityID = 3;
            int devhouseID = 0;

            if (string.IsNullOrEmpty(context.Request.Params["communityID"]))
            {
                //var currentUser=context.Session["EccmUserinfo"] as MODEL.userinfo;
                //if(currentUser!=null)
                //{
                //    communityID = currentUser.communityList.OrderBy(o => o).FirstOrDefault();
                //}
            }
            else
            {
                communityID = Convert.ToInt32(context.Request.Params["communityID"]);
            }

            if (string.IsNullOrEmpty(context.Request.Params["devhouseID"]))
            {
                int dhid = devinfo_bll.GetDevHouseAndSysType(communityID).Where(w => w.systypeID == systypeID).FirstOrDefault().devID;
                if (dhid != 0)
                {
                    devhouseID = dhid;
                }
            }
            else
            {
                devhouseID = Convert.ToInt32(context.Request.Params["devhouseID"]);
            }
            var mp = mopage_bll.GetMonitorPage(devhouseID, systypeID);
            if (mp != null)
            {
                if (systypeID == 3)
                {
                    string showurl = string.IsNullOrEmpty(context.Request.Params["showurl"]) ? mp.pageUrl.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0] : context.Request.Params["showurl"];
                    context.Response.Redirect(string.Format("/Views/{0}?mid={1}&communityID={2}&devhouseID={3}&systypeID={4}&pageUrls={5}", showurl, mp.mID, communityID, mp.devhouseID, mp.systypeID, showurl));
                }
                else
                {
                    context.Response.Redirect(string.Format("/Views/{0}?mid={1}&communityID={2}&devhouseID={3}&systypeID={4}", mp.pageUrl, mp.mID, communityID, mp.devhouseID, mp.systypeID));
                }

            }
            else
            {
                context.Response.Redirect("/Views/Home/Home.aspx");
            }

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}