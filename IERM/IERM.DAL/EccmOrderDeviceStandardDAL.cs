using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EccmOrderDeviceStandardDAL
    {
        /// <summary>
        ///根据order_sn 查询订单设备
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmOrderDeviceStandardModel> GetOrderEquipmentList(string orderSN, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_order_device_standard s ");
            sqlCount.Append(" left join equipmentinfo e on s.equCode = e.equCode ");
            sqlCount.Append(" left join devinfo d on d.devID = e.devhouseID ");
            sqlCount.Append(" left join eccm_device_type t on t.device_type_code = e.device_type_code ");
            sqlCount.AppendFormat(" where s.order_sn='{0}'", orderSN);
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select s.order_sn,s.equCode,equName,devName,devide_type_name,manufacturer,setupDate ");
            sql.Append(" from eccm_order_device_standard s ");
            sql.Append(" left join equipmentinfo e on s.equCode = e.equCode ");
            sql.Append(" left join devinfo d on d.devID = e.devhouseID ");
            sql.Append(" left join eccm_device_type t on t.device_type_code = e.device_type_code ");
            sql.AppendFormat(" where s.order_sn='{0}'", orderSN);
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<EccmOrderDeviceStandardModel>(sql.ToString(), null);
        }
    }
}
