using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EccmReceiverUserDAL
    {
        /// <summary>
        /// 获取责任人和协同人员
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="receiverType">类型(1巡检2维保3维修)</param>
        /// <returns></returns>
        public List<EccmReceiverUserModel> GetEccmReceiverUserList(int orderID,int receiverType)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select r.receiver_id,r.order_id,r.uid_receiver,is_duty,receiver_type ");
            sql.Append(" ,u.nickName ");
            sql.Append(" from eccm_receiver_user r ");
            sql.Append(" left join userinfo u on u.uid=r.uid_receiver ");
            sql.Append(" where receiver_type=@receiverType and r.order_id=@orderID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@orderID", orderID),
                    new MySqlParameter("@receiverType", receiverType),
            };

            return MySQLHelper.ExecuteToList<EccmReceiverUserModel>(sql.ToString(), parameters);
        }
    }
}
