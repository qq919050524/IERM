using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// maintenancecontent:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MainTenanceContentModel
    {
        public MainTenanceContentModel()
        { }

        #region Model
        private int _cid;
        private int _settingid;
        private int _mtypeid;

        /// <summary>
        /// 流水号（主键）
        /// </summary>
        public int cID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 计划编号
        /// </summary>
        public int settingID
        {
            set { _settingid = value; }
            get { return _settingid; }
        }
        /// <summary>
        /// 内容编号
        /// </summary>
        public int mtypeID
        {
            set { _mtypeid = value; }
            get { return _mtypeid; }
        }
        #endregion Model

    }
}
