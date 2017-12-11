using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// operationlog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class OperationLogModel
    {
        public OperationLogModel()
        { }
        #region Model

        private int _oid;
        private int _typeid;
        private string _typename;
        private int _userid;
        private string _nickname;
        private DateTime _optime;
        private string _details;
        private string _ipaddress;

        /// <summary>
        /// 日志id
        /// </summary>
        public int oid
        {
            set { _oid = value; }
            get { return _oid; }
        }

        /// <summary>
        /// 日志类型ID
        /// </summary>
        public int typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }

        
        /// <summary>
        /// 操作用户id
        /// </summary>
        public int userID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime opTime
        {
            set { _optime = value; }
            get { return _optime; }
        }

        /// <summary>
        /// 详情
        /// </summary>
        public string details
        {
            set { _details = value; }
            get { return _details; }
        }

        /// <summary>
        /// 操作类型名
        /// </summary>
        public string typeName
        {
            get
            {
                return _typename;
            }

            set
            {
                _typename = value;
            }
        }

        /// <summary>
        /// 操作人昵称
        /// </summary>
        public string nickName
        {
            get
            {
                return _nickname;
            }

            set
            {
                _nickname = value;
            }
        }

        /// <summary>
        /// 登录的ip地址
        /// </summary>
        public string ipAddress
        {
            get
            {
                return _ipaddress;
            }

            set
            {
                _ipaddress = value;
            }
        }


        #endregion Model

    }
}
