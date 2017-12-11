using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.DAL
{
    public class DevInfoDAL
    {

        /// <summary>
        /// 根据设备编号取得对应的管理用户
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <returns></returns>
        public DataTable GetUserByDev(string devID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  mobile from devinfo d ");
            strSql.Append("left join usercommunityrelative c on c.communityid = d.communityid ");
            strSql.Append("left join userinfo u on u.uid = c.userid ");
            strSql.AppendFormat("where d.isDel=0 and  u.isDel=0 and d.devid = {0} ", devID);

            return MySQLHelper.ExecuteToDataTable(strSql.ToString());
        }

    }
}
