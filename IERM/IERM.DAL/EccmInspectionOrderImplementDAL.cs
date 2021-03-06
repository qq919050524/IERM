﻿using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EccmInspectionOrderImplementDAL
    {
        /// <summary>
        /// 根据order_id 获取实施记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmInspectionOrderImplementModel> GetOrderImplementList(int orderID, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_Inspection_order_implement i ");
            sqlCount.Append(" left join equipmentinfo e on e.equCode = i.equCode ");
            sqlCount.Append(" left join userinfo u on u.uid = i.uid_handle ");
            sqlCount.Append(" left join eccm_Inspection_order o on o.order_id = i.order_id ");
            sqlCount.Append(" left join eccm_order_device_standard s on o.order_sn = s.order_sn and s.equCode = i.equCode and order_device_standard_type = 1 ");
            sqlCount.AppendFormat(" where i.order_id='{0}'", orderID);
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select i.implement_id,i.order_id,i.equCode,i.implement_content,i.implement_time,i.uid_handle,i.ext1,i.ext2,i.ext3 ");
            sql.Append(" , e.equName,u.nickName,s.device_standard ");
            sql.Append(" from eccm_Inspection_order_implement i ");
            sql.Append(" left join equipmentinfo e on e.equCode = i.equCode ");
            sql.Append(" left join userinfo u on u.uid = i.uid_handle ");
            sql.Append(" left join eccm_Inspection_order o on o.order_id = i.order_id ");
            sql.Append(" left join eccm_order_device_standard s on o.order_sn = s.order_sn and s.equCode = i.equCode and order_device_standard_type = 1 ");
            sql.AppendFormat(" where i.order_id='{0}'", orderID);
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<EccmInspectionOrderImplementModel>(sql.ToString(), null);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EccmInspectionOrderImplementModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_inspection_order_implement(");
            strSql.Append("order_id,equCode,implement_content,implement_time,uid_handle,ext1,ext2,ext3)");
            strSql.Append(" values (");
            strSql.Append("@order_id,@equCode,@implement_content,@implement_time,@uid_handle,@ext1,@ext2,@ext3)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@order_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@equCode", MySqlDbType.VarChar,50),
                    new MySqlParameter("@implement_content", MySqlDbType.Text),
                    new MySqlParameter("@implement_time", MySqlDbType.DateTime),
                    new MySqlParameter("@uid_handle", MySqlDbType.Int32,11),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.order_id;
            parameters[1].Value = model.equCode;
            parameters[2].Value = model.implement_content;
            parameters[3].Value = model.implement_time;
            parameters[4].Value = model.uid_handle;
            parameters[5].Value = model.ext1;
            parameters[6].Value = model.ext2;
            parameters[7].Value = model.ext3;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                string sql = "select max(implement_id) from eccm_inspection_order_implement;";//获取实施id
                int i = Convert.ToInt32(MySQLHelper.ExecuteScalar(sql, null));
                return i;
            }
            else
            {
                return 0;
            }
        }
    }
}
