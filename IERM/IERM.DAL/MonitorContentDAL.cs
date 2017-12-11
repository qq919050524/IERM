using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class MonitorContentDAL
    {
        /// <summary>
        /// 获取设备房展示的内容                                            
        /// </summary>
        /// <returns></returns>
        public List<MonitorContentModel> GetMonitorContent(string strWhere)
        {
            return MySQLHelper.ExecuteToList<MonitorContentModel>(string.Format("select * from monitorcontent {0}", strWhere), null);
        }
    }
}
