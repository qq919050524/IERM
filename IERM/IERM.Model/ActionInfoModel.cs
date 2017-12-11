using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ActionInfoModel
    {
        public ActionInfoModel()
        { }
        #region Model
        private int _rightid;
        private string _url;
        private bool _isoperate = false;
        /// <summary>
        /// 权限编号
        /// </summary>
        public int rightID
        {
            set { _rightid = value; }
            get { return _rightid; }
        }
        /// <summary>
        /// 访问url
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 是否可操作（0：查询  1：包括增，删，改，查 未细分）
        /// </summary>
        public bool isOperate
        {
            set { _isoperate = value; }
            get { return _isoperate; }
        }
        #endregion Model

    }
}
