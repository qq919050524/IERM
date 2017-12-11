using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IERM.Model;
using IERM.DAL;

namespace IERM.BLL
{
    public class EccmInspectionOrderImplementBLL
    {
        private EccmInspectionOrderImplementDAL _dal = new EccmInspectionOrderImplementDAL();
        /// <summary>
        /// 根据order_id 获取实施记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmInspectionOrderImplementModel> GetOrderImplementList(int orderID, int pageindex, int pagesize, out int count)
        {
            return _dal.GetOrderImplementList(orderID, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EccmInspectionOrderImplementModel model)
        {
            return _dal.Add(model);
        }
    }
}
