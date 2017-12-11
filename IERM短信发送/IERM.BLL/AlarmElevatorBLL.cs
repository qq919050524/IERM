using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class AlarmElevatorBLL
    {
        private DAL.AlarmElevatorDAL _dal = new DAL.AlarmElevatorDAL();
        /// <summary>
        /// 获取电梯最新的报警记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Model.AlarmElevatorModel> GetCurrentAlarmElevator(string strWhere)
        {
            return _dal.GetCurrentAlarmElevator(strWhere);
        }
    }
}
