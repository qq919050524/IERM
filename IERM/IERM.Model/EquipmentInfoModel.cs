using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 设备信息:实体类
    /// </summary>
    [Serializable]
    public partial class EquipmentInfoModel
    {
        public EquipmentInfoModel()
        { }
        #region Model
        private int _eid;
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
        private string _typeName;
        private string _device_type_code;

        /// <summary>
        /// 设备编号
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
        /// 所属设备房编号
        /// </summary>
        public int devhouseID
        {
            set { _devhouseid = value; }
            get { return _devhouseid; }
        }
        /// <summary>
        /// 所属系统编号
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
        /// 系统类型
        /// </summary>
        public string typeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                _typeName = value;
            }
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string device_type_code
        {
            get
            {
                return _device_type_code;
            }

            set
            {
                _device_type_code = value;
            }
        }
        #endregion Model

    }

    public partial class EquipmentInfoModel
    {
        public string devide_type_name { get; set; }
    }

}
