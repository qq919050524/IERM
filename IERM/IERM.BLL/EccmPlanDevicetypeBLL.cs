using System;
using System.Data;
using System.Collections.Generic;
using IERM.DAL;
using IERM.Model;

namespace IERM.BLL
{
    /// <summary>
    /// EccmPlanDevicetypeBLL
    /// </summary>
    public partial class EccmPlanDevicetypeBLL
    {
        private readonly EccmPlanDevicetypeDAL dal = new EccmPlanDevicetypeDAL();
        public EccmPlanDevicetypeBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmPlanDevicetypeModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 根据条件获取设备类型
        /// </summary>
        public DataTable GetList(int plan_id)
        {
            return dal.GetList(plan_id);
        }

        /// <summary>
        /// 根据计划id删除关联的设备类型
        /// </summary>
        public bool delete(int plan_id)
        {
            return dal.delete(plan_id);
        }
        #endregion  BasicMethod
    }
}

