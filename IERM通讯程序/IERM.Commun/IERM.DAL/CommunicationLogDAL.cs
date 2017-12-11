using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class CommunicationLogDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MODEL.CommunicationLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into communicationlog(");
            strSql.Append("dataSize,data,InsertTime)");
            strSql.Append(" values (");
            strSql.Append("@dataSize,@data,@InsertTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@dataSize", MySqlDbType.Int32,10),
                    new MySqlParameter("@data", MySqlDbType.VarBinary),
                    new MySqlParameter("@InsertTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.dataSize;
            parameters[1].Value = model.data;
            parameters[2].Value = model.InsertTime;

            return Common.MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0 ? true : false;

        }

        /// <summary>
        /// 获取错误通讯日志
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<MODEL.CommunicationLogModel> GetCommLog(string strWhere)
        {
            return Common.MySQLHelper.ExecuteToList<MODEL.CommunicationLogModel>(string.Format("select * from communicationlog {0}", strWhere));
        }
    }
}
