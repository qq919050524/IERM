using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class DevInfoBLL
    {
        private readonly DAL.DevInfoDAL devinfo_dal = new DAL.DevInfoDAL();

        /// <summary>
        /// 获取制定小区的设备房信息
        /// </summary>
        /// <returns></returns>
        public List<MODEL.DevInfoModel> GetDevHouseInfo()
        {
            return devinfo_dal.GetDevHouseInfo();
        }
    }
}
