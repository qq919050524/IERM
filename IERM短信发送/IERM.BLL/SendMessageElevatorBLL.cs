using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class SendMessageElevatorBLL
    {
        private DAL.SendMessageElevatorDAL _dal = new DAL.SendMessageElevatorDAL();

        /// <summary>
        /// 根据aid和registrationCode获取短信消息
        /// </summary>
        /// <param name="aID"></param>
        /// <param name="registrationCode"></param>
        /// <returns></returns>
        public Model.SendMessageElevatorModel getModel(int aID, string registrationCode)
        {
            return _dal.getModel(aID, registrationCode);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool Add(Model.SendMessageElevatorModel model)
        {
            return _dal.Add(model);
        }
    }
}
