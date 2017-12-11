using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class DrawerStateDAL
    {
        /// <summary>
		/// 增加一条数据,返回主键
		/// </summary>
		public int Add(MODEL.DrawerStateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into drawerstate(");
            strSql.Append("f1,f2,f3,f4,f5,f6,f7,f8,f9,f10,f11,f12,f13,f14,f15,f16)");
            strSql.Append(" values (");
            strSql.Append("@f1,@f2,@f3,@f4,@f5,@f6,@f7,@f8,@f9,@f10,@f11,@f12,@f13,@f14,@f15,@f16);");
            strSql.Append(" select last_insert_id() as insertId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@f1", MySqlDbType.Bit),
                    new MySqlParameter("@f2", MySqlDbType.Bit),
                    new MySqlParameter("@f3", MySqlDbType.Bit),
                    new MySqlParameter("@f4", MySqlDbType.Bit),
                    new MySqlParameter("@f5", MySqlDbType.Bit),
                    new MySqlParameter("@f6", MySqlDbType.Bit),
                    new MySqlParameter("@f7", MySqlDbType.Bit),
                    new MySqlParameter("@f8", MySqlDbType.Bit),
                    new MySqlParameter("@f9", MySqlDbType.Bit),
                    new MySqlParameter("@f10", MySqlDbType.Bit),
                    new MySqlParameter("@f11", MySqlDbType.Bit),
                    new MySqlParameter("@f12", MySqlDbType.Bit),
                    new MySqlParameter("@f13", MySqlDbType.Bit),
                    new MySqlParameter("@f14", MySqlDbType.Bit),
                    new MySqlParameter("@f15", MySqlDbType.Bit),
                    new MySqlParameter("@f16", MySqlDbType.Bit)};
            parameters[0].Value = model.f1;
            parameters[1].Value = model.f2;
            parameters[2].Value = model.f3;
            parameters[3].Value = model.f4;
            parameters[4].Value = model.f5;
            parameters[5].Value = model.f6;
            parameters[6].Value = model.f7;
            parameters[7].Value = model.f8;
            parameters[8].Value = model.f9;
            parameters[9].Value = model.f10;
            parameters[10].Value = model.f11;
            parameters[11].Value = model.f12;
            parameters[12].Value = model.f13;
            parameters[13].Value = model.f14;
            parameters[14].Value = model.f15;
            parameters[15].Value = model.f16;

            return Convert.ToInt32(Common.MySQLHelper.ExecuteScalar(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 序列化字符串输出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Serializer(MODEL.DrawerStateModel model)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}", model.f1, model.f2, model.f3, model.f4, model.f5, model.f6, model.f7, model.f8, model.f9, model.f10, model.f11, model.f12, model.f13, model.f14, model.f15, model.f16);
        }
    }
}
