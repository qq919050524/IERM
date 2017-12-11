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
    public class SendMessageDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sendmsgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eccm_sendmessage");
            strSql.Append(" where sendmsgID=@sendmsgID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@sendmsgID", MySqlDbType.Int32)
            };
            parameters[0].Value = sendmsgID;

            object obj = MySQLHelper.ExecuteScalar(strSql.ToString(), parameters);
            if (obj != null && Convert.ToInt32(obj) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SendMessageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_sendmessage(");
            strSql.Append("devID,alarmCode,mobile,content,alarmState,createTime,sendResult)");
            strSql.Append(" values (");
            strSql.Append("@devID,@alarmCode,@mobile,@content,@alarmState,@createTime,@sendResult)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devID", MySqlDbType.Int32,11),
                    new MySqlParameter("@alarmCode", MySqlDbType.VarChar,50),
                    new MySqlParameter("@mobile", MySqlDbType.VarChar,11),
                    new MySqlParameter("@content", MySqlDbType.VarChar,500),
                    new MySqlParameter("@alarmState", MySqlDbType.Int32,2),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@sendResult", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.devID;
            parameters[1].Value = model.alarmCode;
            parameters[2].Value = model.mobile;
            parameters[3].Value = model.content;
            parameters[4].Value = model.alarmState;
            parameters[5].Value = model.createTime;
            parameters[6].Value = model.sendResult;

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
        public bool Update(SendMessageModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_sendmessage set ");
            strSql.Append("devID=@devID,");
            strSql.Append("alarmCode=@alarmCode,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("content=@content,");
            strSql.Append("alarmState=@alarmState,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("sendResult=@sendResult");
            strSql.Append(" where sendmsgID=@sendmsgID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devID", MySqlDbType.Int32,11),
                    new MySqlParameter("@alarmCode", MySqlDbType.VarChar,50),
                    new MySqlParameter("@mobile", MySqlDbType.VarChar,11),
                    new MySqlParameter("@content", MySqlDbType.VarChar,500),
                    new MySqlParameter("@alarmState", MySqlDbType.Int32,2),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@sendResult", MySqlDbType.VarChar,100),
                    new MySqlParameter("@sendmsgID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.devID;
            parameters[1].Value = model.alarmCode;
            parameters[2].Value = model.mobile;
            parameters[3].Value = model.content;
            parameters[4].Value = model.alarmState;
            parameters[5].Value = model.createTime;
            parameters[6].Value = model.sendResult;
            parameters[7].Value = model.sendmsgID;

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
        /// 更改发送状态为正常
        /// </summary>
        public bool UpdateStatus(string alarmCode, string devID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("alarmState=1");
            strSql.Append(" where alarmState<>1 ");
            strSql.Append(" devID=@devID ");
            strSql.Append(" and  alarmCode=@alarmCode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devID", MySqlDbType.Int32,11),
                    new MySqlParameter("@alarmCode", MySqlDbType.VarChar,50),
                 };
            parameters[0].Value = devID;
            parameters[1].Value = alarmCode;

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
        public bool Delete(int sendmsgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_sendmessage ");
            strSql.Append(" where sendmsgID=@sendmsgID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@sendmsgID", MySqlDbType.Int32)
            };
            parameters[0].Value = sendmsgID;

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
        public bool DeleteList(string sendmsgIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_sendmessage ");
            strSql.Append(" where sendmsgID in (" + sendmsgIDlist + ")  ");
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
        public SendMessageModel GetModel(int sendmsgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sendmsgID,devID,alarmCode,mobile,content,alarmState,createTime,sendResult from eccm_sendmessage ");
            strSql.Append(" where sendmsgID=@sendmsgID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@sendmsgID", MySqlDbType.Int32)
            };
            parameters[0].Value = sendmsgID;

            SendMessageModel model = new SendMessageModel();
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
        public SendMessageModel DataRowToModel(DataRow row)
        {
            SendMessageModel model = new SendMessageModel();
            if (row != null)
            {
                if (row["sendmsgID"] != null && row["sendmsgID"].ToString() != "")
                {
                    model.sendmsgID = int.Parse(row["sendmsgID"].ToString());
                }
                if (row["devID"] != null && row["devID"].ToString() != "")
                {
                    model.devID = int.Parse(row["devID"].ToString());
                }
                if (row["alarmCode"] != null && row["alarmCode"].ToString() != "")
                {
                    model.alarmCode = row["alarmCode"].ToString();
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["alarmState"] != null && row["alarmState"].ToString() != "")
                {
                    model.alarmState = int.Parse(row["alarmState"].ToString());
                }
                if (row["createTime"] != null && row["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(row["createTime"].ToString());
                }
                if (row["sendResult"] != null)
                {
                    model.sendResult = row["sendResult"].ToString();
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
            strSql.Append("select sendmsgID,devID,alarmCode,mobile,content,alarmState,createTime,sendResult ");
            strSql.Append(" FROM eccm_sendmessage ");
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
            strSql.Append("select count(1) FROM eccm_sendmessage ");
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
                strSql.Append("order by T.sendmsgID desc");
            }
            strSql.Append(")AS Row, T.*  from eccm_sendmessage T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.ExecuteToDataTable(strSql.ToString());
        }


        #endregion  BasicMethod
    }
}
