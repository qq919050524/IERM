using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IERM.Common;
using IERM.MODEL;
using System.Linq;
using System.Collections.Generic;

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
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmInspectionOrderModel model, string equCodes)
        {
            List<string> cmdlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_inspection_order(");
            strSql.Append("order_sn,order_type,order_time,term_time,order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,uid,plan_id)");
            strSql.Append(" values (");
            strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", model.order_sn, model.order_type, model.order_time, model.term_time, model.order_finish_time, model.community_id, model.order_stats, model.uid_dispatch, model.ext1, model.ext2, model.ext3, model.uid,model.plan_id);
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

            int rows = Common.MySQLHelper.ExecuteSqlByTran(cmdlist);
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
        /// 根据计划得到一个对象实体
        /// </summary>
        public EccmInspectionOrderModel GetModel(int plan_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select order_id,plan_id,order_sn,order_type,order_time,term_time,order_finish_time,community_id,order_stats,uid_dispatch,ext1,ext2,ext3,i.uid,u.nickname as dispatchName");
            strSql.Append(" from eccm_inspection_order i ");
            strSql.Append(" left join userinfo u on uid_dispatch=u.uid ");
            strSql.AppendFormat(" where plan_id={0} ", plan_id);
            strSql.Append(" order by order_time desc ");
            strSql.Append(" limit 1 ");
            DataTable dt = MySQLHelper.ExecuteToDataTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
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
        #endregion  BasicMethod
    }
}

