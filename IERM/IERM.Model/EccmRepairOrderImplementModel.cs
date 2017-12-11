using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmRepairOrderImplementModel
    {
        public int implement_id { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 设备code
        /// </summary>
        public string equCode { get; set; }
        /// <summary>
        /// 实施内容
        /// </summary>
        public string implement_content { get; set; }
        /// <summary>
        /// 实施时间
        /// </summary>
        public DateTime implement_time { get; set; }
        /// <summary>
        /// 实施人
        /// </summary>
        public int uid_handle { get; set; }
        public string ext1 { get; set; }
        public string ext2 { get; set; }
        public string ext3 { get; set; }
    }
    public partial class EccmRepairOrderImplementModel
    {
        public string equName { get; set; }
        public string nickName { get; set; }
        public string device_standard { get; set; }
    }
}
