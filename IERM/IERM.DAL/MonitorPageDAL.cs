using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class MonitorPageDAL
    {
        public MonitorPageModel GetMonitorPage(string strWhere)
        {
            return MySQLHelper.ExecuteToList<MonitorPageModel>(string.Format("SELECT * from monitorpage {0}", strWhere), null).FirstOrDefault();
        }
    }
}
