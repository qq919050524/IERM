using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.Model
{
    /// <summary>
    /// 电梯报警记录
    /// </summary>
    public partial class AlarmElevatorModel
    {
        public AlarmElevatorModel()
        {

        }
        public int aID { get; set; }
        /// <summary>
        /// 电梯注册码
        /// </summary>
        public string registrationCode { get; set; }
        /// <summary>
        ///金太阳其他=（电梯品牌+电梯型号+当前故障码）
        /// </summary>
        public string errorCodeType { get; set; }
        /// <summary>
        /// noProblem=恢复,forHelp=手动报警 ,trapped=困人,金太阳其他=other
        /// </summary>
        public string customCode { get; set; }
        /// <summary>
        /// 当前故障码含意 
        /// </summary>
        public string errorCodeMean { get; set; }
        /// <summary>
        /// 报警状态（ -1异常 1正常 ）
        /// </summary>
        public int alarmState { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime insertTime { get; set; }
    }
    public partial class AlarmElevatorModel
    {
        /// <summary>
        /// 电梯位置
        /// </summary>
        public string elevatorPosition { get; set; }
        /// <summary>
        /// 小区id
        /// </summary>
        public int communityId { get; set; }
        /// <summary>
        /// 小区名
        /// </summary>
        public string communityName { get; set; }
    }
}
