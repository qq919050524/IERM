
using IERM.Common;
using IERM.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class DevInfoDAL
    {
        /// <summary>
        /// 获取全部设备
        /// </summary>
        /// <returns></returns>
        public List<DevInfoModel> GetAllDevinfo()
        {
            return MySQLHelper.ExecuteToList<DevInfoModel>("SELECT di.*, dt.devTypeName FROM devinfo AS di INNER JOIN devtype AS dt ON dt.dtID = di.devType WHERE di.isDel = 0 AND dt.isDel = 0 ORDER BY di.sort", null);
        }

        /// <summary>
        /// 获取指定小区设备房及其所含系统类型
        /// </summary>
        /// <param name="communityid">小区编号</param>
        /// <param name="devType">设备类型</param>
        /// <param name="systypeID">设备房编号</param>
        /// <returns></returns>
        public List<DevInfoModel> GetDevHouseAndSysType(int communityid, int devType, int systypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT di.*,dhs.systypeID,st.typeName as systypeName from devinfo as di  ");
            strSql.Append(" INNER JOIN devhousesystype as dhs on dhs.devhouseID = di.devID ");
            strSql.Append(" INNER JOIN systemtype as st on st.tID = dhs.systypeID ");
            strSql.Append(" where di.isDel = 0 ");
            strSql.AppendFormat("  and communityID = {0} ", communityid);


            //当是水岸星城时，有个消防泵房设备房有给排水和消防
            if (communityid == 3 && systypeID == 1)
            {
                strSql.Append(" AND di.devType in (1,3) ");
            }
            else
            {
                strSql.AppendFormat(" AND di.devType={0} ", devType);

            }
            strSql.AppendFormat(" AND dhs.systypeID={0} ", systypeID);
            strSql.AppendFormat("  ORDER BY sort,systypeID ");

            return MySQLHelper.ExecuteToList<DevInfoModel>(strSql.ToString(), null);
        }
        /// <summary>
        /// 获取指定小区设备房及其所含系统类型
        /// </summary>
        /// <param name="communityid"></param>
        /// <returns></returns>
        public List<DevInfoModel> GetDevHouseAndSysType(int communityid)
        {
            return MySQLHelper.ExecuteToList<DevInfoModel>(string.Format("SELECT di.*,dhs.systypeID,st.typeName as systypeName from devinfo as di INNER JOIN devhousesystype as dhs on dhs.devhouseID = di.devID INNER JOIN systemtype as st on st.tID = dhs.systypeID where di.isDel = 0 and communityID = {0}  ORDER BY sort,systypeID", communityid), null);
        }
        /// <summary>
        /// 获取某小区所有设备
        /// </summary>
        /// <returns></returns>
        public List<DevInfoModel> GetCommunityDevinfo(int communityID, int devType)
        {
            return MySQLHelper.ExecuteToList<DevInfoModel>(@" SELECT  devinfo.devID,devinfo.devName  from  devinfo LEFT JOIN communityinfo on devinfo.communityID=communityinfo.communityID
 where devinfo.communityID=" + communityID + "  AND devinfo.devType =" + devType + "", null
              );

        }

        /// <summary>
        /// 根据设备编号取得对应的管理用户
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <returns></returns>
        public DataTable GetUserByDev(string devID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  mobile from devinfo d ");
            strSql.Append("left join usercommunityrelative c on c.communityid = d.communityid ");
            strSql.Append("left join userinfo u on u.uid = c.userid ");
            strSql.AppendFormat("where d.devid = {0} ", devID);

            return MySQLHelper.ExecuteToDataTable(strSql.ToString());
        }

    }
}
