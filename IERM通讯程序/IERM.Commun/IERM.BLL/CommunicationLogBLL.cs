using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class CommunicationLogBLL
    {
        private readonly DAL.CommunicationLogDAL comm_dal = new DAL.CommunicationLogDAL();

        /// <summary>
        /// 添加一条通信记录（只记录异常数据包）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MODEL.CommunicationLogModel model)
        {
            return comm_dal.Add(model);
        }

        /// <summary>
        /// 获取错误通讯日志
        /// </summary>
        /// <returns></returns>
        public List<MODEL.CommunicationLogModel> GetCommLog(DateTime seldate)
        {
            return comm_dal.GetCommLog(string.Format(" where InsertTime>='{0}' and InsertTime<='{1}'", seldate.Date.ToString(), seldate.Date.AddDays(1).ToString()));
        }
    }
}
