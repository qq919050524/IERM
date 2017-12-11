
using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class CityInfoDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CityInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_city_info(");
            strSql.Append("areaName,pID,isDel,sort)");
            strSql.Append(" values (");
            strSql.Append("@areaName,@pID,@isDel,@sort)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@areaName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@pID", MySqlDbType.Int32,10),
                    new MySqlParameter("@isDel", MySqlDbType.Bit),
                    new MySqlParameter("@sort", MySqlDbType.Int32,10)};
            parameters[0].Value = model.areaName;
            parameters[1].Value = model.pID;
            parameters[2].Value = model.isDel;
            parameters[3].Value = model.sort;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CityInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_city_info set ");
            strSql.Append("areaName=@areaName,");
            strSql.Append("pID=@pID,");
            strSql.Append("isDel=@isDel,");
            strSql.Append("sort=@sort");
            strSql.Append(" where areaID=@areaID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@areaName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@pID", MySqlDbType.Int32,10),
                    new MySqlParameter("@isDel", MySqlDbType.Bit),
                    new MySqlParameter("@sort", MySqlDbType.Int32,10),
                    new MySqlParameter("@areaID", MySqlDbType.Int32,10)};
            parameters[0].Value = model.areaName;
            parameters[1].Value = model.pID;
            parameters[2].Value = model.isDel;
            parameters[3].Value = model.sort;
            parameters[4].Value = model.areaID;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int areaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_city_info ");
            strSql.Append(" where areaID=@areaID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@areaID", MySqlDbType.Int32)
            };
            parameters[0].Value = areaID;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CityInfoModel GetModel(int areaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select areaID,areaName,pID,isDel,sort from eccm_city_info ");
            strSql.Append(" where areaID=@areaID");
            strSql.Append(" order by sort ase ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@areaID", MySqlDbType.Int32)
            };
            parameters[0].Value = areaID;

            return MySQLHelper.ExecuteToList<CityInfoModel>(strSql.ToString(), parameters).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有激活的城市信息
        /// </summary>
        /// <returns></returns>
        public List<CityInfoModel> GetAllCity()
        {
            return MySQLHelper.ExecuteToList<CityInfoModel>("select * from eccm_city_info where isDel=0", null);
        }
    }
}
