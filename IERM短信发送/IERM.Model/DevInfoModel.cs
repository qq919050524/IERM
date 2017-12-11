using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.Model
{
    /// <summary>
	/// 设备类型实体
	/// </summary>
	[Serializable]
    public partial class DevInfoModel
    {

        #region Model
        private int _devid;
        private string _devname;
        private int _devtype = 0;
        private int _communityid;
        private bool _isdel = false;
        private int _sort = 1000;
        private string _devTypeName;
        private string _devhousetypes;
        private int _systypeID;
        private string _systypeName;

        /// <summary>
        /// 设备ID
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string devName
        {
            set { _devname = value; }
            get { return _devname; }
        }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int devType
        {
            set { _devtype = value; }
            get { return _devtype; }
        }

        /// <summary>
        /// 所属小区id
        /// </summary>
        public int communityID
        {
            set { _communityid = value; }
            get { return _communityid; }
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
        /// 排序
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }

        /// <summary>
        /// 设备类型名称
        /// </summary>
        public string devTypeName
        {
            get
            {
                return _devTypeName;
            }

            set
            {
                _devTypeName = value;
            }
        }
        /// <summary>
        /// 设备房所含类型
        /// </summary>
        public string devhouseTypes
        {
            get
            {
                return _devhousetypes;
            }

            set
            {
                _devhousetypes = value;
            }
        }

        /// <summary>
        /// 系统类型ID
        /// </summary>
        public int systypeID
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
        /// <summary>
        /// 系统类型名称
        /// </summary>
        public string systypeName
        {
            get
            {
                return _systypeName;
            }

            set
            {
                _systypeName = value;
            }
        }
        #endregion Model

    }
}
