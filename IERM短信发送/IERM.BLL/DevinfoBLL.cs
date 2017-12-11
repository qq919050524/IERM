using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class DevinfoBLL
    {
        private readonly DAL.DevInfoDAL dev_dal = new DAL.DevInfoDAL();

        /// <summary>
        /// 根据设备编号取得对应的管理用户
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <returns></returns>
        public DataTable GetUserByDev(string devID)
        {
            return dev_dal.GetUserByDev(devID);
        }
    }
}
