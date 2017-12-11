using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.Model
{
    public class SendMessageElevatorModel
    {
        /// <summary>
        /// auto_increment
        /// </summary>
        public int sendmsgID { get; set; }
        /// <summary>
        /// 报警id
        /// </summary>
        public int aID { get; set; }
        /// <summary>
        /// 电梯注册码
        /// </summary>
        public string registrationCode { get; set; }
        /// <summary>
        /// 当前故障码类型（电梯品牌+电梯型号+当前故障码）
        /// </summary>
        public string errorCodeType { get; set; }
        /// <summary>
        /// 自定义错误码
        /// </summary>
        public string customCode { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime createTime { get; set; }

        /// <summary>
        /// 发送结果 
        /// </summary>
        public string sendResult { get; set; }
    }
}
