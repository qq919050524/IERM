using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 维保类型:实体类
	/// </summary>
	[Serializable]
    public partial class MainTenanceTypeModel
    {
        public MainTenanceTypeModel()
        { }
        #region Model
        private int _mid;
        private int _systypeid;
        private string _mtypename;
        private bool _isdel = false;
        private int _sort = 10000;

        /// <summary>
        /// 巡检内容流水号
        /// </summary>
        public int mID
        {
            set { _mid = value; }
            get { return _mid; }
        }

        /// <summary>
        /// 所属系统编号
        /// </summary>
        public int systypeID
        {
            set { _systypeid = value; }
            get { return _systypeid; }
        }

        /// <summary>
        /// 巡检类型名称
        /// </summary>
        public string mtypeName
        {
            set { _mtypename = value; }
            get { return _mtypename; }
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
        /// 排序标志
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model

    }
}
