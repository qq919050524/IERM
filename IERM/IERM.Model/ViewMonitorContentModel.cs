using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 运行监控展示信息  JINXIN
    /// </summary>
    [Serializable]
   public partial class ViewMonitorContentModel
    {
        /// <summary>
        /// 流水号（主键  自增）
        /// </summary>
        private int _tID;
        /// <summary>
        /// 设备房编号
        /// </summary>
        private int _devhouseID;
        /// <summary>
        /// 系统类型编号
        /// </summary>
        private int _sysType;
        /// <summary>
        /// 内容编码
        /// </summary>
        private string _contentCode;
        /// <summary>
        /// 内容名称
        /// </summary>
        private string _contentName;
        /// <summary>
        /// 删除标志
        /// </summary>
        private int _isDel;

        /// <summary>
        /// 设备房
        /// </summary>
        private string _devName;

        /// <summary>
        /// 设备ID
        /// </summary>
        private int _devID;

        /// <summary>
        /// 系统类型ID
        /// </summary>
        private int _systypeID;

        /// <summary>
        /// 类型名字
        /// </summary>
        private string _typeName;

        public int TID
        {
            get
            {
                return _tID;
            }

            set
            {
                _tID = value;
            }
        }

        public int DevhouseID
        {
            get
            {
                return _devhouseID;
            }

            set
            {
                _devhouseID = value;
            }
        }

        public int SysType
        {
            get
            {
                return _sysType;
            }

            set
            {
                _sysType = value;
            }
        }

        public string ContentCode
        {
            get
            {
                return _contentCode;
            }

            set
            {
                _contentCode = value;
            }
        }

        public string ContentName
        {
            get
            {
                return _contentName;
            }

            set
            {
                _contentName = value;
            }
        }

        public int IsDel
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

        public int SystypeID
        {
            get
            {
                return _systypeID;
            }

            set
            {
                _systypeID = value;
            }
        }

        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                _typeName = value;
            }
        }
    }
}
