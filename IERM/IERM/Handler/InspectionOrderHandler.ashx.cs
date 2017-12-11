using IERM.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using IERM.Model;
using IERM.Common;

namespace IERM.Handler
{
    /// <summary>
    /// InspectionHandler 的摘要说明
    /// </summary>
    public class InspectionOrderHandler : IHttpHandler
    {
        private EccmInspectionOrderBLL _inspectionBLL = new EccmInspectionOrderBLL();
        private EccmOrderDeviceStandardBLL _devBLL = new EccmOrderDeviceStandardBLL();
        private EccmInspectionOrderImplementBLL _implementBLL = new EccmInspectionOrderImplementBLL();
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
                    case "getinspectionorderlist"://获取巡检工单列表
                        result = GetInspectionOrderList(context);
                        break;
                    case "addinspectionorder"://新增
                        result = AddInspectionOrder(context);
                        break;
                    case "deleteinspectionorder"://删除
                        result = DeleteInspectionOrder(context);
                        break;
                    case "sendinspectionorder"://派单
                        result = SendInspectionOrder(context);
                        break;
                    case "getorderequipment"://获取工单设备
                        result = GetOrderEquipment(context);
                        break;
                    case "getorderimplementlist"://实施记录
                        result = GetOrderImplementList(context);
                        break;
                    case "getinspectionuserorderlist"://获取用户工单列表
                        result = GetInspectionUserOrderList(context);
                        break;
                }
            }
            context.Response.Write(result);

        }

        /// <summary>
        /// 获取巡检订单列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetInspectionOrderList(HttpContext context)
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
            string timespan = context.Request.Params["timeSpan"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value).AddDays(1);
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" and order_time>'{0}' and order_time<'{1}'", begintime, endtime);
            strWhere.AppendFormat(" and community_id={0} ", communityID);
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion
            int rowcount = 0;
            var pr = new PagingResultModel<DataTable>()
            {
                total = 0,
                rows = new DataTable()
            };
            pr.rows = _inspectionBLL.GetInspectionOrderList(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取用户工单列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetInspectionUserOrderList(HttpContext context)
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
            var pr = new PagingResultModel<DataTable>()
            {
                total = 0,
                rows = new DataTable()
            };
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                string timespan = context.Request.Params["timeSpan"];
                var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
                DateTime begintime = DateTime.Parse(ts[0].Value);
                DateTime endtime = DateTime.Parse(ts[1].Value).AddDays(1);
                StringBuilder strWhere = new StringBuilder();
                strWhere.AppendFormat(" and order_time>'{0}' and order_time<'{1}'", begintime, endtime);
                strWhere.AppendFormat(" and community_id={0} ", communityID);
                strWhere.AppendFormat(" and ru.uid_receiver={0} ", uid);
                strWhere.AppendFormat(" and ru.receiver_type={0} ", 1);//1巡检2维保3维修
                if (strWhere.Length > 0) strWhere.Remove(0, 4);
                #endregion
                int rowcount = 0;

                pr.rows = _inspectionBLL.GetInspectionUserOrderList(strWhere.ToString(), pageindex, pagesize, out rowcount);
                pr.total = rowcount;
            }
            return JsonConvert.SerializeObject(pr);
        }
        /// <summary>
        /// 新增巡检工单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddInspectionOrder(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "新增失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string equCodes = context.Request.Params["equCodes"];
            string termtime = context.Request.Params["termtime"];
            //string reason = context.Request.Params["reason"];
            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);
            string orderSn = OrderHelp.GetOrderSN("XJ");
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                //给对象赋值
                EccmInspectionOrderModel model = new EccmInspectionOrderModel();
                model.order_sn = orderSn;
                model.order_stats = 0;
                model.order_time = DateTime.Now;
                model.order_type = 0;
                model.term_time = DateTime.Parse(termtime);
                model.community_id = communityID;
                model.uid = int.Parse(uid);
                //model.plan_id = 0;//手动增加工单时，该字段为0

                if (_inspectionBLL.Add(model, equCodes))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "新增成功";
                }
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除巡检工单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeleteInspectionOrder(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除失败",
                RedirectUrl = string.Empty
            };
            string orderID = context.Request.Params["orderID"];
            if (_inspectionBLL.Delete(Convert.ToInt32(orderID)))
            {
                jr.IsSucceed = true;
                jr.Msg = "删除成功";
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string SendInspectionOrder(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "派单失败",
                RedirectUrl = string.Empty
            };
            int orderID = string.IsNullOrEmpty(context.Request.Params["orderID"]) ? 0 : int.Parse(context.Request.Params["orderID"]);
            int userID = string.IsNullOrEmpty(context.Request.Params["userID"]) ? 0 : int.Parse(context.Request.Params["userID"]);
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);

                string dispatch = decodeCookie.Values["userid"];//派单人
                if (orderID > 0 && userID > 0)
                {
                    if (_inspectionBLL.SendInspectionOrder(orderID, userID, Convert.ToInt32(dispatch)))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "派单成功";
                    }

                }
            }

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取工单设备
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetOrderEquipment(HttpContext context)
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
            string orderSN = context.Request.Params["orderSN"];
            #endregion
            int rowcount = 0;
            var pr = new PagingResultModel<List<EccmOrderDeviceStandardModel>>()
            {
                total = 0,
                rows = new List<EccmOrderDeviceStandardModel>()
            };
            pr.rows = _devBLL.GetOrderEquipmentList(orderSN, pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }
        /// <summary>
        /// 获取实施记录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetOrderImplementList(HttpContext context)
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
            int orderID = string.IsNullOrEmpty(context.Request.Params["orderID"]) ? 0 : int.Parse(context.Request.Params["orderID"]);
            #endregion
            int rowcount = 0;
            var pr = new PagingResultModel<List<EccmInspectionOrderImplementModel>>()
            {
                total = 0,
                rows = new List<EccmInspectionOrderImplementModel>()
            };
            pr.rows = _implementBLL.GetOrderImplementList(orderID, pageindex, pagesize, out rowcount);
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