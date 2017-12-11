
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IERM.Message.Model
{
    [Serializable]
    /// <summary>
    /// 报警设置实体类
    /// </summary>
    public class AlarmSettingModel
    {

        #region Model
        private int _sid;
        private int _devid = 0;
        private string _devname;
        private string _alarmcode;
        private string _alarmname;
        private decimal _maxvalue = 0.000M;
        private decimal _minvalue = 0.000M;
        private bool _iswork = false;
        private int _delayed = 60;
        private bool _issend = false;

        /// <summary>
        /// 流水号（主键）
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
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
        /// 报警上限值
        /// </summary>
        public decimal maxValue
        {
            set { _maxvalue = value; }
            get { return _maxvalue; }
        }
        /// <summary>
        /// 报警下限值
        /// </summary>
        public decimal minValue
        {
            set { _minvalue = value; }
            get { return _minvalue; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool isWork
        {
            set { _iswork = value; }
            get { return _iswork; }
        }
        /// <summary>
        /// 延时（单位：秒）
        /// </summary>
        public int delayed
        {
            set { _delayed = value; }
            get { return _delayed; }
        }

        /// <summary>
        /// 是否发送短信
        /// </summary>
        public bool isSend
        {
            set { _issend = value; }
            get { return _issend; }
        }
        /// <summary>
        /// 设备房名
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
        /// 报价名称
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
