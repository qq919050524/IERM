
using IERM.BLL;
using IERM.Common;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// 小区和城市信息相关操作
    /// </summary>
    public class CityAndCommunity : IHttpHandler
    {
        private readonly CityInfoBLL city_bll = new CityInfoBLL();
        private readonly CommunityInfoBLL community_bll = new CommunityInfoBLL();
        private readonly DevInfoBLL devinfo_bll = new DevInfoBLL();
        private readonly MonitorPageBLL mcontent_bll = new MonitorPageBLL();
        private readonly DevHouseSysTypeBLL housetype_bll = new DevHouseSysTypeBLL();

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
                    case "getprovinces"://获取所有省份列表
                        result = GetProvinces(context);
                        break;
                    case "getcitys"://获取所有的城市列表GetCmmunity
                        result = GetCitys(context);
                        break;
                    case "getcommunity"://获取城市下所有小区
                        result = GetCommunity(context);
                        break;
                    case "getpcc"://获取省市小区信息列表
                        result = GetPCC(context);
                        break;
                    case "getdevbycid"://获取小区对应设备列表
                        result = GetDevByCid(context);
                        break;
                    case "getcpot":// 获取省市小区选项树
                        result = GetCPOT(context);
                        break;
                    case "getcpoe":// 获取(单级)省市小区选项树
                        result = GetCPOE(context);
                        break;
                    case "getmonitorcontent":// 获取监控内容
                        result = GetMonitorContent(context);
                        break;
                    case "getdevhousesystype":// 获取设备房系统类型
                        result = GetDevHouseSystype(context);
                        break;
                    case "getdevhouseandsystype":// 获取设备房系及所含系统
                        result = GetDevHouseAndSysType(context);
                        break;
                    case "getcity":// 获取省市选项树  todo
                        result = GetCity(context);
                        break;
                    case "getcitycommunity": //获取某个城市的所有小区  TODO
                        result = GetCityCommunity(context);
                        break;
                    case "getcommunitydev": //获取某个小区的所有设备 TODO
                        result = GetCommunityDev(context);
                        break;
                    case "getpropertycommunity": //获取某个物业下面的所有小区   TODO
                        result = GetPropertyComm(context);
                        break;
                    case "getaddcommunity": //添加小区  TODO
                        result = AddCommunity(context);
                        break;
                    case "deletecomm": //删除小区  TODO
                        result = DeleteCommunity(context);
                        break;
                    case "updatecomm": //编辑小区  TODO
                        result = UpdateCommunity(context);
                        break;
                    case "getallommunity": //获取所有小区 TODO
                        result = GetAllCommunity(context);
                        break;
                    case "getcommunitybyid": //获取单个小区  TODO
                        result = GetCommunityById(context);
                        break;
                    case "getprocpot": //通过物业公司获取小区  TODO
                        result = GetProCPOT(context);
                        break;
                    case "getdevice":
                        result = GetdeviceRelation(context);
                        break;
                    case "getcommunitybyuser":
                        result = GetCommunityByUser(context);
                        break;
                }
            }
            context.Response.Write(result);
        }
        private string GetdeviceRelation(HttpContext context)
        {
            var jr = new JsonResultModel<List<DeviceRelationModel>>()
            {
                IsSucceed = false,
                Data = new List<DeviceRelationModel>(),
                Msg = "获取配电房设备失败",
                RedirectUrl = string.Empty
            };
            DeviceRelationBLL bll = new DeviceRelationBLL();
            int devhouseID = Convert.ToInt32(context.Request.QueryString["devhouseID"]);
            try
            {
                List<DeviceRelationModel> list = bll.GetDeviceRelation(devhouseID);
                jr.Data = list;
                jr.IsSucceed = true;
            }
            catch (Exception ex)
            {
                jr.Msg = ex.Message;
            }
            return JsonConvert.SerializeObject(jr);
        }
        /// <summary>
        /// 获取指定设备房所含系统
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDevHouseSystype(HttpContext context)
        {
            var jr = new JsonResultModel<List<DevHouseSysTypeModel>>()
            {
                IsSucceed = false,
                Data = new List<DevHouseSysTypeModel>(),
                Msg = "获取设备房系统类型失败",
                RedirectUrl = string.Empty
            };

            int devhouseid = string.IsNullOrEmpty(context.Request.Params["devhouseID"]) ? 0 : Convert.ToInt32(context.Request.Params["devhouseID"]);
            //int userid = string.IsNullOrEmpty(context.Request.Params["userID"]) ? 0 : Convert.ToInt32(context.Request.Params["userID"]);
            var typeList = housetype_bll.GetHouseSystype(devhouseid);
            if (typeList != null && typeList.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = typeList;
                jr.Msg = "获取设备房系统类型成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取小区对应设备房列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDevByCid(HttpContext context)
        {
            int pagesize = 10;
            int pageindex = 1;
            int communityid = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize = context.Request.Params["pageSize"];
            string _communityid = context.Request.Params["communityID"];
            bool _timeliness = string.IsNullOrEmpty(context.Request.Params["timeliness"]) ? false : true;

            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }
            if (!string.IsNullOrEmpty(_communityid))
            {
                communityid = int.Parse(_communityid);
            }
            var devlist = GetAllDevinfo(_timeliness);

            var pr = new PagingResultModel<List<DevInfoModel>>()
            {
                total = 0,
                rows = new List<DevInfoModel>()
            };
            pr.rows = devlist.Where(d => d.communityID == communityid).ToList();
            pr.total = pr.rows.Count;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取小区设备房及包含的设备类型
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDevHouseAndSysType(HttpContext context)
        {
            var jr = new JsonResultModel<List<DevInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<DevInfoModel>(),
                Msg = "获取设备房及类型失败",
                RedirectUrl = string.Empty
            };

            int _communityid = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : Convert.ToInt32(context.Request.Params["communityID"]);
            int devType = string.IsNullOrEmpty(context.Request.Params["attribute"]) ? 0 : Convert.ToInt32(context.Request.Params["attribute"]);
            int systypeID = string.IsNullOrEmpty(context.Request.Params["systypeID"]) ? 0 : Convert.ToInt32(context.Request.Params["systypeID"]);

            var dhsList = devinfo_bll.GetDevHouseAndSysType(_communityid, devType, systypeID);
            if (dhsList != null && dhsList.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = dhsList;
                jr.Msg = "获取设备房及类型成功";
            }
            return JsonConvert.SerializeObject(jr);
        }


        /// <summary>
        /// 获取实时监控展示内容
        /// </summary>
        /// <returns></returns>
        private string GetMonitorContent(HttpContext context)
        {
            var jr = new JsonResultModel<MonitorPageModel>()
            {
                IsSucceed = false,
                Data = new MonitorPageModel(),
                Msg = "获取监控显示信息失败",
                RedirectUrl = string.Empty
            };

            int devhouseid = string.IsNullOrEmpty(context.Request.Params["devhouseID"]) ? 0 : Convert.ToInt32(context.Request.Params["devhouseID"]);
            int systypeid = string.IsNullOrEmpty(context.Request.Params["systypeID"]) ? 0 : Convert.ToInt32(context.Request.Params["systypeID"]);

            var mcontent = mcontent_bll.GetMonitorPage(devhouseid, systypeid);
            if (mcontent != null)
            {
                jr.IsSucceed = true;
                jr.Data = mcontent;
                jr.Msg = "获取监控显示信息成功";
            }
            return JsonConvert.SerializeObject(jr);
        }


        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        private string GetProvinces(HttpContext context)
        {
            List<CityInfoModel> citylist = GetAllCity();

            var jr = new JsonResultModel<List<CityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CityInfoModel>(),
                Msg = "获取城市信息失败",
                RedirectUrl = string.Empty
            };
            if (citylist != null && citylist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = citylist.Where(c => c.pID == 0).ToList();
                jr.Msg = "获取省份成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取指定省份的城市集合
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCitys(HttpContext context)
        {
            string _pid = context.Request.Params["pid"];
            int pid = -1;
            if (!string.IsNullOrEmpty(_pid))
            {
                int.TryParse(_pid, out pid);
            }
            var jr = new JsonResultModel<List<CityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CityInfoModel>(),
                Msg = "获取城市信息失败",
                RedirectUrl = string.Empty
            };
            var citylist = CacheHelper.GetCache("areas") as List<CityInfoModel>;
            if (citylist != null && citylist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = citylist.Where(c => c.pID == pid).ToList();
                jr.Msg = "获取城市成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取城市小区集合
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCommunity(HttpContext context)
        {
            var jr = new JsonResultModel<List<CommunityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CommunityInfoModel>(),
                Msg = "获取小区信息失败",
                RedirectUrl = string.Empty
            };
            //int userid = string.IsNullOrEmpty(context.Request.Params["userID"]) ? 0 : Convert.ToInt32(context.Request.Params["userID"]);
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string userid = decodeCookie.Values["userid"];
                List<CommunityInfoModel> communitylist = GetAllCommunity();

                string _cid = context.Request.Params["cid"];
                int cid = -1;
                if (!string.IsNullOrEmpty(_cid))
                {
                    int.TryParse(_cid, out cid);
                }

                if (communitylist != null && communitylist.Count > 0)
                {
                    jr.IsSucceed = true;
                    jr.Data = communitylist.Where(c => c.pCityID == cid).ToList();
                    jr.Msg = "获取小区成功";
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        //private List<devinfo> Get
        /// <summary>
        /// 获取省市小区列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetPCC(HttpContext context)
        {
            //int userid = string.IsNullOrEmpty(context.Request.Params["userID"]) ? 0 : Convert.ToInt32(context.Request.Params["userID"]);
            var citylist = GetAllCity();
            var communitylist = GetAllCommunity();
            //var devlist = GetAllDevinfo();
            var ppclist = new List<TreeViewModel>();
            string pid = context.Request.Params["pid"];
            string cid = context.Request.Params["cid"];
            string cmid = context.Request.Params["cmid"];

            foreach (var pp in citylist.Where(p => p.pID == 0))
            {
                //省份
                var model = new TreeViewModel();
                model.id = pp.areaID.ToString();
                model.text = pp.areaName;
                model.nodes = new List<TreeViewModel>();
                model.selectable = false;
                if (model.id == pid)
                {
                    model.state.expanded = true;
                }
                ppclist.Add(model);

                foreach (var cc in citylist.Where(c => c.pID == pp.areaID))
                {
                    //城市
                    var city = new TreeViewModel();
                    city.id = cc.areaID.ToString();
                    city.text = cc.areaName;
                    city.selectable = false;
                    if (communitylist.Count(cmc => cmc.pCityID == cc.areaID) > 0)
                    {
                        if (city.id == cid)
                        {
                            city.state.expanded = true;
                        }
                        city.nodes = new List<TreeViewModel>();
                        foreach (var cmy in communitylist.Where(cm => cm.pCityID == cc.areaID))
                        {
                            //小区
                            var community = new TreeViewModel();
                            community.id = cmy.communityID.ToString();
                            community.text = cmy.communityName;
                            community.selectable = true;
                            if (community.id == cmid)
                            {
                                community.state.selected = true;
                            }
                            //if (devlist.Count(dc => dc.communityID == cmy.communityID) > 0)
                            //{
                            //    community.nodes = new List<TreeViewModel>();
                            //    foreach (var de in devlist.Where(d => d.communityID == cmy.communityID))
                            //    {
                            //        //设备
                            //        var device = new TreeViewModel();
                            //        device.id = de.devID.ToString();
                            //        device.text = de.devName;
                            //        device.color = "#ff0394";
                            //        //device.backColor = "";
                            //        community.nodes.Add(device);
                            //    }
                            //}
                            city.nodes.Add(community);
                        }
                    }
                    model.nodes.Add(city);

                }
            }

            var jr = new JsonResultModel<List<TreeViewModel>>()
            {
                IsSucceed = false,
                Data = new List<TreeViewModel>(),
                Msg = "获取省市小区信息失败",
                RedirectUrl = string.Empty
            };


            if (ppclist != null && ppclist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = ppclist;
                jr.Msg = "获取省市小区成功";
            }
            string s = JsonConvert.SerializeObject(jr);
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取某物业公司所有小区
        /// </summary>
        /// <returns></returns>
        private List<CommunityInfoModel> GetPropertyCommunity(string propertyMId, string pCityID)
        {
            List<CommunityInfoModel> communitylist = null;
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];

                if (CacheHelper.GetCache("getpropertycommunity") == null)
                {
                    communitylist = community_bll.GetProperCommunity(propertyMId, pCityID, int.Parse(uid));
                    if (communitylist != null)
                    {
                        //在缓存中保存24小时
                        //CacheHelper.SetCache("getpropertycommunity", communitylist, 24);
                    }
                }
                else
                {
                    communitylist = CacheHelper.GetCache("getpropertycommunity") as List<CommunityInfoModel>;
                }
            }
            return communitylist;
        }

        /// <summary>
        /// 根据物业公司获取省市小区选项树
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetProCPOT(HttpContext context)
        {
            string _propertyid = context.Request.Params["propertyid"];
            string _pcityid = context.Request.Params["pcityid"];

            System.Text.StringBuilder opts = new System.Text.StringBuilder();
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = string.Empty,
                Msg = "获取省市小区选项树失败",
                RedirectUrl = string.Empty
            };
            var citylist = GetAllCity();
            var procommunitylst = GetPropertyCommunity(_propertyid, _pcityid);
            foreach (var pp in citylist.Where(p => p.pID == 0))
            {
                //省份
                opts.AppendFormat("<option value='{0}' disabled>{1}</option>", pp.areaID, pp.areaName);
                foreach (var cc in citylist.Where(c => c.pID == pp.areaID))
                {
                    if (procommunitylst.Count(cmc => cmc.pCityID == cc.areaID) > 0)
                    {
                        //城市
                        opts.AppendFormat("<option disabled='disabled' value='{0}' data-value='{0}' data-level='2' parent='{1}'>{2}</option>", cc.areaID, pp.areaID, cc.areaName);
                        foreach (var cmy in procommunitylst.Where(cm => cm.pCityID == cc.areaID))
                        {
                            //小区
                            opts.AppendFormat("<option data-value='{0}' data-level='3' parent='{1}'>{2}</option>", cmy.communityID, cc.areaID, cmy.communityName);
                        }
                    }
                    else
                    {
                        //城市
                        opts.AppendFormat("<option disabled parent='{1}'>{0}</option>", cc.areaName, pp.areaID);
                    }
                }
            }
            if (!string.IsNullOrEmpty(opts.ToString()))
            {
                jr.IsSucceed = true;
                jr.Data = opts.ToString();
                jr.Msg = "获取省市小区选项树成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取省市小区选项树
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCPOT(HttpContext context)
        {
            //int userid = string.IsNullOrEmpty(context.Request.Params["userID"]) ? 0 : Convert.ToInt32(context.Request.Params["userID"]);
            System.Text.StringBuilder opts = new System.Text.StringBuilder();
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = string.Empty,
                Msg = "获取省市小区选项树失败",
                RedirectUrl = string.Empty
            };
            var citylist = GetAllCity();
            var communitylist = GetAllCommunity();

            foreach (var pp in citylist.Where(p => p.pID == 0))
            {
                //省份
                opts.AppendFormat("<option value='{0}' disabled>{1}</option>", pp.areaID, pp.areaName);
                foreach (var cc in citylist.Where(c => c.pID == pp.areaID))
                {
                    if (communitylist.Count(cmc => cmc.pCityID == cc.areaID) > 0)
                    {
                        //城市
                        opts.AppendFormat("<option value='{0}' data-value='{0}' data-level='2' parent='{1}'>{2}</option>", cc.areaID, pp.areaID, cc.areaName);
                        foreach (var cmy in communitylist.Where(cm => cm.pCityID == cc.areaID))
                        {
                            //小区
                            opts.AppendFormat("<option data-value='{0}' data-level='3' parent='{1}'>{2}</option>", cmy.communityID, cc.areaID, cmy.communityName);
                        }
                    }
                    else
                    {
                        //城市
                        opts.AppendFormat("<option disabled parent='{1}'>{0}</option>", cc.areaName, pp.areaID);
                    }
                }
            }
            if (!string.IsNullOrEmpty(opts.ToString()))
            {
                jr.IsSucceed = true;
                jr.Data = opts.ToString();
                jr.Msg = "获取省市小区选项树成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取省市小区选项树
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCPOE(HttpContext context)
        {

            System.Text.StringBuilder opts = new System.Text.StringBuilder();
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = string.Empty,
                Msg = "获取省市小区选项树失败",
                RedirectUrl = string.Empty
            };
            int pid = string.IsNullOrEmpty(context.Request.Params["propertyID"]) ? 0 : Convert.ToInt32(context.Request.Params["propertyID"]);
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                int id = Convert.ToInt32(decodeCookie.Values["userid"]);
                //string uid = context.Request.Cookies.AllKeys['userinfo'];
                //System.Text.RegularExpressions.Regex.IsMatch(uid, "^\\d+$");
                var citylist = GetAllCity();
                var communitylist = GetAllCommunity();
                if (pid > 0)
                {
                    communitylist = communitylist.Where(s => s.propertyMId == pid).ToList();
                }
                #region 取得城市信息
                foreach (var pp in citylist.Where(p => p.pID == 0))
                {
                    //省份
                    opts.AppendFormat("<option value='{0}' data-level='1' disabled>{1}</option>", pp.areaID, pp.areaName);
                    foreach (var cc in citylist.Where(c => c.pID == pp.areaID))
                    {
                        if (communitylist.Count(cmc => cmc.pCityID == cc.areaID) > 0)
                        {
                            //城市
                            opts.AppendFormat("<option data-level='2' value='{0}' disabled parent='{1}'>{2}</option>", cc.areaID, pp.areaID, cc.areaName);
                            foreach (var cmy in communitylist.Where(cm => cm.pCityID == cc.areaID))
                            {
                                //小区
                                opts.AppendFormat("<option data-level='3' data-value='{0}' parent='{1}'>{2}</option>", cmy.communityID, cc.areaID, cmy.communityName);
                            }
                        }
                        else
                        {
                            //城市
                            opts.AppendFormat("<option data-level='2' disabled parent='{1}'>{0}</option>", cc.areaName, pp.areaID);
                        }
                    }
                }
                #endregion
            }
            if (!string.IsNullOrEmpty(opts.ToString()))
            {
                jr.IsSucceed = true;
                jr.Data = opts.ToString();
                jr.Msg = "获取省市小区选项树成功";
            }
            return JsonConvert.SerializeObject(jr);

        }

        #region -------在缓存中操作省市小区设备房信息----------------
        /// <summary>
        /// 获取全部省市信息列表
        /// </summary>
        private List<CityInfoModel> GetAllCity()
        {
            List<CityInfoModel> citylist = null;
            if (CacheHelper.GetCache("areas") == null)
            {
                citylist = city_bll.GetAllCity();
                if (citylist != null)
                {
                    CacheHelper.SetCache("areas", citylist, 24);
                }
            }
            else
            {
                citylist = CacheHelper.GetCache("areas") as List<CityInfoModel>;
            }
            return citylist;
        }

        /// <summary>
        /// 获取全部小区信息
        /// </summary>
        /// <returns></returns>
        private List<CommunityInfoModel> GetAllCommunity()
        {
            List<CommunityInfoModel> communitylist = null;
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                if (CacheHelper.GetCache("community") == null)
                {
                    communitylist = community_bll.GetCommunity(" and isdel=0 ", int.Parse(uid)).OrderBy(o => o.communityID).ToList();
                    if (communitylist != null)
                    {
                        //在缓存中保存24小时
                        CacheHelper.SetCache("community", communitylist, 24);
                    }
                }
                else
                {
                    communitylist = CacheHelper.GetCache("community") as List<CommunityInfoModel>;
                }
            }
            return communitylist;
        }

        /// <summary>
        /// 获取全部设备房列表
        /// </summary>
        private List<DevInfoModel> GetAllDevinfo(bool timeliness)
        {
            if (timeliness)
            {
                return devinfo_bll.GetAllDevinfo();
            }
            List<DevInfoModel> devlist = null;
            if (CacheHelper.GetCache("device") == null)
            {
                devlist = devinfo_bll.GetAllDevinfo();
                if (devlist != null)
                {
                    CacheHelper.SetCache("device", devlist, 24);
                }
            }
            else
            {
                devlist = CacheHelper.GetCache("device") as List<DevInfoModel>;
            }
            return devlist;
        }
        #endregion

        /// <summary>
        /// 获取省市选项树
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCity(HttpContext context)
        {
            System.Text.StringBuilder opts = new System.Text.StringBuilder();
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = string.Empty,
                Msg = "获取省市选项树失败",
                RedirectUrl = string.Empty
            };
            var citylist = GetAllCity();

            foreach (var pp in citylist.Where(p => p.pID == 0))
            {
                //省份
                opts.AppendFormat("<option value='{0}' disabled>{1}</option>", pp.areaID, pp.areaName);
                foreach (var cc in citylist.Where(c => c.pID == pp.areaID))
                {
                    opts.AppendFormat("<option value='{0}' data-value='{0}' data-level='2' parent='{1}'>{2}</option>", cc.areaID, pp.areaID, cc.areaName);
                }
            }
            if (!string.IsNullOrEmpty(opts.ToString()))
            {
                jr.IsSucceed = true;
                jr.Data = opts.ToString();
                jr.Msg = "获取省市选项树成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        ///小区精确到城市
        /// </summary>
        /// <returns></returns>
        private string GetCityCommunity(HttpContext context)
        {
            string _areaID = context.Request.Params["areaID"];
            int areaID = -1;
            if (!string.IsNullOrEmpty(_areaID))
            {
                int.TryParse(_areaID, out areaID);
            }
            List<CommunityInfoModel> communitylist = GetCityCommunity(areaID);
            var jr = new JsonResultModel<List<CommunityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CommunityInfoModel>(),
                Msg = "获取小区信息失败",
                RedirectUrl = string.Empty
            };

            if (communitylist != null && communitylist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = communitylist.Where(c => c.pCityID == areaID).ToList();
                jr.Msg = "获取小区成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        ///设备房精确到小区
        /// </summary>
        /// <returns></returns>
        private string GetCommunityDev(HttpContext context)
        {

            string _communityid = context.Request.Params["communityid"];
            string _devtype = context.Request.Params["devtype"];

            int communityid = -1;
            if (!string.IsNullOrEmpty(_communityid))
            {
                int.TryParse(_communityid, out communityid);
            }
            int devtype = -1;
            if (!string.IsNullOrEmpty(_devtype))
            {
                int.TryParse(_devtype, out devtype);
            }

            List<ParameterModel> lstcommdev = new List<ParameterModel>();
            ParameterModel comdev = new ParameterModel();
            comdev.Communityid = communityid;
            comdev.Devtype = devtype;
            lstcommdev.Add(comdev);

            List<DevInfoModel> devlist = GetCommunityALLDev(communityid, devtype);
            var jr = new JsonResultModel<List<DevInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<DevInfoModel>(),
                Msg = "获取设备信息失败",
                RedirectUrl = string.Empty
            };

            if (devlist != null && devlist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = devlist.Where(c => lstcommdev[0] == lstcommdev[0]).ToList();
                jr.Msg = "获取设备信息成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 某小区的所有设备
        /// </summary>
        /// <param name="areaid"></param>
        /// <param name="communityid"></param>
        /// <param name="devtype"></param>
        /// <param name="propertyid"></param>
        /// <returns></returns>
        private List<DevInfoModel> GetCommunityALLDev(int communityid, int devtype)
        {
            List<DevInfoModel> devlist = null;
            if (CacheHelper.GetCache("getcommunitydev") == null)
            {
                devlist = devinfo_bll.GetCommunityDevinfo(communityid, devtype);
                if (devlist != null)
                {
                    //在缓存中保存24小时
                    //CacheHelper.SetCache("getcommunitydev", devlist, 24);
                }
            }
            else
            {
                devlist = CacheHelper.GetCache("getcommunitydev") as List<DevInfoModel>;
            }
            return devlist;
        }



        private string GetAllCommunity(HttpContext context)
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
            var pr = new PagingResultModel<List<CommunityInfoModel>>()
            {
                total = 0,
                rows = new List<CommunityInfoModel>()
            };
            pr.rows = community_bll.GetAllCommunity(pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 添加小区
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string AddCommunity(HttpContext context)
        {
            try
            {
                string communityName = context.Request.Params["communityName"];
                int cityid = string.IsNullOrEmpty(context.Request.Params["selectcity"]) ? 0 : Convert.ToInt32(context.Request.Params["selectcity"]);
                int proid = string.IsNullOrEmpty(context.Request.Params["selectppi"]) ? 0 : Convert.ToInt32(context.Request.Params["selectppi"]);
                decimal cuLongitude = string.IsNullOrEmpty(context.Request.Params["cuLongitude"]) ? 0 : Convert.ToDecimal(context.Request.Params["cuLongitude"]);
                decimal cuLatitude = string.IsNullOrEmpty(context.Request.Params["cuLatitude"]) ? 0 : Convert.ToDecimal(context.Request.Params["cuLatitude"]);
                decimal acreage = string.IsNullOrEmpty(context.Request.Params["acreage"]) ? 0 : Convert.ToDecimal(context.Request.Params["acreage"]);
                string address = context.Request.Params["address"];
                string intro = context.Request.Params["intro"];

                int flag = community_bll.AddCommunity(new CommunityInfoModel()
                {
                    communityName = communityName,
                    pCityID = cityid,
                    propertyMId = proid,
                    cuLongitude = cuLongitude,
                    cuLatitude = cuLatitude,
                    acreage = acreage,
                    address = address,
                    intro = intro
                });

                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "添加小区失败",
                    RedirectUrl = ""
                };

                if (flag > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "添加小区成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {

                LogHelper.Debug("添加新小区（AddCommunity）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 删除小区
        /// </summary>
        private string DeleteCommunity(HttpContext context)
        {
            string communityid = context.Request.Params["communityid"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除小区失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(communityid))
            {
                int cid = 0;
                int.TryParse(communityid, out cid);

                if (community_bll.DeleteCommunity(cid) > 0)
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
        public string UpdateCommunity(HttpContext context)
        {

            string communityid = context.Request.Params["hd_communityid"];
            string communityName = context.Request.Params["communityName"];
            int cityid = string.IsNullOrEmpty(context.Request.Params["selectcity"]) ? 0 : Convert.ToInt32(context.Request.Params["selectcity"]);
            int proid = string.IsNullOrEmpty(context.Request.Params["selectppi"]) ? 0 : Convert.ToInt32(context.Request.Params["selectppi"]);
            decimal cuLongitude = string.IsNullOrEmpty(context.Request.Params["cuLongitude"]) ? 0 : Convert.ToDecimal(context.Request.Params["cuLongitude"]);
            decimal cuLatitude = string.IsNullOrEmpty(context.Request.Params["cuLatitude"]) ? 0 : Convert.ToDecimal(context.Request.Params["cuLatitude"]);
            decimal acreage = string.IsNullOrEmpty(context.Request.Params["acreage"]) ? 0 : Convert.ToDecimal(context.Request.Params["acreage"]);
            string address = context.Request.Params["address"];
            string intro = context.Request.Params["intro"];

            int flag = community_bll.UpdateCommunity(new CommunityInfoModel()
            {
                communityID = int.Parse(communityid),
                communityName = communityName,
                pCityID = cityid,
                propertyMId = proid,
                cuLongitude = cuLongitude,
                cuLatitude = cuLatitude,
                acreage = acreage,
                address = address,
                intro = intro
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

        /// <summary>
        /// 获取某个小区信息
        /// </summary>
        /// <returns></returns>
        private string GetCommunityById(HttpContext context)
        {
            var jr = new JsonResultModel<List<CommunityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CommunityInfoModel>(),
                Msg = "获取小区信息失败",
                RedirectUrl = string.Empty
            };
            int communityid = string.IsNullOrEmpty(context.Request.Params["communityid"]) ? 0 : Convert.ToInt32(context.Request.Params["communityid"]);
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                List<CommunityInfoModel> commlist = community_bll.GetCommunityById(communityid, int.Parse(uid));


                if (commlist != null && commlist.Count > 0)
                {
                    jr.IsSucceed = true;
                    jr.Data = commlist.ToList();
                    jr.Msg = "获取小区信息成功";
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 某城市所有小区
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        private List<CommunityInfoModel> GetCityCommunity(int areaid)
        {
            List<CommunityInfoModel> communitylist = null;
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                string uid = decodeCookie.Values["userid"];
                if (CacheHelper.GetCache("citycommunity") == null)
                {
                    communitylist = community_bll.GetCityCommunity(areaid, int.Parse(uid));
                    if (communitylist != null)
                    {
                        //在缓存中保存24小时
                        //CacheHelper.SetCache("citycommunity", communitylist, 24);
                    }
                }
                else
                {
                    communitylist = CacheHelper.GetCache("citycommunity") as List<CommunityInfoModel>;
                }
            }
            return communitylist;
        }

        /// <summary>
        /// 获取物业公司所属小区集合
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetPropertyComm(HttpContext context)
        {
            string _propertymid = context.Request.Params["propertyid"];
            string _pcityid = context.Request.Params["pcityid"];
            int propertymid = -1;
            int pcityid = -1;
            if (!string.IsNullOrEmpty(_propertymid))
            {
                int.TryParse(_propertymid, out propertymid);
            }
            if (!string.IsNullOrEmpty(_pcityid))
            {
                int.TryParse(_pcityid, out pcityid);
            }
            List<CommunityInfoModel> communitylist = GetPropertyCommunity(propertymid.ToString(), pcityid.ToString());
            var jr = new JsonResultModel<List<CommunityInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<CommunityInfoModel>(),
                Msg = "获取小区信息失败",
                RedirectUrl = string.Empty
            };

            List<ParameterModel> lstpara = new List<ParameterModel>();
            ParameterModel para = new ParameterModel();
            para.Propertyid = propertymid;
            para.Pcityid = pcityid;
            lstpara.Add(para);

            if (communitylist != null && communitylist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = communitylist.Where(c => lstpara[0] == lstpara[0]).ToList();
                jr.Msg = "获取小区成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取全部设备列表
        /// </summary>
        private List<DevInfoModel> GetAllDevinfo()
        {
            List<DevInfoModel> devlist = null;
            if (CacheHelper.GetCache("device") == null)
            {
                devlist = devinfo_bll.GetAllDevinfo();
                if (devlist != null)
                {
                    CacheHelper.SetCache("device", devlist, 24);
                }
            }
            else
            {
                devlist = CacheHelper.GetCache("device") as List<DevInfoModel>;
            }
            return devlist;
        }

        /// <summary>
        /// 根据用户id，获取所有小区
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCommunityByUser(HttpContext context)
        {
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = "",
                Msg = "获取小区信息失败",
                RedirectUrl = string.Empty
            };
            System.Text.StringBuilder opts = new System.Text.StringBuilder();
            List<CommunityInfoModel> communitylist = new List<CommunityInfoModel>();
            HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
            if (cook != null)
            {
                //解密Cookie 
                HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                int userid = Convert.ToInt32(decodeCookie.Values["userid"]);

                if (userid > 0)
                {
                    communitylist = community_bll.GetCommunityByUser(userid);
                }
            }
            if (communitylist.Count > 0)
            {
                var citylist = GetAllCity();

                foreach (var pp in citylist.Where(p => p.pID == 0))
                {
                    //省份
                    opts.AppendFormat("<option value='{0}' data-level='1' disabled>{1}</option>", pp.areaID, pp.areaName);
                    foreach (var cc in citylist.Where(c => c.pID == pp.areaID))
                    {
                        if (communitylist.Count(cmc => cmc.pCityID == cc.areaID) > 0)
                        {
                            //城市
                            opts.AppendFormat("<option data-level='2' value='{0}' disabled parent='{1}'>{2}</option>", cc.areaID, pp.areaID, cc.areaName);
                            foreach (var cmy in communitylist.Where(cm => cm.pCityID == cc.areaID))
                            {
                                //小区
                                opts.AppendFormat("<option data-level='3' data-value='{0}' parent='{1}'>{2}</option>", cmy.communityID, cc.areaID, cmy.communityName);
                            }
                        }
                        else
                        {
                            //城市
                            opts.AppendFormat("<option data-level='2' disabled parent='{1}'>{0}</option>", cc.areaName, pp.areaID);
                        }
                    }
                }
                jr.IsSucceed = true;
                jr.Data = opts.ToString();
                jr.Msg = "获取小区选项树成功";
            }
            else
            {
                jr.IsSucceed = false;
                jr.Msg = "该用户没有绑定小区";
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