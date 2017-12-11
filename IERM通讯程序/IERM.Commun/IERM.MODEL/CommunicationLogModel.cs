using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    /// <summary>
    /// 通信日志类实体
    /// </summary>
    [Serializable]
    public class CommunicationLogModel
    {
        public CommunicationLogModel()
        { }
        #region Model
        private int _cid;
        private int _datasize;
        private byte[] _data;
        private DateTime _inserttime;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dataSize
        {
            set { _datasize = value; }
            get { return _datasize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] data
        {
            set { _data = value; }
            get { return _data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        #endregion Model
    }
}
