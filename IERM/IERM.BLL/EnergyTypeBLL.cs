using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class EnergyTypeBLL
    {
        private readonly EnergyTypeDAL energtype_dal = new EnergyTypeDAL();
        /// <summary>
        /// 获取指定类型的能源模板
        /// </summary>
        public List<EnergyTypeModel> GetEnergyTmplByPid(int pid)
        {
            return energtype_dal.GetEnergyTmplByPid(pid);
        }
    }
}
