using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 报警设置记录
	/// </summary>
	[Serializable]
    public partial class AlarmSettingModel : AlarmTypeModel
    {
        public AlarmSettingModel()
        { }
        #region Model
        private int _sid;
        private int _devid = 0;
        private decimal _maxvalue = 1000.000M;
        private decimal _minvalue = 0.000M;
        private bool _iswork = true;
        private int _delayed = 60;
        private bool _issend = false;

        /// <summary>
        /// 流水号
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
        }

        /// <summary>
        /// 设备编号
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }

        /// <summary>
        /// 报警值上限
        /// </summary>
        public decimal maxValue
        {
            set { _maxvalue = value; }
            get { return _maxvalue; }
        }

        /// <summary>
        /// 报警值下限
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
        /// 延时时间（单位：秒）
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
        #endregion Model

    }
}
