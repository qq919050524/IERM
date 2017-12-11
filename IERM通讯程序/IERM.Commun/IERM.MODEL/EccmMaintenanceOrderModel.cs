using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    public partial class EccmMaintenanceOrderModel
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 计划sn
        /// </summary>
        public int plan_id { get; set; }
        /// <summary>
        /// 订单sn
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int order_type { get; set; }
        /// <summary>
        /// 发起时间
        /// </summary>
        public DateTime order_time { get; set; }
        /// <summary>
        /// 完成期限
        /// </summary>
        public DateTime term_order { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime order_finish_time { get; set; }
        /// <summary>
        /// 小区id
        /// </summary>
        public int community_id { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int order_stats { get; set; }
        /// <summary>
        /// 责任人id
        /// </summary>
        public int uid_dispatch { get; set; }
        /// <summary>
        /// 发起人
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 是否删除 0=默认,1=删除
        /// </summary>
        public int is_del { get; set; }
        public string ext1 { get; set; }//备用1
        public string ext2 { get; set; }//备用2
        public string ext3 { get; set; }//备用3

    }
    public partial class EccmMaintenanceOrderModel
    {
        /// <summary>
        /// 小区名字
        /// </summary>
        public string communityName { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string cityName { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string areaName { get; set; }
        /// <summary>
        /// 物业公司
        /// </summary>
        public string propertyName { get; set; }
        /// <summary>
        /// 责任人
        /// </summary>
        public string dispatchName { get; set; }
    }
}
