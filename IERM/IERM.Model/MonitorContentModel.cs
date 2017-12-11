using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    [Serializable]
    public partial class MonitorContentModel
    {
        /// <summary>
        /// 监控内容
        /// </summary>
        public MonitorContentModel()
        { }
        #region Model
        private int _tid;
        private int _pID;
        private string _contentcode;
        private string _contentname;
        private bool _isdel = false;
        private string _unit;
        private int _sort;
        /// <summary>
        /// 流水号
        /// </summary>
        public int tID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 设备房编号
        /// </summary>
        public int pID
        {
            set { _pID = value; }
            get { return _pID; }
        }
        /// <summary>
        /// 内容编码
        /// </summary>
        public string contentCode
        {
            set { _contentcode = value; }
            get { return _contentcode; }
        }
        /// <summary>
        /// 内容名称
        /// </summary>
        public string contentName
        {
            set { _contentname = value; }
            get { return _contentname; }
        }
        [JsonIgnore]
        /// <summary>
        /// 
        /// </summary>
        public bool isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        //计量单位
        public string unit
        {
            get
            {
                return _unit;
            }

            set
            {
                _unit = value;
            }
        }
        //排序
        public int sort
        {
            get
            {
                return _sort;
            }

            set
            {
                _sort = value;
            }
        }
        #endregion Model

    }
}
