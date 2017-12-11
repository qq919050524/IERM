using System;
namespace IERM.MODEL
{
    /// <summary>
    /// EccmInspectionOrderModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EccmInspectionOrderModel
    {
        public EccmInspectionOrderModel()
        { }
        #region Model
        public int order_id { get; set; }//订单id
        public int? plan_id { get; set; }//计划sn
        public string order_sn { get; set; }//订单sn
        public int? order_type { get; set; }//订单类型
        public DateTime? order_time { get; set; }//发起时间
        public DateTime? term_time { get; set; }//完成期限
        public DateTime? order_finish_time { get; set; }//完成时间
        public int? community_id { get; set; }//小区id
        public int? order_stats { get; set; }//订单状态
        public int? uid_dispatch { get; set; }//责任人id
        public string ext1 { get; set; }//备用1
        public string ext2 { get; set; }//备用2
        public string ext3 { get; set; }//备用3
        public int? uid { get; set; }//发起人
        public string communityName { get; set; }//小区名字
        public string cityName { get; set; }//城市
        public string areaName { get; set; }//省份
        public string propertyName { get; set; }//物业公司
        public string dispatchName { get; set; }//责任人
        #endregion Model

    }
}

