using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmOrderDeviceStandardBLL
    {
        private EccmOrderDeviceStandardDAL _dal = new EccmOrderDeviceStandardDAL();
        /// <summary>
        ///根据order_sn 查询订单设备
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmOrderDeviceStandardModel> GetOrderEquipmentList(string orderSN, int pageindex, int pagesize, out int count)
        {
            return _dal.GetOrderEquipmentList(orderSN, pageindex, pagesize, out count);
        }
    }
}
