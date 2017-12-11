using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class ElevatorInfoDAL
    {
        /// <summary>
        /// 获取绑定电梯的注册码和小区
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<MODEL.ElevatorInfoModel> GetListElevatorInfo(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select e.eID,e.communityID,e.registrationCode,e.elevatorPosition ");
            sql.Append(" ,c.communityName ");
            sql.Append(" from elevatorinfo e");
            sql.Append(" left join communityinfo c on c.communityID=e.communityID ");
            sql.Append(" where e.isDel=0  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.AppendFormat(" and {0} ", strWhere);
            }

            return Common.MySQLHelper.ExecuteToList<MODEL.ElevatorInfoModel>(sql.ToString(), null);
        }
    }

}
