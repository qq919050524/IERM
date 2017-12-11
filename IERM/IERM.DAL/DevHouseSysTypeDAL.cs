using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class DevHouseSysTypeDAL
    {
        public List<DevHouseSysTypeModel> GetHouseSystype(string strWhere)
        {
            return MySQLHelper.ExecuteToList<DevHouseSysTypeModel>(string.Format("select * from devhousesystype {0}", strWhere), null);
        }
    }
}
