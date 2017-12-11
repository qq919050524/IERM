using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class AreaInfoBLL
    {
        /// <summary>
        /// 获取全部区域信息
        /// </summary>
        /// <returns></returns>
        public List<MODEL.AreaInfoModel> GetAllArea()
        {
            return new DAL.AreaInfoDAL().GetAllArea();
        }
    }
}
