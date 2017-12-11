using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.DAL
{
    public class SendMessageElevatorDAL
    {
        /// <summary>
        /// 根据aid和registrationCode获取短信消息
        /// </summary>
        /// <param name="aID"></param>
        /// <param name="registrationCode"></param>
        /// <returns></returns>
        public Model.SendMessageElevatorModel getModel(int aID, string registrationCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select sendmsgID,aID,registrationCode,errorCodeType,customCode,content,mobile,sendResult,createTime  ");
            sql.Append(" from eccm_sendmessageelevator ");
            sql.Append(" where aID=@aID and  registrationCode=@registrationCode ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@aID", aID),
                    new MySqlParameter("@registrationCode", registrationCode)
            };
            return MySQLHelper.ExecuteToList<Model.SendMessageElevatorModel>(sql.ToString(), parameters).FirstOrDefault();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool Add(Model.SendMessageElevatorModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_sendmessageelevator(");
            strSql.Append("aID,registrationCode,errorCodeType,customCode,content,mobile,sendResult,createTime)");
            strSql.Append(" values (");
            strSql.Append("@aID,@registrationCode,@errorCodeType,@customCode,@content,@mobile,@sendResult,@createTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@aID", model.aID),
                    new MySqlParameter("@registrationCode", model.registrationCode),
                    new MySqlParameter("@errorCodeType", model.errorCodeType),
                    new MySqlParameter("@customCode", model.customCode),
                    new MySqlParameter("@content", model.content),
                    new MySqlParameter("@mobile", model.mobile),
                    new MySqlParameter("@sendResult", model.sendResult),
                    new MySqlParameter("@createTime", model.createTime),
            };

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
    }
}
