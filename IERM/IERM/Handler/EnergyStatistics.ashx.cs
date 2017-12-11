using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Web.Script.Serialization;
using IERM.Model;
using IERM.BLL;

namespace IERM.Handler
{
    /// <summary>
    /// EnergyStatistics 的摘要说明
    /// </summary>
    public class EnergyStatistics : IHttpHandler
    {
        private readonly EnergyStatisticsBLL bll_energyStatistics = new EnergyStatisticsBLL();
        JavaScriptSerializer jsS = new JavaScriptSerializer();
        string result = "";

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
                    case "getenergy":
                        result = GetEnergyDataList(context);
                        break;
                    case "getalarmcount":
                        result = GetAlarmDataList(context);
                        break;
                    case "getimportantcount":
                        result = GetImportantcount(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取所有事件 派单报警的数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetImportantcount(HttpContext context)
        {
            jsS = new JavaScriptSerializer();
            int year = string.IsNullOrEmpty(context.Request.Params["year"]) ? 0 : Convert.ToInt32(context.Request.Params["year"]);
            int prono = string.IsNullOrEmpty(context.Request.Params["prono"]) ? 0 : Convert.ToInt32(context.Request.Params["prono"]);
            result = jsS.Serialize(bll_energyStatistics.GetMonthImportantData(prono, year));
            return result;
        }

        /// <summary>
        /// 获取故障设备和总设备数的数组
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAlarmDataList(HttpContext context)
        {
            jsS = new JavaScriptSerializer();
            int prono = string.IsNullOrEmpty(context.Request.Params["prono"]) ? 0 : Convert.ToInt32(context.Request.Params["prono"]);
            List<int> lstType = new List<int>();
            lstType.Add(1);
            lstType.Add(2);
            lstType.Add(3);
            lstType.Add(5);
            result = jsS.Serialize(bll_energyStatistics.GetAlarmEquipment(lstType, prono));
            return result;
        }

        /// <summary>
        /// 获取能源消耗数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetEnergyDataList(HttpContext context)
        {


            int prono = 0;  //物业公司
            int year = 0;   //年 
            int type = 1;   //能耗类型  1 用电  2 用水  3用气
            if (!string.IsNullOrEmpty(context.Request.Params["prono"]))
            {
                prono = Convert.ToInt32(context.Request.Params["prono"]);
            }
            if (!string.IsNullOrEmpty(context.Request.Params["year"]))
            {
                year = Convert.ToInt32(context.Request.Params["year"]);
            }
            if (!string.IsNullOrEmpty(context.Request.Params["type"]))
            {
                type = Convert.ToInt32(context.Request.Params["type"]);
            }
            //int month = string.IsNullOrEmpty(context.Request.Params["month"]) ? 0 : Convert.ToInt32(context.Request.Params["month"]);

            //电水气的数据
            //result = jsS.Serialize(bll_energyStatistics.GetEnergyConsumptionList(prono,year));
            List<EnergyInfoModel> energyList = bll_energyStatistics.GetEnergyList(prono, year, type);
            result = JsonConvert.SerializeObject(energyList.ConvertAll(c => c.engValue));
            return result;
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