using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Views
{
    public abstract class BasePage: System.Web.UI.Page
    {
        private UserInfoModel _currentUser;
        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public UserInfoModel CurrentUser
        {
            get
            {
                if(_currentUser==null)
                {
                    _currentUser = Session["EccmUserinfo"] as UserInfoModel;
                }
                return _currentUser;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public abstract void Child_Load();
    }
}