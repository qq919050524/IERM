using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
    /// JINXIN
    /// </summary>
    public partial class PumpHouseRdDAL
    {

        public List<PumpHouseRdModel> GetPumphouse_Rd(string devId, int pagesize, int pageindex, out int pumpCount)
        {
            try
            {
                StringBuilder sbWhere = new StringBuilder();
                if (devId != null)
                {
                    //如果没有设备号就输出全部数据
                    sbWhere.AppendFormat(" where devid={0}", devId);

                }
                //分页查询
                pumpCount = Convert.ToInt32(MySQLHelper.ExecuteScalar(string.Format("select count(1) from pumphouse_rd  {0}", sbWhere), null));
                sbWhere.AppendFormat(" LIMIT {0},{1}", (pageindex - 1) * pagesize, pagesize);
                //返回数据
                return MySQLHelper.ExecuteToList<PumpHouseRdModel>(string.Format("select * from pumphouse_rd {0}", sbWhere), null);
            }
            catch (Exception err)
            {
                LogHelper.Error(string.Format("IERM.operationlog.GetSysLog------{0}", err.Message));
                throw err;
            }
        }
    }
}
