using IERM.BLL;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// EquipmentHandler 的摘要说明
    /// </summary>
    public class EquipmentHandler : IHttpHandler
    {
        private readonly EquipmentInfoBLL equinfo_bll = new EquipmentInfoBLL();
        private readonly EquipmentAccBLL equacc_bll = new EquipmentAccBLL();


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
                    case "getequinfobyhouseid"://获取设备房全部设备列表
                        result = GetEquinfoByhouseid(context);
                        break;
                    case "getequinfo"://获取设备详细信息
                        result = GetEquinfo(context);
                        break;
                    case "getequaccinfolist"://获取省市小区信息列表
                        result = GetEquAccInfoList(context);
                        break;
                    case "insertequipment"://添加设备信息
                        result = AddEquipment(context);
                        break;
                    case "updateequipment":// 更新设备信息
                        result = UpdateEquipment(context);
                        break;
                    case "deleteequipment":// 删除设备
                        result = DeleteEquipment(context);
                        break;
                    case "deleteequacc":// 删除设备附件信息
                        result = DeleteEquAcc(context);
                        break;
                    //case "getcpoe":// 获取(单级)省市小区选项树
                    //    result = GetCPOE(context);
                    //    break;
                    case "getequipmentinfolistbycommunity":
                        result = GetEquipmentInfoListByCommunity(context);
                        break;
                    case "getequipmentinfolistbycommunityforplan"://根据计划获取设备类型或者设备
                        result = GetEquipmentInfoListByCommunityForPlan(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取设备房安装的设备集合
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetEquinfoByhouseid(HttpContext context)
        {
            int pagesize = 10;
            int pageindex = 1;
            int houseid = 0;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize = context.Request.Params["pageSize"];
            string _houseid = context.Request.Params["houseID"]; //获取小区ID
            //string _propertyID = context.Request.Params["propertyID"];

            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }
            if (!string.IsNullOrEmpty(_houseid))
            {
                houseid = int.Parse(_houseid);
            }

            var equlist = equinfo_bll.GetEquListByHouseID(houseid, pagesize, pageindex, out rowcount);

            var pr = new PagingResultModel<List<EquipmentInfoModel>>()
            {
                total = rowcount,
                rows = equlist
            };
            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取指定设备详细信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetEquinfo(HttpContext context)
        {
            var jr = new JsonResultModel<ViewEquinfoModel>()
            {
                IsSucceed = false,
                Data = new ViewEquinfoModel(),
                Msg = "获取设备信息失败",
                RedirectUrl = string.Empty
            };

            int equid = string.IsNullOrEmpty(context.Request.Params["equID"]) ? 0 : int.Parse(context.Request.Params["equID"]);

            var data = equinfo_bll.GetEquipmentinfoByequId(equid);
            if (data != null)
            {
                jr.IsSucceed = true;
                jr.Data = data;
                jr.Msg = "获取设备信息成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取指定设备的配件信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetEquAccInfoList(HttpContext context)
        {
            var jr = new JsonResultModel<List<EquipmentaccModel>>()
            {
                IsSucceed = false,
                Data = new List<EquipmentaccModel>(),
                Msg = "获取设备配件信息失败",
                RedirectUrl = string.Empty
            };

            int equid = string.IsNullOrEmpty(context.Request.Params["equID"]) ? 0 : int.Parse(context.Request.Params["equID"]);

            var data = equacc_bll.GetEquAccByequID(equid);
            if (data != null)
            {
                jr.IsSucceed = true;
                jr.Data = data;
                jr.Msg = "获取设备配件信息成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddEquipment(HttpContext context)
        {
            var jr = new JsonResultModel<bool>()
            {
                IsSucceed = false,
                Data = false,
                Msg = "添加设备失败",
                RedirectUrl = string.Empty
            };

            var equdata = JsonConvert.DeserializeObject<EquipmentInfoModel>(context.Server.UrlDecode(context.Request.Params["equdata"]));
            var accdata = JsonConvert.DeserializeObject<List<EquipmentaccModel>>(context.Server.UrlDecode(context.Request.Params["accdata"]));

            if (equinfo_bll.Add(equdata, accdata) > 0)
            {
                jr.IsSucceed = true;
                jr.Data = true;
                jr.Msg = "添加设备成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 更新设备
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string UpdateEquipment(HttpContext context)
        {
            var jr = new JsonResultModel<bool>()
            {
                IsSucceed = false,
                Data = false,
                Msg = "更新设备失败",
                RedirectUrl = string.Empty
            };
            var equdata = JsonConvert.DeserializeObject<EquipmentInfoModel>(context.Server.UrlDecode(context.Request.Params["equdata"]));
            var accdata = JsonConvert.DeserializeObject<List<EquipmentaccModel>>(context.Server.UrlDecode(context.Request.Params["accdata"]));

            if (equinfo_bll.Update(equdata, accdata))
            {
                jr.Data = true;
                jr.IsSucceed = true;
                jr.Msg = "更新设备成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeleteEquipment(HttpContext context)
        {
            var jr = new JsonResultModel<bool>()
            {
                IsSucceed = false,
                Data = false,
                Msg = "删除设备失败",
                RedirectUrl = string.Empty
            };

            int equid = string.IsNullOrEmpty(context.Request.Params["equid"]) ? 0 : Convert.ToInt32(context.Request.Params["equid"]);

            if (equinfo_bll.Delete(equid))
            {
                jr.Data = true;
                jr.IsSucceed = true;
                jr.Msg = "删除设备成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除设备附件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeleteEquAcc(HttpContext context)
        {
            var jr = new JsonResultModel<bool>()
            {
                IsSucceed = false,
                Data = false,
                Msg = "删除设备附件失败",
                RedirectUrl = string.Empty
            };

            int accid = string.IsNullOrEmpty(context.Request.Params["accid"]) ? 0 : Convert.ToInt32(context.Request.Params["accid"]);

            if (equacc_bll.DeleteAcc(accid))
            {
                jr.Data = true;
                jr.IsSucceed = true;
                jr.Msg = "删除设备附件成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 根据小区获取设备
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetEquipmentInfoListByCommunity(HttpContext context)
        {
            var jr = new JsonResultModel<List<EquipmentInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<EquipmentInfoModel>(),
                Msg = "获取设备失败",
                RedirectUrl = string.Empty
            };

            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);

            var data = equinfo_bll.GetEquipmentInfoListByCommunity(communityID);
            if (data != null)
            {
                jr.IsSucceed = true;
                jr.Data = data;
                jr.Msg = "获取设备成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 根据计划获取设备类型或者设备
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetEquipmentInfoListByCommunityForPlan(HttpContext context)
        {
            var jr = new JsonResultModel<List<EquipmentInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<EquipmentInfoModel>(),
                Msg = "获取设备失败",
                RedirectUrl = string.Empty
            };

            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : int.Parse(context.Request.Params["communityID"]);
            int type = int.Parse(context.Request.Params["type"]);
            var data = equinfo_bll.GetEquipmentInfoListByCommunityForPlan(communityID, type);
            if (data != null)
            {
                jr.IsSucceed = true;
                jr.Data = data;
                jr.Msg = "获取设备成功";
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