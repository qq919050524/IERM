using System;
using System.Data;
using System.Collections.Generic;
using IERM.DAL;
using IERM.Model;

namespace IERM.BLL
{
    /// <summary>
    /// EccmImplementImgBLL
    /// </summary>
    public partial class EccmImplementImgBLL
    {
        private readonly EccmImplementImgDAL dal = new EccmImplementImgDAL();
        public EccmImplementImgBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmImplementImgModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 根据条件获取图片数据
        /// </summary>
        public DataTable GetList(int implement_id, int img_type)
        {
            return dal.GetList(implement_id, img_type);
        }
        #endregion  BasicMethod
    }
}

