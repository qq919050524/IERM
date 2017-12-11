using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IERM.DAL;
using IERM.MODEL;
using System.Data;

namespace IERM.BLL
{
    public class EccmPlanBLL
    {
        private readonly EccmPlanDAL dal = new EccmPlanDAL();

        /// <summary>
        /// 根据计划id获取设备
        /// </summary>" ", 
        /// <param name="plan_id">计划id</param>
        /// <param name="choose_type">0设备类型，1设备</param>
        /// <returns></returns>
        public DataTable GetPlanDeviceCode(int plan_id, int choose_type)
        {
            return dal.GetPlanDeviceCode(plan_id, choose_type);
        }

        /// <summary>
        /// 获取计划列表
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<EccmPlanModel> GetPlanList()
        {
            return dal.GetPlanList();
        }        
    }
}