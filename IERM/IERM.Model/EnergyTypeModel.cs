using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// 能耗实体类
	/// </summary>
	[Serializable]
    public partial class EnergyTypeModel
    {
        public EnergyTypeModel()
        { }
        #region Model
        private int _tid;
        private int _pid = 0;
        private string _typename;
        private bool _isdel = false;

        /// <summary>
        /// 编号
        /// </summary>
        public int tID
        {
            set { _tid = value; }
            get { return _tid; }
        }

        /// <summary>
        /// 父id
        /// </summary>
        public int pID
        {
            set { _pid = value; }
            get { return _pid; }
        }


        /// <summary>
        /// 能耗类型名
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
