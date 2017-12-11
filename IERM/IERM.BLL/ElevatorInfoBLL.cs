using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class ElevatorInfoBLL
    {
        private ElevatorInfoDAL _dal = new ElevatorInfoDAL();

        /// <summary>
        /// 获取实时报警记录
        /// </summary>" ", 
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public List<ElevatorInfoModel> GetList(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetList(strWhere, pageindex, pagesize, out count);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(ElevatorInfoModel model)
        {
            return _dal.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ElevatorInfoModel model)
        {
            return _dal.Update(model);
        }

        /// <summary>
        ///  删除,假删除
        /// </summary>
        /// <param name="eID"></param>
        /// <returns></returns>
        public bool Delete(int eID)
        {
            return _dal.Delete(eID);
        }

        /// <summary>
        /// 注册码是否存在(true存在)
        /// </summary>
        /// <returns></returns>
        public bool Exists(string registrationCode, int eID)
        {
            return _dal.Exists(registrationCode, eID);
        }

        /// <summary>
        /// 获取小区和电梯信息列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ElevatorInfoModel> GetListElevatorInfo(string strWhere, int pageindex, int pagesize, out int count)
        {
            return _dal.GetListElevatorInfo(strWhere, pageindex, pagesize, out count);
        }
    }
}
