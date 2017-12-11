using IERM.Common;
using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
    /// 数据列表 JINXIN
    /// </summary>
    public partial class DataListDAL
    {
        #region  查询某个给排水设备的数据
        /// <summary>
        /// 查询某个设备的泵房所有记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="dataCount"></param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetDevIdPumpHouseInfo(string strWhere, int pageindex, int pagesize, out int dataCount)
        {
            //获取数据总数
            dataCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) FROM pumphouse_rd  " + strWhere, null));
            //返回数据列表
            return MySQLHelper.ExecuteToList<PumpHouseRdModel>
                (string.Format(@"select  T_ROOM,H_ROOM,UAB_SH,UBC_SH,UCA_SH,IA_SH,IB_SH,IC_SH,KWH_SH,KVARH_SH,PF_SH,L_SHSX,
                                           P_IN, P_LO, P_MI, P_HI, P_SP,insertTime from pumphouse_rd {0} order by insertTime desc LIMIT {1},{2} ", strWhere, (pageindex - 1) * pagesize, pagesize), null);
        }

        /// <summary>
        /// 查询某个消防设备的泵房所有记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="dataCount"></param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetDevidFirePumpInfo(string strWhere, int pageindex, int pagesize, out int dataCount)
        {
            //获取数据总数
            dataCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) FROM pumphouse_rd  " + strWhere, null));
            //返回数据列表
            return MySQLHelper.ExecuteToList<PumpHouseRdModel>
                (string.Format(@"select  T_ROOM,H_ROOM,UAB_XF, UBC_XF, UCA_XF, IA_XF, IB_XF, IC_XF, KWH_XF, KVARH_XF, PF_XF,L_XFSX,
                                           P_XF1, P_PL1, P_XF2, P_PL2,insertTime from pumphouse_rd {0} order by insertTime desc LIMIT {1},{2} ", strWhere, (pageindex - 1) * pagesize, pagesize), null);
        }
        /// <summary>
        /// 查询某个设备配电所有记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="dataCount"></param>
        /// <returns></returns>
        public List<SwitchRoomRdModel> GetDevIdSwitchRoomInfo(string strWhere, int pageindex, int pagesize, out int dataCount)
        {
            //获取数据总数
            dataCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) FROM switchroom_rd  " + strWhere, null));
            //返回数据列表
            return MySQLHelper.ExecuteToList<SwitchRoomRdModel>
                (string.Format(@"SELECT  T_ROOM,H_ROOM,N1_T_A,N1_T_B,N1_T_C,N1_UAB,N1_UBC,N1_UCA,
                                            N1_IA,N1_IB,N1_IC,N1_PF,N1_KWH,N1_KVARH,N2_T_A,N2_T_B,N2_T_C,N2_UAB,N2_UBC,
                                            N2_UCA,N2_IA,N2_IB,N2_IC,N2_PF,N2_KWH,N2_KVARH,insertTime
                                            from  switchroom_rd  {0}  order by insertTime desc LIMIT {1},{2} ", strWhere, (pageindex - 1) * pagesize, pagesize), null);
        }
        #endregion

        #region 磅房某一列数据评估
        /// <summary>
        /// 磅房数据某一列最大值  最小值  平均值  
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public List<DataAnalysisModel> GetColumnAnalysis(string columnName, string tableName)
        {
            List<DataAnalysisModel> lstDataAnalysis = new List<DataAnalysisModel>();
            DataAnalysisModel da = new DataAnalysisModel();
            da.Max = Decimal.Parse(MySQLHelper.ExecuteScalar("select max(" + columnName + ") from " + tableName + " limit  0,1", null).ToString());
            da.Min = Decimal.Parse(MySQLHelper.ExecuteScalar("select min(" + columnName + ") from " + tableName + " limit  0,1", null).ToString());
            da.Avg = Decimal.Parse(MySQLHelper.ExecuteScalar("select avg(" + columnName + ") from " + tableName + "  limit  0,1", null).ToString());
            da.Difference = da.Max - da.Min;
            lstDataAnalysis.Add(da);
            return lstDataAnalysis;
        }

        #endregion

        #region  曲线图数据 泵房  配电室
        /// <summary>
        /// 给排水泵房 曲线图
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="strWhere"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<PumpHouseModel> GetPumphouseCurveData(int dataType, string strWhere, string beginTime, string endTime)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (dataType == 27)
            {
                //泵房环境温度
                sbWhere.Append(" T_ROOM,insertTime ");
            }
            else if (dataType == 28)
            {
                //泵房环境湿度
                sbWhere.Append(" H_ROOM,insertTime");
            }
            else if (dataType == 29)
            {
                //泵房三相电压
                //sbWhere.Append(" UAB_SH,UBC_SH,UCA_SH,UAB_XF,UBC_XF,UCA_XF,insertTime  ");
                sbWhere.Append(" UAB_SH,UBC_SH,UCA_SH,insertTime  ");
            }
            else if (dataType == 30)
            {
                // 泵房三相电流
                //sbWhere.Append("  IA_SH,IB_SH,IC_SH,IA_XF,IB_XF,IC_XF,insertTime  ");
                sbWhere.Append("  IA_SH,IB_SH,IC_SH,insertTime  ");

            }
            else if (dataType == 31)
            {
                //泵房供水压力
                //sbWhere.Append("  P_IN,P_LO,P_MI,P_HI,P_SP,P_XF1,P_PL1,P_XF2,P_PL2,insertTime  ");
                sbWhere.Append("  P_IN,P_LO,P_MI,P_HI,P_SP,insertTime  ");

            }
            else if (dataType == 32)
            {
                //泵房水箱液压
                //sbWhere.Append("  L_SHSX,L_XFSX,insertTime  ");
                sbWhere.Append("  L_SHSX,insertTime  ");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sbWhere.ToString());
            strSql.Append(" from  pumphouse_rd a ");
            strSql.Append(" LEFT JOIN devinfo b  ON a.devid=b.devID ");
            strSql.Append(" WHERE " + strWhere);
            strSql.AppendFormat("  AND  insertTime between '{0}' and '{1}' ", beginTime, endTime);

            List<PumpHouseModel> pumpHouseList = MySQLHelper.ExecuteToList<PumpHouseModel>(strSql.ToString(), null);

            return pumpHouseList;
        }

        /// <summary>
        /// 配电房 曲线图
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="strWhere"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<SwitchRoomRdModel> GetSwitchCurveData(int dataType, string strWhere, string beginTime, string endTime)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (dataType == 33)
            {
                //配电室环境温度
                sbWhere.Append(" T_ROOM,insertTime ");
            }
            else if (dataType == 34)
            {
                //泵房环境湿度
                sbWhere.Append(" H_ROOM,insertTime");
            }
            else if (dataType == 35)
            {
                //配电室变压器温度
                sbWhere.Append("  N1_T_A,N1_T_B,N1_T_C,N2_T_A,N2_T_B,N2_T_C,insertTime  ");
            }
            else if (dataType == 36)
            {
                //配电室三相电压
                sbWhere.Append(" N1_UAB, N1_UBC, N1_UCA, N2_UAB, N2_UBC, N2_UCA ,insertTime ");
            }
            else if (dataType == 37)
            {
                // 配电室三相电流
                sbWhere.Append("  N1_IA, N1_IB, N1_IC,N2_IA,N2_IB,N2_IC,insertTime  ");
            }
            else if (dataType == 38)
            {
                //配电室功率因数
                sbWhere.Append("  N1_PF,N2_PF,insertTime  ");
            }
            return MySQLHelper.ExecuteToList<SwitchRoomRdModel>
                (String.Format(@"select " + sbWhere + " from  switchroom_rd a LEFT JOIN devinfo b ON a.devid=b.devID WHERE  " + strWhere + " AND  insertTime between '" + beginTime + "' and '" + endTime + "' ", beginTime, endTime), null);
        }

        /// <summary>
        /// 消防泵房 曲线图
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="strWhere"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<FirePumpHouseModel> GetFirePumphouseCurveData(int dataType, string strWhere, string beginTime, string endTime)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (dataType == 27)
            {
                //泵房环境温度
                sbWhere.Append(" T_ROOM,insertTime ");
            }
            else if (dataType == 28)
            {
                //泵房环境湿度
                sbWhere.Append(" H_ROOM,insertTime");
            }
            else if (dataType == 29)
            {
                //泵房三相电压
                sbWhere.Append(" UAB_XF,UBC_XF,UCA_XF,insertTime  ");
            }
            else if (dataType == 30)
            {
                // 泵房三相电流
                sbWhere.Append("  IA_XF,IB_XF,IC_XF,insertTime  ");
            }
            else if (dataType == 31)
            {
                //泵房供水压力
                sbWhere.Append(" P_XF1,P_PL1,P_XF2,P_PL2,insertTime  ");
            }
            else if (dataType == 32)
            {
                //泵房水箱液压
                sbWhere.Append(" L_XFSX,insertTime  ");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(sbWhere.ToString());
            strSql.Append(" from  pumphouse_rd a ");
            strSql.Append(" left join devinfo b  on a.devid=b.devid ");
            strSql.Append(" where " + strWhere);
            strSql.AppendFormat(" AND  insertTime between '{0}' and '{1}'  ", beginTime, endTime);

            return MySQLHelper.ExecuteToList<FirePumpHouseModel>(strSql.ToString(), null);
        }


        #endregion

        #region  excel 生成
        /// <summary>
        /// 取得给排水泵房数据
        /// </summary>
        /// <param name="devid">设备房编号</param>
        /// <param name="communityID">小区编号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetExcelPumpData(string strWhere, string beginTime, string endTime)
        {
            return MySQLHelper.ExecuteToList<PumpHouseRdModel>(@"SELECT insertTime,
	                                    T_ROOM,H_ROOM,UAB_SH,UBC_SH,UCA_SH,IA_SH,IB_SH,IC_SH,KWH_SH,KVARH_SH,
                                        PF_SH,L_SHSX,P_IN,P_LO,P_MI,P_HI,P_SP
                                    FROM    pumphouse_rd a
                                    INNER JOIN devinfo b ON a.devid = b.devID
                                    INNER JOIN  communityinfo c  ON  b.communityID = c.communityID 
                                    WHERE " + strWhere + "  AND  a.insertTime  >='" + beginTime + "'  AND   a.insertTime<'" + endTime + "' ");
        }


        /// <summary>
        /// 取得给配电房数据
        /// </summary>
        /// <param name="devid">设备房编号</param>
        /// <param name="communityID">小区编号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<SwitchRoomRdModel> GetExcelSwitchData(string strWhere, string beginTime, string endTime)
        {
            return MySQLHelper.ExecuteToList<SwitchRoomRdModel>(@"SELECT insertTime,
	                                T_ROOM,H_ROOM,N1_T_A,N1_T_B,N1_T_C,N1_UAB,N1_UBC,N1_UCA,N1_IA,N1_IB,N1_IC,N1_PF,
                                    N1_KWH,N1_KVARH,N2_T_A,N2_T_B,N2_T_C,N2_UAB,N2_UBC,N2_UCA,N2_IA,N2_IB,N2_IC,N2_PF,
                                    N2_KWH,N2_KVARH
                                FROM    switchroom_rd a
                                INNER JOIN devinfo b ON a.devid = b.devID
                                INNER JOIN communityinfo c ON b.communityID = c.communityID 
                                WHERE  " + strWhere + "  AND a.insertTime  >='" + beginTime + "'  AND   a.insertTime<'" + endTime + "' ");
        }

        /// <summary>
        /// 取得消防泵房数据
        /// </summary>
        /// <param name="devid">设备房编号</param>
        /// <param name="communityID">小区编号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<PumpHouseRdModel> GetExcelFirePumpData(string strWhere, string beginTime, string endTime)
        {
            return MySQLHelper.ExecuteToList<PumpHouseRdModel>(@"SELECT insertTime,
	                                    T_ROOM,H_ROOM,UAB_XF,UBC_XF,UCA_XF,IA_XF,IB_XF,IC_XF,KWH_XF,KVARH_XF,PF_XF,L_XFSX,
                                        P_XF1,P_PL1,P_XF2,P_PL2
                                    FROM    pumphouse_rd a
                                    INNER JOIN devinfo b ON a.devid = b.devID
                                    INNER JOIN  communityinfo c  ON  b.communityID = c.communityID 
                                    WHERE " + strWhere + "  AND  a.insertTime  >='" + beginTime + "'  AND   a.insertTime<'" + endTime + "' ");
        }
        #endregion

    }
}
