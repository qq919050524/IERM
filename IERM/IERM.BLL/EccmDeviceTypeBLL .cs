using System;
using System.Data;
using System.Collections.Generic;
using IERM.Model;
using IERM.DAL;

namespace IERM.BLL
{
    /// <summary>
    /// EccmDeviceTypeBLL
    /// </summary>
    public partial class EccmDeviceTypeBLL
    {
        private readonly EccmDeviceTypeDAL dal = new EccmDeviceTypeDAL();
        public EccmDeviceTypeBLL()
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
        public bool Exists(int devicetype_id)
        {
            return dal.Exists(devicetype_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmDeviceTypeModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EccmDeviceTypeModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int devicetype_id)
        {
            return dal.Delete(devicetype_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string devicetype_idlist)
        {
            return dal.DeleteList(devicetype_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmDeviceTypeModel GetModel(int devicetype_id)
        {
            return dal.GetModel(devicetype_id);
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public DataTable GetList(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out rowCount);
        }

        public int AddRelation(int standard_id, string device_type_code)
        {
            return dal.AddRelation(standard_id, device_type_code);
        }

        #endregion  BasicMethod
    }
}

