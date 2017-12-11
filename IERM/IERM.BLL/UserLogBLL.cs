using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    /// <summary>
    /// 记录用户操作
    /// </summary>
    public partial class UserLogBLL
    {
        private readonly UserLogDAL user_log = new UserLogDAL();

        /// <summary>
        /// 获取用户日志
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public List<UserLogModel> GetUserLog(int pageindex, int pagesize, DateTime begintime, DateTime endtime)
        {
            return user_log.GetUserLog("", pageindex, pagesize);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public int Add(UserLogModel model)
        {
            return user_log.Add(model);
        }

        /// <summary>
        /// 添加用户日志
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="propertyName">所属小区名字</param>
        ///<param name="operationName">操作描述</param>
        public void addUserLog(int uid, string operationName)
        {
            //string uid = HttpContext.Current.Request.Cookies["userinfo"]["userid"];
            // List<propertyinfo> propertyinfolist = null;
            UserInfoBLL userinfo_bll = new UserInfoBLL();
            PropertyInfoDAL property_dal = new PropertyInfoDAL();
            var u = userinfo_bll.GetModel(uid);
            var pid = property_dal.GetPropertyID(u.companyName);
            int a = pid[0].propertyID;
            var userlog = new UserLogModel()
            {
                userID = uid,

                OperationTime = DateTime.Now.ToString(),
                OperationName = operationName,
                IsDel = false,
                PropertyName = u.companyName,
                Pid = pid[0].propertyID
        };
            Add(userlog);
        }
    }
}
