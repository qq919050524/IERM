using IERM.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IERM.WCFService.DevHouse
{
    /// <summary>
    /// ECCM系统设备房基类
    /// </summary>
    public abstract class BaseDevHouse
    {
        /// <summary>
        /// 设备编号（数字）
        /// </summary>
        public int DevNum { get; set; }

        /// <summary>
        /// 设备房报警设置列表
        /// </summary>
        public List<MODEL.AlarmSettingModel> AlarmSettingList { get; set; }

        /// <summary>
        /// 数据插入时间
        /// </summary>
        public DateTime InsertTime { get; set; }

        public abstract byte[] Request();

        public abstract BaseDevHouse Decode(byte[] data);

        public abstract string ToJson();

        private readonly BLL.AlarmLogBLL alarmlog_bll = new BLL.AlarmLogBLL();

        /// <summary>
        /// 获取数字量报警
        /// </summary>
        protected void GetDigitalAlarm(bool _value, string _alarmcode)
        {
            if (AlarmSettingList.Count(c => c.alarmCode == _alarmcode) > 0)
            {
                var tmp = AlarmSettingList.Where(c => c.alarmCode == _alarmcode).FirstOrDefault();
                tmp.AlarmLogValue.devID = DevNum;
                tmp.AlarmLogValue.devName = tmp.devName;
                tmp.AlarmLogValue.alarmCode = _alarmcode;
                tmp.AlarmLogValue.alarmName = tmp.alarmName;
                tmp.AlarmLogValue.alarmValue = Convert.ToDecimal(_value);
                tmp.AlarmLogValue.alarmState = _value ? 1 : -1;//_value=false时为异常状态
                tmp.AlarmLogValue.insertTime = DateTime.Now;

                if(!tmp.IsAlarm)
                {
                    if (!_value)
                    {
                        if (!tmp.TimerState)
                        {
                            tmp.TimerState = true;
                            tmp.Timercallback = alarmlog_bll.Add;
                            tmp.ParamTimer.Change(tmp.delayed * 1000, Timeout.Infinite);
                        }
                    }
                    else
                    {
                        tmp.ParamTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        tmp.TimerState = false;
                    }
                }
                else
                {
                    if (_value)
                    {
                        if (!tmp.TimerState)
                        {
                            tmp.TimerState = true;
                            tmp.Timercallback = alarmlog_bll.ReSet;
                            tmp.ParamTimer.Change(tmp.delayed * 1000, Timeout.Infinite);
                        }
                    }
                    else
                    {
                        tmp.ParamTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        tmp.TimerState = false;
                    }
                }
            }
        }

        /// <summary>
        /// 获取模拟量报警
        /// </summary>
        protected void GetAnalogAlarm(decimal _value, string _alarmcode)
        {
            if (AlarmSettingList.Count(c => c.alarmCode == _alarmcode) > 0)
            {
                var tmp = AlarmSettingList.Where(c => c.alarmCode == _alarmcode).FirstOrDefault();
                tmp.AlarmLogValue.devID = DevNum;
                tmp.AlarmLogValue.devName = tmp.devName;
                tmp.AlarmLogValue.alarmCode = _alarmcode;
                tmp.AlarmLogValue.alarmName = tmp.alarmName;
                tmp.AlarmLogValue.alarmValue = _value;
                tmp.AlarmLogValue.insertTime = DateTime.Now;
                if (_value >= tmp.maxValue || _value <= tmp.minValue)
                {
                    if (_value <= tmp.minValue)
                    {
                        tmp.AlarmLogValue.alarmState = -2;//超低报警
                    }
                    else
                    {
                        tmp.AlarmLogValue.alarmState = 2;//超高报警
                    }
                    if (!tmp.IsAlarm)
                    {
                        if (!tmp.TimerState)
                        {
                            tmp.TimerState = true;
                            tmp.Timercallback = alarmlog_bll.Add;
                            tmp.ParamTimer.Change(tmp.delayed * 1000, Timeout.Infinite);
                        }
                    }
                    else
                    {
                        if (tmp.TimerState)
                        {
                            tmp.ParamTimer.Change(Timeout.Infinite, Timeout.Infinite);
                            tmp.TimerState = false;
                        }
                    }
                }
                else
                {
                    tmp.AlarmLogValue.alarmState = 1;//恢复正常
                    if (tmp.IsAlarm)
                    {
                        if (!tmp.TimerState)
                        {
                            tmp.TimerState = true;
                            tmp.Timercallback = alarmlog_bll.ReSet;   //liuli ：检查当前状态如果正常就新增一条数据记录代码正常
                            tmp.ParamTimer.Change(tmp.delayed * 1000, Timeout.Infinite);
                        }
                    }
                    else
                    {
                        if (tmp.TimerState)
                        {
                            tmp.ParamTimer.Change(Timeout.Infinite, Timeout.Infinite);
                            tmp.TimerState = false;
                        }
                    }

                }
            }
        }

    }
}
