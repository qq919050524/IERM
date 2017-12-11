using IERM.BLL;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace IERM.Handler
{
    /// <summary>
    /// MaintenanceHandler 的摘要说明
    /// </summary>
    public class MaintenanceHandler : IHttpHandler
    {
        private readonly MainTenanceSettingBLL msetting_bll = new MainTenanceSettingBLL();
        private readonly MainTenanceTypeBLL type_bll = new MainTenanceTypeBLL();
        JavaScriptSerializer jsS = new JavaScriptSerializer();

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
                    case "getmaintenancesetting"://获取指定设备房的维保计划
                        result = GetMaintenancesetting(context);
                        break;
                    case "getmaintenancetype"://获取制定系统类型的维保内容详情
                        result = GetMaintenanceType(context);
                        break;
                    case "update"://更新操作
                        result = Update(context);
                        break;
                    case "add"://新增操作
                        result = Add(context);
                        break;
                    case "delete"://删除用户
                        result = Delete(context);
                        break;

                }
            }
            context.Response.Write(result);
        }




        /// <summary>
        /// 获取指定设备房的维保计划
        /// </summary>
        private string GetMaintenancesetting(HttpContext context)
        {
            int pagesize = 10;
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

            int houseid = string.IsNullOrEmpty(context.Request.Params["devhouseID"]) ? 0 : int.Parse(context.Request.Params["devhouseID"]);
            int systypeid = string.IsNullOrEmpty(context.Request.Params["systypeID"]) ? 0 : int.Parse(context.Request.Params["systypeID"]);

            var pr = new PagingResultModel<List<ViewMainTenanceSettingModel>>()
            {
                total = 0,
                rows = new List<ViewMainTenanceSettingModel>()
            };

            pr.rows = msetting_bll.GetMaintenancesetting(houseid, systypeid, pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取制定系统类型的维保内容详情
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetMaintenanceType(HttpContext context)
        {
            var jr = new JsonResultModel<List<MainTenanceTypeModel>>()
            {
                IsSucceed = false,
                Data = new List<MainTenanceTypeModel>(),
                Msg = "获取维保内容列表失败",
                RedirectUrl = string.Empty
            };

            int systypeid = string.IsNullOrEmpty(context.Request.Params["systypeID"]) ? 0 : int.Parse(context.Request.Params["systypeID"]);
            var typelist = type_bll.GetMaintenanceType(systypeid);

            if (typelist != null && typelist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = typelist;
                jr.Msg = "获取维保内容表成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 更新维保计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Update(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "更新计划失败",
                RedirectUrl = string.Empty
            };
            MainTenanceSettingModel model = null;

            string msettingStr = context.Request.Params["mSetting"];
            string mcontentStr = context.Request.Params["mContent"];
            if (!string.IsNullOrEmpty(msettingStr))
            {
                var match = Regex.Match(msettingStr, "settingid=(\\d+?)&equID=(\\d+?)&mType=(\\d+?)&status=(\\d+?)&cycLength=(\\d+?)&cycUnit=(\\d+?)&isCyclic=(\\d+?)");
                model = new MainTenanceSettingModel() {
                    sID = Convert.ToInt32(match.Groups[1].Value),
                    equID=Convert.ToInt32(match.Groups[2].Value),
                    mType= Convert.ToInt32(match.Groups[3].Value),
                    status= match.Groups[4].Value=="0"?false:true,
                    cycLength= Convert.ToInt32(match.Groups[5].Value),
                    cycUnit= Convert.ToInt32(match.Groups[6].Value),
                    isCyclic= match.Groups[7].Value=="0"?false:true,
                    stratDate=DateTime.Now
                };
            }
            if (!string.IsNullOrEmpty(mcontentStr))
            {
                model.mcontentList = mcontentStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => new MainTenanceContentModel() { settingID = model.sID, mtypeID = int.Parse(s) }).ToList();                
            }

            if(msetting_bll.Update(model))
            {
                jr.IsSucceed = true;
                jr.Data = 0;
                jr.Msg = "更新计划成功";
            }
            
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 添加维保计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Add(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "添加计划失败",
                RedirectUrl = string.Empty
            };
            MainTenanceSettingModel model = null;

            string msettingStr = context.Request.Params["mSetting"];
            string mcontentStr = context.Request.Params["mContent"];
            if (!string.IsNullOrEmpty(msettingStr))
            {
                var match = Regex.Match(msettingStr, "settingid=(\\d+?)&equID=(\\d+?)&mType=(\\d+?)&status=(\\d+?)&cycLength=(\\d+?)&cycUnit=(\\d+?)&isCyclic=(\\d+?)");
                model = new MainTenanceSettingModel()
                {
                    sID = Convert.ToInt32(match.Groups[1].Value),
                    equID = Convert.ToInt32(match.Groups[2].Value),
                    mType = Convert.ToInt32(match.Groups[3].Value),
                    status = match.Groups[4].Value == "0" ? false : true,
                    cycLength = Convert.ToInt32(match.Groups[5].Value),
                    cycUnit = Convert.ToInt32(match.Groups[6].Value),
                    isCyclic = match.Groups[7].Value == "0" ? false : true,
                    stratDate = DateTime.Now
                };
            }
            if (!string.IsNullOrEmpty(mcontentStr))
            {
                model.mcontentList = mcontentStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => new MainTenanceContentModel() { settingID = model.sID, mtypeID = int.Parse(s) }).ToList();
            }

            if (msetting_bll.Add(model))
            {
                jr.IsSucceed = true;
                jr.Data = 0;
                jr.Msg = "添加计划成功";
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除维保计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Delete(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除计划失败",
                RedirectUrl = string.Empty
            };
            int settingID = string.IsNullOrEmpty(context.Request.Params["settingID"]) ? 0 : Convert.ToInt32(context.Request.Params["settingID"]);
            if (msetting_bll.Delete(settingID))
            {
                jr.IsSucceed = true;
                jr.Data = 0;
                jr.Msg = "删除计划成功";
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