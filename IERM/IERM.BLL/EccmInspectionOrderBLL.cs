using System;
using System.Data;
using System.Collections.Generic;
using IERM.Model;
using IERM.DAL;

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
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 获取巡检工单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetInspectionOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return dal.GetInspectionOrderList(strWhere, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 获取用户工单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetInspectionUserOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return dal.GetInspectionUserOrderList(strWhere, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int order_id)
        {
            return dal.Exists(order_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmInspectionOrderModel model, string equCodes)
        {
            return dal.Add(model, equCodes);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EccmInspectionOrderModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新改订单状态
        /// </summary>
        public bool UpdateStates(EccmInspectionOrderModel model)
        {
            return dal.UpdateStates(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int order_id)
        {
            return dal.Delete(order_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string order_idlist)
        {
            return dal.DeleteList(order_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmInspectionOrderModel GetModel(int order_id)
        {
            return dal.GetModel(order_id);
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public DataTable GetList(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            return dal.GetList(strWhere, pageIndex, pageSize, out rowCount);
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public bool SendInspectionOrder(int orderID, int userID, int dispatch)
        {
            return dal.SendInspectionOrder(orderID, userID, dispatch);
        }

            #endregion  BasicMethod
        }
}

