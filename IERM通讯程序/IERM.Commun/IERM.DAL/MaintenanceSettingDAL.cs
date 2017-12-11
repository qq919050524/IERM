using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class MaintenanceSettingDAL
    {
        public List<MODEL.MaintenanceSettingModel> GetAllSetting()
        {
            return Common.MySQLHelper.ExecuteToList<MODEL.MaintenanceSettingModel>("SELECT mts.*, mtl.createTime AS logcreatetime,mtl.operateTime AS logoperatetime,emi.devhouseID FROM maintenancesetting AS mts LEFT JOIN maintenancelog AS mtl ON mtl.settingID = mts.sID LEFT JOIN equipmentinfo AS emi ON emi.eID = mts.equID WHERE mts.isDel = 0 AND mts.`status` = 1");
        }

        /// <summary>
        /// 创建维保工单
        /// </summary>
        /// <param name="cmdlist"></param>
        /// <returns></returns>
        public bool CreateMaintenance(List<string> cmdlist)
        {
            return Common.MySQLHelper.ExecuteSqlByTran(cmdlist) > 0 ? true : false;
        }

        public List<MODEL.MaintenanceContentModel> GetAllMContent()
        {
            return Common.MySQLHelper.ExecuteToList<MODEL.MaintenanceContentModel>("SELECT mc.cID,mc.settingID,mc.mtypeID,mt.mtypeName from maintenancecontent as mc LEFT JOIN maintenancetype as mt on mt.mID = mc.mtypeID");
        }

    }
}
