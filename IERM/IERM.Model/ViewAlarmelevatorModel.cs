using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public class ViewAlarmelevatorModel
    {
        public int aID { get; set; }
        /// <summary>
        /// 电梯注册码
        /// </summary>
        public string registrationCode { get; set; }
        /// <summary>
        /// 自定义code  noProblem=恢复,forHelp=手动报警 ,trapped=困人,金太阳其他=other
        /// </summary>
        public string customCode { get; set; }
        /// <summary>
        /// 电梯错误码
        /// </summary>
        public string errorCodeType { get; set; }
        /// <summary>
        /// 电梯信息
        /// </summary>
        public string errorCodeMean { get; set; }
        /// <summary>
        /// 报警状态（-1异常，1正常）
        /// </summary>
        public int alarmState { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime insertTime { get; set; }
        /// <summary>
        /// 电梯位置
        /// </summary>
        public string elevatorPosition { get; set; }
        /// <summary>
        /// 小区id
        /// </summary>
        public int communityID { get; set; }
        /// <summary>
        /// 小区名
        /// </summary>
        public string communityName { get; set; }
        /// <summary>
        /// 物业公司id
        /// </summary>
        public int propertyID { get; set; }
        /// <summary>
        /// 物业公司名
        /// </summary>
        public string propertyName { get; set; }
        /// <summary>
        /// 城市id
        /// </summary>
        public int cityID { get; set; }
        /// <summary>
        /// 城市名
        /// </summary>
        public string cityName { get; set; }
        /// <summary>
        /// 省id
        /// </summary>
        public int provinceID { get; set; }
        /// <summary>
        /// 省名
        /// </summary>
        public string provinceName { get; set; }

    }
}
