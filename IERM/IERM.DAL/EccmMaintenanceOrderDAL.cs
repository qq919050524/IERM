using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EccmMaintenanceOrderDAL
    {
        /// <summary>
        /// 获取维保订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetMaintenanceOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_maintenance_order o ");
            sqlCount.Append(" left join communityinfo c on c.communityID = o.community_id ");
            sqlCount.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sqlCount.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sqlCount.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sqlCount.Append(" where o.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select order_id,plan_id,order_sn,order_type,unix_timestamp(order_time) as order_time,unix_timestamp(term_order) as term_order,unix_timestamp(order_finish_time) as order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3 ");
            sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" from eccm_maintenance_order o ");
            sql.Append(" left join communityinfo c on c.communityID = o.community_id ");
            sql.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sql.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sql.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sql.Append(" where o.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by order_stats,order_time desc ");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToDataTable(sql.ToString(), null);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmMaintenanceOrderModel model, string equCodes)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_maintenance_order(");
            strSql.Append("order_sn,order_type,order_time,term_order,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,uid)");
            strSql.Append(" values (");
            strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", model.order_sn, model.order_type, model.order_time, model.term_order, model.community_id, model.order_stats, model.uid_dispatch, model.ext1, model.ext2, model.ext3, model.uid);
            cmdlist.Add(strSql.ToString());


            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" insert into eccm_order_device_standard(order_sn, equCode, device_standard, order_device_standard_type) ");
            strSql2.AppendFormat(" select '{0}',ei.equCode,s.inspection_standard,2 FROM equipmentinfo ei ", model.order_sn);
            strSql2.Append(" left join eccm_device_relation_standard drs ON ei.device_type_code = drs.device_type_code ");
            strSql2.Append(" left join eccm_standard s ON drs.standard_id = s.standard_id  and s.standard_type = 2 ");
            StringBuilder codes = new StringBuilder();
            foreach (string d in equCodes.Split(','))
            {
                codes.AppendFormat("'{0}',", d);
            }
            codes.Remove(codes.Length - 1, 1);
            strSql2.AppendFormat(" where ei.equCode in ({0}) ", codes);
            cmdlist.Add(strSql2.ToString());

            int rows = MySQLHelper.ExecuteSqlByTran(cmdlist);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据 逻辑删除
        /// </summary>
        public bool Delete(int order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update eccm_maintenance_order set ");
            strSql.Append(" is_del=@isDel ");
            strSql.Append(" where order_id=@order_id ");
            MySqlParameter[] parameters = {
                new MySqlParameter("@isDel", MySqlDbType.Int32,11),
                new MySqlParameter("@order_id", MySqlDbType.Int32,11)
           };
            parameters[0].Value = 1;
            parameters[1].Value = order_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新改订单状态
        /// </summary>
        public bool UpdateStates(EccmMaintenanceOrderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_maintenance_order set ");
            strSql.Append("order_stats=@order_stats,");
            strSql.Append("order_finish_time=@order_finish_time");
            strSql.Append(" where order_id=@order_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@order_stats", MySqlDbType.Int32,11),
                    new MySqlParameter("@order_finish_time", MySqlDbType.DateTime),
                    new MySqlParameter("@order_id", MySqlDbType.Int32)};
            parameters[0].Value = model.order_stats;
            parameters[1].Value = model.order_finish_time;
            parameters[2].Value = model.order_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmMaintenanceOrderModel GetModel(int order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select order_id,plan_id,order_sn,order_type,order_time,term_order,order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,o.uid,u.nickname as dispatchName");
            strSql.Append(" from eccm_maintenance_order o ");
            strSql.Append(" left join userinfo u on o.uid_dispatch=u.uid ");
            strSql.AppendFormat(" where order_id={0} ", order_id);
            return MySQLHelper.ExecuteToList<EccmMaintenanceOrderModel>(strSql.ToString(), null).FirstOrDefault();
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public bool SendMaintenanceOrder(int orderID, int userID, int dispatch)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into eccm_receiver_user(order_id,uid_receiver,is_duty,receiver_type) ");
            strSql.AppendFormat(" values({0},{1},{2},{3}); ", orderID, userID, 1, 2);
            cmdlist.Add(strSql.ToString());

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" update eccm_maintenance_order set ");
            strSql2.AppendFormat(" uid_dispatch={0} ", dispatch);
            strSql2.AppendFormat(" ,order_stats={0} ", 1);
            strSql2.AppendFormat(" where order_id={0}; ", orderID);
            cmdlist.Add(strSql2.ToString());

            return MySQLHelper.ExecuteSqlByTran(cmdlist) > 0;
        }

        /// <summary>
        /// 获取用户维保订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetMaintenanceUserOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_maintenance_order o ");
            sqlCount.Append(" left join communityinfo c on c.communityID = o.community_id ");
            sqlCount.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sqlCount.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sqlCount.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sqlCount.Append(" LEFT JOIN eccm_receiver_user ru ON ru.order_id = o.order_id ");
            sqlCount.Append(" where o.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select o.order_id,plan_id,order_sn,order_type,unix_timestamp(order_time) as order_time,unix_timestamp(term_order) as term_order,unix_timestamp(order_finish_time) as order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3 ");
            sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" from eccm_maintenance_order o ");
            sql.Append(" left join communityinfo c on c.communityID = o.community_id ");
            sql.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sql.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sql.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sql.Append(" LEFT JOIN eccm_receiver_user ru ON ru.order_id = o.order_id ");
            sql.Append(" where o.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by order_stats,order_time desc ");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToDataTable(sql.ToString(), null);
        }
    }
}
