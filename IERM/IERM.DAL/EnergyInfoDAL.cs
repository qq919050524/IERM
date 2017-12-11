using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;

namespace IERM.DAL
{
    public partial class EnergyInfoDAL
    {
        /// <summary>
        /// 获取能耗记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergyLog(string strWhere, int pageindex, int pagesize, out int logCount)
        {
            logCount = Convert.ToInt32(MySQLHelper.ExecuteScalar("SELECT count(1) from energyinfo as ei INNER JOIN energytype as et on et.tID = ei.typeID" + strWhere, null));
            if (logCount > 0)
            {
                return MySQLHelper.ExecuteToList<EnergyInfoModel>(string.Format("SELECT * from energyinfo as ei INNER JOIN energytype as et on et.tID = ei.typeID {0} ORDER BY insertTime DESC LIMIT {1},{2}", strWhere, (pageindex - 1) * pagesize, pagesize), null);
            }
            else
            {
                return new List<EnergyInfoModel>();
            }
        }

        /// <summary>
        /// 获取能源图表数据集合
        /// </summary>
        /// <returns></returns>
        public List<EnergyInfoModel> GetEnergData(int areaid, int arealevel, int selyear,int energtype)
        {
            if (arealevel == 3)
            {
                return MySQLHelper.ExecuteToList<EnergyInfoModel>(string.Format("SELECT ei.*, et.typeName FROM energyinfo as ei INNER JOIN energytype as et on et.tID = ei.typeID where communityID={0} and(`year`={1} or `year`={2}) and et.pID={3} and et.isDel=0", areaid, selyear, selyear - 1, energtype), null);
            }
            else
            {
                return MySQLHelper.ExecuteToList<EnergyInfoModel>(string.Format("SELECT ei.*,ci.communityName from energyinfo as ei INNER JOIN communityinfo as ci on ci.communityID = ei.communityID INNER JOIN energytype as et on et.tID=ei.typeID where ci.pCityID = {0} and ci.isDel = 0 and(ei.`year`= {1} or ei.`year`= {2}) and et.isDel=0 and et.pID={3}", areaid, selyear, selyear - 1, energtype), null);
            }

        }

        /// <summary>
        /// 添加能耗数据
        /// </summary>
        /// <param name="englist"></param>
        /// <returns></returns>
        public int Add(List<string> cmdstrlist)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdstrlist);
        }

        /// <summary>
        /// 更新一条能源数据
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public bool Update(int nID,decimal newValue)
        {
            return MySQLHelper.ExecuteNonQuery(string.Format("update energyinfo set engValue={0} where nID={1}", newValue, nID), null) > 0 ? true : false;
        }

        /// <summary>
        /// 删除指定能耗数据
        /// </summary>
        /// <param name="nID"></param>
        /// <returns></returns>
        public bool Delete(int nID)
        {
            return MySQLHelper.ExecuteNonQuery(string.Format("delete from energyinfo where nID={0}", nID), null) > 0 ? true : false;
        }
    }
}
