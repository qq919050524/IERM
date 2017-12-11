using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IERM.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OperationLogBLL
    {
        private readonly OperationLogDAL opl_dal = new OperationLogDAL();

        /// <summary>
        /// 系统日志
        /// </summary>
        public List<OperationLogModel> GetSysLog(int typeid, string partname, string timespan, int pagesize, int pageindex,out int logCount)
        {
            try
            {
                var ts = Regex.Matches(timespan, "[0-9]{4}-[0-9]{1,2}-[0-9]{1,2}");
                DateTime[] tps = { DateTime.Parse(ts[0].Value), DateTime.Parse(ts[1].Value).AddDays(1) };
                return opl_dal.GetSysLog(typeid, partname, tps, pagesize, pageindex, out logCount);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        //获取操作详情
        public string GetDetailsById(int oid)
        {
            return opl_dal.GetLogModel(oid).details;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        public int RecordLog(OperationLogModel model)
        {
            return opl_dal.RecordLog(model);
        }
    }
}
