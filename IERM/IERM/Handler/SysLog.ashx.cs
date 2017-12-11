using IERM.BLL;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// SysLog 的摘要说明
    /// </summary>
    public class SysLog : IHttpHandler
    {
        private readonly OperationLogBLL opl_bll = new OperationLogBLL();
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
                    case "getsyslog"://获取系统日志
                        result = GetSysLog(context);
                        break;
                    case "getlogdetails"://获取日志详情
                        result = GetLogDetails(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取系统日志
        /// </summary>
        private string GetSysLog(HttpContext context)
        {
            var jr = new PagingResultModel<List<OperationLogModel>>()
            {
                rows = new List<OperationLogModel>(),
                total = 0
            };

            string typeid = context.Request.Params["typeID"];
            string partname = context.Request.Params["partName"];
            string tsp = context.Request.Params["timeSpan"];
            string pageindex = context.Request.Params["pageNumber"];
            string pagesize = context.Request.Params["pageSize"];

            try
            {
                int logcount = 0;
                jr.rows = opl_bll.GetSysLog(int.Parse(typeid), partname, tsp, int.Parse(pagesize), int.Parse(pageindex), out logcount);
                jr.total = logcount;
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 获取操作详情
        /// </summary>
        private string GetLogDetails(HttpContext context)
        {
            string oid = context.Request.Params["oid"];
            var jr = new JsonResultModel<string[]>()
            {
                IsSucceed = false,
                Data = { },
                Msg = "获取操作详情失败",
                RedirectUrl = string.Empty
            };

            try
            {
                string details = opl_bll.GetDetailsById(int.Parse(oid));
                jr.Data = details.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                jr.IsSucceed = true;
                jr.Msg = "获取操作详情成功";

                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
                throw err;
            }

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