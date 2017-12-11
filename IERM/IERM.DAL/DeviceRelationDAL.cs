using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
   public class DeviceRelationDAL
    {
        public List<DeviceRelationModel> GetDeviceRelation(string strWhere)
        {
            return MySQLHelper.ExecuteToList<DeviceRelationModel>(string.Format("select deviceID,deviceName,deviceUrl,devInfoID from deviceRelation {0}", strWhere), null);
        }
    }
}
