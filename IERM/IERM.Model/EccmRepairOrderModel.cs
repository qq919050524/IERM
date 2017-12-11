using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    public partial class EccmRepairOrderModel
    {
        public EccmRepairOrderModel()
        {
            is_del = 0;
            r_state = 0;
        }
        /// <summary>
        /// 订单id
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        /// 维修原因
        /// </summary>
        public string r_reason { get; set; }
        /// <summary>
        /// 发起时间
        /// </summary>
        public DateTime r_stime { get; set; }
        /// <summary>
        /// 发起人
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 关联小区
        /// </summary>
        public int community_id { get; set; }
        /// <summary>
        /// 维修状态 0=未派单,1=已派单,2=已接单,3=处理中,4=完成
        /// </summary>
        public int r_state { get; set; }
        /// <summary>
        /// 派单人
        /// </summary>
        public int uid_dispatch { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime r_etime { get; set; }
        /// <summary>
        /// 完成期限
        /// </summary>
        public DateTime term_time { get; set; }
        /// <summary>
        /// 删除 0=默认,1=删除
        /// </summary>
        public int is_del { get; set; }

        public string ext1 { get; set; }
        public string ext2 { get; set; }
        public string ext3 { get; set; }
    }

    public partial class EccmRepairOrderModel
    {
        public string communityName { get; set; }
        public string cityName { get; set; }
        public string areaName { get; set; }
        public string propertyName { get; set; }
        /// <summary>
        /// 派单人
        /// </summary>
        public string dispatchName { get; set; }
    }
}
