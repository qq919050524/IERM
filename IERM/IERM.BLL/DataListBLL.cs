using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    /// <summary>
    /// 数据列表记录 JINXIN
    /// </summary>
    public partial class DataListBLL
    {
        private readonly DataListDAL dl = new DataListDAL();
        /// <summary>
        /// 获取某个设备给排水泵房记录
        /// </summary>
        /// <param name="devid"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="datacount"></param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetDevidPumpInfo(string devid, int pageindex, int pagesize, out int datacount, string beginTime, string endTime)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(@"  WHERE  devid={0}  and insertTime >='{1}'  AND  insertTime< '{2}'", devid, beginTime, endTime);
            return dl.GetDevIdPumpHouseInfo(strWhere.ToString(), pageindex, pagesize, out datacount);
        }

        /// <summary>
        /// 获取某个设备消防泵房记录
        /// </summary>
        /// <param name="devid"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="datacount"></param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetDevidFirePumpInfo(string devid, int pageindex, int pagesize, out int datacount, string beginTime, string endTime)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(@"  WHERE  devid={0}  and insertTime >='{1}'  AND  insertTime< '{2}'", devid, beginTime, endTime);
            return dl.GetDevidFirePumpInfo(strWhere.ToString(), pageindex, pagesize, out datacount);
        }

        /// <summary>
        /// 获取某个设备配电房记录
        /// </summary>
        /// <param name="devid"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="datacount"></param>
        /// <returns></returns>
        public List<SwitchRoomRdModel> GetDevidSwitchInfo(string devid, int pageindex, int pagesize, out int datacount, string beginTime, string endTime)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(@"  WHERE  devid={0}  and insertTime  BETWEEN  '{1}'  AND   '{2}'", devid, beginTime, endTime);
            return dl.GetDevIdSwitchRoomInfo(strWhere.ToString(), pageindex, pagesize, out datacount);
        }

        public List<DataAnalysisModel> GetColumnAnalysis(string columnName, string tableName)
        {
            return dl.GetColumnAnalysis(columnName, tableName);
        }

        /// <summary>
        /// 获取能源图表数据集合
        /// </summary>
        //public List<PumpHouseRdModel> GetPumpSwitchTest(int sysType, int dataType, string beginTime, string endTime, int commcommunityID, int devID)
        //{
        //    StringBuilder sbWhere = new StringBuilder();
        //    List<PumpHouseRdModel> lstPumpCurve = null;
        //    //devid等于0 说明用户查询小区所有设备室
        //    if (devID == 0)
        //    {
        //        sbWhere.Append(@"  b.communityID=" + commcommunityID.ToString());
        //    }
        //    else
        //    {
        //        //如果不等于0 就表示有选择具体哪一个设备房
        //        sbWhere.Append(@"   a.devid= " + devID);
        //    }
        //    if (sysType == 1)
        //    {
        //        //泵房
        //        lstPumpCurve = dl.GetPumphouseCurveData(dataType, sbWhere.ToString(), beginTime, endTime);
        //    }
        //    else
        //    {

        //    }
        //    return lstPumpCurve;
        //}

        /// <summary>
        /// 给排水泵房 曲线图
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="commcommunityID"></param>
        /// <param name="devID"></param>
        /// <returns></returns>
        public List<PumpHouseModel> GetPumpdata(int dataType, string beginTime, string endTime, int commcommunityID, int devID)
        {
            StringBuilder sbWhere = new StringBuilder();
            //devid等于0 说明用户查询小区所有设备室
            if (devID == 0)
            {
                sbWhere.Append(@"  b.communityID=" + commcommunityID.ToString());
            }
            else
            {
                //如果不等于0 就表示有选择具体哪一个设备房
                sbWhere.Append(@"   a.devid= " + devID);
            }
            //泵房
            List<PumpHouseModel> lstPumpCurve = dl.GetPumphouseCurveData(dataType, sbWhere.ToString(), beginTime, endTime);
            return lstPumpCurve;
        }

        /// <summary>
        /// 配电室 曲线图
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="commcommunityID"></param>
        /// <param name="devID"></param>
        /// <returns></returns>
        public List<SwitchRoomRdModel> GetSwitchdata(int dataType, string beginTime, string endTime, int commcommunityID, int devID)
        {
            StringBuilder sbWhere = new StringBuilder();
            List<SwitchRoomRdModel> lstSwitchCurve = null;
            //devid等于0 说明用户查询小区所有设备室
            if (devID == 0)
            {
                sbWhere.Append(@"  b.communityID=" + commcommunityID.ToString());
            }
            else
            {
                //如果不等于0 就表示有选择具体哪一个设备房
                sbWhere.Append(@"   a.devid= " + devID);
            }
            //泵房
            lstSwitchCurve = dl.GetSwitchCurveData(dataType, sbWhere.ToString(), beginTime, endTime);
            return lstSwitchCurve;
        }


        /// <summary>
        /// 消防泵房 曲线图
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="commcommunityID"></param>
        /// <param name="devID"></param>
        /// <returns></returns>
        public List<FirePumpHouseModel> GetFirePumpdata(int dataType, string beginTime, string endTime, int commcommunityID, int devID)
        {
            StringBuilder sbWhere = new StringBuilder();
            List<FirePumpHouseModel> lstPumpCurve = null;
            //devid等于0 说明用户查询小区所有设备室
            if (devID == 0)
            {
                sbWhere.Append(@"  b.communityID=" + commcommunityID.ToString());
            }
            else
            {
                //如果不等于0 就表示有选择具体哪一个设备房
                sbWhere.Append(@"   a.devid= " + devID);
            }
            //泵房
            lstPumpCurve = dl.GetFirePumphouseCurveData(dataType, sbWhere.ToString(), beginTime, endTime);
            return lstPumpCurve;
        }

        /// <summary>
        /// 取得给排水泵房数据
        /// </summary>
        /// <param name="devid">设备房编号</param>
        /// <param name="communityID">小区编号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetExcelPumpData(int devid, int communityID, string beginTime, string endTime)
        {
            StringBuilder sbWhere = new StringBuilder();
            List<PumpHouseRdModel> lstPump = null;
            //devid等于0 说明用户查询小区所有设备室
            if (devid == 0)
            {
                sbWhere.Append("  c.communityID=" + communityID.ToString());
            }
            else
            {
                //如果不等于0 就表示有选择具体哪一个设备房
                sbWhere.Append("   a.devid= " + devid);
            }
            lstPump = dl.GetExcelPumpData(sbWhere.ToString(), beginTime, endTime);
            return lstPump;
        }

        /// <summary>
        /// 取得给配电房数据
        /// </summary>
        /// <param name="devid">设备房编号</param>
        /// <param name="communityID">小区编号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<SwitchRoomRdModel> GetExcelSwitchData(int devid, int communityID, string beginTime, string endTime)
        {
            StringBuilder sbWhere = new StringBuilder();
            List<SwitchRoomRdModel> lstSwitch = null;
            //devid等于0 说明用户查询小区所有设备室
            if (devid == 0)
            {
                sbWhere.Append("  c.communityID=" + communityID.ToString());
            }
            else
            {
                //如果不等于0 就表示有选择具体哪一个设备房
                sbWhere.Append("   a.devid= " + devid);
            }
            lstSwitch = dl.GetExcelSwitchData(sbWhere.ToString(), beginTime, endTime);
            return lstSwitch;
        }

        /// <summary>
        /// 取得消防泵房数据
        /// </summary>
        /// <param name="devid">设备房编号</param>
        /// <param name="communityID">小区编号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetExcelFirePumpData(int devid, int communityID, string beginTime, string endTime)
        {
            StringBuilder sbWhere = new StringBuilder();
            List<PumpHouseRdModel> lstPump = null;
            //devid等于0 说明用户查询小区所有设备室
            if (devid == 0)
            {
                sbWhere.Append("  c.communityID=" + communityID.ToString());
            }
            else
            {
                //如果不等于0 就表示有选择具体哪一个设备房
                sbWhere.Append("   a.devid= " + devid);
            }
            lstPump = dl.GetExcelFirePumpData(sbWhere.ToString(), beginTime, endTime);
            return lstPump;
        }
    }
}
