using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// energyinfo:能耗实体类
    /// </summary>
    [Serializable]
    public partial class EnergyInfoModel
    {
        public EnergyInfoModel()
        { }
        #region Model
        private int _nid;
        private int _communityid;
        private int _typeid = 0;
        private int _year = 2017;
        private int _month = 1;
        private decimal _engvalue;
        private DateTime _inserttime;
        private int _pID;
        private int _tID;
        private string _typeName;
        private string __communityName;

        /// <summary>
        /// 录入编号
        /// </summary>
        public int nID
        {
            set { _nid = value; }
            get { return _nid; }
        }
        /// <summary>
        /// 小区编号
        /// </summary>
        public int communityID
        {
            set { _communityid = value; }
            get { return _communityid; }
        }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int typeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 年份
        /// </summary>
        public int year
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 月份
        /// </summary>
        public int month
        {
            set { _month = value; }
            get { return _month; }
        }
        /// <summary>
        /// 能耗值
        /// </summary>
        public decimal engValue
        {
            set { _engvalue = value; }
            get { return _engvalue; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime insertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }

        /// <summary>
        /// 父类型id
        /// </summary>
        public int pID
        {
            get
            {
                return _pID;
            }

            set
            {
                _pID = value;
            }
        }

        /// <summary>
        /// 能耗类型名称
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
        /// 小区名
        /// </summary>
        public string communityName
        {
            get
            {
                return __communityName;
            }

            set
            {
                __communityName = value;
            }
        }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int tID
        {
            get
            {
                return _tID;
            }

            set
            {
                _tID = value;
            }
        }
        #endregion Model

    }
}
