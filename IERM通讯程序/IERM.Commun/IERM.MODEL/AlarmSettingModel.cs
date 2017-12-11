using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IERM.MODEL
{
    [Serializable]
    /// <summary>
    /// 报警设置实体类
    /// </summary>
    public class AlarmSettingModel
    {
        public AlarmSettingModel()
        {
            
        }

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

        [JsonIgnore]
        /// <summary>
        /// 流水号（主键）
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        [JsonIgnore]
        /// <summary>
        /// 设备房编号
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }
        [JsonIgnore]
        /// <summary>
        /// 报警编码
        /// </summary>
        public string alarmCode
        {
            set { _alarmcode = value; }
            get { return _alarmcode; }
        }
        [JsonIgnore]
        /// <summary>
        /// 报警上限值
        /// </summary>
        public decimal maxValue
        {
            set { _maxvalue = value; }
            get { return _maxvalue; }
        }
        [JsonIgnore]
        /// <summary>
        /// 报警下限值
        /// </summary>
        public decimal minValue
        {
            set { _minvalue = value; }
            get { return _minvalue; }
        }
        [JsonIgnore]
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool isWork
        {
            set { _iswork = value; }
            get { return _iswork; }
        }
        [JsonIgnore]
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
        [JsonIgnore]
        public bool isSend
        {
            set { _issend = value; }
            get { return _issend; }
        }
        [JsonIgnore]
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
        [JsonIgnore]
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

        private System.Threading.Timer _paramtimer = null;
        [JsonIgnore]
        /// <summary>
        /// 计时器
        /// </summary>
        public System.Threading.Timer ParamTimer
        {
            get
            {
                if (_paramtimer == null)
                {
                    _paramtimer = new System.Threading.Timer(callback, null, Timeout.Infinite, Timeout.Infinite);
                }
                return _paramtimer;
            }
            set
            {
                _paramtimer = value;
            }
        }

        private void callback(object state)
        {
            if(Timercallback!=null)
            {
                if(AlarmLogValue.alarmState==1)
                {
                    IsAlarm = false;
                }
                else
                {
                    IsAlarm = true;
                }
                Timercallback(AlarmLogValue);
            }
            TimerState = false;
        }

        private bool _timerstate = false;
        [JsonIgnore]
        /// <summary>
        /// 计时器运行状态
        /// </summary>
        public bool TimerState
        {
            get
            {
                return _timerstate;
            }
            set
            {
                _timerstate = value;
            }
        }


        [JsonIgnore]
        /// <summary>
        /// 计时器回调委托
        /// </summary>
        public TimerCallback Timercallback { get; set; }

        private AlarmLogModel _alarmLogValue;
        /// <summary>
        /// 报警记录
        /// </summary>
        public AlarmLogModel AlarmLogValue
        {
            get
            {
                if(_alarmLogValue==null)
                {
                    _alarmLogValue = new AlarmLogModel();
                }
                return _alarmLogValue;
            }

            set
            {
                _alarmLogValue = value;
            }
        }


        private bool _isalarm = false;
        /// <summary>
        /// 是否报警
        /// </summary>
        [JsonIgnore]
        public bool IsAlarm
        {
            get
            {
                return _isalarm;
            }

            set
            {
                _isalarm = value;
            }
        }



    }
}
