using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 设备附件:实体类()
	/// </summary>
	[Serializable]
    public partial class EquipmentaccModel
    {
        public EquipmentaccModel()
        { }
        #region Model
        private int _aid;
        private int _equid;
        private string _accname;
        private string _accno;
        private string _accparameter;
        private string _other;
        /// <summary>
        /// 附件编号（主键）
        /// </summary>
        public int aID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 所属设备编号
        /// </summary>
        public int equID
        {
            set { _equid = value; }
            get { return _equid; }
        }
        /// <summary>
        /// 附件名
        /// </summary>
        public string accName
        {
            set { _accname = value; }
            get { return _accname; }
        }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string accNo
        {
            set { _accno = value; }
            get { return _accno; }
        }
        /// <summary>
        /// 技术参数
        /// </summary>
        public string accParameter
        {
            set { _accparameter = value; }
            get { return _accparameter; }
        }
        /// <summary>
        /// 其他信息
        /// </summary>
        public string other
        {
            set { _other = value; }
            get { return _other; }
        }
        #endregion Model
    }
}
