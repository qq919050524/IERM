using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EccmRepairOrderDAL
    {
        /// <summary>
        /// 获取报修订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmRepairOrderModel> GetRepairOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_repair_order r ");
            sqlCount.Append(" left join communityinfo c on c.communityID = r.community_id ");
            sqlCount.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sqlCount.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sqlCount.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sqlCount.Append(" where r.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select order_id,order_sn,r_reason,r_stime,uid,community_id,r_state,uid_dispatch,r_etime,term_time,is_del,ext1,ext2,ext3 ");
            sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" from eccm_repair_order r ");
            sql.Append(" left join communityinfo c on c.communityID = r.community_id ");
            sql.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sql.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sql.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sql.Append(" where r.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by r_state,r_stime desc ");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<EccmRepairOrderModel>(sql.ToString(), null);
        }

        /// <summary>
        /// 新增报修工单
        /// </summary>
        /// <param name="orderSn">订单号</param>
        /// <param name="equCodes">设备code 多个，号分割</param>
        /// <param name="communityID">小区id</param>
        /// <param name="reason">原因</param>
        /// <param name="termtime">期限时间</param>
        /// <param name="uid">创建人</param>
        /// <returns></returns>
        public bool AddRepairOrder(string orderSn, string equCodes, int communityID, string reason, DateTime termtime, int uid)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into eccm_repair_order(order_sn,r_reason,r_stime,term_time,uid,community_id,r_state) ");
            strSql.AppendFormat(" values('{0}','{1}','{2}','{3}',{4},{5},{6}); ", orderSn, reason, DateTime.Now, termtime, uid, communityID, 0);
            cmdlist.Add(strSql.ToString());

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" insert into eccm_order_device_standard(order_sn, equCode, device_standard, order_device_standard_type) ");
            strSql2.AppendFormat(" select '{0}',ei.equCode,s.inspection_standard,3 FROM equipmentinfo ei ", orderSn);
            strSql2.Append(" left join eccm_device_relation_standard drs ON ei.device_type_code = drs.device_type_code ");
            strSql2.Append(" left join eccm_standard s ON drs.standard_id = s.standard_id  and s.standard_type = 3 ");
            StringBuilder codes = new StringBuilder();
            foreach (string d in equCodes.Split(','))
            {
                codes.AppendFormat("'{0}',", d);
            }
            codes.Remove(codes.Length - 1, 1);
            strSql2.AppendFormat(" where ei.equCode in ({0}) ", codes);
            cmdlist.Add(strSql2.ToString());

            return MySQLHelper.ExecuteSqlByTran(cmdlist) > 0;
        }

        /// <summary>
        /// 删除，假删除
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool DeleteRepairOrder(int orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update eccm_repair_order set ");
            strSql.Append(" is_del=@isDel ");
            strSql.Append(" where order_id=@orderID; ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@isDel", 1),
                    new MySqlParameter("@orderID", orderID)
            };

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public bool SendRepairOrder(int orderID, int userID, int dispatch)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into eccm_receiver_user(order_id,uid_receiver,is_duty,receiver_type) ");
            strSql.AppendFormat(" values({0},{1},{2},{3}); ", orderID, userID, 1, 3);
            cmdlist.Add(strSql.ToString());

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" update eccm_repair_order set ");
            strSql2.AppendFormat(" uid_dispatch={0} ", dispatch);
            strSql2.AppendFormat(" ,r_state={0} ", 1);
            strSql2.AppendFormat(" where order_id={0}; ", orderID);
            cmdlist.Add(strSql2.ToString());

            return MySQLHelper.ExecuteSqlByTran(cmdlist) > 0;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public EccmRepairOrderModel GetRepairOrderDetail(int orderID)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" select order_id,order_sn,r_reason,r_stime,r.uid,community_id,r_state,uid_dispatch,r_etime,term_time,is_del,ext1,ext2,ext3 ");
            //sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" ,u.nickname dispatchName ");
            sql.Append(" from eccm_repair_order r ");
            //sql.Append(" left join communityinfo c on c.communityID = r.community_id ");
            //sql.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            //sql.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            //sql.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sql.Append(" left join userinfo u on r.uid_dispatch=u.uid ");
            sql.Append(" where r.order_id=@orderID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@orderID", orderID),
            };

            return MySQLHelper.ExecuteToList<EccmRepairOrderModel>(sql.ToString(), parameters).FirstOrDefault();
        }

        /// <summary>
        /// 更新改订单状态
        /// </summary>
        public bool UpdateStates(EccmRepairOrderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_repair_order set ");
            strSql.Append("r_state=@r_state,");
            strSql.Append("r_etime=@r_etime");
            strSql.Append(" where order_id=@order_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@r_state", MySqlDbType.Int32,11),
                    new MySqlParameter("@r_etime", MySqlDbType.DateTime),
                    new MySqlParameter("@order_id", MySqlDbType.Int32)};
            parameters[0].Value = model.r_state;
            parameters[1].Value = model.r_etime;
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
        /// 获取用户报修订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmRepairOrderModel> GetRepairUserOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_repair_order r ");
            sqlCount.Append(" left join communityinfo c on c.communityID = r.community_id ");
            sqlCount.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sqlCount.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sqlCount.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sqlCount.Append(" LEFT JOIN eccm_receiver_user ru ON ru.order_id = r.order_id ");
            sqlCount.Append(" where r.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlCount.AppendFormat(" and {0} ", strWhere);
            }
            count = Convert.ToInt32(MySQLHelper.ExecuteScalar(sqlCount.ToString(), null));

            StringBuilder sql = new StringBuilder();
            sql.Append(" select r.order_id,order_sn,r_reason,r_stime,uid,community_id,r_state,uid_dispatch,r_etime,term_time,is_del,ext1,ext2,ext3 ");
            sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" from eccm_repair_order r ");
            sql.Append(" left join communityinfo c on c.communityID = r.community_id ");
            sql.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sql.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sql.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sql.Append(" LEFT JOIN eccm_receiver_user ru ON ru.order_id = r.order_id ");
            sql.Append(" where r.is_del=0 ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by r_state,r_stime desc ");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToList<EccmRepairOrderModel>(sql.ToString(), null);
        }
    }
}
