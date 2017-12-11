using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 系统类型:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class SystemTypeModel
    {
        public SystemTypeModel()
        { }
        #region Model
        private int _tid;
        private string _typename;
        private bool _isdel = false;
        /// <summary>
        /// 系统类型编号（主键）
        /// </summary>
        public int tID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string typeName
        {
            set { _typename = value; }
            get { return _typename; }
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
