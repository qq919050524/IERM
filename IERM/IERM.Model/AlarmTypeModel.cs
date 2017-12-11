using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 报警类型实体
	/// </summary>
	[Serializable]
    public partial class AlarmTypeModel
    {
        public AlarmTypeModel()
        { }
        #region Model
        private string _alarmcode;
        private string _alarmname;
        private int _devtype = 0;
        private bool _isdigital = false;
        private bool _isdel = false;
        private int _sysType = 0;

        /// <summary>
        /// 报警编码
        /// </summary>
        public string alarmCode
        {
            set { _alarmcode = value; }
            get { return _alarmcode; }
        }

        /// <summary>
        /// 报警名称
        /// </summary>
        public string alarmName
        {
            set { _alarmname = value; }
            get { return _alarmname; }
        }

        /// <summary>
        /// 报警所属设备房类型（0为全部类型通用 ）
        /// </summary>
        public int devType
        {
            set { _devtype = value; }
            get { return _devtype; }
        }

        /// <summary>
        /// 是否是数字量报警（0模拟量  1数字量）
        /// </summary>
        public bool isDigital
        {
            set { _isdigital = value; }
            get { return _isdigital; }
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
        /// 系统类型
        /// </summary>
        public int sysType
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
        #endregion Model

    }
}
