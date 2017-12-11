using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    /// <summary>
    /// JINXIN
    /// </summary>
    public partial class EnergyStatisticsBLL
    {
        private readonly EnergyStatisticsDAL consum = new EnergyStatisticsDAL();

        #region 能耗数据统计
        /// <summary>
        /// 返回电水气数据
        /// </summary>
        /// <param name="proNo"></param>
        /// <returns></returns>
        public List<String> GetEnergyConsumptionList(int proNo, int year)
        {
            List<String> lstStr = new List<String>();
            //取出电的数据
            StringBuilder strElectricity = new StringBuilder();
            List<EnergyInfoModel> lst_electricity = consum.GetEnergyElectricityList(proNo, year);
            for (int i = 0; i < lst_electricity.Count(); i++)
            {
                if (i + 1 == lst_electricity.Count())
                {
                    strElectricity.Append(lst_electricity[i].engValue.ToString());
                }
                else
                {
                    strElectricity.Append(lst_electricity[i].engValue.ToString() + ",");
                }
            }
            lstStr.Add(strElectricity.ToString());
            //取出水的数据
            StringBuilder strWater = new StringBuilder();
            List<EnergyInfoModel> lst_water = consum.GetEnergyWaterList(proNo, year);
            for (int i = 0; i < lst_water.Count(); i++)
            {
                if (i + 1 == lst_water.Count())
                {
                    strWater.Append(lst_water[i].engValue.ToString());
                }
                else
                {
                    strWater.Append(lst_water[i].engValue.ToString() + ",");
                }
            }
            lstStr.Add(strWater.ToString());
            //取出气的数据
            StringBuilder strGas = new StringBuilder();
            List<EnergyInfoModel> lst_gas = consum.GetEnergyGasList(proNo, year);
            for (int i = 0; i < lst_gas.Count(); i++)
            {
                if (i + 1 == lst_gas.Count())
                {
                    strGas.Append(lst_gas[i].engValue.ToString());
                }
                else
                {
                    strGas.Append(lst_gas[i].engValue.ToString() + ",");
                }
            }
            lstStr.Add(strGas.ToString());
            return lstStr;
        }

        /// <summary>
        /// 取得能耗信息
        /// </summary>
        /// <param name="proNo">物业公司</param>
        /// <param name="year">年</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergyList(int proNo, int year, int type)
        {
            List<EnergyInfoModel> energyList = new List<EnergyInfoModel>();
            switch (type)
            {
                case 1://用电能耗
                    energyList = consum.GetEnergyElectricityList(proNo, year);
                    break;
                case 2://用水能耗
                    energyList = consum.GetEnergyWaterList(proNo, year);
                    break;
                case 3://用气能耗
                    energyList = consum.GetEnergyGasList(proNo, year);
                    break;
                default:
                    energyList = consum.GetEnergyElectricityList(proNo, year);
                    break;
            }
            return energyList;
        }


        /// <summary>
        /// 按照月份返回具体的日期段
        /// </summary>
        /// <returns></returns>
        private String GetTime(int year, int month)
        {
            //输入年份和月份 返回这个月的天数
            int days = DateTime.DaysInMonth(year, month);

            return "'" + year.ToString() + "-" + month.ToString() + "-1'  AND  '" + year.ToString() + "-" + month.ToString() + "-" + days + "'";
        }
        #endregion

        #region 设备使用情况统计
        ///1)	给系统障设备数量、完好设备数量
        public List<String> GetAlarmEquipment(List<int> sysType, int prono)
        {
            List<String> lstcount = new List<String>();
            for (int i = 0; i < sysType.Count; i++)
            {
                //获取设备异常数量
                int erroCount = consum.GetAlarmCount(sysType[i], prono);
                lstcount.Add(erroCount.ToString());
                //获取设备总量
                int count = consum.GetEquipmentCount(sysType[i], prono);
                lstcount.Add(count.ToString());
            }
            return lstcount;
        }
        #endregion

        /// <summary>
        /// 每个月的结束日期
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<String> GetEndDate(int year)
        {
            List<String> endDateList = new List<String>();
            for (int i = 1; i <= 12; i++)
            {
                endDateList.Add(DateTime.DaysInMonth(year, i).ToString());
            }
            return endDateList;
        }

        /// <summary>
        /// 返回每个月的所有数据统计
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<String> GetMonthImportantData(int prono, int year)
        {
            List<string> DataList = new List<string>();
            StringBuilder sbFire = new StringBuilder();
            StringBuilder sbIssued = new StringBuilder();
            StringBuilder sbComplete = new StringBuilder();
            List<int> fireDataCount = new List<int>();
            List<String> endDateList = GetEndDate(year);
            string beginTime = null;
            string endTime = null;
            for (int i = 0; i < endDateList.Count; i++)
            {
                beginTime = year.ToString() + "-" + (i + 1).ToString() + "-1";
                endTime = year.ToString() + "-" + (i + 1).ToString() + "-" + endDateList[i];

                if (i == 11)
                {
                    //消防最后一个
                    sbFire.Append(consum.GetMonthFireControl(prono, beginTime, endTime).ToString());
                    //派单最后一个
                    sbIssued.Append(consum.GetMonthIssuedData(prono, beginTime, endTime).ToString());
                    //完成派单最后一个
                    sbComplete.Append(consum.GetMonthCompleteData(prono, beginTime, endTime).ToString());
                }
                else
                {
                    sbFire.Append(consum.GetMonthFireControl(prono, beginTime, endTime).ToString() + ",");
                    sbIssued.Append(consum.GetMonthIssuedData(prono, beginTime, endTime).ToString() + ",");
                    sbComplete.Append(consum.GetMonthCompleteData(prono, beginTime, endTime).ToString() + ",");
                }
            }
            DataList.Add(sbFire.ToString());
            DataList.Add(sbIssued.ToString());
            DataList.Add(sbComplete.ToString());
            return DataList;
        }
    }
}
