using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.DAL
{
    public class ElevatorInfoDAL
    {
        /// <summary>
        /// 根据电梯注册码获取，需发送的手机号
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <returns></returns>
        public DataTable GetUserMobile(string registrationCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select distinct(mobile) mobile from elevatorinfo e ");
            strSql.Append(" left join usercommunityrelative c on c.communityid = e.communityid ");
            strSql.Append(" left join userinfo u on u.uid = c.userid ");
            strSql.Append(" where u.isDel = 0 and e.isDel = 0 and u.nickName != 'admin' ");
            strSql.AppendFormat(" and e.registrationCode = '{0}' ", registrationCode);

            return MySQLHelper.ExecuteToDataTable(strSql.ToString());
        }
    }
}
