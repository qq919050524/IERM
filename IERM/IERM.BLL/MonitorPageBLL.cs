using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IERM.DAL;
using IERM.Model;

namespace IERM.BLL
{
    public class MonitorPageBLL
    {
        private readonly  MonitorPageDAL mpage_dal = new MonitorPageDAL();
     public   MonitorPageModel GetMonitorPage(int devhouseID,int systypeID)
        {
            return mpage_dal.GetMonitorPage(string.Format(" where devhouseID={0} and systypeID={1}", devhouseID, systypeID));
        }
    }
}
