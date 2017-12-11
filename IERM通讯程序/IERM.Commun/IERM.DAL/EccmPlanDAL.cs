using IERM.Common;
using IERM.MODEL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EccmPlanDAL
    {
        /// <summary>
        /// 获取计划列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmPlanModel> GetPlanList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select * from eccm_plan p");
            sql.Append(" WHERE p.plan_stime<='" + DateTime.Now.ToShortDateString() + "' AND p.is_delete=0 AND p.plan_stats=1 AND ( p.plan_etime>='" + DateTime.Now.ToShortDateString() + "' OR p.plan_etime IS NULL)");

            DataTable dt = MySQLHelper.ExecuteToDataTable(sql.ToString(), null);

            List<EccmPlanModel> list = new List<EccmPlanModel>();
            foreach (DataRow row in dt.Rows)
            {
                EccmPlanModel model = DataRowToModel(row);
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 根据计划id获取设备
        /// </summary>" ", 
        /// <param name="plan_id">计划id</param>
        /// <param name="choose_type">0设备类型，1设备</param>
        /// <returns></returns>
        public DataTable GetPlanDeviceCode(int plan_id,int choose_type)
        {
            StringBuilder sql = new StringBuilder();
            if (choose_type == 0)
            {
                sql.Append(" SELECT e.equCode FROM equipmentinfo e");
                sql.Append(" LEFT JOIN eccm_plan_devicetype epd ON epd.system_type_code = e.device_type_code");
                sql.AppendFormat(" WHERE epd.plan_id = {0}", plan_id);
            }
            else if (choose_type == 1)
            {
                sql.AppendFormat("SELECT equCode FROM eccm_plan_device a where a.plan_id={0}",plan_id);
            }           
            DataTable dt = MySQLHelper.ExecuteToDataTable(sql.ToString(), null);
            return dt;
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EccmPlanModel DataRowToModel(DataRow row)
        {
            EccmPlanModel model = new EccmPlanModel();
            if (row != null)
            {
                if (row["plan_id"] != null && row["plan_id"].ToString() != "")
                {
                    model.plan_id = int.Parse(row["plan_id"].ToString());
                }
                if (row["plan_cycle"] != null && row["plan_cycle"].ToString() != "")
                {
                    model.plan_cycle = int.Parse(row["plan_cycle"].ToString());
                }
                if (row["plan_role"] != null)
                {
                    model.plan_role = row["plan_role"].ToString();
                }
                if (row["execution_frequency"] != null && row["execution_frequency"].ToString() != "")
                {
                    model.execution_frequency = int.Parse(row["execution_frequency"].ToString());
                }
                if (row["execution_time"] != null && row["execution_time"].ToString() != "")
                {
                    model.execution_time = DateTime.Parse(row["execution_time"].ToString());
                }
                if (row["plan_build_time"] != null && row["plan_build_time"].ToString() != "")
                {
                    model.plan_build_time = DateTime.Parse(row["plan_build_time"].ToString());
                }
                if (row["plan_stime"] != null && row["plan_stime"].ToString() != "")
                {
                    model.plan_stime = DateTime.Parse(row["plan_stime"].ToString());
                }
                if (row["plan_etime"] != null && row["plan_etime"].ToString() != "")
                {
                    model.plan_etime = DateTime.Parse(row["plan_etime"].ToString());
                }
                if (row["term_day"] != null && row["term_day"].ToString() != "")
                {
                    model.term_day = int.Parse(row["term_day"].ToString());
                }
                if (row["uid"] != null && row["uid"].ToString() != "")
                {
                    model.uid = int.Parse(row["uid"].ToString());
                }
                if (row["plan_creat_time"] != null && row["plan_creat_time"].ToString() != "")
                {
                    model.plan_creat_time = DateTime.Parse(row["plan_creat_time"].ToString());
                }
                if (row["plan_stats"] != null && row["plan_stats"].ToString() != "")
                {
                    model.plan_stats = int.Parse(row["plan_stats"].ToString());
                }
                if (row["plan_type"] != null && row["plan_type"].ToString() != "")
                {
                    model.plan_type = int.Parse(row["plan_type"].ToString());
                }
                if (row["choose_type"] != null && row["choose_type"].ToString() != "")
                {
                    model.choose_type = int.Parse(row["choose_type"].ToString());
                }
                if (row["is_delete"] != null && row["is_delete"].ToString() != "")
                {
                    model.is_delete = int.Parse(row["is_delete"].ToString());
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
                if (row["communityID"] != null && row["communityID"].ToString() != "")
                {
                    model.communityID = int.Parse(row["communityID"].ToString());
                }
            }
            return model;
        }
    }
}
