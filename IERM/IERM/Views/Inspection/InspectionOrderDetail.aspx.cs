using IERM.BLL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IERM.Views.Inspection
{
    public partial class InspectionOrderDetail : System.Web.UI.Page
    {
        private EccmInspectionOrderBLL _bll = new EccmInspectionOrderBLL();
        private EccmReceiverUserBLL _userBLL = new EccmReceiverUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderID = string.IsNullOrEmpty(Request.Params["orderID"]) ? 0 : int.Parse(Request.Params["orderID"]);
            if (orderID == 0)
            {
                Response.Write("参数错误");
                Response.End();
            }
            EccmInspectionOrderModel model = _bll.GetModel(orderID);
            List<EccmReceiverUserModel> list = _userBLL.GetEccmReceiverUserList(orderID, 1);
            //订单基本信息
            if (model != null)
            {
                this.orderID.Value = orderID.ToString();
                this.orderSN.Value = model.order_sn;
                this.dispatchName.Value = model.dispatchName;
                this.createTime.Value = model.order_time.ToString();
                this.termTime.Value = model.term_time.ToString();
                this.endTime.Value = "暂无完成";
                switch (model.order_stats)
                {
                    case 0:
                        this.orderStatus.Value = "未派单";
                        break;
                    case 1:
                        this.orderStatus.Value = "已派单";
                        break;
                    case 2:
                        this.orderStatus.Value = "已接单";
                        break;
                    case 3:
                        this.orderStatus.Value = "处理中";
                        break;
                    case 4:
                        this.orderStatus.Value = "完成";
                        this.endTime.Value = model.order_finish_time.ToString();
                        break;
                }

            }
            //责任人和协同人员
            if (list.Count > 0)
            {
                this.receiverName.Value = list.Where(p => p.is_duty == 1).FirstOrDefault().nickName;
                this.coordinationNames.Value = string.Join(",", list.Where(p => p.is_duty == 0).Select(p => p.nickName).ToArray()); ;
            }

        }
    }
}