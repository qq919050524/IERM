using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class SwitchRoomRdBLL
    {
        private readonly DAL.SwitchRoomRdDAL switchroow_dal = new DAL.SwitchRoomRdDAL();
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MODEL.SwitchRoomRdModel model)
        {
            return switchroow_dal.Add(model);
        }
    }
}
