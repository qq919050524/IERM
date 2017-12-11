using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FX.ECCM.MODEL
{
    public class UserInfo
    {
        public UserInfo()
        { }
        /// <summary>
        /// 手机号
        /// </summary>
        private string _mobile;
        /// <summary>
        /// 昵称
        /// </summary>
        private string _nickName;
        /// <summary>
        /// 权限ID
        /// </summary>
        private int _roleID;
        /// <summary>
        /// 设备名
        /// </summary>
        private string _devName;
        /// <summary>
        /// 设备ID
        /// </summary>
        private int _devID;

        public string Mobile
        {
            get
            {
                return _mobile;
            }

            set
            {
                _mobile = value;
            }
        }

        public string NickName
        {
            get
            {
                return _nickName;
            }

            set
            {
                _nickName = value;
            }
        }

        public int RoleID
        {
            get
            {
                return _roleID;
            }

            set
            {
                _roleID = value;
            }
        }

        public string DevName
        {
            get
            {
                return _devName;
            }

            set
            {
                _devName = value;
            }
        }

        public int DevID
        {
            get
            {
                return _devID;
            }

            set
            {
                _devID = value;
            }
        }
    }
}
