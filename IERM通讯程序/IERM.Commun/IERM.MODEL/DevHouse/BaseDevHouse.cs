using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FX.ECCM.MODEL.DevHouse
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
        public List<MODEL.AlarmSetting> AlarmSettingList { get; set; }

        /// <summary>
        /// 数据插入时间
        /// </summary>
        public DateTime InsertTime { get; set; }

        public abstract byte[] Request();

        public abstract BaseDevHouse Decode(byte[] data);

        public abstract string ToJson();

    }
}
