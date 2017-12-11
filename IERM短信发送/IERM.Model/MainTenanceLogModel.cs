using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Message.Model
{
    /// <summary>
    /// 工单记录:实体类
    /// </summary>
    [Serializable]
    public partial class MainTenanceLogModel
    {
        public MainTenanceLogModel()
        { }
        #region Model
        private int _mid;
        private int _settingID;
        private int _devhouseID;
        private string _ordercode;
        private string _ordercontent;
        private int _ordertype = 0;
        private DateTime _createtime;
        private DateTime _operatetime;
        private int _status = 1;
        private string _remark;
        /// <summary>
        /// 工单流水号
        /// </summary>
        public int mID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 工单号（唯一）
        /// </summary>
        public string orderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 工单内容
        /// </summary>
        public string orderContent
        {
            set { _ordercontent = value; }
            get { return _ordercontent; }
        }
        /// <summary>
        /// 工单类型（1报警  2维保  3巡检）
        /// </summary>
        public int orderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 工单生成时间
        /// </summary>
        public DateTime createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 工单处理时间
        /// </summary>
        public DateTime operateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// 工单状态（1：等待处理 2：已接单  3：已处理 4：已过期） 
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 所属设备房编号
        /// </summary>
        public int devhouseID
        {
            get
            {
                return _devhouseID;
            }

            set
            {
                _devhouseID = value;
            }
        }
        /// <summary>
        /// 维保计划ID  (报警派单该值为0)
        /// </summary>
        public int settingID
        {
            get
            {
                return _settingID;
            }

            set
            {
                _settingID = value;
            }
        }
        #endregion Model

    }
}
