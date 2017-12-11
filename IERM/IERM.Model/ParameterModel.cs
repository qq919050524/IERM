using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 获取某小区的设备房列表所需参数
    /// </summary>
    [Serializable]
    public partial class ParameterModel
    {
        public ParameterModel()
        {
        }
        //------------------------------------- 获取某物业公司所有小区-----------------------------//
        /// <summary>
        /// 物业公司ID
        /// </summary>
        private int _propertymid;

        /// <summary>
        /// 城市ID
        /// </summary>
        private int _pcityid;

        public int Propertymid
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

        public int Pcityid
        {
            get
            {
                return _pcityid;
            }

            set
            {
                _pcityid = value;
            }
        }
        //----------------------------------设备房精确到小区----------------------------------------//
        /// <summary>
        /// 小区ID
        /// </summary>
        private int _communityid;
        /// <summary>
        /// 城市ID
        /// </summary>
        private int _areaid;
        /// <summary>
        /// 设备类型
        /// </summary>
        private int _devtype;
        /// <summary>
        /// 所属公司ID
        /// </summary>
        private int _propertyid;

        public int Communityid
        {
            get
            {
                return _communityid;
            }

            set
            {
                _communityid = value;
            }
        }

        public int Areaid
        {
            get
            {
                return _areaid;
            }

            set
            {
                _areaid = value;
            }
        }

        public int Devtype
        {
            get
            {
                return _devtype;
            }

            set
            {
                _devtype = value;
            }
        }

        public int Propertyid
        {
            get
            {
                return _propertyid;
            }

            set
            {
                _propertyid = value;
            }
        }
    }
}
