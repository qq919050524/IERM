using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public class AuthCommunityModel
    {
        private int _communityID;
        private string _communityName;
        private int _pCityID;
        private bool _isauth;
        private int _propertyMId = 0;
        /// <summary>
        /// 小区编号
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


        /// <summary>
        /// 城市编号
        /// </summary>
        public int pCityID
        {
            get
            {
                return _pCityID;
            }

            set
            {
                _pCityID = value;
            }
        }
        /// <summary>
        /// 是否被授权
        /// </summary>
        public bool isauth
        {
            get
            {
                return _isauth;
            }

            set
            {
                _isauth = value;
            }
        }
        /// <summary>
        /// 所属物业公司ID
        /// </summary>
        public int propertyMId
        {
            get
            {
                return _propertyMId;
            }

            set
            {
                _propertyMId = value;
            }
        }
    }
}
