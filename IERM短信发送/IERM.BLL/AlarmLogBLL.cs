using IERM.Message.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
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
            alarmlog_dal.Add(model as AlarmLogModel);
        }

        /// <summary>
        /// 添加一条报警恢复记录
        /// </summary>
        /// <param name="model"></param>
        public void ReSet(object model)
        {
            alarmlog_dal.ReSet(model as AlarmLogModel);
        }

        public DataTable GetList(int top, string strWhere)
        {
            return alarmlog_dal.GetList(top,strWhere);
        }
        public DataTable GetList(string strWhere)
        {
            return alarmlog_dal.GetList(strWhere);
        }
    }
}
