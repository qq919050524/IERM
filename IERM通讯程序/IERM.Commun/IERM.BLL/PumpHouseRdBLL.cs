using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class PumpHouseRdBLL
    {
        private readonly DAL.PumpHouseRdDAL pumphouse_dal = new DAL.PumpHouseRdDAL();

        /// <summary>
        /// 增加一条泵房记录
        /// </summary>
        public bool Add(MODEL.PumpHouseRdModel model)
        {
            return pumphouse_dal.Add(model);
        }
    }
}
