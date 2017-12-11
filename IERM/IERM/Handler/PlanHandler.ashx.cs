
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IERM.BLL;
using System.Data;
using System.Text;
using IERM.Model;
using IERM.Common;

namespace IERM.Handler
{
    /// <summary>
    /// PlanHandler 的摘要说明
    /// </summary>
    public class PlanHandler : IHttpHandler
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
                    case "addplan"://添加计划
                        result = AddPlan(context);
                        break;
                    case "updateplan"://修改计划
                        result = UpdatePlan(context);
                        break;
                    case "deleteplan"://删除计划
                        result = DeletePlan(context);
                        break;
                    case "updatestates"://更改计划状态
                        result = UpdateStates(context);
                        break;
                    case "getplan"://获取计划
                        result = GetPlan(context);
                        break;
                }
            }
            context.Response.Write(result);
        }
        /// <summary>
        /// 添加计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddPlan(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "添加失败",
                RedirectUrl = string.Empty
            };

            #region 传递参数处理为对象
            //获取传递参数
            string plancycle = context.Request.Params["plancycle"];
            string planrole = context.Request.Params["planrole"];
            string executionfrequency = context.Request.Params["executionfrequency"];
            string term_day = context.Request.Params["term_day"];
            string planstime = context.Request.Params["planstime"];
            string planetime = context.Request.Params["planetime"];
            string communityID = context.Request.Params["communityID"];
            string planstats = context.Request.Params["planstats"];
            string choosetype = context.Request.Params["choosetype"];
            string plantype = context.Request.Params["plantype"];
            string Codes = context.Request.Params["Codes"];
            EccmPlanModel model = new EccmPlanModel();
            model.plan_cycle = int.Parse(plancycle);
            model.plan_role = planrole;
            model.execution_frequency = int.Parse(executionfrequency);
            model.term_day = int.Parse(term_day);
            model.plan_stime = DateTime.Parse(planstime);
            if (planetime != "")
            {
                model.plan_etime = DateTime.Parse(planetime);
            }
            model.communityID = int.Parse(communityID);
            model.plan_stats = int.Parse(planstats);
            model.choose_type = int.Parse(choosetype);
            model.plan_type = int.Parse(plantype);
            model.plan_creat_time = DateTime.Now;
            model.is_delete = 0;
            #endregion
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                //给对象赋值
                model.uid = int.Parse(uid);
            }
            EccmPlanBLL bll = new EccmPlanBLL();
            int id = bll.Add(model);//添加计划并获取id
            if (id > 0)//添加计划成功
            {
                if (model.choose_type == 0)//设备类型
                {
                    EccmPlanDevicetypeModel pdt_model = new EccmPlanDevicetypeModel();
                    pdt_model.community_id = model.communityID;
                    pdt_model.plan_id = id;
                    pdt_model.system_type_code = Codes;

                    EccmPlanDevicetypeBLL pdt_bll = new EccmPlanDevicetypeBLL();
                    if (pdt_bll.Add(pdt_model))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "添加成功";
                    }
                }
                else if (model.choose_type == 1)//设备
                {
                    EccmPlanDeviceModel pd_model = new EccmPlanDeviceModel();
                    pd_model.community_id = model.communityID;
                    pd_model.plan_id = id;
                    pd_model.equCode = Codes;

                    EccmPlanDeviceBLL pd_bll = new EccmPlanDeviceBLL();
                    if (pd_bll.Add(pd_model))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "添加成功";
                    }
                }
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 修改计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string UpdatePlan(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "修改失败",
                RedirectUrl = string.Empty
            };

            #region 传递参数处理为对象
            //获取传递参数
            string plancycle = context.Request.Params["plancycle"];
            string planrole = context.Request.Params["planrole"];
            string executionfrequency = context.Request.Params["executionfrequency"];
            string term_day = context.Request.Params["term_day"];
            string planstime = context.Request.Params["planstime"];
            string planetime = context.Request.Params["planetime"];
            string communityID = context.Request.Params["communityID"];
            string planstats = context.Request.Params["planstats"];
            string choosetype = context.Request.Params["choosetype"];
            string plantype = context.Request.Params["plantype"];

            string Codes = context.Request.Params["Codes"];
            int planid = int.Parse(context.Request.Params["planid"]);

            //给对象赋值
            EccmPlanModel model = new EccmPlanModel();
            model.plan_cycle = int.Parse(plancycle);
            model.plan_role = planrole;
            model.execution_frequency = int.Parse(executionfrequency);
            model.term_day = int.Parse(term_day);
            model.plan_stime = DateTime.Parse(planstime);
            if (planetime != "")
            {
                model.plan_etime = DateTime.Parse(planetime);
            }
            model.communityID = int.Parse(communityID);
            model.plan_stats = int.Parse(planstats);
            model.choose_type = int.Parse(choosetype);
            model.plan_type = int.Parse(plantype);

            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                //给对象赋值
                model.uid = int.Parse(uid);
            }
            model.plan_creat_time = DateTime.Now;
            model.is_delete = 0;
            model.plan_id = planid;
            #endregion


            EccmPlanBLL bll = new EccmPlanBLL();
            if (bll.Update(model))//修改计划成功
            {
                //先删除之前的设备类型数据                
                EccmPlanDevicetypeBLL pdt_bll = new EccmPlanDevicetypeBLL();
                pdt_bll.delete(planid);

                //先删除之前的设备数据    
                EccmPlanDeviceBLL pd_bll = new EccmPlanDeviceBLL();
                pd_bll.delete(planid);

                if (model.choose_type == 0)//设备类型
                {
                    EccmPlanDevicetypeModel pdt_model = new EccmPlanDevicetypeModel();
                    pdt_model.community_id = model.communityID;
                    pdt_model.plan_id = planid;
                    pdt_model.system_type_code = Codes;

                    if (pdt_bll.Add(pdt_model))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "修改成功";
                    }
                }
                else if (model.choose_type == 1)//设备
                {
                    EccmPlanDeviceModel pd_model = new EccmPlanDeviceModel();
                    pd_model.community_id = model.communityID;
                    pd_model.plan_id = planid;
                    pd_model.equCode = Codes;

                    if (pd_bll.Add(pd_model))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "修改成功";
                    }
                }
                else { }
            }

            return JsonConvert.SerializeObject(jr);
        }


        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeletePlan(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string planID = context.Request.Params["planID"];

            EccmPlanModel model = new EccmPlanModel();
            model.plan_id = int.Parse(planID);
            model.is_delete = 1;

            EccmPlanBLL bll = new EccmPlanBLL();
            if (bll.Delete(model))//删除该id计划
            {
                jr.IsSucceed = true;
                jr.Msg = "删除成功";
            }

            return JsonConvert.SerializeObject(jr);
        }


        /// <summary>
        /// 更改计划状态
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string UpdateStates(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "更改失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string planID = context.Request.Params["planid"];
            string states = context.Request.Params["planstats"];

            EccmPlanModel model = new EccmPlanModel();
            model.plan_id = int.Parse(planID);
            model.plan_stats = int.Parse(states);

            EccmPlanBLL bll = new EccmPlanBLL();
            if (bll.UpdataStates(model))//更改计划状态
            {
                jr.IsSucceed = true;
                jr.Msg = "更改成功";
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 查询计划
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetPlan(HttpContext context)
        {
            var jr = new JsonResultModel<DataTable>()
            {
                IsSucceed = false,
                Data = null,
                Msg = "查询失败",
                RedirectUrl = string.Empty
            };

            #region 分页参数
            int pagesize = 1;
            int pageindex = 1;
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
            #endregion
            #region 查询条件
            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);
            string timespan = context.Request.Params["timeSpan"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value).AddDays(1);
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" and p.plan_creat_time>='{0}' and p.plan_creat_time<='{1}'", begintime, endtime);
            strWhere.AppendFormat(" and p.communityID={0} ", communityID);
            strWhere.Append(" and p.is_delete=0 ");
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion
            EccmPlanBLL bll = new EccmPlanBLL();
            int rowcount = 0;
            var pr = new PagingResultModel<DataTable>()
            {
                total = 0,
                rows = new DataTable()
            };
            DataTable dt = bll.GetPlanList(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.rows = dt;
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