using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 物业公司信息实体
	/// </summary>
	[Serializable]
    public partial class PropertyInfoModel
    {
        public PropertyInfoModel()
        { }
        #region Model
        private int _propertyid;
        private string _propertyname;
        private string _intro;
        private bool _isdel = false;

        /// <summary>
        /// 公司编号
        /// </summary>
        public int propertyID
        {
            set { _propertyid = value; }
            get { return _propertyid; }
        }

        /// <summary>
        /// 物业公司名
        /// </summary>
        public string propertyName
        {
            set { _propertyname = value; }
            get { return _propertyname; }
        }

        /// <summary>
        /// 公司介绍（可放富文本）
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
