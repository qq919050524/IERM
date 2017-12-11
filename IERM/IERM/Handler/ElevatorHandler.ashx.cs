
using IERM.BLL;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// ElevatorHandler 的摘要说明
    /// </summary>
    public class ElevatorHandler : IHttpHandler
    {
        private ElevatorInfoBLL _infoBLL = new ElevatorInfoBLL();
        private AlarmElevatorBLL _alarmBLL = new AlarmElevatorBLL();
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
                    case "getlistinelevatorinfo":
                        result = GetListInElevatorInfo(context);//列表
                        break;
                    case "addelevatorinfo":
                        result = AddElevatorInfo(context);//新增
                        break;
                    case "editelevatorinfo":
                        result = EditElevatorInfo(context);//编辑
                        break;
                    case "deleteelevatorinfo":
                        result = DeleteElevatorInfo(context);//删除
                        break;
                    case "getlistcommunityelevator":
                        result = GetListCommunityElevator(context);//小区电梯列表
                        break;
                    case "getliftrundata":
                        result = GetLiftRunData(context);//获取电梯实时监控
                        break;
                    case "getliftdetail":
                        result = GetLiftDetail(context);//获取电梯明细
                        break;
                    case "getliftvideo":
                        result = GetLiftVideo(context);
                        break;
                    case "getcurrentalarmelevator":
                        result = GetCurrentAlarmElevator(context);//实时报警记录
                        break;
                    case "gethistoryalarmelevator":
                        result = GetHistoryAlarmElevator(context);//历史报警记录
                        break;
                }
            }
            context.Response.Write(result);
        }

        #region 小区绑定电梯
        /// <summary>
        /// 获取小区电梯集合
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetListInElevatorInfo(HttpContext context)
        {
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

            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(@" and communityID={0} ", communityID);
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion
            int rowcount = 0;
            var pr = new PagingResultModel<List<ElevatorInfoModel>>()
            {
                total = 0,
                rows = new List<ElevatorInfoModel>()
            };

            pr.rows = _infoBLL.GetList(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 新增电梯注册码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddElevatorInfo(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "新增失败",
                RedirectUrl = string.Empty
            };
            string registrationCode = context.Request.Params["registrationCode"];
            string elevatorPosition = context.Request.Params["elevatorPosition"];
            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);
            if (_infoBLL.Exists(registrationCode, 0))
            {
                jr.IsSucceed = false;
                jr.Msg = "注册码已经存在";
            }
            else
            {
                ElevatorInfoModel model = new ElevatorInfoModel()
                {
                    registrationCode = registrationCode,
                    elevatorPosition = elevatorPosition,
                    communityID = communityID
                };
                if (_infoBLL.Add(model))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "新增成功";
                }
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 编辑电梯绑定信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string EditElevatorInfo(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "编辑失败",
                RedirectUrl = string.Empty
            };
            string registrationCode = context.Request.Params["registrationCode"];
            string elevatorPosition = context.Request.Params["elevatorPosition"];
            int eID = string.IsNullOrEmpty(context.Request.Params["eID"]) ? 0 : int.Parse(context.Request.Params["eID"]);
            if (_infoBLL.Exists(registrationCode, eID))
            {
                jr.IsSucceed = false;
                jr.Msg = "注册码已经存在";
            }
            else
            {
                ElevatorInfoModel model = new ElevatorInfoModel()
                {
                    registrationCode = registrationCode,
                    elevatorPosition = elevatorPosition,
                    eID = eID
                };
                if (_infoBLL.Update(model))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "编辑成功";
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除注册码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeleteElevatorInfo(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除失败",
                RedirectUrl = string.Empty
            };
            int eID = string.IsNullOrEmpty(context.Request.Params["eID"]) ? 0 : int.Parse(context.Request.Params["eID"]);

            if (_infoBLL.Delete(eID))
            {
                jr.IsSucceed = true;
                jr.Msg = "删除成功";
            }

            return JsonConvert.SerializeObject(jr);
        }
        #endregion

        #region 电梯实时监控api
        /// <summary>
        /// 获取小区和电梯信息列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetListCommunityElevator(HttpContext context)
        {
            #region 分页参数
            int pagesize = 1;
            int pageindex = 1;
            string _pindex = context.Request["pageNumber"];
            string _psize = context.Request["pageSize"];

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
            string searchText = context.Request.Params["searchText"];
            int property = string.IsNullOrEmpty(context.Request["property"]) ? 0 : int.Parse(context.Request["property"]);
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(@" and c.propertyMId = {0} ", property);
            if (!string.IsNullOrEmpty(searchText))
            {
                strWhere.AppendFormat(@" and c.communityName like '%{0}%' ", searchText);
            }
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion

            int rowcount = 0;
            var pr = new PagingResultModel<List<ElevatorInfoModel>>()
            {
                total = 0,
                rows = new List<ElevatorInfoModel>()
            };

            pr.rows = _infoBLL.GetListElevatorInfo(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取电梯实时监控
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetLiftRunData(HttpContext context)
        {
            try
            {
                IERM.EccmWcf.ECCMServiceClient client = new IERM.EccmWcf.ECCMServiceClient();
                string registrationCode = context.Request.Params["registrationCode"];
                string communityID = context.Request.Params["communityID"];
                var data = client.GetLiftRunData(registrationCode);//MODEL.JsonResult

                return data;
            }
            catch (Exception e)
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = e.ToString(),
                    RedirectUrl = string.Empty
                };
                return JsonConvert.SerializeObject(jr);
            }
        }

        /// <summary>
        /// 获取电梯明细
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetLiftDetail(HttpContext context)
        {
            try
            {
                IERM.EccmWcf.ECCMServiceClient client = new IERM.EccmWcf.ECCMServiceClient();
                string registrationCode = context.Request.Params["registrationCode"];
                var data = client.GetLiftDetail(registrationCode);//MODEL.JsonResult

                return data;
            }
            catch (Exception e)
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = e.ToString(),
                    RedirectUrl = string.Empty
                };
                return JsonConvert.SerializeObject(jr);
            }
        }

        /// <summary>
        /// 获取电梯视频
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetLiftVideo(HttpContext context)
        {
            try
            {
                IERM.EccmWcf.ECCMServiceClient client = new IERM.EccmWcf.ECCMServiceClient();
                string registrationCode = context.Request.Params["registrationCode"];
                var data = client.GetLiftVideo(registrationCode);//MODEL.JsonResult

                return data;
            }
            catch (Exception e)
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = e.ToString(),
                    RedirectUrl = string.Empty
                };
                return JsonConvert.SerializeObject(jr);
            }
        }
        #endregion

        #region 报警记录
        /// <summary>
        /// 实时报警记录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetCurrentAlarmElevator(HttpContext context)
        {
            #region 分页
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
            int cityid = string.IsNullOrEmpty(context.Request.Params["cityID"]) ? 0 : int.Parse(context.Request.Params["cityID"]);
            int propertyid = string.IsNullOrEmpty(context.Request.Params["propertyID"]) ? 0 : int.Parse(context.Request.Params["propertyID"]);
            string partname = context.Request.Params["partName"];
            StringBuilder strWhere = new StringBuilder();
            if (cityid != 0)
            {
                strWhere.AppendFormat(" and cityID={0}", cityid);
            }
            if (propertyid != 0)
            {
                strWhere.AppendFormat(" and propertyID={0}", propertyid);
            }
            if (!string.IsNullOrEmpty(partname))
            {
                strWhere.AppendFormat(" and communityName like '%{0}%'", partname);
            }
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion

            var pr = new PagingResultModel<List<ViewAlarmelevatorModel>>()
            {
                total = 0,
                rows = new List<ViewAlarmelevatorModel>()
            };

            int rowcount = 0;
            pr.rows = _alarmBLL.GetCurrentAlarmElevator(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 历史报警记录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetHistoryAlarmElevator(HttpContext context)
        {
            #region 分页
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
            int cityid = string.IsNullOrEmpty(context.Request.Params["cityID"]) ? 0 : int.Parse(context.Request.Params["cityID"]);
            int propertyid = string.IsNullOrEmpty(context.Request.Params["propertyID"]) ? 0 : int.Parse(context.Request.Params["propertyID"]);
            string partname = context.Request.Params["partName"];
            string timespan = context.Request.Params["timeSpan"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value).AddDays(1);
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" and insertTime>'{0}' and insertTime<'{1}'", begintime, endtime);
            if (cityid != 0)
            {
                strWhere.AppendFormat(" and cityID={0}", cityid);
            }
            if (propertyid != 0)
            {
                strWhere.AppendFormat(" and propertyID={0}", propertyid);
            }
            if (!string.IsNullOrEmpty(partname))
            {
                strWhere.AppendFormat(" and communityName like '%{0}%'", partname);
            }
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion

            var pr = new PagingResultModel<List<ViewAlarmelevatorModel>>()
            {
                total = 0,
                rows = new List<ViewAlarmelevatorModel>()
            };

            int rowcount = 0;
            pr.rows = _alarmBLL.GetHistoryAlarmElevator(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


}