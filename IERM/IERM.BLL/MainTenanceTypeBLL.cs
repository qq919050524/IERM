using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class MainTenanceTypeBLL
    {
        private readonly MainTenanceTypeDAL mtype_dal = new MainTenanceTypeDAL();

        /// <summary>
        /// 获取指定系统类型的维保内容
        /// </summary>
        /// <param name="systypeid"></param>
        /// <returns></returns>
        public List<MainTenanceTypeModel> GetMaintenanceType(int systypeid)
        {
            return mtype_dal.GetMaintenanceType(systypeid);
        }
    }
}
