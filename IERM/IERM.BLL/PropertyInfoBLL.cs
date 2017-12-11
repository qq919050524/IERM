using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class PropertyInfoBLL
    {
        private readonly PropertyInfoDAL ppi_dal = new PropertyInfoDAL();
        public DataTable GetAllPropertyinfo()
        {
            return ppi_dal.GetAllPropertyinfo();
        }
        /// <summary>
        /// 获取用户授权公司
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public DataTable GetAuthorizePropertyinfo(int UserID)
        {
            DataTable dt = new DataTable();
            UserInfoDAL userinfo_dal = new UserInfoDAL();
            //授权小区列表
            List<AuthCommunityModel> CommunityList = userinfo_dal.GetAuthCommunity(UserID);
            List<int> propertyList = new List<int>();
            if (CommunityList.Count > 0)
            {
                propertyList = CommunityList.Select(x => x.propertyMId).Distinct().ToList<int>();
                PropertyInfoDAL property_dal = new PropertyInfoDAL();
                string sqlwhere = " AND propertyID in(" + string.Join(",", propertyList) + ")";
                dt = property_dal.GetAllPropertyinfoList(sqlwhere);
            }
            return dt;


        }
        public List<PropertyInfoModel> GetAllPropertyinfoList()
        {
            return ppi_dal.GetAllPropertyinfoList();
        }
    }
}
