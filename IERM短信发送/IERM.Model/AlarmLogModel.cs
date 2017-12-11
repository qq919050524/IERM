using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.Model
{
    /// <summary>
    /// 报警记录实体类
    /// </summary>
    public class AlarmLogModel
    {

        #region Model
        private int _aid;
        private int _devid;
        private string _devname;
        private string _alarmcode;
        private string _alarmname;
        private decimal _alarmvalue = 0.000M;
        private int _alarmstate = 1;
        private DateTime _inserttime;


        /// <summary>
        /// 流水号（主键）
        /// </summary>
        public int aID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 设备房编号
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
        /// 报警状态码
        /// </summary>
        public int alarmState
        {
            set { _alarmstate = value; }
            get { return _alarmstate; }
        }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime insertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        /// <summary>
        /// 设备房名称
        /// </summary>
        public string devName
        {
            get
            {
                return _devname;
            }

            set
            {
                _devname = value;
            }
        }
        /// <summary>
        /// 报警名称
        /// </summary>
        public string alarmName
        {
            get
            {
                return _alarmname;
            }

            set
            {
                _alarmname = value;
            }
        }
        #endregion Model
    }
}
