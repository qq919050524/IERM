using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.Model
{
    public class SendMessageModel
    {
        #region Model
        private int _sendmsgid;
        private int _devid;
        private string _alarmcode;
        private string _mobile;
        private string _content;
        private int _alarmstate;
        private DateTime _createtime;
        private string _sendResult;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int sendmsgID
        {
            set { _sendmsgid = value; }
            get { return _sendmsgid; }
        }
        /// <summary>
        /// 设备编号
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }
        /// <summary>
        /// 报警类型编号
        /// </summary>
        public string alarmCode
        {
            set { _alarmcode = value; }
            get { return _alarmcode; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 状态（-2 过低  -1异常 1正常  2过高）
        /// </summary>
        public int alarmState
        {
            set { _alarmstate = value; }
            get { return _alarmstate; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }

        /// <summary>
        /// 发送结果
        /// </summary>
        public string sendResult
        {
            get { return _sendResult; }

            set { _sendResult = value; }
        }
        #endregion Model
    }
}
