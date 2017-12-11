using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using IERM.Model;
using IERM.Common;
using IERM.BLL;

namespace IERM.Handler
{
    /// <summary>
    /// DataListHandler 的摘要说明
    /// </summary>
    public class DataListHandler : IHttpHandler
    {
        private readonly DataListBLL dl = new DataListBLL();
        private readonly EnergyTypeBLL energytype_bll = new EnergyTypeBLL();
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
                    case "getdevpump"://某个设备的给排水泵房信息
                        result = GetDevidPump(context);
                        break;
                    case "getdevswitch"://某个设备的配电室信息
                        result = GetDevidSwitch(context);
                        break;
                    case "getdevicefirepump"://某个设备的消防泵房信息
                        result = GetDeviceFirePump(context);
                        break;

                    case "getdanalysis":
                        result = GetAnalysis(context);
                        break;
                    case "getenrgypumpswitch":
                        result = GetEnrgyPumpSwitch(context);
                        break;
                    case "getchartsdatalist":
                        result = GetChartsDataList(context);
                        break;
                    case "getexcel":
                        result = GetExcelData(context);
                        break;
                }
            }
            context.Response.Write(result);
        }


        /// <summary>
        /// excle导出
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetExcelData(HttpContext context)
        {
            jsS = new JavaScriptSerializer();
            ExcelHelper.GetFilePath(HttpContext.Current.Server.MapPath("~/upload/DataExcel/"));
            DataColumn[] column = null;
            DataColumn dc = null;
            List<SwitchRoomRdModel> lstSwitch = new List<SwitchRoomRdModel>();
            List<PumpHouseRdModel> lstPump = new List<PumpHouseRdModel>();
            //string timespan = context.Request.Params["timeSpan"];
            //var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            //DateTime beginTime = DateTime.Parse(ts[0].Value);
            //DateTime endTime = DateTime.Parse(ts[1].Value);
            /*
           设置当前时间为默认时间，由时间范围改为开始时间和结束时间
           2017年5月5日 11:06:08 BY 潘阳
           */
            string beginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (context.Request.Params["begindate"] != null)
            {
                beginTime = DateTime.Parse(context.Request.Params["begindate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (context.Request.Params["enddate"] != null)
            {
                endTime = DateTime.Parse(context.Request.Params["enddate"].ToString()).AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");
            }

            int systype = string.IsNullOrEmpty(context.Request.Params["systype"]) ? 0 : Convert.ToInt32(context.Request.Params["systype"]);
            int devid = string.IsNullOrEmpty(context.Request.Params["devid"]) ? 0 : Convert.ToInt32(context.Request.Params["devid"]);
            int communityid = string.IsNullOrEmpty(context.Request.Params["communityid"]) ? 0 : Convert.ToInt32(context.Request.Params["communityid"]);
            //var name = beginTime.ToString("yyyy-MM-dd") + "-" + endTime.ToString("yyyy-MM-dd") + "-" + new Random(DateTime.Now.Second).Next(10000);
            var name = DateTime.Now.ToFileTimeUtc().ToString();
            var path = HttpContext.Current.Server.MapPath("~/upload/DataExcel/" + name + ".xlsx");
            var dt = new System.Data.DataTable();
            try
            {
                if (systype == 1)
                {
                    #region 泵房
                    dt.Columns.Clear();
                    dt.Columns.Add("时间");
                    dt.Columns.Add("设备房-环境温度");
                    dt.Columns.Add("设备房-环境湿度");
                    dt.Columns.Add("生活供水-电源柜AB线电压");
                    dt.Columns.Add("生活供水-电源柜BC线电压");
                    dt.Columns.Add("生活供水-电源柜CA线电压");
                    dt.Columns.Add("生活供水-电源柜A相电流");
                    dt.Columns.Add("生活供水 - 电源柜B相电流");
                    dt.Columns.Add("生活供水-电源柜C相电流");
                    dt.Columns.Add("生活供水-电源柜有功电能");
                    dt.Columns.Add("生活供水-电源柜无功电能");
                    dt.Columns.Add("生活供水-电源柜功率因素");
                    dt.Columns.Add("生活供水-生活水箱液位");
                    dt.Columns.Add("生活供水-市政进水压力");
                    dt.Columns.Add("生活供水-低区供水压力");
                    dt.Columns.Add("生活供水-中区供水压力");
                    dt.Columns.Add("生活供水-高区供水压力");
                    dt.Columns.Add("生活供水-超高区供水压力");
                    //dt.Columns.Add("消防供水-电源柜AB线电压");
                    //dt.Columns.Add("消防供水-电源柜BC线电压");
                    //dt.Columns.Add("消防供水-电源柜CA线电压");
                    //dt.Columns.Add("消防供水-电源柜A相电流");
                    //dt.Columns.Add("消防供水-电源柜B相电流");
                    //dt.Columns.Add("消防供水-电源柜C相电流");
                    //dt.Columns.Add("消防供水-电源柜有功电能");
                    //dt.Columns.Add("消防供水-电源柜无功电能");
                    //dt.Columns.Add("消防供水 - 电源柜功率因素");
                    //dt.Columns.Add("消防供水-消防水箱液位");
                    //dt.Columns.Add("消防供水-消防1#供水压力");
                    //dt.Columns.Add("消防供水-喷淋1#供水压力");
                    //dt.Columns.Add("消防供水-消防2#供水压力");
                    //dt.Columns.Add("消防供水 - 喷淋2#供水压力");
                    #endregion
                    lstPump = dl.GetExcelPumpData(devid, communityid, beginTime, endTime);
                    for (int i = 0; i < lstPump.Count(); i++)
                    {
                        //dt.Rows.Add(lstPump[i].InsertTime, lstPump[i].T_ROOM, lstPump[i].H_ROOM, lstPump[i].UAB_SH, lstPump[i].UBC_SH, lstPump[i].UCA_SH, lstPump[i].IA_SH,
                        //    lstPump[i].IB_SH, lstPump[i].IC_SH, lstPump[i].KWH_SH, lstPump[i].KVARH_SH, lstPump[i].PF_SH, lstPump[i].L_SHSX, lstPump[i].P_IN, lstPump[i].P_LO,
                        //    lstPump[i].P_MI, lstPump[i].P_HI, lstPump[i].P_SP, lstPump[i].UAB_XF, lstPump[i].UBC_XF, lstPump[i].UCA_XF, lstPump[i].IA_XF, lstPump[i].IB_XF,
                        //    lstPump[i].IC_XF, lstPump[i].KWH_XF, lstPump[i].KVARH_XF, lstPump[i].PF_XF, lstPump[i].L_XFSX,
                        //    lstPump[i].P_XF1, lstPump[i].P_PL1, lstPump[i].P_XF2, lstPump[i].P_PL2);
                        dt.Rows.Add(lstPump[i].InsertTime, lstPump[i].T_ROOM, lstPump[i].H_ROOM, lstPump[i].UAB_SH, lstPump[i].UBC_SH, lstPump[i].UCA_SH, lstPump[i].IA_SH,
                           lstPump[i].IB_SH, lstPump[i].IC_SH, lstPump[i].KWH_SH, lstPump[i].KVARH_SH, lstPump[i].PF_SH, lstPump[i].L_SHSX, lstPump[i].P_IN, lstPump[i].P_LO,
                           lstPump[i].P_MI, lstPump[i].P_HI, lstPump[i].P_SP);
                    }
                }
                else if (systype == 2)
                {
                    #region 配电室
                    dt.Columns.Clear();
                    dt.Columns.Add("时间");
                    dt.Columns.Add("环境温度");
                    dt.Columns.Add("环境湿度");
                    dt.Columns.Add("变压器A相温度");
                    dt.Columns.Add("变压器B相温度");
                    dt.Columns.Add("变压器C相温度");
                    dt.Columns.Add("进线柜AB线电压");
                    dt.Columns.Add("进线柜BC线电压");
                    dt.Columns.Add("进线柜CA线电压");
                    dt.Columns.Add("进线柜A相电流");
                    dt.Columns.Add("进线柜B相电流");
                    dt.Columns.Add("进线柜C相电流");
                    dt.Columns.Add("进线柜功率因素");
                    dt.Columns.Add("进线柜有功电能");
                    dt.Columns.Add("进线柜无功电能");
                    dt.Columns.Add("变压器2A相温度");
                    dt.Columns.Add("变压器2B相温度");
                    dt.Columns.Add("变压器2C相温度");
                    dt.Columns.Add("进线柜2AB线电压");
                    dt.Columns.Add("进线柜2BC线电压");
                    dt.Columns.Add("进线柜2CA线电压");
                    dt.Columns.Add("进线柜2A相电流");
                    dt.Columns.Add("进线柜2B相电流");
                    dt.Columns.Add("进线柜2C相电流");
                    dt.Columns.Add("进线柜2功率因素");
                    dt.Columns.Add("进线柜2有功电能");
                    dt.Columns.Add("进线柜2无功电能");
                    #endregion
                    //dt.Columns.AddRange(column);
                    lstSwitch = dl.GetExcelSwitchData(devid, communityid, beginTime, endTime);
                    for (int i = 0; i < lstSwitch.Count(); i++)
                    {
                        dt.Rows.Add(lstSwitch[i].InsertTime, lstSwitch[i].T_ROOM, lstSwitch[i].H_ROOM, lstSwitch[i].N1_T_A, lstSwitch[i].N1_T_B, lstSwitch[i].N1_T_C, lstSwitch[i].N1_UAB,
                             lstSwitch[i].N1_UBC, lstSwitch[i].N1_UCA, lstSwitch[i].N1_IA, lstSwitch[i].N1_IB,
                             lstSwitch[i].N1_IC, lstSwitch[i].N1_PF, lstSwitch[i].N1_KWH, lstSwitch[i].N1_KVARH, lstSwitch[i].N2_T_A, lstSwitch[i].N2_T_B, lstSwitch[i].N2_T_C,
                             lstSwitch[i].N2_UAB, lstSwitch[i].N2_UBC, lstSwitch[i].N2_UCA,
                             lstSwitch[i].N2_IA, lstSwitch[i].N2_IB, lstSwitch[i].N2_IC, lstSwitch[i].N2_PF, lstSwitch[i].N2_KWH, lstSwitch[i].N2_KVARH);
                    }
                }
                else
                {

                    #region 泵房
                    dt.Columns.Clear();
                    dt.Columns.Add("时间");
                    dt.Columns.Add("设备房-环境温度");
                    dt.Columns.Add("设备房-环境湿度");
                    //dt.Columns.Add("生活供水-电源柜AB线电压");
                    //dt.Columns.Add("生活供水-电源柜BC线电压");
                    //dt.Columns.Add("生活供水-电源柜CA线电压");
                    //dt.Columns.Add("生活供水-电源柜A相电流");
                    //dt.Columns.Add("生活供水 - 电源柜B相电流");
                    //dt.Columns.Add("生活供水-电源柜C相电流");
                    //dt.Columns.Add("生活供水-电源柜有功电能");
                    //dt.Columns.Add("生活供水-电源柜无功电能");
                    //dt.Columns.Add("生活供水-电源柜功率因素");
                    //dt.Columns.Add("生活供水-生活水箱液位");
                    //dt.Columns.Add("生活供水-市政进水压力");
                    //dt.Columns.Add("生活供水-低区供水压力");
                    //dt.Columns.Add("生活供水-中区供水压力");
                    //dt.Columns.Add("生活供水-高区供水压力");
                    //dt.Columns.Add("生活供水-超高区供水压力");
                    dt.Columns.Add("消防供水-电源柜AB线电压");
                    dt.Columns.Add("消防供水-电源柜BC线电压");
                    dt.Columns.Add("消防供水-电源柜CA线电压");
                    dt.Columns.Add("消防供水-电源柜A相电流");
                    dt.Columns.Add("消防供水-电源柜B相电流");
                    dt.Columns.Add("消防供水-电源柜C相电流");
                    dt.Columns.Add("消防供水-电源柜有功电能");
                    dt.Columns.Add("消防供水-电源柜无功电能");
                    dt.Columns.Add("消防供水 - 电源柜功率因素");
                    dt.Columns.Add("消防供水-消防水箱液位");
                    dt.Columns.Add("消防供水-消防1#供水压力");
                    dt.Columns.Add("消防供水-喷淋1#供水压力");
                    dt.Columns.Add("消防供水-消防2#供水压力");
                    dt.Columns.Add("消防供水 - 喷淋2#供水压力");
                    #endregion
                    lstPump = dl.GetExcelPumpData(devid, communityid, beginTime, endTime);
                    for (int i = 0; i < lstPump.Count(); i++)
                    {
                        dt.Rows.Add(lstPump[i].InsertTime, lstPump[i].T_ROOM, lstPump[i].H_ROOM, lstPump[i].UAB_XF, lstPump[i].UBC_XF, lstPump[i].UCA_XF, lstPump[i].IA_XF, lstPump[i].IB_XF, lstPump[i].IC_XF, lstPump[i].KWH_XF, lstPump[i].KVARH_XF, lstPump[i].PF_XF, lstPump[i].L_XFSX,
                            lstPump[i].P_XF1, lstPump[i].P_PL1, lstPump[i].P_XF2, lstPump[i].P_PL2);
                    }
                }

                ExcelHelper.x2007.TableToExcelForXLSX(dt, path);
                string s_fileName = name + ".xlsx";
                List<String> lstRes = new List<String>();
                lstRes.Add("0");
                lstRes.Add(s_fileName);
                result = JsonHelper.SerializeObject(lstRes);
            }
            catch (Exception ex)
            {
                List<String> lstRes = new List<String>();
                lstRes.Add("1");
                result = JsonHelper.SerializeObject(lstRes);
            }
            return result;
        }

        /// <summary>
        /// 获取能耗图形数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetChartsDataList(HttpContext context)
        {

            List<SwitchRoomRdModel> lstSwitch = new List<SwitchRoomRdModel>();
            jsS = new JavaScriptSerializer();

            int sysType = string.IsNullOrEmpty(context.Request.Params["sysType"]) ? 0 : Convert.ToInt32(context.Request.Params["sysType"]);
            int dataType = string.IsNullOrEmpty(context.Request.Params["dataType"]) ? 0 : Convert.ToInt32(context.Request.Params["dataType"]);

            string timespan = context.Request.Params["timeSpan"];
            var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            DateTime beginTime = DateTime.Parse(ts[0].Value);
            DateTime endTime = DateTime.Parse(ts[1].Value);
            int commcommunityID = string.IsNullOrEmpty(context.Request.Params["commcommunityID"]) ? 0 : Convert.ToInt32(context.Request.Params["commcommunityID"]);
            int devID = string.IsNullOrEmpty(context.Request.Params["devID"]) ? 0 : Convert.ToInt32(context.Request.Params["devID"]);
            if (sysType == 1)
            {
                //给排水泵房
                List<PumpHouseModel> lstpump = dl.GetPumpdata(dataType, beginTime.ToString(), endTime.ToString(), commcommunityID, devID);
                jsS.MaxJsonLength = Int32.MaxValue;
                result = JsonHelper.SerializeObject(lstpump);
            }
            else if (sysType == 2)
            {
                //配电室
                lstSwitch = dl.GetSwitchdata(dataType, beginTime.ToString(), endTime.ToString(), commcommunityID, devID);
                jsS.MaxJsonLength = Int32.MaxValue;
                result = JsonHelper.SerializeObject(lstSwitch);
            }
            if (sysType == 3)
            {
                //消防泵房
                List<FirePumpHouseModel> lstpump = dl.GetFirePumpdata(dataType, beginTime.ToString(), endTime.ToString(), commcommunityID, devID);
                jsS.MaxJsonLength = Int32.MaxValue;
                result = JsonHelper.SerializeObject(lstpump);
            }
            return result;
        }

        /// <summary>
        /// 获取能耗模板 
        /// </summary>
        private string GetEnrgyPumpSwitch(HttpContext context)
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
        /// 获取数据分析结果 (最大值，最小值，差值，平均值)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAnalysis(HttpContext context)
        {
            string columnName = context.Request.Params["columnname"];
            string tableName = context.Request.Params["tablename"];

            var pr = new PagingResultModel<List<DataAnalysisModel>>()
            {
                total = 0,
                rows = new List<DataAnalysisModel>()
            };
            pr.rows = dl.GetColumnAnalysis(columnName, tableName);
            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 给排水泵房
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDevidPump(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            int devid = string.IsNullOrEmpty(context.Request.Params["devid"]) ? 0 : int.Parse(context.Request.Params["devid"]);
            //string timespan = context.Request.Params["timeSpan"];
            //var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            //DateTime beginTime = DateTime.Parse(ts[0].Value);
            //DateTime endTime = DateTime.Parse(ts[1].Value);
            /*
            设置当前时间为默认时间，由时间范围改为开始时间和结束时间
            2017年5月5日 11:06:08 BY 潘阳
            */
            string beginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (context.Request.Params["begindate"] != null)
            {
                beginTime = DateTime.Parse(context.Request.Params["begindate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (context.Request.Params["enddate"] != null)
            {
                endTime = DateTime.Parse(context.Request.Params["enddate"].ToString()).AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
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


            var pr = new PagingResultModel<List<PumpHouseRdModel>>()
            {
                total = 0,
                rows = new List<PumpHouseRdModel>()
            };
            pr.rows = dl.GetDevidPumpInfo(devid.ToString(), pageindex, pagesize, out rowcount, beginTime.ToString(), endTime.ToString());
            pr.total = rowcount;
            string strJson = JsonHelper.SerializeObject(pr);

            return strJson;
        }

        /// <summary>
        /// 配电室
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDevidSwitch(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            //string timespan = context.Request.Params["timeSpan"];
            //var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            //DateTime beginTime = DateTime.Parse(ts[0].Value);
            //DateTime endTime = DateTime.Parse(ts[1].Value);
            string beginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (context.Request.Params["begindate"] != null)
            {
                beginTime = DateTime.Parse(context.Request.Params["begindate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (context.Request.Params["enddate"] != null)
            {
                endTime = DateTime.Parse(context.Request.Params["enddate"].ToString()).AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
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
            int devid = string.IsNullOrEmpty(context.Request.Params["devid"]) ? 0 : int.Parse(context.Request.Params["devid"]);

            var pr = new PagingResultModel<List<SwitchRoomRdModel>>()
            {
                total = 0,
                rows = new List<SwitchRoomRdModel>()
            };
            pr.rows = dl.GetDevidSwitchInfo(devid.ToString(), pageindex, pagesize, out rowcount, beginTime.ToString(), endTime.ToString());
            pr.total = rowcount;
            return JsonConvert.SerializeObject(pr);
        }


        /// <summary>
        /// 消防泵房
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetDeviceFirePump(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            int devid = string.IsNullOrEmpty(context.Request.Params["devid"]) ? 0 : int.Parse(context.Request.Params["devid"]);
            //string timespan = context.Request.Params["timeSpan"];
            //var ts = System.Text.RegularExpressions.Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
            //DateTime beginTime = DateTime.Parse(ts[0].Value);
            //DateTime endTime = DateTime.Parse(ts[1].Value);
            /*
            设置当前时间为默认时间，由时间范围改为开始时间和结束时间
            2017年5月5日 11:06:08 BY 潘阳
            */
            string beginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (context.Request.Params["begindate"] != null)
            {
                beginTime = DateTime.Parse(context.Request.Params["begindate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (context.Request.Params["enddate"] != null)
            {
                endTime = DateTime.Parse(context.Request.Params["enddate"].ToString()).AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
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


            var pr = new PagingResultModel<List<PumpHouseRdModel>>()
            {
                total = 0,
                rows = new List<PumpHouseRdModel>()
            };
            pr.rows = dl.GetDevidFirePumpInfo(devid.ToString(), pageindex, pagesize, out rowcount, beginTime.ToString(), endTime.ToString());
            pr.total = rowcount;
            string strJson = JsonHelper.SerializeObject(pr);

            return strJson;
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