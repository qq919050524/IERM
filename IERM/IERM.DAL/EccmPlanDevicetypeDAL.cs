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
    /// 数据访问类:EccmPlanDevicetypeDAL
    /// </summary>
    public partial class EccmPlanDevicetypeDAL
    {
        public EccmPlanDevicetypeDAL()
        { }
        #region  BasicMethod     

        /// <summary>
        /// 增加设备类型数据
        /// </summary>
        public bool Add(EccmPlanDevicetypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into eccm_plan_devicetype(plan_id, system_type_code, community_id) values ");
            foreach (string s in model.system_type_code.Split(','))
            {
                strSql.Append("(" + model.plan_id + ",'" + s + "'," + model.community_id + "),");
            }
            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString().Substring(0, strSql.Length - 1));
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
        /// 根据条件获取设备类型
        /// </summary>
        public DataTable GetList(int plan_id)
        {
            StringBuilder strcmd = new StringBuilder("select * from eccm_plan_devicetype ");
            strcmd.AppendFormat(" where plan_id={0}", plan_id);
            return MySQLHelper.ExecuteToDataTable(strcmd.ToString(), null);
        }

        /// <summary>
        /// 根据计划id删除关联的设备类型
        /// </summary>
        public bool delete(int plan_id)
        {
            StringBuilder strcmd = new StringBuilder("delete from eccm_plan_devicetype ");
            strcmd.AppendFormat(" where plan_id={0}", plan_id);
            int row= MySQLHelper.ExecuteNonQuery(strcmd.ToString(), null);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod
    }
}

