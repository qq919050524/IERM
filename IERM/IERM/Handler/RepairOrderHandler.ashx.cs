using IERM.BLL;
using IERM.Common;
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
    /// RepairHandler 的摘要说明
    /// </summary>
    public class RepairOrderHandler : IHttpHandler
    {
        private EccmRepairOrderBLL _reqairBLL = new EccmRepairOrderBLL();
        private EccmOrderDeviceStandardBLL _devBLL = new EccmOrderDeviceStandardBLL();
        private EccmRepairOrderImplementBLL _implementBLL = new EccmRepairOrderImplementBLL();
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
                    case "getrepairorderlist"://获取报修订单列表
                        result = GetRepairOrderList(context);
                        break;
                    case "addrepairorder"://新增
                        result = AddRepairOrder(context);
                        break;
                    case "deleterepairorder"://删除
                        result = DeleteRepairOrder(context);
                        break;
                    case "sendrepairorder"://派单
                        result = SendRepairOrder(context);
                        break;
                    case "getorderequipment"://获取工单设备
                        result = GetOrderEquipment(context);
                        break;
                    case "getorderimplementlist"://实施记录
                        result = GetOrderImplementList(context);
                        break;
                    case "getrepairuserorderlist"://获取用户报修订单列表
                        result = GetRepairUserOrderList(context);
                        break;
                }
            }
            context.Response.Write(result);

        }

        /// <summary>
        /// 获取报修订单列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetRepairOrderList(HttpContext context)
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
            string status = context.Request.Params["status"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value).AddDays(1);
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" and r.r_stime>'{0}' and r.r_stime<'{1}'", begintime, endtime);
            strWhere.AppendFormat(" and community_id={0} ", communityID);
            if (!string.IsNullOrEmpty(status))
            {
                strWhere.AppendFormat(" and r_state={0} ", status);
            }
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion
            int rowcount = 0;
            var pr = new PagingResultModel<List<EccmRepairOrderModel>>()
            {
                total = 0,
                rows = new List<EccmRepairOrderModel>()
            };
            pr.rows = _reqairBLL.GetRepairOrderList(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 新增报修工单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddRepairOrder(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "新增失败",
                RedirectUrl = string.Empty
            };
            string equCodes = context.Request.Params["equCodes"];
            string termtime = context.Request.Params["termtime"];
            string reason = context.Request.Params["reason"];
            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);
            string orderSn = OrderHelp.GetOrderSN("WX");
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                if (_reqairBLL.AddRepairOrder(orderSn, equCodes, communityID, reason, Convert.ToDateTime(termtime), Convert.ToInt32(uid)))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "新增成功";
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除报修工单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeleteRepairOrder(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除失败",
                RedirectUrl = string.Empty
            };
            string orderID = context.Request.Params["orderID"];
            if (_reqairBLL.DeleteRepairOrder(Convert.ToInt32(orderID)))
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
        private string SendRepairOrder(HttpContext context)
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
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];//派单人
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string dispatch = decodeCookie.Values["userid"];
                if (orderID > 0 && userID > 0)
                {
                    if (_reqairBLL.SendRepairOrder(orderID, userID, Convert.ToInt32(dispatch)))
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
            var pr = new PagingResultModel<List<EccmRepairOrderImplementModel>>()
            {
                total = 0,
                rows = new List<EccmRepairOrderImplementModel>()
            };
            pr.rows = _implementBLL.GetOrderImplementList(orderID, pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取用户报修订单列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetRepairUserOrderList(HttpContext context)
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
            string status = context.Request.Params["status"];

            int uid = 0;// int.Parse(context.Request.Cookies["EccmUserinfo"].Values["userid"]);
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                uid = int.Parse(decodeCookie.Values["userid"]);
            }
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value).AddDays(1);
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" and r.r_stime>'{0}' and r.r_stime<'{1}'", begintime, endtime);
            strWhere.AppendFormat(" and community_id={0} ", communityID);
            strWhere.AppendFormat(" and ru.uid_receiver={0} ", uid);
            strWhere.AppendFormat(" and ru.receiver_type={0} ", 3);//1巡检2维保3维修
            if (!string.IsNullOrEmpty(status))
            {
                strWhere.AppendFormat(" and r_state={0} ", status);
            }
            if (strWhere.Length > 0) strWhere.Remove(0, 4);
            #endregion
            int rowcount = 0;
            var pr = new PagingResultModel<List<EccmRepairOrderModel>>()
            {
                total = 0,
                rows = new List<EccmRepairOrderModel>()
            };
            pr.rows = _reqairBLL.GetRepairUserOrderList(strWhere.ToString(), pageindex, pagesize, out rowcount);
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