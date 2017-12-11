using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    /// <summary>
    /// 维保计划实体类
    /// </summary>
    [Serializable]
    public class MaintenanceSettingModel
    {        
        public MaintenanceSettingModel()
        { }
        #region Model
        private int _sid;
        private int _equid;
        private int _mtype = 1;
        private int _cyclength;
        private int _cycunit;
        private bool _iscyclic = false;
        private DateTime _stratdate;
        private bool _status = false;
        private bool _isdel = false;
        private DateTime _logcreatetime;
        private DateTime _logoperatetime;
        private int _devhouseID;

        /// <summary>
        /// 计划流水号（主键 自增）
        /// </summary>
        public int sID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 设备编号
        /// </summary>
        public int equID
        {
            set { _equid = value; }
            get { return _equid; }
        }
        /// <summary>
        /// 计划类型（1：维保   2：巡检）
        /// </summary>
        public int mType
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        /// <summary>
        /// 周期长度
        /// </summary>
        public int cycLength
        {
            set { _cyclength = value; }
            get { return _cyclength; }
        }
        /// <summary>
        /// 周期单位（1：日    2：周     3：月）
        /// </summary>
        public int cycUnit
        {
            set { _cycunit = value; }
            get { return _cycunit; }
        }
        /// <summary>
        /// 是否循环
        /// </summary>
        public bool isCyclic
        {
            set { _iscyclic = value; }
            get { return _iscyclic; }
        }
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime stratDate
        {
            set { _stratdate = value; }
            get { return _stratdate; }
        }
        /// <summary>
        /// 运行状态（0停止  1启动）
        /// </summary>
        public bool status
        {
            set { _status = value; }
            get { return _status; }
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
        /// 工单创建时间
        /// </summary>
        public DateTime logcreatetime
        {
            get
            {
                return _logcreatetime;
            }

            set
            {
                _logcreatetime = value;
            }
        }
        /// <summary>
        /// 工单处理时间
        /// </summary>
        public DateTime logoperatetime
        {
            get
            {
                return _logoperatetime;
            }

            set
            {
                _logoperatetime = value;
            }
        }
        /// <summary>
        /// 设备房ID
        /// </summary>
        public int devhouseID
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
        #endregion Model
    }
}
