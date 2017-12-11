using IERM.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmMaintenanceOrderBLL
    {
        private DAL.EccmMaintenanceOrderDAL _dal = new DAL.EccmMaintenanceOrderDAL();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmMaintenanceOrderModel model, string equCodes)
        {
            return _dal.Add(model, equCodes);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmMaintenanceOrderModel GetModel(int plan_id)
        {
            return _dal.GetModel(plan_id);
        }
    }
}
