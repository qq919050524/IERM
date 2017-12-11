using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmOrderDeviceStandardModel
    {
        public int order_device_standard_id { get; set; }

        /// <summary>
        /// 工单编号
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        /// 设备code
        /// </summary>
        public string equCode { get; set; }
        /// <summary>
        /// 标准内容
        /// </summary>
        public string device_standard { get; set; }
        /// <summary>
        /// 类型(1巡检2维保3维修)
        /// </summary>
        public int order_device_standard_type { get; set; }
    }
    public partial class EccmOrderDeviceStandardModel
    {
        /// <summary>
        /// 设备名
        /// </summary>
        public string equName { get; set; }
        /// <summary>
        /// 设备房
        /// </summary>
        public string devName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string devide_type_name { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public string manufacturer { get; set; }
        /// <summary>
        /// 安装时间
        /// </summary>
        public DateTime setupDate { get; set; }
    }

}
