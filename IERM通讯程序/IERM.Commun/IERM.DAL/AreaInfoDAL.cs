using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class AreaInfoDAL
    {
        /// <summary>
        /// 获取全部区域信息
        /// </summary>
        /// <returns></returns>
        public List<MODEL.AreaInfoModel> GetAllArea()
        {
            return Common.MySQLHelper.ExecuteToList<MODEL.AreaInfoModel>(string.Format("SELECT ci.areaID as cityid, ci.areaName as cityname,ci2.areaID as provid, ci2.areaName as provname,cy.communityID, cy.communityName from cityinfo as ci INNER JOIN cityinfo as ci2 on ci.pID = ci2.areaID INNER JOIN communityinfo as cy on cy.pCityID = ci.areaID WHERE ci.isDel = 0 and cy.isDel = 0"), null);
        }
    }
}
