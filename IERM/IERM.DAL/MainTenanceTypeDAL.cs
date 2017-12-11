using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class MainTenanceTypeDAL
    {
        /// <summary>
        /// 获取指定系统类型的维保内容
        /// </summary>
        /// <param name="systypeid"></param>
        /// <returns></returns>
        public List<MainTenanceTypeModel> GetMaintenanceType(int systypeid)
        {
            return MySQLHelper.ExecuteToList<MainTenanceTypeModel>(string.Format("SELECT * from maintenancetype where systypeID={0} and isDel=0 order by sort asc", systypeid), null);
        }
    }
}
