using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmRepairOrderBLL
    {
        private EccmRepairOrderDAL _dal = new EccmRepairOrderDAL();

        /// <summary>
        /// 获取报修订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmRepairOrderModel> GetRepairOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetRepairOrderList(strWhere, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 新增报修工单
        /// </summary>
        /// <param name="orderSn">订单号</param>
        /// <param name="equCodes">设备code 多个，号分割</param>
        /// <param name="communityID">小区id</param>
        /// <param name="reason">原因</param>
        /// <param name="termtime">期限时间</param>
        /// <param name="uid">创建人</param>
        /// <returns></returns>
        public bool AddRepairOrder(string orderSn, string equCodes, int communityID, string reason, DateTime termtime, int uid)
        {
            return _dal.AddRepairOrder(orderSn, equCodes, communityID, reason, termtime, uid);
        }

        /// <summary>
        /// 删除，假删除
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool DeleteRepairOrder(int orderID)
        {
            return _dal.DeleteRepairOrder(orderID);
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public bool SendRepairOrder(int orderID, int userID, int dispatch)
        {
            return _dal.SendRepairOrder(orderID, userID, dispatch);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public EccmRepairOrderModel GetRepairOrderDetail(int orderID)
        {
            return _dal.GetRepairOrderDetail(orderID);
        }

        /// <summary>
        /// 更新改订单状态
        /// </summary>
        public bool UpdateStates(EccmRepairOrderModel model)
        {
            return _dal.UpdateStates(model);
        }
        /// <summary>
        /// 获取用户报修订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmRepairOrderModel> GetRepairUserOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetRepairUserOrderList(strWhere, pageindex, pagesize, out count);
        }
    }
}
