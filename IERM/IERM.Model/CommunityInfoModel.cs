using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 小区信息实体
	/// </summary>
	[Serializable]
    public partial class CommunityInfoModel
    {
        public CommunityInfoModel()
        { }
        #region Model
        private int _communityid;
        private string _communityname;
        private int _pcityid = 0;
        private string _cityname;
        private int _provinceid = 0;
        private string __provincename;
        private decimal _culongitude=0;
        private decimal _culatitude=0;
        private string _address;
        private string _intro;
        private bool _isdel = false;
        private int _sort = 1000;
        private int _propertymid = 0;
        private decimal _acreage;
        private string _propertyname;

        /// <summary>
        /// 小区ID
        /// </summary>
        public int communityID
        {
            set { _communityid = value; }
            get { return _communityid; }
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
        /// 小区所属城市ID
        /// </summary>
        public int pCityID
        {
            set { _pcityid = value; }
            get { return _pcityid; }
        }

        /// <summary>
        /// 小区经度
        /// </summary>
        public decimal cuLongitude
        {
            set { _culongitude = value; }
            get { return _culongitude; }
        }

        /// <summary>
        /// 小区纬度
        /// </summary>
        public decimal cuLatitude
        {
            set { _culatitude = value; }
            get { return _culatitude; }
        }

        /// <summary>
        /// 小区地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }

        /// <summary>
        /// 小区介绍
        /// </summary>
        public string intro
        {
            set { _intro = value; }
            get { return _intro; }
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
        /// 排序
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }

        /// <summary>
        /// 小区物业公司编号
        /// </summary>
        public int propertyMId
        {
            get
            {
                return _propertymid;
            }

            set
            {
                _propertymid = value;
            }
        }

        /// <summary>
        /// 所属省份ID
        /// </summary>
        public int provinceid
        {
            get
            {
                return _provinceid;
            }

            set
            {
                _provinceid = value;
            }
        }

        /// <summary>
        /// 城市名
        /// </summary>
        public string cityname
        {
            get
            {
                return _cityname;
            }

            set
            {
                _cityname = value;
            }
        }

        /// <summary>
        /// 省份名
        /// </summary>
        public string provincename
        {
            get
            {
                return __provincename;
            }

            set
            {
                __provincename = value;
            }
        }

        /// <summary>
        /// 小区面积（单位;平方米）
        /// </summary>
        public decimal acreage
        {
            get
            {
                return _acreage;
            }

            set
            {
                _acreage = value;
            }
        }

        public string Propertyname
        {
            get
            {
                return _propertyname;
            }

            set
            {
                _propertyname = value;
            }
        }
        #endregion Model

    }
}
