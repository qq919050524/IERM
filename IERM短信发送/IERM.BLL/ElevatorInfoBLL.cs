using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class ElevatorInfoBLL
    {
        private DAL.ElevatorInfoDAL _dal = new DAL.ElevatorInfoDAL();
        /// <summary>
        /// 根据电梯注册码获取，需发送的手机号
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <returns></returns>
        public DataTable GetUserMobile(string registrationCode)
        {
            return _dal.GetUserMobile(registrationCode);
        }
    }
}
