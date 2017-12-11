using IERM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class ElevatorInfoBLL
    {
        private DAL.ElevatorInfoDAL _dal = new DAL.ElevatorInfoDAL();
        /// <summary>
        /// 获取绑定电梯的注册码和小区
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<MODEL.ElevatorInfoModel> GetListElevatorInfo(string strWhere)
        {
            return _dal.GetListElevatorInfo(strWhere);
        }

        /// <summary>
        /// 电梯注集合
        /// </summary>
        /// <returns></returns>
        public List<MODEL.ElevatorInfoModel> GetelEvatorList()
        {

            object obj = CacheHelper.GetCache("ElevatorModel.ElevatorList");
            if (obj == null)
            {
                List<MODEL.ElevatorInfoModel> elevatorList = GetListElevatorInfo("");
                if (elevatorList.Count > 0)
                {
                    CacheHelper.SetCache("ElevatorModel.ElevatorList", elevatorList, CacheHelper.ExpireTime);
                }
                return elevatorList;
            }
            else
            {
                return obj as List<MODEL.ElevatorInfoModel>;
            }

        }
    }
}
