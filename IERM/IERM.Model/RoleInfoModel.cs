using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 角色信息
	/// </summary>
	[Serializable]
    public partial class RoleInfoModel
    {
        public RoleInfoModel()
        { }
        #region Model
        private int _rid;
        private string _rolecode;
        private string _rolename;
        private string _intro;
        private bool _isdel = false;
        private int _propertyID;

        /// <summary>
        /// 角色id 主键
        /// </summary>
        public int rid
        {
            set { _rid = value; }
            get { return _rid; }
        }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string roleCode
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }

        /// <summary>
        /// 角色名
        /// </summary>
        public string roleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }

        /// <summary>
        /// 角色简介
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

        public int propertyID
        {
            get
            {
                return _propertyID;
            }

            set
            {
                _propertyID = value;
            }
        }
        #endregion Model

    }
}
