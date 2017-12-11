using System;

namespace IERM.MODEL
{
    [Serializable]
    /// <summary>
    /// 省市小区信息实体
    /// </summary>
    public class AreaInfoModel
    {
        private int _cityid;
        private string _cityname;
        private int _provid;
        private string _provname;
        private int _communityID;
        private string _communityName;

        /// <summary>
        /// 城市id
        /// </summary>
        public int cityID
        {
            get
            {
                return _cityid;
            }

            set
            {
                _cityid = value;
            }
        }

        /// <summary>
        /// 城市名
        /// </summary>
        public string cityName
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
        /// 省份编号
        /// </summary>
        public int provID
        {
            get
            {
                return _provid;
            }

            set
            {
                _provid = value;
            }
        }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string provName
        {
            get
            {
                return _provname;
            }

            set
            {
                _provname = value;
            }
        }

        /// <summary>
        /// 小区id
        /// </summary>
        public int communityID
        {
            get
            {
                return _communityID;
            }

            set
            {
                _communityID = value;
            }
        }

        /// <summary>
        /// 小区名称
        /// </summary>
        public string communityName
        {
            get
            {
                return _communityName;
            }

            set
            {
                _communityName = value;
            }
        }

    }
}
