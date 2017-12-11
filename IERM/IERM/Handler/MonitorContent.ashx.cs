using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IERM.Model;
using IERM.BLL;
using IERM.Common;

namespace IERM.Handler
{
    /// <summary>
    /// 运行监控展示信息表
    /// </summary>
    public class MonitorContent : IHttpHandler
    {
        private ViewMonitorContentBLL mc_bll = new ViewMonitorContentBLL();

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
                    case "getallcontent"://获取所有运行监控展示信息
                        result = GetAllContent(context);
                        break;
                    case "getaddcontent"://添加运行监控展示信息
                        result = AddContent(context);
                        break;
                    case "getupdatecontent":// 修改运行监控展示信息
                        result = Updatecontent(context);
                        break;
                    case "getdelcontent"://删除运行监控展示信息
                        result = DeleteContent(context);
                        break;
                    case "getcontentbyid"://获取某个运行监控展示信息
                        result = GetContentById(context);
                        break;
                }

            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取某个运行监控展示信息
        /// </summary>
        /// <returns></returns>
        private string GetContentById(HttpContext context)
        {
            int tID = string.IsNullOrEmpty(context.Request.Params["tID"]) ? 0 : Convert.ToInt32(context.Request.Params["tID"]);
            List<ViewMonitorContentModel> contentlist = mc_bll.GetGetContentById(tID);

            var jr = new JsonResultModel<List<ViewMonitorContentModel>>()
            {
                IsSucceed = false,
                Data = new List<ViewMonitorContentModel>(),
                Msg = "获取运行监控展示信息失败",
                RedirectUrl = string.Empty
            };
            if (contentlist != null && contentlist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = contentlist.ToList();
                jr.Msg = "获取运行监控展示信息成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取所有运行监控展示信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAllContent(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize = context.Request.Params["pageSize"];

            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }
            var pr = new PagingResultModel<List<ViewMonitorContentModel>>()
            {
                total = 0,
                rows = new List<ViewMonitorContentModel>()
            };
            pr.rows = mc_bll.GetAllContent(pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 添加小区
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string AddContent(HttpContext context)
        {
            try
            {
                int devid = string.IsNullOrEmpty(context.Request.Params["devid"]) ? 0 : Convert.ToInt32(context.Request.Params["devid"]);
                int systype = string.IsNullOrEmpty(context.Request.Params["systype"]) ? 0 : Convert.ToInt32(context.Request.Params["systype"]);
                string contentCode = context.Request.Params["code"];
                string contentName = context.Request.Params["codename"];

                int flag = mc_bll.AddContent(new ViewMonitorContentModel()
                {
                    DevhouseID = devid,
                    SysType = systype,
                    ContentCode = contentCode,
                    ContentName = contentName,
                });

                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "添加运行监控展示信息失败",
                    RedirectUrl = ""
                };

                if (flag > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "添加运行监控展示信息成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {

                LogHelper.Error("添加新小区（AddContent）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 删除小区
        /// </summary>
        private string DeleteContent(HttpContext context)
        {
            string tID = context.Request.Params["tID"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除小区失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(tID))
            {
                int cid = 0;
                int.TryParse(tID, out cid);

                if (mc_bll.DeleteContent(cid) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "删除小区成功";
                    jr.Data = cid;
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 修改小区信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Updatecontent(HttpContext context)
        {
            string contentid = context.Request.Params["contentid"];
            int devid = string.IsNullOrEmpty(context.Request.Params["devid"]) ? 0 : Convert.ToInt32(context.Request.Params["devid"]);
            int systype = string.IsNullOrEmpty(context.Request.Params["systype"]) ? 0 : Convert.ToInt32(context.Request.Params["systype"]);
            string contentCode = context.Request.Params["code"];
            string contentName = context.Request.Params["codename"];

            int flag = mc_bll.UpdateContent(new ViewMonitorContentModel()
            {
                TID = int.Parse(contentid),
                DevhouseID = devid,
                SysType = systype,
                ContentCode = contentCode,
                ContentName = contentName,
            });
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "编辑小区失败",
                RedirectUrl = string.Empty
            };
            if (flag > 0)
            {
                jr.IsSucceed = true;
                jr.Msg = "编辑小区成功";
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