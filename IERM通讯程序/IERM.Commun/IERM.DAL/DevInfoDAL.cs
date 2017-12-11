using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class DevInfoDAL
    {
        /// <summary>
        /// 获取全部设备房信息
        /// </summary>
        /// <returns></returns>
        public List<MODEL.DevInfoModel> GetDevHouseInfo()
        {
            return Common.MySQLHelper.ExecuteToList<MODEL.DevInfoModel>(string.Format("select * from devinfo where isDel=0"), null);
        }
    }
}
