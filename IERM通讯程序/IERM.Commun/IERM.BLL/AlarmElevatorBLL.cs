using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class AlarmElevatorBLL
    {
        private DAL.AlarmElevatorDAL _dal = new DAL.AlarmElevatorDAL();
        /// <summary>
        /// 添加一条电梯报警记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MODEL.AlarmElevatorModel model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 根据registrationCode和customCode 查询最新报警
        /// </summary>
        /// <param name="registrationCode"></param>
        /// <param name="customCode"></param>
        /// <returns></returns>
        public MODEL.AlarmElevatorModel GetLatestEvent(string registrationCode, string customCode)
        {
            return _dal.GetLatestEvent(registrationCode, customCode);
        }
    }
}
