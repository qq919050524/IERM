using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 维保计划试图实体
    /// </summary>
    /// <summary>
	[Serializable]
    public partial class ViewMainTenanceSettingModel
    {
        public ViewMainTenanceSettingModel()
        { }
        #region Model
        private string _equname;
        private string _equcode;
        private string _equnum;
        private int _sid = 0;
        private int _equid;
        private int _mtype = 1;
        private int _cyclength;
        private int _cycunit;
        private bool _iscyclic = false;
        private DateTime _stratdate;
        private bool _status = false;
        private bool _isdel = false;
        private string _devname;
        private string _systypename;
        private int _mtypeid;
        private string _mtypename;
        private int _systypeid;
        private int _devhouseid;
        private List<MainTenanceTypeModel> _mtypelist;
        private Dictionary<string, string> _flagtime;

        /// <summary>
        /// 设备名称
        /// </summary>
        public string equName
        {
            set { _equname = value; }
            get { return _equname; }
        }
        /// <summary>
        /// 设备编码
        /// </summary>
        public string equCode
        {
            set { _equcode = value; }
            get { return _equcode; }
        }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string equNum
        {
            set { _equnum = value; }
            get { return _equnum; }
        }
        /// <summary>
        /// 维保计划ID
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
        /// 是否循环（true：周期执行   false：只执行一次）
        /// </summary>
        public bool isCyclic
        {
            set { _iscyclic = value; }
            get { return _iscyclic; }
        }
        /// <summary>
        /// 计划起始日期
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
        /// 设备房名称
        /// </summary>
        public string devName
        {
            set { _devname = value; }
            get { return _devname; }
        }
        /// <summary>
        /// 所属系统类型名称
        /// </summary>
        public string systypeName
        {
            set { _systypename = value; }
            get { return _systypename; }
        }
        /// <summary>
        /// 维保类型id
        /// </summary>
        public int mtypeID
        {
            set { _mtypeid = value; }
            get { return _mtypeid; }
        }
        /// <summary>
        /// 维保类型名称
        /// </summary>
        public string mtypeName
        {
            set { _mtypename = value; }
            get { return _mtypename; }
        }

        /// <summary>
        /// 所属类型id
        /// </summary>
        public int systypeID
        {
            get
            {
                return _systypeid;
            }

            set
            {
                _systypeid = value;
            }
        }

        /// <summary>
        /// 设备房ID
        /// </summary>
        public int devhouseID
        {
            get
            {
                return _devhouseid;
            }

            set
            {
                _devhouseid = value;
            }
        }

        /// <summary>
        /// 维保明细
        /// </summary>
        public List<MainTenanceTypeModel> mtypeList
        {
            get
            {
                return _mtypelist;
            }

            set
            {
                _mtypelist = value;
            }
        }

        /// <summary>
        /// 上次，下次维保时间
        /// </summary>
        public Dictionary<string, string> flagTime
        {
            get
            {
                return _flagtime;
            }

            set
            {
                _flagtime = value;
            }
        }

        #endregion Model

    }
}
