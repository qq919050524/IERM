using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using IERM.Common;
using IERM.Model;

namespace IERM.DAL
{
    /// <summary>
    /// 数据访问类:EccmInspectionOrderDAL
    /// </summary>
    public partial class EccmInspectionOrderDAL
    {
        public EccmInspectionOrderDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("order_id", "eccm_inspection_order");
        }

        /// <summary>
        /// 获取巡检工单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetInspectionOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_Inspection_order r ");
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
            sql.Append(" select order_id,plan_id,order_sn,order_type,unix_timestamp(order_time) as order_time,unix_timestamp(term_time) as term_time,unix_timestamp(order_finish_time) as order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3 ");
            sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" from eccm_Inspection_order r ");
            sql.Append(" left join communityinfo c on c.communityID = r.community_id ");
            sql.Append(" left join eccm_city_info city on city.areaID = c.pCityID ");
            sql.Append(" left join eccm_city_info area on city.pID = area.areaID ");
            sql.Append(" left join propertyinfo p on p.propertyID = c.propertyMId ");
            sql.Append(" where r.is_del=0 ");            
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }
            sql.Append(" order by order_time desc ");
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToDataTable(sql.ToString(), null);
        }


        /// <summary>
        /// 获取用户工单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetInspectionUserOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            StringBuilder sqlCount = new StringBuilder();
            sqlCount.Append(" select count(1) ");
            sqlCount.Append(" from eccm_Inspection_order r ");
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
            sql.Append(" select r.order_id,plan_id,order_sn,order_type,unix_timestamp(order_time) as order_time,unix_timestamp(term_time) as term_time,unix_timestamp(order_finish_time) as order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3 ");
            sql.Append(" ,c.communityName,city.areaName cityName,area.areaName,p.propertyName ");
            sql.Append(" from eccm_Inspection_order r ");
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
            sql.AppendFormat(" limit {0},{1} ", (pageindex - 1) * pagesize, pagesize);


            return MySQLHelper.ExecuteToDataTable(sql.ToString(), null);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int order_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eccm_inspection_order");
            strSql.Append(" where order_id=@order_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@order_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = order_id;

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(strSql.ToString(), parameters)) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmInspectionOrderModel model,string equCodes)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_inspection_order(");
            strSql.Append("order_sn,order_type,order_time,term_time,order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,uid)");
            strSql.Append(" values (");
            strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", model.order_sn, model.order_type, model.order_time, model.term_time, model.order_finish_time, model.community_id,model.order_stats, model.uid_dispatch, model.ext1, model.ext2, model.ext3, model.uid);
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("@order_sn", MySqlDbType.VarChar,32),
            //        new MySqlParameter("@order_type", MySqlDbType.Int32,11),
            //        new MySqlParameter("@order_time", MySqlDbType.DateTime),
            //        new MySqlParameter("@term_time", MySqlDbType.DateTime),
            //        new MySqlParameter("@order_finish_time", MySqlDbType.DateTime),
            //        new MySqlParameter("@community_id", MySqlDbType.Int32,11),
            //        new MySqlParameter("@order_stats", MySqlDbType.Int32,11),
            //        new MySqlParameter("@uid_dispatch", MySqlDbType.Int32,11),
            //        new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
            //        new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
            //        new MySqlParameter("@ext3", MySqlDbType.VarChar,50),
            //        new MySqlParameter("@uid", MySqlDbType.Int32)};
            //parameters[0].Value = model.order_sn;
            //parameters[1].Value = model.order_type;
            //parameters[2].Value = model.order_time;
            //parameters[3].Value = model.term_time;
            //parameters[4].Value = model.order_finish_time;
            //parameters[5].Value = model.community_id;
            //parameters[6].Value = model.order_stats;
            //parameters[7].Value = model.uid_dispatch;
            //parameters[8].Value = model.ext1;
            //parameters[9].Value = model.ext2;
            //parameters[10].Value = model.ext3;
            //parameters[11].Value = model.uid;
            cmdlist.Add(strSql.ToString());


            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" insert into eccm_order_device_standard(order_sn, equCode, device_standard, order_device_standard_type) ");
            strSql2.AppendFormat(" select '{0}',ei.equCode,s.inspection_standard,1 FROM equipmentinfo ei ", model.order_sn);
            strSql2.Append(" left join eccm_device_relation_standard drs ON ei.device_type_code = drs.device_type_code ");
            strSql2.Append(" left join eccm_standard s ON drs.standard_id = s.standard_id  and s.standard_type = 1 ");
            StringBuilder codes = new StringBuilder();
            foreach (string d in equCodes.Split(','))
            {
                codes.AppendFormat("'{0}',", d);
            }
            codes.Remove(codes.Length - 1, 1);
            strSql2.AppendFormat(" where ei.equCode in ({0}) ", codes);
            cmdlist.Add(strSql2.ToString());

            int rows =  MySQLHelper.ExecuteSqlByTran(cmdlist);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(EccmInspectionOrderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_inspection_order set ");
            strSql.Append("order_sn=@order_sn,");
            strSql.Append("order_type=@order_type,");
            strSql.Append("order_time=@order_time,");
            strSql.Append("term_time=@term_time,");
            strSql.Append("order_finish_time=@order_finish_time,");
            strSql.Append("community_id=@community_id,");
            strSql.Append("order_stats=@order_stats,");
            strSql.Append("uid_dispatch=@uid_dispatch,");
            strSql.Append("ext1=@ext1,");
            strSql.Append("ext2=@ext2,");
            strSql.Append("ext3=@ext3,");
            strSql.Append("uid=@uid");
            strSql.Append(" where order_id=@order_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@order_sn", MySqlDbType.VarChar,32),
                    new MySqlParameter("@order_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@order_time", MySqlDbType.DateTime),
                    new MySqlParameter("@term_time", MySqlDbType.DateTime),
                    new MySqlParameter("@order_finish_time", MySqlDbType.DateTime),
                    new MySqlParameter("@community_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@order_stats", MySqlDbType.Int32,11),
                    new MySqlParameter("@uid_dispatch", MySqlDbType.Int32,11),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,50),
                    new MySqlParameter("@uid", MySqlDbType.Int32),
                    new MySqlParameter("@order_id", MySqlDbType.Int32)};
            parameters[0].Value = model.order_sn;
            parameters[1].Value = model.order_type;
            parameters[2].Value = model.order_time;
            parameters[3].Value = model.term_time;
            parameters[4].Value = model.order_finish_time;
            parameters[5].Value = model.community_id;
            parameters[6].Value = model.order_stats;
            parameters[7].Value = model.uid_dispatch;
            parameters[8].Value = model.ext1;
            parameters[9].Value = model.ext2;
            parameters[10].Value = model.ext3;
            parameters[11].Value = model.uid;
            parameters[12].Value = model.order_id;

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
        public bool UpdateStates(EccmInspectionOrderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_inspection_order set ");
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
        /// 删除一条数据 逻辑删除
        /// </summary>
        public bool Delete(int order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update eccm_inspection_order set ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string order_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_inspection_order ");
            strSql.Append(" where order_id in (" + order_idlist + ")  ");
            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString());
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
        public EccmInspectionOrderModel GetModel(int order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select order_id,plan_id,order_sn,order_type,order_time,term_time,order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,i.uid,u.nickname as dispatchName");
            strSql.Append(" from eccm_inspection_order i ");
            strSql.Append(" left join userinfo u on uid_dispatch=u.uid ");
            strSql.AppendFormat(" where order_id={0} ", order_id);
            return DataRowToModel(MySQLHelper.ExecuteToDataTable(strSql.ToString()).Rows[0]);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmInspectionOrderModel DataRowToModel(DataRow row)
        {
            EccmInspectionOrderModel model = new EccmInspectionOrderModel();
            if (row != null)
            {
                if (row["order_id"] != null && row["order_id"].ToString() != "")
                {
                    model.order_id = int.Parse(row["order_id"].ToString());
                }
                if (row["plan_id"] != null && row["plan_id"].ToString() != "")
                {
                    model.plan_id = int.Parse(row["plan_id"].ToString());
                }
                if (row["order_sn"] != null)
                {
                    model.order_sn = row["order_sn"].ToString();
                }
                if (row["order_type"] != null && row["order_type"].ToString() != "")
                {
                    model.order_type = int.Parse(row["order_type"].ToString());
                }
                if (row["order_time"] != null && row["order_time"].ToString() != "")
                {
                    model.order_time = DateTime.Parse(row["order_time"].ToString());
                }
                if (row["term_time"] != null && row["term_time"].ToString() != "")
                {
                    model.term_time = DateTime.Parse(row["term_time"].ToString());
                }
                if (row["order_finish_time"] != null && row["order_finish_time"].ToString() != "" && row["order_finish_time"].ToString() != "0000/0/0 0:00:00")
                {
                    model.order_finish_time = DateTime.Parse(row["order_finish_time"].ToString());
                }
                if (row["community_id"] != null && row["community_id"].ToString() != "")
                {
                    model.community_id = int.Parse(row["community_id"].ToString());
                }
                if (row["order_stats"] != null && row["order_stats"].ToString() != "")
                {
                    model.order_stats = int.Parse(row["order_stats"].ToString());
                }
                if (row["uid_dispatch"] != null && row["uid_dispatch"].ToString() != "")
                {
                    model.uid_dispatch = int.Parse(row["uid_dispatch"].ToString());
                }
                if (row["ext1"] != null)
                {
                    model.ext1 = row["ext1"].ToString();
                }
                if (row["ext2"] != null)
                {
                    model.ext2 = row["ext2"].ToString();
                }
                if (row["ext3"] != null)
                {
                    model.ext3 = row["ext3"].ToString();
                }
                if (row["uid"] != null && row["uid"].ToString() != "")
                {
                    model.uid = int.Parse(row["uid"].ToString());
                }
                if (row["dispatchName"] != null && row["dispatchName"].ToString() != "")
                {
                    model.dispatchName = row["dispatchName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public DataTable GetList(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            StringBuilder strcmd = new StringBuilder("select order_id,plan_id,order_sn,order_type,order_time,term_time,order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,uid  from eccm_inspection_order ");
            string strqur = "select count(1) from eccm_inspection_order ";
            if (strWhere.Trim() != "")
            {
                strcmd.Append(" where " + strWhere);
                strqur = strqur + " where " + strWhere;
            }
            rowCount = Convert.ToInt32(MySQLHelper.ExecuteScalar(strqur, null));

            int startIndex = (pageIndex - 1) * pageSize;
            strcmd.AppendFormat(" LIMIT {0},{1}", startIndex, pageSize);
            return MySQLHelper.ExecuteToDataTable(strcmd.ToString(), null);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM eccm_inspection_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = MySQLHelper.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public bool SendInspectionOrder(int orderID, int userID, int dispatch)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into eccm_receiver_user(order_id,uid_receiver,is_duty,receiver_type) ");
            strSql.AppendFormat(" values({0},{1},{2},{3}); ", orderID, userID, 1, 1);
            cmdlist.Add(strSql.ToString());

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" update eccm_inspection_order set ");
            strSql2.AppendFormat(" uid_dispatch={0} ", dispatch);
            strSql2.AppendFormat(" ,order_stats={0} ", 1);
            strSql2.AppendFormat(" where order_id={0}; ", orderID);
            cmdlist.Add(strSql2.ToString());

            return MySQLHelper.ExecuteSqlByTran(cmdlist) > 0;
        }

        #endregion  BasicMethod
    }
}

