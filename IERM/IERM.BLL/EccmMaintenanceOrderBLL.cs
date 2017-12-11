using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmMaintenanceOrderBLL
    {
        private EccmMaintenanceOrderDAL _dal = new EccmMaintenanceOrderDAL();
        /// <summary>
        /// 获取维保订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetMaintenanceOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetMaintenanceOrderList(strWhere, pageindex, pagesize, out count);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmMaintenanceOrderModel model, string equCodes)
        {
            return _dal.Add(model, equCodes);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int order_id)
        {
            return _dal.Delete(order_id);
        }

        /// <summary>
        /// 更新改订单状态
        /// </summary>
        public bool UpdateStates(EccmMaintenanceOrderModel model)
        {
            return _dal.UpdateStates(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmMaintenanceOrderModel GetModel(int order_id)
        {
            return _dal.GetModel(order_id);
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <param name="dispatch"></param>
        /// <returns></returns>
        public bool SendMaintenanceOrder(int orderID, int userID, int dispatch)
        {
            return _dal.SendMaintenanceOrder(orderID, userID, dispatch);
        }
        /// <summary>
        /// 获取用户维保订单列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetMaintenanceUserOrderList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetMaintenanceUserOrderList(strWhere, pageindex, pagesize, out count);
        }
    }
}
