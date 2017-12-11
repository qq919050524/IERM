using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 用户信息实体
	/// </summary>
	[Serializable]
    public partial class UserInfoModel
    {
        public UserInfoModel()
        { }
        #region Model
        private int _uid;
        private string _loginname;
        private string _password;
        private string _nickname;
        private string _mobile;
        private string _headimg;
        private string _companyname;
        private string _departmentname;
        private string _remark;
        private bool _isdel = false;

        private List<int> _communityList;
        private List<ActionInfoModel> _actionList;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int uid
        {
            set { _uid = value; }
            get { return _uid; }
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public string loginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string headimg
        {
            set { _headimg = value; }
            get { return _headimg; }
        }

        /// <summary>
        /// 所属公司名
        /// </summary>
        public string companyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }

        /// <summary>
        /// 所属部门名
        /// </summary>
        public string departmentName
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }

        /// <summary>
        /// 权限行为列表
        /// </summary>
        public List<ActionInfoModel> actionList
        {
            get
            {
                return _actionList;
            }

            set
            {
                _actionList = value;
            }
        }
        /// <summary>
        /// 授权小区列表
        /// </summary>
        public List<int> communityList
        {
            get
            {
                return _communityList;
            }

            set
            {
                _communityList = value;
            }
        }

        #endregion Model



    }
}
