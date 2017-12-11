
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IERM.BLL;
using System.Data;
using IERM.Model;
using IERM.Common;

namespace IERM.Handler
{
    /// <summary>
    /// UploadImgHandler 的摘要说明
    /// </summary>
    public class ImplementHandler : IHttpHandler
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
                    case "addinspectionimplement"://添加巡检实施
                        result = AddInspectionImplement(context);
                        break;
                    case "addrepairimplement"://添加维修实施记录
                        result = AddRepairImplement(context);
                        break;
                    case "addmaintenanceimplement"://添加维保实施记录
                        result = AddMaintenanceImplement(context);
                        break;
                    case "getimplementimg"://获取巡检图片
                        result = GetImplementImg(context);
                        break;
                }
            }
            context.Response.Write(result);
        }
        /// <summary>
        /// 添加巡检实施
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddInspectionImplement(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "添加失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string orderid = context.Request.Params["orderid"];
            string ordersn = context.Request.Params["ordersn"];
            string content = context.Request.Params["content"];
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                string imgurl = context.Request.Params["imgurl"];
                string type = context.Request.Params["type"];//1巡检2维保3维修

                //给对象赋值
                EccmInspectionOrderImplementModel model = new EccmInspectionOrderImplementModel();
                model.order_id = int.Parse(orderid);
                model.equCode = "";//该处没有设备编码
                model.implement_content = content;
                model.implement_time = DateTime.Now;
                model.uid_handle = int.Parse(uid);

                EccmInspectionOrderImplementBLL bll = new EccmInspectionOrderImplementBLL();
                int id = bll.Add(model);//插入并获取id
                if (id > 0)//实施内容插入成功
                {
                    EccmImplementImgModel img_model = new EccmImplementImgModel();
                    img_model.implement_id = id;
                    img_model.img_path = imgurl;
                    img_model.img_type = int.Parse(type); ;//1巡检2维保3维修
                    EccmImplementImgBLL img_bll = new EccmImplementImgBLL();
                    if (img_bll.Add(img_model))//插入实施图片
                    {
                        EccmInspectionOrderModel inspection_model = new EccmInspectionOrderModel();
                        inspection_model.order_id = int.Parse(orderid);
                        inspection_model.order_stats = 4;//0未派单1已派单2已接单3处理中4完成
                        inspection_model.order_finish_time = DateTime.Now;
                        EccmInspectionOrderBLL inspection_bll = new EccmInspectionOrderBLL();
                        inspection_bll.UpdateStates(inspection_model);//更改订单为完成
                        jr.IsSucceed = true;
                        jr.Msg = "添加成功";
                    }
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 添加维修实施记录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddRepairImplement(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "添加失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string orderid = context.Request.Params["orderid"];
            string ordersn = context.Request.Params["ordersn"];
            string content = context.Request.Params["content"];
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                string imgurl = context.Request.Params["imgurl"];
                string type = context.Request.Params["type"];//1巡检2维保3维修

                //给对象赋值
                EccmRepairOrderImplementModel model = new EccmRepairOrderImplementModel();
                model.order_id = int.Parse(orderid);
                model.equCode = "";//该处没有设备编码
                model.implement_content = content;
                model.implement_time = DateTime.Now;
                model.uid_handle = int.Parse(uid);

                EccmRepairOrderImplementBLL bll = new EccmRepairOrderImplementBLL();
                int id = bll.Add(model);//插入并获取id
                if (id > 0)//实施内容插入成功
                {
                    EccmImplementImgModel imgModel = new EccmImplementImgModel();
                    imgModel.implement_id = id;
                    imgModel.img_path = imgurl;
                    imgModel.img_type = int.Parse(type); ;//1巡检2维保3维修
                    EccmImplementImgBLL img_bll = new EccmImplementImgBLL();
                    if (img_bll.Add(imgModel))//插入实施图片
                    {
                        EccmRepairOrderModel repairModel = new EccmRepairOrderModel();
                        repairModel.order_id = int.Parse(orderid);
                        repairModel.r_state = 4;//0未派单1已派单2已接单3处理中4完成
                        repairModel.r_etime = DateTime.Now;
                        EccmRepairOrderBLL repairBLL = new EccmRepairOrderBLL();
                        repairBLL.UpdateStates(repairModel);//更改订单为完成
                        jr.IsSucceed = true;
                        jr.Msg = "添加成功";
                    }
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 添加维保实施记录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddMaintenanceImplement(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "添加失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string orderid = context.Request.Params["orderid"];
            string ordersn = context.Request.Params["ordersn"];
            string content = context.Request.Params["content"];
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                string imgurl = context.Request.Params["imgurl"];
                string type = context.Request.Params["type"];//1巡检2维保3维修

                //给对象赋值
                EccmMaintenanceOrderImplementModel model = new EccmMaintenanceOrderImplementModel();
                model.order_id = int.Parse(orderid);
                model.equCode = "";//该处没有设备编码
                model.implement_content = content;
                model.implement_time = DateTime.Now;
                model.uid_handle = int.Parse(uid);

                EccmMaintenanceOrderImplementBLL bll = new EccmMaintenanceOrderImplementBLL();
                int id = bll.Add(model);//插入并获取id
                if (id > 0)//实施内容插入成功
                {
                    EccmImplementImgModel imgModel = new EccmImplementImgModel();
                    imgModel.implement_id = id;
                    imgModel.img_path = imgurl;
                    imgModel.img_type = int.Parse(type); ;//1巡检2维保3维修
                    EccmImplementImgBLL img_bll = new EccmImplementImgBLL();
                    if (img_bll.Add(imgModel))//插入实施图片
                    {
                        EccmMaintenanceOrderModel maintenanceModel = new EccmMaintenanceOrderModel();
                        maintenanceModel.order_id = int.Parse(orderid);
                        maintenanceModel.order_stats = 4;//0未派单1已派单2已接单3处理中4完成
                        maintenanceModel.order_finish_time = DateTime.Now;
                        EccmMaintenanceOrderBLL maintenanceBLL = new EccmMaintenanceOrderBLL();
                        maintenanceBLL.UpdateStates(maintenanceModel);//更改订单为完成
                        jr.IsSucceed = true;
                        jr.Msg = "添加成功";
                    }
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 查询实施图片
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetImplementImg(HttpContext context)
        {
            var jr = new JsonResultModel<DataTable>()
            {
                IsSucceed = false,
                Data = null,
                Msg = "查询失败",
                RedirectUrl = string.Empty
            };

            //获取传递参数
            string implementid = context.Request.Params["implementid"];
            string type = context.Request.Params["type"];//1巡检2维保3维修
            EccmImplementImgBLL bll = new EccmImplementImgBLL();
            DataTable dt = bll.GetList(int.Parse(implementid), int.Parse(type));

            if (dt.Rows.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = dt;
                jr.Msg = "查询成功";
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