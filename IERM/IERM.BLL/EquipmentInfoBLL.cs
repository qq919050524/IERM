using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IERM.BLL
{
    public class EquipmentInfoBLL
    {
        private readonly EquipmentInfoDAL equinfo_dal = new EquipmentInfoDAL();

        /// <summary>
        /// 获取指定设备详细信息
        /// </summary>
        /// <param name="houseid"></param>
        /// <returns></returns>
        public ViewEquinfoModel GetEquipmentinfoByequId(int equid)
        {
            return equinfo_dal.GetEquipmentinfoByequId(equid);

        }

        /// <summary>
        /// 获取指定设备房全部设备信息
        /// </summary>
        public List<EquipmentInfoModel> GetEquListByHouseID(int houseid, int pagesize, int pageindex, out int rowcount)
        {
            return equinfo_dal.GetEquListByHouseID(houseid, pagesize, pageindex, out rowcount);
        }

        /// <summary>
        /// 增加一条数据并返回新行号
        /// </summary>
        public int Add(EquipmentInfoModel model, List<EquipmentaccModel> accdata)
        {
            return equinfo_dal.Add(model, accdata);
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EquipmentInfoModel model, List<EquipmentaccModel> accdata)
        {
            return equinfo_dal.Update(model, accdata);
        }

        /// <summary>
        /// 删除一条设备记录
        /// </summary>
        /// <param name="equID"></param>
        /// <returns></returns>
        public bool Delete(int equID)
        {
            List<string> cmdstrlist = new List<string>();
            cmdstrlist.Add(string.Format("delete from equipmentinfo where eID={0}", equID));
            cmdstrlist.Add(string.Format("delete from equipmentacc where equID={0}", equID));
            return equinfo_dal.Delete(cmdstrlist);
        }
        /// <summary>
        /// 根据小区获取设备
        /// </summary>
        /// <param name="communityID"></param>
        /// <returns></returns>
        public List<EquipmentInfoModel> GetEquipmentInfoListByCommunity(int communityID)
        {
            return equinfo_dal.GetEquipmentInfoListByCommunity(communityID);
        }
        /// <summary>
        /// 根据小区计划选择获取设备
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="type">0获取设备类型，1获取设备</param>
        /// <returns></returns>
        public List<EquipmentInfoModel> GetEquipmentInfoListByCommunityForPlan(int communityID, int type)
        {
            return equinfo_dal.GetEquipmentInfoListByCommunityForPlan(communityID, type);
        }
    }
}
