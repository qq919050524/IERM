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
    /// MapHandler 的摘要说明
    /// </summary>
    public class MapHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
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
                    case "getprovincecommunity"://某个设备的泵房信息
                        result = GetProvinceCommunity(context);
                        break;
                }
            }
            context.Response.Write(result);
        }


        /// <summary>
        /// 取得当前省份下的项目
        /// </summary>
        /// <returns></returns>
        public string GetProvinceCommunity(HttpContext context)
        {
            var jr = new JsonResultModel<List<CommunityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CommunityInfoModel>(),
                Msg = "获取项目信息失败",
                RedirectUrl = string.Empty
            };

            string province = context.Request.Params["province"];

            if (!string.IsNullOrEmpty(province))
            {
                CommunityInfoBLL community = new CommunityInfoBLL();

                List<CommunityInfoModel> communityList = community.GetCommunityByProvince(province);
                if (communityList != null)
                {
                    jr.IsSucceed = true;
                    jr.Data = communityList;
                    jr.Msg = "获取项目信息失败";
                }
            }
            return JsonConvert.SerializeObject(jr);
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