using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class CommunityInfoBLL
    {
        private readonly CommunityInfoDAL ciDal = new CommunityInfoDAL();

        /// <summary>
        /// 获取所有小区列表
        /// </summary>
        public List<CommunityInfoModel> GetCommunity(string strWhere, int uid)
        {
            return ciDal.GetCommunity(strWhere, uid);
        }

        /// <summary>
        /// 获取默认小区实体
        /// </summary>
        /// <returns></returns>
        public CommunityInfoModel GetDefaultModel(string strWhere, int uid)
        {
            return ciDal.GetCommunity(strWhere, uid).FirstOrDefault();
        }

        /// <summary>
        /// 获取管理面积
        /// </summary>
        public Dictionary<int, decimal> GetManageAreas()
        {
            return ciDal.GetManageAreas().ToDictionary(k => k.communityID, v => v.acreage);
        }

        /// <summary>
        /// 获取指定城市的小区列表  TODO
        /// </summary>
        public List<CommunityInfoModel> GetProperCommunity(string propertyMId, string pCityID, int uid)
        {
            StringBuilder sbWhere = new StringBuilder();
            if (pCityID == "0")
            {
                //用户下拉框插件select2andtree  这个下拉框是直接显示省市小区 所以只用查询
                sbWhere.Append(" and isDel=0 AND propertyMId = " + propertyMId);
            }
            else
            {
                sbWhere.Append(" and isDel=0 AND  propertyMId = " + propertyMId + " and pCityID = " + pCityID);
            }
            return ciDal.GetCommunity(sbWhere.ToString(), uid);
        }

        /// <summary>
        /// 获取指定城市的小区列表 TODO
        /// </summary>
        public List<CommunityInfoModel> GetCityCommunity(int areaid, int uid)
        {
            return ciDal.GetCommunity("  and isDel=0  AND  pCityID=" + areaid.ToString(), uid);
        }

        /// <summary>
        /// 添加小区  TODO
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        public int AddCommunity(CommunityInfoModel community)
        {
            return ciDal.AddCommunity(community);
        }

        /// <summary>
        /// 删除小区  TODO
        /// </summary>
        /// <param name="CommunityId"></param>
        /// <returns></returns>
        public int DeleteCommunity(int CommunityId)
        {
            return ciDal.DeleteCommunityID(CommunityId);
        }

        /// <summary>
        /// 修改小区 TODO
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public int UpdateCommunity(CommunityInfoModel comm)
        {
            return ciDal.UpdateCommunityID(comm);
        }

        /// <summary>
        /// 获取所有小区 TODO
        /// </summary>
        /// <returns></returns>
        public List<CommunityInfoModel> GetAllCommunity(int pageIndex, int pageSize, out int datacount)
        {
            return ciDal.GetAllCommunity(pageIndex, pageSize, out datacount);
        }

        /// <summary>
        /// 返回单个小区的信息 TODO
        /// </summary>
        /// <param name="communityID"></param>
        /// <returns></returns>
        public List<CommunityInfoModel> GetCommunityById(int communityID, int uid)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("  and isDel=0 AND communityID=" + communityID);
            return ciDal.GetCommunity(sbWhere.ToString(), uid);
        }

        /// <summary>
        /// 根据用户id，获取小区
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<CommunityInfoModel> GetCommunityByUser(int userID)
        {
            return ciDal.GetCommunityByUser(userID);
        }

        /// <summary>
        /// 根据省取得当前省下面的小区信息
        /// </summary>
        /// <param name="province">省</param>
        /// <returns></returns>
        public List<CommunityInfoModel> GetCommunityByProvince(string province)
        {
            return ciDal.GetCommunityByProvince(province);
        }
    }
}
