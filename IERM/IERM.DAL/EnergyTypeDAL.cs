using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public partial class EnergyTypeDAL
    {
        /// <summary>
        /// 获取指定类型的能源模板
        /// </summary>
        public List<EnergyTypeModel> GetEnergyTmplByPid(int pid)
        {
            return MySQLHelper.ExecuteToList<EnergyTypeModel>(string.Format("select * from energytype where pID={0} and isDel=0", pid), null);
        }
    }
}
