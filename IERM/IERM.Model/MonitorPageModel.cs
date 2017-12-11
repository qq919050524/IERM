using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// monitorpage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class MonitorPageModel
    {
        public MonitorPageModel()
        { }
        #region Model
        private int _mid;
        private int _devhouseid;
        private int _systypeid;
        private string _pageurl;

        private List<MonitorContentModel> _contentList;

        /// <summary>
        /// 流水号
        /// </summary>
        public int mID
        {
            set { _mid = value; }
            get { return _mid; }
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
        /// 系统类型编号
        /// </summary>
        public int systypeID
        {
            set { _systypeid = value; }
            get { return _systypeid; }
        }
        /// <summary>
        /// 对应url页面
        /// </summary>
        public string pageUrl
        {
            set { _pageurl = value; }
            get { return _pageurl; }
        }
        /// <summary>
        /// 监控内容列表
        /// </summary>
        public List<MonitorContentModel> contentList
        {
            get
            {
                return _contentList;
            }

            set
            {
                _contentList = value;
            }
        }

        #endregion Model

    }
}
