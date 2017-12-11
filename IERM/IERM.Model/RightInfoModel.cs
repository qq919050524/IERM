using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// rightinfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class RightInfoModel
    {
        public RightInfoModel()
        { }
        #region Model
        private int _rid;
        private string _rightname;
        private string _intro;
        private bool _isdel = false;

        /// <summary>
        /// 权限id
        /// </summary>
        public int rid
        {
            set { _rid = value; }
            get { return _rid; }
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string rightName
        {
            set { _rightname = value; }
            get { return _rightname; }
        }

        /// <summary>
        /// 权限说明
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
        #endregion Model

    }
}
