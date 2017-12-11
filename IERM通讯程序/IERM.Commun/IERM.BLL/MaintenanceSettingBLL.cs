using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IERM.BLL
{
    public class MaintenanceSettingBLL
    {
        private readonly DAL.MaintenanceSettingDAL msetting_dal = new DAL.MaintenanceSettingDAL();
        private Random rd = new Random();
        /// <summary>
        /// 获取维保计划
        /// </summary>
        /// <returns></returns>
        public List<MODEL.MaintenanceSettingModel> GetAllSetting()
        {
            var tmpdata = msetting_dal.GetAllSetting();

            return tmpdata.GroupBy(o => o.sID).Select(s =>
            {
                if (s.Where(w => w.logcreatetime > DateTime.MinValue).Count() > 0)
                {
                    var ct = s.Where(h => h.logcreatetime == s.Max(m => m.logcreatetime)).FirstOrDefault();
                    ct.stratDate = ct.logcreatetime;
                    return ct;
                }
                else
                {
                    return s.FirstOrDefault();
                }
            }).ToList();
        }

        /// <summary>
        /// 获取全部维保类型
        /// </summary>
        /// <returns></returns>
        public List<MODEL.MaintenanceContentModel> GetAllMContent()
        {
            return msetting_dal.GetAllMContent();
        }

        /// <summary>
        /// 创建维保工单
        /// </summary>
        /// <param name="cmdlist"></param>
        /// <returns></returns>
        public bool CreateMaintenance(object obj)
        {
            var maintenancesetting = GetAllSetting();
            var maintenancecontent = GetAllMContent();

            var cmdlist = new List<string>();
            foreach (var item in maintenancesetting)
            {
                if (GetExpireDate(item.stratDate, item.cycLength, item.cycUnit) < DateTime.Now)
                {
                    if (!item.isCyclic)
                    {
                        cmdlist.Add(string.Format("UPDATE maintenancesetting set `status`=0 where sID={0}",item.sID));
                    }

                    cmdlist.Add(string.Format("insert into maintenancelog(settingID,devhouseID,orderCode,orderContent,orderType,createTime,status) values({0},{1},'{2}','{3}',{4},'{5}',1)",
                        item.sID,
                        item.devhouseID,
                        DateTime.Now.ToString("yyMMddHHmmssfff") + Regex.Match(item.sID.ToString("000"), "^.+(\\d{3})$").Groups[1].Value,
                        string.Join("<br/>", maintenancecontent.Where(w => w.settingID == item.sID).Select(s => s.mtypeName)),
                        item.mType + 1,
                        DateTime.Now
                        ));
                }
            }

            return msetting_dal.CreateMaintenance(cmdlist);
        }

        /// <summary>
        /// 获取到期日期
        /// </summary>
        private DateTime GetExpireDate(DateTime beginTime, int cyclength, int cycunit)
        {
            DateTime expDate = beginTime.Date.AddHours(6);
            do
            {
                //周期单位（1：日    2：周     3：月）
                if (cycunit == 1)
                {
                    expDate = expDate.AddDays(cyclength);
                }
                else if (cycunit == 2)
                {
                    expDate = expDate.AddDays(cyclength * 7);
                }
                else
                {
                    expDate = expDate.AddMonths(cyclength);
                }
            }
            while (expDate < DateTime.Now);
           return expDate;
        }

        /// <summary>
        /// 获取报警类型
        /// </summary>
        /// <param name="alarmstate"></param>
        /// <returns></returns>
        private string GetAlarmStateName(int alarmstate)
        {
            string statename = string.Empty;
            switch (alarmstate)
            {
                case -2:
                    statename = "过低";
                    break;
                case 2:
                    statename = "过高";
                    break;
                case -1:
                    statename = "异常";
                    break;
                default:
                    statename = "正常";
                    break;
            }
            return statename;
        }
    }
}
