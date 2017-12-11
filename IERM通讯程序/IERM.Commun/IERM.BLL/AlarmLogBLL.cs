using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{  
    public class AlarmLogBLL
    {
        private readonly DAL.AlarmLogDAL alarmlog_dal = new DAL.AlarmLogDAL();

        /// <summary>
        /// 新增一条报警记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Add(object model)
        {
            alarmlog_dal.Add(model as MODEL.AlarmLogModel);
        }

        /// <summary>
        /// 添加一条报警恢复记录
        /// </summary>
        /// <param name="model"></param>
        public void ReSet(object model)
        {
            alarmlog_dal.ReSet(model as MODEL.AlarmLogModel);
        }
    }
}
