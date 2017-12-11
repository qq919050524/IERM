using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public partial class UserLogDAL
    {
        /// <summary>
        /// 获取用户日志
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<UserLogModel> GetUserLog(string strWhere, int pageindex, int pagesize)
        {
            return MySQLHelper.ExecuteToList<UserLogModel>(string.Format(""));
        }

        /// <summary>
        /// 增加一条日志
        /// </summary>
        /// <param name="maincmdstr"></param>
        /// <param name="subcmdlist"></param>
        /// <returns></returns>
        //public int Add(MODEL.userLog model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into userLog(");
        //    strSql.Append("userID,operationName,operationTime,isDel,propertyName)");
        //    strSql.Append("values(");
        //    strSql.Append("@userID,@operationName,@operationTime,isDel,propertyName)");
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter("@userID",MySqlDbType.Int32,10),
        //        new MySqlParameter("@operationName",MySqlDbType.String,20),
        //        new MySqlParameter("@operationTime",MySqlDbType.DateTime),
        //        new MySqlParameter("@isDel",MySqlDbType.Bit) ,
        //        new MySqlParameter("@propertyName", MySqlDbType.VarChar, 20)};
        //    parameters[0].Value = model.userID;
        //    parameters[1].Value = model.OperationName;
        //    parameters[2].Value = model.OperationTime;
        //    parameters[3].Value = model.IsDel;
        //    parameters[4].Value = model.PropertyName;
        //    return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        //}
        public int Add(UserLogModel model)
        {
            //string strsql = @"INSERT INTO userLog(userID,operationName,operationTime,isDel,propertyName)VALUES(" + model.userID + ","
            //   + model.OperationName + "," + model.OperationTime + "," + model.IsDel + "," + model.PropertyName + ")";
            return MySQLHelper.ExecuteNonQuery(string.Format("insert into userLog(userID,operationName,operationTime,isDel,propertyName,pid) values ({0},'{1}','{2}',{3},'{4}','{5}')",model.userID, model.OperationName, model.OperationTime, model.IsDel, model.PropertyName,model.Pid));
        }
    }
}
