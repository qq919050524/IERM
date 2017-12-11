using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class DeviceRelationBLL
    {
        private readonly DeviceRelationDAL device_dal = new DeviceRelationDAL();
        /// <summary>
        /// 获取设备房所含系统类型
        /// </summary>
        /// <param name="devInfoID"></param>
        /// <returns></returns>
        public List<DeviceRelationModel> GetDeviceRelation(int devInfoID)
        {
            return device_dal.GetDeviceRelation(string.Format(" where devInfoID={0}", devInfoID));
        }
    }
}
