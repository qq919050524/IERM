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
    public class MainTenanceLogDAL
    {
        /// <summary>
        /// 获取工单列表
        /// </summary>
        /// <param name="communityid"></param>
        /// <param name="devhouseid"></param>
        /// <param name="ordertype"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public List<MainTenanceLogModel> GetMaintenanceLog(int communityid, int devhouseid, int ordertype, DateTime begintime, DateTime endtime, int pagesize, int pageindex, out int rowcount)
        {
            StringBuilder cmdstr = new StringBuilder();

            if (devhouseid == 0)
            {
                cmdstr.AppendFormat("SELECT count(1) FROM maintenancelog as ml INNER JOIN devinfo as di on di.devID = ml.devhouseID where di.communityID={0}", communityid);
            }
            else
            {
                cmdstr.AppendFormat("SELECT count(1) FROM maintenancelog as ml where ml.devhouseID={0} ", devhouseid);
            }
            if (ordertype != 0)
            {
                cmdstr.AppendFormat(" and orderType={0} ", ordertype);
            }
            cmdstr.AppendFormat(" and ml.createTime>='{0}' and ml.createTime<='{1}'", begintime, endtime);

            rowcount = Convert.ToInt32(MySQLHelper.ExecuteScalar(cmdstr.ToString(), null));

            cmdstr.AppendFormat(" order by ml.createTime desc limit {0},{1}", (pageindex - 1) * pagesize, pagesize);
            var tttt = cmdstr.ToString().Replace("count(1)", "ml.*");
            var ttt = MySQLHelper.ExecuteToList<MainTenanceLogModel>(cmdstr.ToString().Replace("count(1)", "ml.*"), null);
            return MySQLHelper.ExecuteToList<MainTenanceLogModel>(cmdstr.ToString().Replace("count(1)", "ml.*"), null);
        }





        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MainTenanceLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into maintenancelog(");
            strSql.Append("settingID,devhouseID,orderCode,orderContent,orderType,createTime,operateTime,status,remark)");
            strSql.Append(" values (");
            strSql.Append("@settingID,@devhouseID,@orderCode,@orderContent,@orderType,@createTime,@operateTime,@status,@remark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@settingID", MySqlDbType.Int32,10),
                    new MySqlParameter("@devhouseID", MySqlDbType.Int32,10),
                    new MySqlParameter("@orderCode", MySqlDbType.VarChar,18),
                    new MySqlParameter("@orderContent", MySqlDbType.VarChar,500),
                    new MySqlParameter("@orderType", MySqlDbType.Int32,4),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@operateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@status", MySqlDbType.Int32,4),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.settingID;
            parameters[1].Value = model.devhouseID;
            parameters[2].Value = model.orderCode;
            parameters[3].Value = model.orderContent;
            parameters[4].Value = model.orderType;
            parameters[5].Value = model.createTime;
            parameters[6].Value = model.operateTime;
            parameters[7].Value = model.status;
            parameters[8].Value = model.remark;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(MainTenanceLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update maintenancelog set ");
            strSql.Append("settingID=@settingID,");
            strSql.Append("devhouseID=@devhouseID,");
            strSql.Append("orderCode=@orderCode,");
            strSql.Append("orderContent=@orderContent,");
            strSql.Append("orderType=@orderType,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("operateTime=@operateTime,");
            strSql.Append("status=@status,");
            strSql.Append("remark=@remark");
            strSql.Append(" where mID=@mID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@settingID", MySqlDbType.Int32,10),
                    new MySqlParameter("@devhouseID", MySqlDbType.Int32,10),
                    new MySqlParameter("@orderCode", MySqlDbType.VarChar,18),
                    new MySqlParameter("@orderContent", MySqlDbType.VarChar,500),
                    new MySqlParameter("@orderType", MySqlDbType.Int32,4),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@operateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@status", MySqlDbType.Int32,4),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,50),
                    new MySqlParameter("@mID", MySqlDbType.Int32,10)};
            parameters[0].Value = model.settingID;
            parameters[1].Value = model.devhouseID;
            parameters[2].Value = model.orderCode;
            parameters[3].Value = model.orderContent;
            parameters[4].Value = model.orderType;
            parameters[5].Value = model.createTime;
            parameters[6].Value = model.operateTime;
            parameters[7].Value = model.status;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.mID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int mID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from maintenancelog ");
            strSql.Append(" where mID=@mID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@mID", MySqlDbType.Int32)
            };
            parameters[0].Value = mID;

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
        public bool DeleteList(string mIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from maintenancelog ");
            strSql.Append(" where mID in (" + mIDlist + ")  ");
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
        public MainTenanceLogModel GetModel(int mID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mID,settingID,devhouseID,orderCode,orderContent,orderType,createTime,operateTime,status,remark from maintenancelog ");
            strSql.Append(" where mID=@mID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@mID", MySqlDbType.Int32)
            };
            parameters[0].Value = mID;

            MainTenanceLogModel model = new MainTenanceLogModel();
            DataTable dt = MySQLHelper.ExecuteToDataTable(strSql.ToString(), parameters);
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
        public MainTenanceLogModel DataRowToModel(DataRow row)
        {
            MainTenanceLogModel model = new MainTenanceLogModel();
            if (row != null)
            {
                if (row["mID"] != null && row["mID"].ToString() != "")
                {
                    model.mID = int.Parse(row["mID"].ToString());
                }
                if (row["settingID"] != null && row["settingID"].ToString() != "")
                {
                    model.settingID = int.Parse(row["settingID"].ToString());
                }
                if (row["devhouseID"] != null && row["devhouseID"].ToString() != "")
                {
                    model.devhouseID = int.Parse(row["devhouseID"].ToString());
                }
                if (row["orderCode"] != null)
                {
                    model.orderCode = row["orderCode"].ToString();
                }
                if (row["orderContent"] != null)
                {
                    model.orderContent = row["orderContent"].ToString();
                }
                if (row["orderType"] != null && row["orderType"].ToString() != "")
                {
                    model.orderType = int.Parse(row["orderType"].ToString());
                }
                if (row["createTime"] != null && row["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(row["createTime"].ToString());
                }
                if (row["operateTime"] != null && row["operateTime"].ToString() != "")
                {
                    model.operateTime = DateTime.Parse(row["operateTime"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mID,settingID,devhouseID,orderCode,orderContent,orderType,createTime,operateTime,status,remark ");
            strSql.Append(" FROM maintenancelog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySQLHelper.ExecuteToDataTable(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM maintenancelog ");
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
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.mID desc");
            }
            strSql.Append(")AS Row, T.*  from maintenancelog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.ExecuteToDataTable(strSql.ToString());
        }



    }
}
