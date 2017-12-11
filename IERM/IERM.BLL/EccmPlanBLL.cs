using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IERM.Model;
using IERM.DAL;

namespace IERM.BLL
{
    public class EccmPlanBLL
    {
        private readonly EccmPlanDAL dal = new EccmPlanDAL();
        /// <summary>
        /// 根据小区id 获取计划列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public DataTable GetPlanList(string strwhere, int pageindex, int pagesize, out int count)
        {
            return dal.GetPlanList(strwhere, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 增加一条计划数据
        /// </summary>
        public int Add(EccmPlanModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EccmPlanModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(EccmPlanModel model)
        {
            return dal.Delete(model);
        }

        /// <summary>
		/// 更改计划状态
		/// </summary>
		public bool UpdataStates(EccmPlanModel model)
        {
            return dal.UpdataStates(model);
        }
    }
}