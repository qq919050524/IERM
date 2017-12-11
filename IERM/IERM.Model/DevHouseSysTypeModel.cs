using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// devhousesystype:设备房所含系统类型实体类
	/// </summary>
	[Serializable]
    public partial class DevHouseSysTypeModel
    {
        public DevHouseSysTypeModel()
        { }
        #region Model
        private int _sid;
        private int _devhouseid;
        private int _systypeid;
        /// <summary>
        /// 流水号
        /// </summary>
        public int sID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 设备房编号
        /// </summary>
        public int devhouseID
        {
            set { _devhouseid = value; }
            get { return _devhouseid; }
        }
        /// <summary>
        /// 系统编号
        /// </summary>
        public int systypeID
        {
            set { _systypeid = value; }
            get { return _systypeid; }
        }
        #endregion Model

    }
}
