using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class DevInfoBLL
    {
        private readonly DevInfoDAL dev_dal = new DevInfoDAL();

        /// <summary>
        /// 获取全部设备房
        /// </summary>
        /// <returns></returns>
        public List<DevInfoModel> GetAllDevinfo()
        {
            return dev_dal.GetAllDevinfo();
        }

        /// <summary>
        /// 获取指定小区设备房及所含系统类型
        /// </summary>
        /// <param name="communityid">小区</param>
        /// <param name="devType">设备类型</param>
        /// <param name="systypeID">设备房机型</param>
        /// <returns></returns>
        public List<DevInfoModel> GetDevHouseAndSysType(int communityid,int devType, int systypeID)
        {
            return dev_dal.GetDevHouseAndSysType(communityid, devType, systypeID);
        }
        public List<DevInfoModel> GetDevHouseAndSysType(int communityid)
        {
            return dev_dal.GetDevHouseAndSysType(communityid);
        }
        public List<DevInfoModel> GetCommunityDevinfo(int communityId, int devType)
        {
            //StringBuilder sbWhere = new StringBuilder();
            //if (propertyID !=0)
            //{
            //    sbWhere.AppendFormat(@"    and  propertyinfo.propertyID={0}",propertyID);
            //}
            //else
            //{
            //    sbWhere.AppendFormat("        ");
            //}
            return dev_dal.GetCommunityDevinfo(communityId, devType);
        }


        /// <summary>
        /// 根据设备编号取得对应的管理用户
        /// </summary>
        /// <param name="devID">设备编号</param>
        /// <returns></returns>
        public DataTable GetUserByDev(string devID)
        {
            return dev_dal.GetUserByDev(devID);
        }
    }
}
