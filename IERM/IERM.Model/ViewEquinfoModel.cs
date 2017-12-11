using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 设备信息实体类
    /// </summary>
    [Serializable]
    public partial class ViewEquinfoModel
    {
        public ViewEquinfoModel()
        { }
        #region Model
        private int _eid = 0;
        private string _equname;
        private string _equcode;
        private string _equnum;
        private string _queimgpath;
        private int _devhouseid;
        private int _systypeid;
        private DateTime _setupdate;
        private DateTime _startupdate;
        private int _agelimit = 15;
        private string _manufacturer;
        private string _supplier;
        private string _suppliercontact;
        private string _mdepartment;
        private string _mpname;
        private string _mphonenum;
        private bool _isdel = false;
        private string _typename;
        private string _devname;
        private string _communityname;
        private string _cityname;
        private string _provincename;
        private string _propertyname;
        private List<EquipmentaccModel> _equacclist;
        private int _cityid = 0;
        private int _provinceid = 0;
        private int _communityid;
        private int _propertyid = 0;
        /// <summary>
        /// 设备号（主键  流水号）
        /// </summary>
        public int eID
        {
            set { _eid = value; }
            get { return _eid; }
        }
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
        /// 设备图片地址
        /// </summary>
        public string queImgPath
        {
            set { _queimgpath = value; }
            get { return _queimgpath; }
        }
        /// <summary>
        /// 设备所属设备房编号
        /// </summary>
        public int devhouseID
        {
            set { _devhouseid = value; }
            get { return _devhouseid; }
        }
        /// <summary>
        /// 设备所属系统编号
        /// </summary>
        public int sysTypeID
        {
            set { _systypeid = value; }
            get { return _systypeid; }
        }
        /// <summary>
        /// 安装日期
        /// </summary>
        public DateTime setupDate
        {
            set { _setupdate = value; }
            get { return _setupdate; }
        }
        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime startupDate
        {
            set { _startupdate = value; }
            get { return _startupdate; }
        }
        /// <summary>
        /// 使用年限
        /// </summary>
        public int agelimit
        {
            set { _agelimit = value; }
            get { return _agelimit; }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
        }
        /// <summary>
        /// 供应商
        /// </summary>
        public string supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 供应商联系人
        /// </summary>
        public string supplierContact
        {
            set { _suppliercontact = value; }
            get { return _suppliercontact; }
        }
        /// <summary>
        /// 维保部门
        /// </summary>
        public string mDepartment
        {
            set { _mdepartment = value; }
            get { return _mdepartment; }
        }
        /// <summary>
        /// 维保人
        /// </summary>
        public string mpName
        {
            set { _mpname = value; }
            get { return _mpname; }
        }
        /// <summary>
        /// 维保人电话
        /// </summary>
        public string mPhoneNum
        {
            set { _mphonenum = value; }
            get { return _mphonenum; }
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
        /// 类型名
        /// </summary>
        public string typeName
        {
            set { _typename = value; }
            get { return _typename; }
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
        /// 小区名
        /// </summary>
        public string communityName
        {
            set { _communityname = value; }
            get { return _communityname; }
        }
        /// <summary>
        /// 城市名
        /// </summary>
        public string cityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 省份名
        /// </summary>
        public string provinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
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
		/// 城市id
		/// </summary>
		public int cityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 省份id
        /// </summary>
        public int provinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 小区id
        /// </summary>
        public int communityID
        {
            set { _communityid = value; }
            get { return _communityid; }
        }
        /// <summary>
        /// 物业公司id
        /// </summary>
        public int propertyID
        {
            set { _propertyid = value; }
            get { return _propertyid; }
        }
        /// <summary>
        /// 设备附件集合
        /// </summary>
        public List<EquipmentaccModel> equaccList
        {
            get
            {
                if(_equacclist == null)
                {
                    _equacclist = new List<EquipmentaccModel>();
                }
                return _equacclist;
            }

            set
            {
                _equacclist = value;
            }
        }
        #endregion Model

    }
}
