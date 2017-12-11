using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmReceiverUserModel
    {
        public int receiver_id { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 接单人id
        /// </summary>
        public int uid_receiver { get; set; }
        /// <summary>
        /// 是否责任人0是协同人员1是责任人
        /// </summary>
        public int is_duty { get; set; }
        /// <summary>
        /// 类型(1巡检2维保3维修)
        /// </summary>
        public int receiver_type { get; set; }
    }
    public partial class EccmReceiverUserModel
    {
        public string nickName { get; set; }
    }

    }
