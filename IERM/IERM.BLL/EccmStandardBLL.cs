using System;
using System.Data;
using System.Collections.Generic;
using IERM.DAL;
using IERM.Model;

namespace IERM.BLL
{
    /// <summary>
    /// EccmStandardBLL
    /// </summary>
    public partial class EccmStandardBLL
    {
        private readonly EccmStandardDAL dal = new EccmStandardDAL();
        public EccmStandardBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int standard_id)
        {
            return dal.Exists(standard_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmStandardModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EccmStandardModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int standard_id)
        {
            return dal.Delete(standard_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string standard_idlist)
        {
            return dal.DeleteList(standard_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmStandardModel GetModel(int standard_id)
        {
            return dal.GetModel(standard_id);
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public DataTable GetList(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out rowCount);
        }

        #endregion  BasicMethod
    }
}

