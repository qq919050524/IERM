using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 用户日志：实体类  //liuli :TODO:该功能未完成
    /// </summary>
    [Serializable]
    public partial class LoginLogModel
    {
        #region 登入日志 Model
        public LoginLogModel()
        { }
        private int _id;
        private string _loginIP;
        private DateTime _logintime;
        private string _remaks;
        private string _usename;

        /// <summary>
        /// 用户id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 登入ip
        /// </summary>
        public string loginIP
        {
            set { _loginIP = value; }
            get { return _loginIP; }
        }
        /// <summary>
        /// 登入时间
        /// </summary>
        public DateTime logintime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remaks
        {
            set { _remaks = value; }
            get { return _remaks; }
        }
        
        /// <summary>
        /// 用户名称
        /// </summary>
        public string username
        {
            set { _usename = value; }
            get { return _usename; }
        }
        #endregion


    }
}
