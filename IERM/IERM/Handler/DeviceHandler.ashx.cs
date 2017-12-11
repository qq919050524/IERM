using IERM.BLL;
using IERM.Common;
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
    /// DeviceTypeHandler 的摘要说明
    /// </summary>
    public class DeviceHandler : IHttpHandler
    {
        private readonly EccmDeviceTypeBLL bll = new EccmDeviceTypeBLL();
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
                    case "getdevicetype"://分页获取设备类型
                        result = GetDeviceType(context);
                        break;
                    case "getalldevicetype"://获取所有设备类型
                        result = GetAllDeviceType(context);
                        break;
                    case "adddevicetype"://添加新新设备类型
                        result = AddDeviceType(context);
                        break;
                    case "updatedevicetype"://编辑设备类型
                        result = UpdateDeviceType(context);
                        break;
                    case "deletedevicetype"://删除设备类型
                        result = DeleteDeviceType(context);
                        break;
                    case "addrelation"://添加设备标准关联
                        result = AddRelation(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取设备类型
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDeviceType(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageIndex"];
            string _psize = context.Request.Params["pageSize"];
            string _name = context.Request.Params["name"];
            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }

            var pr = new PagingResultModel<DataTable>()
            {
                total = 0,
                rows = new DataTable()
            };
            pr.rows = bll.GetList(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取所有设备类型
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAllDeviceType(HttpContext context)
        {
            int rowcount = 0;
            DataTable dt = bll.GetList("", 1, 9999, out rowcount);
            var jr = new JsonResultModel<DataTable>()
            {
                IsSucceed = false,
                Data = new DataTable(),
                Msg = "获取菜单失败",
            };
            if (dt != null && dt.Rows.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = dt;
                jr.Msg = "获取菜单成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        
        /// <summary>
        /// 添加新设备类型
        /// </summary>
        private string AddDeviceType(HttpContext context)
        {
            //设备类型编码
            string code = context.Request.Params["code"];
            //设备类型名字
            string name = context.Request.Params["name"];

            //新设备类型
            EccmDeviceTypeModel model = new EccmDeviceTypeModel();
            model.device_type_code = code;
            model.devide_type_name = name;

            try
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "添加设备类型失败",
                    RedirectUrl = ""
                };

                if (bll.Add(model))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "添加设备类型成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
               LogHelper.Debug("添加新设备类型（AddDeviceType）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 更新设备类型
        /// </summary>
        private string UpdateDeviceType(HttpContext context)
        {
            //设备类型ID
            string id = context.Request.Params["id"];
            //设备类型编码
            string code = context.Request.Params["code"];
            //设备类型名字
            string name = context.Request.Params["name"];

            //设备类型
            EccmDeviceTypeModel model = new EccmDeviceTypeModel();
            model.type_id = int.Parse(id);
            model.device_type_code = code;
            model.devide_type_name = name;

            try
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "修改设备类型失败",
                    RedirectUrl = ""
                };

                if (bll.Update(model))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "修改设备类型成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
               LogHelper.Debug("修改设备类型（UpdateDeviceType）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 删除设备类型
        /// </summary>
        private string DeleteDeviceType(HttpContext context)
        {
            string id = context.Request.Params["id"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除设备类型失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(id))
            {

                if (bll.Delete(int.Parse(id)))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "删除设备类型成功";
                    jr.Data = int.Parse(id);
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 添加设备类型和标准关联
        /// </summary>
        private string AddRelation(HttpContext context)
        {
            //设备类型编码
            string sid = context.Request.Params["sid"];
            //设备类型名字
            string code = context.Request.Params["code"];

            try
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "添加关联失败",
                    RedirectUrl = ""
                };

                if (bll.AddRelation(int.Parse(sid), code) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "添加关联成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
               LogHelper.Debug("添加设备类型和标准关联（AddRelation）---" + err.Message);
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