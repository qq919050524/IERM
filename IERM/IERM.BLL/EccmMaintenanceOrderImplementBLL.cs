using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmMaintenanceOrderImplementBLL
    {
        private EccmMaintenanceOrderImplementDAL _dal = new EccmMaintenanceOrderImplementDAL();
        /// <summary>
        /// 根据order_id 获取实施记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmMaintenanceOrderImplementModel> GetOrderImplementList(int orderID, int pageindex, int pagesize, out int count)
        {
            return _dal.GetOrderImplementList(orderID, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EccmMaintenanceOrderImplementModel model)
        {
            return _dal.Add(model);
        }
    }
}
