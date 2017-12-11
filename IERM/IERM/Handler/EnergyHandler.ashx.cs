
using IERM.BLL;
using IERM.Common;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// EnergyHandler 的摘要说明
    /// </summary>
    public class EnergyHandler : IHttpHandler
    {
        private readonly EnergyInfoBLL energyinfo_bll = new EnergyInfoBLL();
        private readonly EnergyTypeBLL energytype_bll = new EnergyTypeBLL();
        private readonly UserLogBLL userlog_bll = new UserLogBLL();

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
                    case "getenergylog"://获取能耗信息
                        result = GetEnergyLog(context);
                        break;
                    case "getchartsdata"://获取能源图表数据
                        result = GetChartsData(context);
                        break;
                    case "getenrgytmpl"://获取能耗模板
                        result = GetEnrgyTmpl(context);
                        break;
                    case "add"://添加能耗数据
                        result = Add(context);
                        break;
                    case "update"://更新能耗数据
                        result = Update(context);
                        break;
                    case "delete"://删除能耗数据
                        result = Delete(context);
                        break;
                        //case "deleteuser"://删除用户
                        //    result = DeleteUser(context);
                        //    break;
                }
            }
            context.Response.Write(result);
        }


        /// <summary>
        /// 获取能耗记录
        /// </summary>
        private string GetEnergyLog(HttpContext context)
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
            //小区编号
            int communityid = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);

            //父类型ID
            int ptypeid = string.IsNullOrEmpty(context.Request.Params["pTypeID"]) ? 0 : int.Parse(context.Request.Params["pTypeID"]);

            //统计年月
            string egydate = context.Request.Params["egyDate"];

            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();
            strWhere.AppendFormat(" where communityID={0}", communityid);
            if (ptypeid != 0)
            {
                strWhere.AppendFormat(" and pID={0}", ptypeid);
            }
            if (!string.IsNullOrEmpty(egydate))
            {
                string[] yearmonth = egydate.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                strWhere.AppendFormat(" and year='{0}' and month='{1}'", yearmonth[0], yearmonth[1]);
            }

            var pr = new PagingResultModel<List<EnergyInfoModel>>()
            {
                total = 0,
                rows = new List<EnergyInfoModel>()
            };

            pr.rows = energyinfo_bll.GetEnergyLog(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonHelper.SerializeObject(pr);
        }


        /// <summary>
        /// 获取能耗图形数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetChartsData(HttpContext context)
        {
            var jr = new JsonResultModel<Dictionary<int, ChartsDataModel>>()
            {
                IsSucceed = false,
                Data = new Dictionary<int, ChartsDataModel>(),
                Msg = "获取能耗数据失败",
                RedirectUrl = string.Empty
            };

            int selyear = string.IsNullOrEmpty(context.Request.Params["selYear"]) ? 0 : Convert.ToInt32(context.Request.Params["selYear"]);
            int arealevel = string.IsNullOrEmpty(context.Request.Params["areaLevel"]) ? 0 : Convert.ToInt32(context.Request.Params["areaLevel"]);
            int areaid = string.IsNullOrEmpty(context.Request.Params["areaID"]) ? 0 : Convert.ToInt32(context.Request.Params["areaID"]);
            int energytype = string.IsNullOrEmpty(context.Request.Params["energyType"]) ? 0 : Convert.ToInt32(context.Request.Params["energyType"]);
            var tmpdata = energyinfo_bll.GetEnergData(areaid, arealevel, selyear, energytype);
            if (tmpdata != null && tmpdata.Count > 0)
            {
                jr.Data = tmpdata;
                jr.IsSucceed = true;
                jr.Msg = "获取能耗数据成功";
            }
            else if (tmpdata.Count == 0)
            {
                jr.Data = tmpdata;
                jr.IsSucceed = false;
                jr.Msg = "暂无数据";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取能耗模板
        /// </summary>
        private string GetEnrgyTmpl(HttpContext context)
        {
            var jr = new JsonResultModel<List<EnergyTypeModel>>()
            {
                IsSucceed = false,
                Data = new List<EnergyTypeModel>(),
                Msg = "获取能耗模板失败",
                RedirectUrl = string.Empty
            };

            int pid = string.IsNullOrEmpty(context.Request.Params["pID"]) ? 0 : Convert.ToInt32(context.Request.Params["pID"]);
            var tmplist = energytype_bll.GetEnergyTmplByPid(pid);
            if (tmplist != null && tmplist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = tmplist;
                jr.Msg = "获取能耗模板成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 添加能耗数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Add(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "添加能耗数据失败",
                RedirectUrl = string.Empty
            };

            string pms = context.Request.Params["PMS"];//hd_communityID=1&sym=2017-02&t9=12&t10=12&t11=12
            var match = Regex.Match(pms, "hd_communityID=(.+?)&sym=(.+?)&(.+)");
            int communityID = string.IsNullOrEmpty(match.Groups[1].Value) ? 0 : Convert.ToInt32(match.Groups[1].Value);

            if (!string.IsNullOrEmpty(match.Groups[2].Value))
            {
                string[] date = match.Groups[2].Value.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                int _year = Convert.ToInt32(date[0]);
                int _month = Convert.ToInt32(date[1]);

                if (!string.IsNullOrEmpty(match.Groups[3].Value))
                {
                    var modellist = match.Groups[3].Value.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries).Select(s => new EnergyInfoModel()
                    {
                        communityID = communityID,
                        typeID = int.Parse(s.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[0].Substring(1)),
                        year = _year,
                        month = _month,
                        engValue = decimal.Parse(s.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1]),
                        insertTime = DateTime.Now
                    });

                    if (modellist != null && modellist.Count() > 0)
                    {
                        int addcount = energyinfo_bll.Add(modellist.ToList());
                        if (addcount > 0)
                        {
                            jr.IsSucceed = true;
                            jr.Data = addcount / 2;
                            jr.Msg = "成功添加能耗数据！";
                            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
                            if (cook != null)
                            {
                                //解密Cookie 
                                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                                string uid = decodeCookie.Values["userid"];
                                userlog_bll.addUserLog(int.Parse(uid), "添加能耗数据");
                            }
                        }
                    }


                }
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 更新能耗数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Update(HttpContext context)
        {
            var jr = new JsonResultModel<bool>()
            {
                IsSucceed = false,
                Data = false,
                Msg = "更新能耗数据失败",
                RedirectUrl = string.Empty
            };

            int eneid = string.IsNullOrEmpty(context.Request.Params["eneid"]) ? 0 : Convert.ToInt32(context.Request.Params["eneid"]);
            decimal newdata = string.IsNullOrEmpty(context.Request.Params["newdata"]) ? 0 : Convert.ToInt32(context.Request.Params["newdata"]);

            if (energyinfo_bll.Update(eneid, newdata))
            {
                jr.IsSucceed = true;
                jr.Data = true;
                jr.Msg = "更新能耗数据成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除能耗数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Delete(HttpContext context)
        {
            var jr = new JsonResultModel<bool>()
            {
                IsSucceed = false,
                Data = false,
                Msg = "删除能耗数据失败",
                RedirectUrl = string.Empty
            };

            int nid = string.IsNullOrEmpty(context.Request.Params["eneid"]) ? 0 : Convert.ToInt32(context.Request.Params["eneid"]);
            if (energyinfo_bll.Delete(nid))
            {
                jr.IsSucceed = true;
                jr.Data = true;
                jr.Msg = "删除能耗数据成功";
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