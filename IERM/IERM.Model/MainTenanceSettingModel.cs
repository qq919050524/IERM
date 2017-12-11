using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 维保计划:实体类 
    /// </summary>
    [Serializable]
    public partial class MainTenanceSettingModel
    {
        public MainTenanceSettingModel()
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
        private List<MainTenanceContentModel> _mcontentlist;

        /// <summary>
        /// 维保计划id
        /// </summary>
        public int sID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 设备id
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
        /// 是否循环（true:周期执行   false:只执行一次）
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
        /// 维保计划状态
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
        /// 巡检（维保）内容列表
        /// </summary>
        public List<MainTenanceContentModel> mcontentList
        {
            get
            {
                return _mcontentlist;
            }

            set
            {
                _mcontentlist = value;
            }
        }
        #endregion Model

    }
}
