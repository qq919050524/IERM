using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    /// <summary>
    /// 报警记录
    /// </summary>
    public partial class AlarmLogBLL
    {

        private readonly AlarmLogDAL alarm_dal = new AlarmLogDAL();

        /// <summary>
        /// 获取实时报警信息
        /// </summary>
        /// <param name="cityid">城市id</param>
        /// <param name="propertyid">物业id</param>
        /// <param name="partname">项目名关键字</param>
        /// <param name="devtypeid">系统id</param>
        public List<ViewAlarmlogModel> GetCurrentAlarmLog(int cityid, int propertyid, string partname, int devtypeid, int pageindex, int pagesize, out int alarmcount)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" and areaID={0} ", cityid);
            if (propertyid != 0)
            {
                strWhere.AppendFormat(" and propertyID={0}", propertyid);
            }

            if (devtypeid != 0)
            {
                strWhere.AppendFormat(" and systypeID={0}", devtypeid);
            }
            if (!string.IsNullOrEmpty(partname))
            {
                strWhere.AppendFormat(" and communityName like '%{0}%'", partname);
            }
            if (strWhere.Length > 0) strWhere.Remove(0, 4);


            return alarm_dal.GetCurrentAlarmLog(strWhere.ToString(), pageindex, pagesize, out alarmcount);
        }

        /// <summary>
        /// 获取报警日志
        /// </summary>
        /// <param name="cityid"></param>
        /// <param name="propertyid"></param>
        /// <param name="partname"></param>
        /// <param name="devtypeid"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="alarmcount"></param>
        /// <returns></returns>
        public List<ViewAlarmlogModel> GetAlarmLog(int cityid, int propertyid, string partname, int systypeid, int pageindex, int pagesize, DateTime begintime, DateTime endtime, out int alarmcount)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" where areaID={0} and insertTime>'{1}' and insertTime<'{2}'", cityid, begintime.ToString("yyyy-MM-dd HH:mm:ss"), endtime.ToString("yyyy-MM-dd HH:mm:ss"));

            if (propertyid != 0)
            {
                strWhere.AppendFormat(" and propertyID={0}", propertyid);
            }

            if (systypeid != 0)
            {
                strWhere.AppendFormat(" and systypeID={0}", systypeid);
            }

            if (!string.IsNullOrEmpty(partname))
            {
                strWhere.AppendFormat(" and communityName like '%{0}%'", partname);
            }

            return alarm_dal.GetAlarmLog(strWhere.ToString(), pageindex, pagesize, out alarmcount);
        }

        public DataTable GetList(string strWhere)
        {
            return alarm_dal.GetList(strWhere);
        }
    }
}
