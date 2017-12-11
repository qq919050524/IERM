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
    /// OrderHandler 的摘要说明
    /// </summary>
    public class OrderHandler : IHttpHandler
    {
        private readonly MainTenanceLogBLL mlog_bll = new MainTenanceLogBLL();

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
                    case "getorderlog"://获取工单信息
                        result = GetOrderLog(context);
                        break;

                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取工单信息
        /// </summary>
        private string GetOrderLog(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize = context.Request.Params["pageSize"];

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }

            int communityid = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);
            int devhouseid = string.IsNullOrEmpty(context.Request.Params["devhouseID"]) ? 0 : int.Parse(context.Request.Params["devhouseID"]);
            int ordertype = string.IsNullOrEmpty(context.Request.Params["orderType"]) ? 0 : int.Parse(context.Request.Params["orderType"]);
            string timespan = context.Request.Params["timeSpan"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value);

            var pr = new PagingResultModel<List<MainTenanceLogModel>>()
            {
                total = 0,
                rows = new List<MainTenanceLogModel>()
            };

            pr.rows = mlog_bll.GetMaintenanceLog(communityid, devhouseid, ordertype, begintime,endtime, pagesize,pageindex , out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
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