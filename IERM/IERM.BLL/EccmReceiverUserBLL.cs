using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EccmReceiverUserBLL
    {
        private EccmReceiverUserDAL _dal = new EccmReceiverUserDAL();
        /// <summary>
        /// 获取责任人和协同人员
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="receiverType">类型(1巡检2维保3维修)</param>
        /// <returns></returns>
        public List<EccmReceiverUserModel> GetEccmReceiverUserList(int orderID, int receiverType)
        {
            return _dal.GetEccmReceiverUserList(orderID, receiverType);
        }
    }
}
