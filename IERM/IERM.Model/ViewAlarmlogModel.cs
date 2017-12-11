using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 报警日志实体类
	/// </summary>
	[Serializable]
    public partial class ViewAlarmlogModel
    {
        public ViewAlarmlogModel()
        { }
        #region Model
        private int _aid = 0;
        private int _devid;
        private string _alarmcode;
        private decimal _alarmvalue = 0.000M;
        private int _alarmstate = 1;
        private DateTime _inserttime;
        private string _alarmname;
        private string _devname;
        private string _communityname;
        private string _propertyname;
        private string _cityname;
        private string _provincename;
        private string _devtypename;
        private int _areaid = 0;
        private int _propertyid = 0;
        private int _dtid = 0;
        private int _systypeID;
        private string _systypeName;

        /// <summary>
        /// 主键 报警id
        /// </summary>
        public int aID
        {
            set { _aid = value; }
            get { return _aid; }
        }

        /// <summary>
        /// 设备号
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }

        /// <summary>
        /// 报警编码
        /// </summary>
        public string alarmCode
        {
            set { _alarmcode = value; }
            get { return _alarmcode; }
        }

        /// <summary>
        /// 报警值
        /// </summary>
        public decimal alarmValue
        {
            set { _alarmvalue = value; }
            get { return _alarmvalue; }
        }

        /// <summary>
        /// 报警状态（-2 过低  -1异常 1正常  2过高）
        /// </summary>
        public int alarmState
        {
            set { _alarmstate = value; }
            get { return _alarmstate; }
        }

        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime insertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
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
        /// 设备名
        /// </summary>
        public string devName
        {
            set { _devname = value; }
            get { return _devname; }
        }

        /// <summary>
        /// 所属小区名
        /// </summary>
        public string communityName
        {
            set { _communityname = value; }
            get { return _communityname; }
        }

        /// <summary>
        /// 所属物业公司名
        /// </summary>
        public string propertyName
        {
            set { _propertyname = value; }
            get { return _propertyname; }
        }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string cityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string provinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }

        /// <summary>
        /// 设备类型名称
        /// </summary>
        public string devTypeName
        {
            set { _devtypename = value; }
            get { return _devtypename; }
        }

        /// <summary>
        /// 城市编号
        /// </summary>
        public int areaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }

        /// <summary>
        /// 物业公司编号
        /// </summary>
        public int propertyID
        {
            set { _propertyid = value; }
            get { return _propertyid; }
        }

        /// <summary>
        /// 设备类型编号
        /// </summary>
        public int dtID
        {
            set { _dtid = value; }
            get { return _dtid; }
        }

        /// <summary>
        /// 系统类型编号
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
