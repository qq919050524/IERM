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
    /// 运行监控展示信息  JINXIN
    /// </summary>
    public partial class ViewMonitorContentDAL
    {
        public ViewMonitorContentDAL()
        { }

        /// <summary>
        /// 获取运行监控展示信息列表
        /// </summary>
        public List<ViewMonitorContentModel> GetContent(string strWhere)
        {
            return MySQLHelper.ExecuteToList<ViewMonitorContentModel>(string.Format("select * from view_monitorcontent {0}", strWhere), null);
        }

        /// <summary>
        /// 获取所有运行监控展示信息
        /// </summary>
        /// <returns></returns>
        public List<ViewMonitorContentModel> GetAllContent(int pageindex, int pagesize, out int dataCount)
        {
            //获取数据总数 
            dataCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) FROM view_monitorcontent  ", null));
            return MySQLHelper.ExecuteToList<ViewMonitorContentModel>(string.Format(
                @"SELECT * FROM view_monitorcontent where isDel=0  order by tID desc LIMIT {0},{1} ", (pageindex - 1) * pagesize, pagesize), null);
        }

        /// <summary>
        /// 添加小区
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        public int AddContent(ViewMonitorContentModel content)
        {
            string strsql = @"INSERT INTO monitorcontent
            (devhouseID,sysType,contentCode,contentName,isDel)
            VALUES(" + content.DevhouseID + "," + content.SysType + ",'" + content.ContentCode +
            "','" + content.ContentName + "',0);";
            return MySQLHelper.ExecuteNonQuery(string.Format(strsql), null);
        }

        /// <summary>
        /// 修改运行监控展示信息
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public int UpdateContentID(ViewMonitorContentModel content)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update monitorcontent set ");
            strSql.Append("devhouseID=@devhouseID,");
            strSql.Append("sysType=@sysType,");
            strSql.Append("contentCode=@contentCode,");
            strSql.Append("contentName=@contentName,");
            strSql.Append("isDel=@isDel");
            strSql.Append(" where tID=@tID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devhouseID", MySqlDbType.Int32,10),
                    new MySqlParameter("@sysType", MySqlDbType.Int32,10),
                    new MySqlParameter("@contentCode", MySqlDbType.VarChar,20),
                    new MySqlParameter("@contentName", MySqlDbType.VarChar,20),
                    new MySqlParameter("@isDel", MySqlDbType.Bit),
                    new MySqlParameter("@tID", MySqlDbType.Int32,10)};
            parameters[0].Value = content.DevhouseID;
            parameters[1].Value = content.SysType;
            parameters[2].Value = content.ContentCode;
            parameters[3].Value = content.ContentName;
            parameters[4].Value = content.IsDel;
            parameters[5].Value = content.TID;

            return MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除运行监控展示信息
        /// </summary>
        /// <param name="communtiyID"></param>
        /// <returns></returns>
        public int DeleteContentID(int tID)
        {
            string strsql = @"update monitorcontent set  isDel=1  where  tID=" + tID;
            return MySQLHelper.ExecuteNonQuery(strsql, null);
        }
    }
}
