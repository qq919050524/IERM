using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class AlarmElevatorDAL
    {
        /// <summary>
        /// 添加一条电梯报警记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MODEL.AlarmElevatorModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into alarmelevator(registrationCode,errorCodeType,errorCodeMean,customCode,alarmState,insertTime) ");
            strSql.Append(" value(@registrationCode,@errorCodeType,@errorCodeMean,@customCode,@alarmState,@insertTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@registrationCode", model.registrationCode),
                    new MySqlParameter("@errorCodeType", model.errorCodeType),
                    new MySqlParameter("@errorCodeMean", model.errorCodeMean),
                    new MySqlParameter("@customCode", model.customCode),
                    new MySqlParameter("@alarmState", model.alarmState),
                    new MySqlParameter("@insertTime", model.insertTime),
            };

            return Common.MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }


        /// <summary>
        /// 根据registrationCode和customCode 查询最新报警
        /// </summary>
        /// <param name="registrationCode"></param>
        /// <param name="customCode"></param>
        /// <returns></returns>
        public MODEL.AlarmElevatorModel GetLatestEvent(string registrationCode, string customCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select aID, registrationCode, errorCodeType, errorCodeMean, customCode, alarmState, insertTime ");
            strSql.Append(" from alarmelevator ");
            strSql.Append(" where registrationCode=@registrationCode and  customCode=@customCode ");
            strSql.Append(" order by insertTime desc ");
            strSql.Append(" limit 0,1 ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@registrationCode", registrationCode),
                    new MySqlParameter("@customCode", customCode),
            };

            return Common.MySQLHelper.ExecuteToList<MODEL.AlarmElevatorModel>(strSql.ToString(), parameters).FirstOrDefault();
        }
    }
}
