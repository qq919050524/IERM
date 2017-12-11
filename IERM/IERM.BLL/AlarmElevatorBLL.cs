using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class AlarmElevatorBLL
    {
        private AlarmElevatorDAL _dal = new AlarmElevatorDAL();
        /// <summary>
        /// 实时报警记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ViewAlarmelevatorModel> GetCurrentAlarmElevator(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetCurrentAlarmElevator(strWhere, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 历史报警记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ViewAlarmelevatorModel> GetHistoryAlarmElevator(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetHistoryAlarmElevator(strWhere, pageindex, pagesize, out count);
        }
    }
}
