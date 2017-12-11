using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// WCFHandler 的摘要说明
    /// </summary>
    public class WCFHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            var result = string.Empty;
            if (string.IsNullOrEmpty(action))
            {
                result = JsonConvert.SerializeObject(new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "行为参数未传递",
                    RedirectUrl = string.Empty
                });
            }
            else
            {
                switch (action.ToLower())
                {
                    case "getdatabydevhouseid"://获取所有激活的用户列表
                        result = GetDatabyDevHouseID(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取指定设备房的实时数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDatabyDevHouseID(HttpContext context)
        {
            int devhouseid = string.IsNullOrEmpty(context.Request.Params["devhouseID"])?0:Convert.ToInt32(context.Request.Params["devhouseID"]);

            IERM.EccmWcf.ECCMServiceClient eccmclient = new IERM.EccmWcf.ECCMServiceClient();
            return eccmclient.GetDataByDevID(devhouseid);
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