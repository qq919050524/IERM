using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmRepairOrderImplementBLL
    {
        private EccmRepairOrderImplementDAL _dal = new EccmRepairOrderImplementDAL();
        /// <summary>
        /// 根据order_id 获取实施记录
        /// </summary>" ", 
        /// <param name="orderID">订单号</param>
        /// <param name="order_device_standard_type">类型(1巡检2维保3维修)</param>
        /// <returns></returns>
        public List<EccmRepairOrderImplementModel> GetOrderImplementList(int orderID, int pageindex, int pagesize, out int count)
        {
            return _dal.GetOrderImplementList(orderID, pageindex, pagesize, out count);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EccmRepairOrderImplementModel model)
        {
            return _dal.Add(model);
        }

    }
}
