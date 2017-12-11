using System;
using System.Data;
using System.Collections.Generic;
using IERM.DAL;
using IERM.Model;

namespace IERM.BLL
{
    /// <summary>
    /// EccmPlanDeviceBLL
    /// </summary>
    public partial class EccmPlanDeviceBLL
    {
        private readonly EccmPlanDeviceDAL dal = new EccmPlanDeviceDAL();
        public EccmPlanDeviceBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmPlanDeviceModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 根据条件获取设备
        /// </summary>
        public DataTable GetList(int plan_id)
        {
            return dal.GetList(plan_id);
        }
        /// <summary>
        /// 根据计划id删除设备
        /// </summary>
        public bool delete(int plan_id)
        {
            return dal.delete(plan_id);
        }
        #endregion  BasicMethod
    }
}

