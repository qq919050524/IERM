using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    /// <summary>
	/// 小区信息
	/// </summary>
    public partial class CommunityInfoDAL
    {
        public CommunityInfoDAL()
        { }

        /// <summary>
        /// 获取所有小区  TODO
        /// </summary>
        /// <returns></returns>
        public List<CommunityInfoModel> GetAllCommunity(int pageindex, int pagesize, out int dataCount)
        {
            //获取数据总数 
            dataCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) FROM view_communityinfo where isDel=0  ", null));
            return MySQLHelper.ExecuteToList<CommunityInfoModel>(string.Format(
                @"SELECT * FROM view_communityinfo a LEFT JOIN  propertyinfo b ON a.propertyMId=b.propertyID  Where a.isDel=0   order by sort asc   LIMIT {0},{1}  ", (pageindex - 1) * pagesize, pagesize), null);
        }


        /// <summary>
        /// 获取小区列表
        /// </summary>
        public List<CommunityInfoModel> GetCommunity(string strWhere, int uid)
        {

            // return MySQLHelper.ExecuteToList<communityinfo>(string.Format("select * from view_communityinfo {0}  LEFT JOIN usercommunityrelative b ON userID=15 order by sort asc", strWhere), null);
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select* from view_communityinfo a ");
            strSql.Append(" LEFT JOIN usercommunityrelative b ON a.communityID = b.communityID ");
            strSql.AppendFormat(" WHERE  b.userID = {0} ", uid);
            strSql.Append(strWhere);
            strSql.Append(" order by sort asc");



            return MySQLHelper.ExecuteToList<CommunityInfoModel>(strSql.ToString(), null);
        }

        /// <summary>
        /// 获取管理面积
        /// </summary>
        /// <returns></returns>
        public List<CommunityInfoModel> GetManageAreas()
        {
            return MySQLHelper.ExecuteToList<CommunityInfoModel>("select communityID,acreage from communityinfo", null);
        }


        /// <summary>
        /// 返回某个表内的最大sort值 TODO
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private int GetNewSort(string tableName)
        {
            string strsql = "select MAX(sort) from " + tableName + " Where isDel=0";
            var max = MySQLHelper.ExecuteScalar(strsql, null);
            return int.Parse(max.ToString());
        }

        /// <summary>
        /// 添加小区  TODO
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        public int AddCommunity(CommunityInfoModel community)
        {
            int maxSort = GetNewSort("communityinfo") + 1;
            string strsql = @"INSERT INTO communityinfo
            (communityName,pCityID,propertyMId,cuLongitude,cuLatitude,acreage,address,intro,isDel,sort)
            VALUES('" + community.communityName + "'," + community.pCityID + "," + community.propertyMId +
            "," + community.cuLongitude + "," + community.cuLatitude + "," + community.acreage +
            ",'" + community.address + "','" + community.intro + "',0," + maxSort + ");";
            return MySQLHelper.ExecuteNonQuery(string.Format(strsql), null);
        }

        /// <summary>
        /// 修改小区 TODO
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public int UpdateCommunityID(CommunityInfoModel comm)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update communityinfo set ");
            strSql.Append("communityName=@communityName,");
            strSql.Append("pCityID=@pCityID,");
            strSql.Append("propertyMId=@propertyMId,");
            strSql.Append("cuLongitude=@cuLongitude,");
            strSql.Append("cuLatitude=@cuLatitude,");
            strSql.Append("acreage=@acreage,");
            strSql.Append("address=@address,");
            strSql.Append("intro=@intro,");
            strSql.Append("isDel=@isDel");
            strSql.Append(" where communityID=@communityID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@communityName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@pCityID", MySqlDbType.Int32,10),
                    new MySqlParameter("@propertyMId", MySqlDbType.Int32,10),
                    new MySqlParameter("@cuLongitude", MySqlDbType.Decimal),
                    new MySqlParameter("@cuLatitude", MySqlDbType.Decimal),
                    new MySqlParameter("@acreage", MySqlDbType.Decimal),
                    new MySqlParameter("@address", MySqlDbType.VarChar,200),
                    new MySqlParameter("@intro", MySqlDbType.VarChar,250),
                    new MySqlParameter("@isDel", MySqlDbType.Bit),
                    new MySqlParameter("@communityID", MySqlDbType.Int32,10)};
            parameters[0].Value = comm.communityName;
            parameters[1].Value = comm.pCityID;
            parameters[2].Value = comm.propertyMId;
            parameters[3].Value = comm.cuLongitude;
            parameters[4].Value = comm.cuLatitude;
            parameters[5].Value = comm.acreage;
            parameters[6].Value = comm.address;
            parameters[7].Value = comm.intro;
            parameters[8].Value = comm.isDel;
            parameters[9].Value = comm.communityID;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除小区  TODO
        /// </summary>
        /// <param name="communtiyID"></param>
        /// <returns></returns>
        public int DeleteCommunityID(int communtiyID)
        {
            string strsql = @"update communityinfo set  isDel=1  where  communityID=" + communtiyID;
            return MySQLHelper.ExecuteNonQuery(strsql, null);
        }

        /// <summary>
        /// 根据用户id，获取小区
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<CommunityInfoModel> GetCommunityByUser(int userID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select c.communityID,c.communityName,c.pCityID,u.uid  ");
            sql.Append(" from communityinfo c ");
            sql.Append(" inner join usercommunityrelative ur on ur.communityID = c.communityID ");
            sql.Append(" inner join userinfo u on u.uid = ur.userID ");
            sql.Append(" where c.isDel = 0 and u.uid=@userID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@userID", userID),
            };
            return MySQLHelper.ExecuteToList<CommunityInfoModel>(sql.ToString(), parameters);
        }

        /// <summary>
        /// 根据省取得当前省下面的小区信息
        /// </summary>
        /// <param name="province">省</param>
        /// <returns></returns>
        public List<CommunityInfoModel> GetCommunityByProvince(string province)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select communityName, city.areaname as cityname  ");
            strSql.Append(" from communityinfo c ");
            strSql.Append(" left join  eccm_city_info city on areaID = c.pCityID ");
            strSql.Append(" left join   eccm_city_info p on p.areaID = city.pid ");
            strSql.AppendFormat(" where c.isdel = 0 and p.areaname = '{0}' ", province);
            return MySQLHelper.ExecuteToList<CommunityInfoModel>(strSql.ToString(), null);
        }

    }
}
