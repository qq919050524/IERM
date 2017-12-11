using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// devtype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class DevTypeModel
    {
        public DevTypeModel()
        { }
        #region Model
        private int _dtid;
        private string _devtypename;
        private string _devtypecode;
        private bool _isdel = false;
        private int _sort = 1000;

        /// <summary>
        /// 流水号（类型编号）
        /// </summary>
        public int dtID
        {
            set { _dtid = value; }
            get { return _dtid; }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string devTypeName
        {
            set { _devtypename = value; }
            get { return _devtypename; }
        }
        /// <summary>
        /// 类型编码
        /// </summary>
        public string devTypeCode
        {
            set { _devtypecode = value; }
            get { return _devtypecode; }
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
        #endregion Model

    }
}
