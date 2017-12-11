using IERM.BLL;
using IERM.Common;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace IERM.Handler
{
    /// <summary>
    /// 报警信息相关操作
    /// </summary>
    public class AlarmHandler : IHttpHandler
    {
        private readonly AlarmLogBLL alarm_bll = new AlarmLogBLL();
        private readonly AlarmSettingBLL alarmsetting_bll = new AlarmSettingBLL();

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
                    case "getcurrentalarmlog"://获取实时报警信息
                        result = GetCurrentAlarmLog(context);
                        break;
                    case "getalarmlog"://获取历史报警信息
                        result = GetAlarmLog(context);
                        break;
                    case "getalarmsetting"://获取报警设置
                        result = GetAlarmSetting(context);
                        break;
                    case "savealarmsetting"://保存报警设置
                        result = SaveAlarmSetting(context);
                        break;
                    case "delete"://删除用户
                        result = Delete(context);
                        break;
                    case "getencrypt": //加密
                        result = GetEncrypt(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        // "mobile:18912341234,18912344321" +
        //"content:TESTCONTEXT" +
        //"source:ECCMAlarm";
        private string GetEncrypt(HttpContext context)
        {
            var jr = new JsonResultModel<List<String>>()
            {
                IsSucceed = false,
                Data = new List<String>(),
                Msg = "加密失败",
                RedirectUrl = string.Empty
            };
            List<String> lstData = new List<string>();
            String val = "{'mobile':'18607147091','content':'IIIIIIII','source':'ECCMAlarm'}";
            string strTest = AESDEncrypt.AESEncrypt(val, "654321");
            lstData.Add(strTest);
            var tmplist = lstData;
            if (tmplist != null && tmplist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = tmplist;
                jr.Msg = "加密成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取实时报警信息
        /// </summary>
        private string GetCurrentAlarmLog(HttpContext context)
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

            int cityid = string.IsNullOrEmpty(context.Request.Params["cityID"]) ? 0 : int.Parse(context.Request.Params["cityID"]);
            int propertyid = string.IsNullOrEmpty(context.Request.Params["propertyID"]) ? 0 : int.Parse(context.Request.Params["propertyID"]);
            string partname = context.Request.Params["partName"];
            int systypeid = string.IsNullOrEmpty(context.Request.Params["systypeID"]) ? 0 : int.Parse(context.Request.Params["systypeID"]);


            var pr = new PagingResultModel<List<ViewAlarmlogModel>>()
            {
                total = 0,
                rows = new List<ViewAlarmlogModel>()
            };

            pr.rows = alarm_bll.GetCurrentAlarmLog(cityid, propertyid, partname, systypeid, pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取历史报警信息
        /// </summary>
        private string GetAlarmLog(HttpContext context)
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

            int cityid = string.IsNullOrEmpty(context.Request.Params["cityID"]) ? 0 : int.Parse(context.Request.Params["cityID"]);
            int propertyid = string.IsNullOrEmpty(context.Request.Params["propertyID"]) ? 0 : int.Parse(context.Request.Params["propertyID"]);
            string partname = context.Request.Params["partName"];
            int systypeid = string.IsNullOrEmpty(context.Request.Params["systypeID"]) ? 0 : int.Parse(context.Request.Params["systypeID"]);
            string timespan = context.Request.Params["timeSpan"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime begintime = DateTime.Parse(ts[0].Value);
            DateTime endtime = DateTime.Parse(ts[1].Value);

            var pr = new PagingResultModel<List<ViewAlarmlogModel>>()
            {
                total = 0,
                rows = new List<ViewAlarmlogModel>()
            };

            pr.rows = alarm_bll.GetAlarmLog(cityid, propertyid, partname, systypeid, pageindex, pagesize, begintime, endtime, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 获取报警设置列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAlarmSetting(HttpContext context)
        {
            var jr = new JsonResultModel<List<AlarmSettingModel>>()
            {
                IsSucceed = false,
                Data = new List<AlarmSettingModel>(),
                Msg = "获取报警类型列表失败",
                RedirectUrl = string.Empty
            };
            int devtype = string.IsNullOrEmpty(context.Request.Params["devType"]) ? 0 : int.Parse(context.Request.Params["devType"]);
            int devid = string.IsNullOrEmpty(context.Request.Params["devID"]) ? 0 : int.Parse(context.Request.Params["devID"]);

            var alarmSettingList = devid == 0 ? alarmsetting_bll.GetAlarmTypeListByDevType(devtype) : alarmsetting_bll.GetAlarmListByDevID(devid);
            if (alarmSettingList != null && alarmSettingList.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = alarmSettingList;
                jr.Msg = "获取报警类型列表成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 保存报警设置
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string SaveAlarmSetting(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "保存报警设置失败",
                RedirectUrl = string.Empty
            };

            DevInfoModel devModel = null;
            bool isupdate = Convert.ToBoolean(context.Request.Params["isUpdate"]);
            string _devName = string.IsNullOrEmpty(context.Request.Params["devName"]) ? "eccm" : context.Request.Params["devName"];
            int _devID = string.IsNullOrEmpty(context.Request.Params["devID"]) ? 0 : Convert.ToInt32(context.Request.Params["devID"]);
            int _devType = string.IsNullOrEmpty(context.Request.Params["devType"]) ? 0 : Convert.ToInt32(context.Request.Params["devType"]);
            int _communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : Convert.ToInt32(context.Request.Params["communityID"]);
            string _devhouseTypes= context.Request.Params["systype"];

            devModel = new DevInfoModel()
            {
                devID = _devID,
                devName = _devName,
                devType = _devType,
                communityID = _communityID,
                sort = 10000,
                devhouseTypes= _devhouseTypes
            };

            var data = string.IsNullOrEmpty(context.Request.Params["settingData"]) ? new List<AlarmSettingModel>() : JsonConvert.DeserializeObject<List<AlarmSettingModel>>(context.Request.Params["settingData"]);

            if (data != null && data.Count > 0)
            {
                int rcount = alarmsetting_bll.SaveAlarmSetting(data, isupdate, devModel);
                if (rcount > 0)
                {
                    jr.IsSucceed = true;
                    jr.Data = rcount;
                    jr.Msg = "保存报警设置成功";
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 删除设备房及其报警设置
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Delete(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除失败",
                RedirectUrl = string.Empty
            };

            int devid = string.IsNullOrEmpty(context.Request.Params["devID"]) ? 0 : Convert.ToInt32(context.Request.Params["devID"]);

            int rcount = alarmsetting_bll.DeleteAlarmSetting(devid);
            if (rcount > 0)
            {
                jr.IsSucceed = true;
                jr.Data = rcount;
                jr.Msg = "删除成功";
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