using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    public class MaintenanceContentModel
    {
        public MaintenanceContentModel()
        { }
        #region Model
        private int _cid;
        private int _settingid;
        private int _mtypeid;
        private string _mtypeName;

        /// <summary>
        /// 流水号
        /// </summary>
        public int cID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 维保计划id
        /// </summary>
        public int settingID
        {
            set { _settingid = value; }
            get { return _settingid; }
        }
        /// <summary>
        /// 维保类型id
        /// </summary>
        public int mtypeID
        {
            set { _mtypeid = value; }
            get { return _mtypeid; }
        }

        /// <summary>
        /// 维保类型名称
        /// </summary>
        public string mtypeName
        {
            get
            {
                return _mtypeName;
            }

            set
            {
                _mtypeName = value;
            }
        }
        #endregion Model
    }
}
