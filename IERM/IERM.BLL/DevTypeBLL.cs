using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class DevTypeBLL
    {
        private readonly DevTypeDAL devtype_dal = new DevTypeDAL();
        /// <summary>
        /// 获取所有设备类型
        /// </summary>
        public List<DevTypeModel> GetAllType()
        {
            return devtype_dal.GetAllType();
        }

        public DevTypeModel GetTypeByCode(string TypeCode)
        {
            List<DevTypeModel> list = devtype_dal.GetTypeByCode(TypeCode);
            DevTypeModel model = new DevTypeModel();
            if (list.Count > 0)
            {
                model = list[0];
            }
            return model;
        }
    }
}