using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class SystemTypeBLL
    {
        private readonly SystemTypeDAL systemtype_dal = new SystemTypeDAL();

        /// <summary>
        /// 获取系统类型列表
        /// </summary>
        /// <returns></returns>
        public List<SystemTypeModel> GetSystemType()
        {
            return systemtype_dal.GetSystemType();
        }

        /// <summary>
        /// JINXIN
        /// </summary>

        public List<SystemTypeModel> GetAllSysType()
        {
            return systemtype_dal.GetAllSystemType();
        }

        public List<CodeInformationModel> GetAllCode()
        {
            return systemtype_dal.GetAllCode();
        }
    }
}
