using System;
using System.Data;
using System.Collections.Generic;
using IERM.DAL;
using IERM.MODEL;
namespace IERM.BLL
{
    /// <summary>
    /// EccmInspectionOrderBLL
    /// </summary>
    public partial class EccmInspectionOrderBLL
    {
        private readonly EccmInspectionOrderDAL dal = new EccmInspectionOrderDAL();
        public EccmInspectionOrderBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmInspectionOrderModel model, string equCodes)
        {
            return dal.Add(model, equCodes);
        }

        /// <summary>
        /// 根据计划得到一个对象实体
        /// </summary>
        public EccmInspectionOrderModel GetModel(int plan_id)
        {
            return dal.GetModel(plan_id);
        }
        #endregion  BasicMethod
    }
}

