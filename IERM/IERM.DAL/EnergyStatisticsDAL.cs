using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
    /// 能耗统计  JINXIN
    /// </summary>
    public partial class EnergyStatisticsDAL
    {
        #region  能耗统计
        /// <summary>
        /// 返回电的能耗统计
        /// </summary>
        /// <param name="proNo">设备号</param>
        /// <param name="year">年</param>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergyElectricityList(int proNo, int year)
        {
            // left join  communityinfo b  on a.communityID = b.communityID
           // where b.propertyMId ={ 0}
            string strSql = string.Format(@"    select  a.communityID,typeID,`year`,`month`,sum(engValue) engValue,insertTime FROM energyinfo a 
                                                left JOIN energytype t on t.tID=a.typeID 
                                                left join  communityinfo b  on a.communityID = b.communityID
                                                where   pid=1  and a.year={1}
                                                group by `month` ", proNo, year);
            return MySQLHelper.ExecuteToList<EnergyInfoModel>(strSql);
        }

        /// <summary>
        /// 返回水的能耗统计
        /// </summary>
        /// <param name="proNo">设备号</param>
        /// <param name="year">年</param>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergyWaterList(int proNo, int year)
        {
            string strSql = string.Format(@"    select  a.communityID,typeID,`year`,`month`,engValue,insertTime FROM energyinfo a 
                                                left JOIN energytype t on t.tID=a.typeID
                                                left join  communityinfo b  on a.communityID = b.communityID
                                                where pid=2  and a.year={1}", proNo, year);
            return MySQLHelper.ExecuteToList<EnergyInfoModel>(strSql);
        }

        /// <summary>
        /// 返回气的能耗统计
        /// </summary>
        /// <param name="proNo">设备号</param>
        /// <param name="year">年</param>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergyGasList(int proNo, int year)
        {
            string strSql = string.Format(@"    select  a.communityID,typeID,`year`,`month`,engValue,insertTime FROM energyinfo a 
                                                left JOIN energytype t on t.tID=a.typeID
                                                left join  communityinfo b  on a.communityID = b.communityID 
                                                where pid=3  and a.year={1}", proNo, year);
            return MySQLHelper.ExecuteToList<EnergyInfoModel>(strSql);
        }
        #endregion

        #region   设备的异常和正常数据
        /// <summary>
        /// 异常量
        /// </summary>
        /// <returns></returns>
        public int GetAlarmCount(int sysType, int proNo)
        {
            return MySQLHelper.ExecuteToList<ViewAlarmlogModel>(string.Format(@"select  a.alarmCode,MAX(a.insertTime) from  view_alarmlog a 
	                            LEFT JOIN alarmtype b ON a.alarmCode=b.alarmCode 
                             WHERE b.sysType=" + sysType + " AND a.propertyID=" + proNo + "  AND a.alarmState IN (-1,-2,-2)	GROUP BY a.alarmCode"), null).Count();
        }

        /// <summary>
        /// 设备总量
        /// </summary>
        /// <param name="sysType"></param>
        /// <returns></returns>
        public int GetEquipmentCount(int sysType, int proNo)
        {
            return MySQLHelper.ExecuteToList<EquipmentInfoModel>(string.Format(@"SELECT
	                                    c.propertyName,
	                                    b.devName,
	                                    a.*
                                    FROM
	                                    equipmentinfo a
                                    INNER JOIN devinfo b ON a.devhouseID = b.devID
                                    INNER JOIN propertyinfo c ON b.communityID = c.propertyID
                                    WHERE a.sysTypeID=" + sysType + " AND c.propertyID=" + proNo + ""), null).Count();
        }
        #endregion

        /// <summary>
        /// 12个月的消防事件记录
        /// </summary>
        /// <returns></returns>
        public int GetMonthFireControl(int prono, string begintime, string endtime)
        {
            int count = MySQLHelper.ExecuteToList<ViewAlarmlogModel>(string.Format(@"SELECT
	                            *
                            FROM
	                            view_alarmlog a
                            LEFT JOIN alarmtype b ON a.alarmCode = b.alarmCode
                            WHERE
	                            b.sysType = 2
                            AND
	                            a.propertyID=" + prono + " AND  a.insertTime  BETWEEN  '" + begintime + "'  AND   '" + endtime + "' "), null).Count();
            return count;
        }

        /// <summary>
        /// 当月派单数量
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetMonthIssuedData(int prono, string beginTime, string endTime)
        {
            return MySQLHelper.ExecuteToList<ViewAlarmlogModel>
                (string.Format(@"SELECT * FROM maintenancelog a INNER JOIN 
                                    maintenancesetting b ON a.settingID=b.sID INNER JOIN  
                                    devinfo c ON c.devID=b.equID INNER JOIN communityinfo d ON c.communityID=d.communityID
                                    WHERE d.propertyMId=" + prono + "  AND  a.createTime BETWEEN '" + beginTime + "' AND  '" + endTime + "'"), null).Count();
        }

        /// <summary>
        /// 当月派单任务完成数量
        /// </summary>
        /// <param name="prono"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetMonthCompleteData(int prono, string beginTime, string endTime)
        {
            return MySQLHelper.ExecuteToList<ViewAlarmlogModel>
                (string.Format(@"SELECT * FROM maintenancelog a INNER JOIN 
                                    maintenancesetting b ON a.settingID=b.sID INNER JOIN  
                                    devinfo c ON c.devID=b.equID INNER JOIN communityinfo d ON c.communityID=d.communityID
                                    WHERE  a.`status` =1  AND  d.propertyMId=" + prono +
                                    "  AND  a.createTime BETWEEN '" + beginTime + "' AND  '" + endTime + "'"), null).Count();
        }


    }
}
