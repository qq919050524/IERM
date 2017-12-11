using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    [Serializable]
    public partial class UserLogModel
    {
        #region 用户操作日志 Model
        public UserLogModel() { }
        private int _userID;
       
        private string _operationName;
        private string _operationTime;
        private bool _isDel;
        private string _propertyName;
        private int _pid;

        /// <summary>
        /// 用户id
        /// </summary>
        public int userID
        {
            get
            {
                return _userID;
            }

            set
            {
                _userID = value;
            }
        }


        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperationName
        {
            get
            {
                return _operationName;
            }

            set
            {
                _operationName = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperationTime
        {
            get
            {
                return _operationTime;
            }

            set
            {
                _operationTime = value;
            }
        }

  

        /// <summary>
        /// 删除状态
        /// </summary>
        public bool IsDel
        {
            get
            {
                return _isDel;
            }

            set
            {
                _isDel = value;
            }
        }
        /// <summary>
        /// 所属公司名称
        /// </summary>
        public string PropertyName
        {
            get
            {
                return _propertyName;
            }
            set
            {
                _propertyName = value;
            }
        }

        /// <summary>
        /// 所属公司id
        /// </summary>
        public int Pid
        {
            get
            {
                return _pid;
            }
            set
            {
                _pid = value;
            }

        }


        #endregion
    }
}
