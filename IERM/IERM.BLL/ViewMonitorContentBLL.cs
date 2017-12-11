using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IERM.Model;
using IERM.DAL;

namespace IERM.BLL
{
    /// <summary>
    /// JINXIN
    /// </summary>
    public partial class ViewMonitorContentBLL
    {
        private readonly ViewMonitorContentDAL mcDal = new ViewMonitorContentDAL();

        /// <summary>
        /// 添加运行监控展示信息
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        public int AddContent(ViewMonitorContentModel content)
        {
            return mcDal.AddContent(content);
        }

        public List<ViewMonitorContentModel> GetGetContentById(int tId)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("   where  tID=" + tId);
            return mcDal.GetContent(sbWhere.ToString());
        }

        /// <summary>
        /// 删除小区
        /// </summary>
        /// <param name="CommunityId"></param>
        /// <returns></returns>
        public int DeleteContent(int contentID)
        {
            return mcDal.DeleteContentID(contentID);
        }

        /// <summary>
        /// 修改运行监控展示信息
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public int UpdateContent(ViewMonitorContentModel content)
        {
            return mcDal.UpdateContentID(content);
        }


        /// <summary>
        /// 获取所有运行监控展示信息
        /// </summary>
        /// <returns></returns>
        public List<ViewMonitorContentModel> GetAllContent(int pageIndex, int pageSize, out int datacount)
        {
            return mcDal.GetAllContent(pageIndex, pageSize, out datacount);
        }
    }
}
