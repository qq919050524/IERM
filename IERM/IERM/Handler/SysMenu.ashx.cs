using IERM.BLL;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// SysMenu 的摘要说明
    /// </summary>
    public class SysMenu : IHttpHandler
    {
        private readonly SysMenuBLL menu_bll = new SysMenuBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var jr = new JsonResultModel<List<SysMenuModel>>()
            {
                IsSucceed = false,
                Data = menu_bll.GetMenuList(string.Empty),
                Msg = string.Empty,
                RedirectUrl = string.Empty
            };
            context.Response.Write(JsonConvert.SerializeObject(jr));
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