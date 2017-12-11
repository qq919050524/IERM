using IERM.MODEL;
using IERM.BLL;
using System.Data;
using System.Collections.Generic;
using System;
using IERM.Common;
using System.Threading;

namespace IERM.WCFService
{
    /// <summary>
    /// 计划生成工单
    /// </summary>
    public static class PlanToOrder
    {
        /// <summary>
        /// 执行计划
        /// </summary>
        public static void BulidOrder()
        {
            /** step1:获取计划列表 */
            EccmPlanBLL plan_bll = new EccmPlanBLL();
            List<EccmPlanModel> plan_list = plan_bll.GetPlanList();

            /** step2:循环计划列表，进行逻辑判断 */
            foreach (EccmPlanModel plan_model in plan_list)
            {
                /** step3: 判断是巡检还是维保 plan_type:1巡检，2维保 */
                if (plan_model.plan_type == 1)//巡检
                {
                    /** step4: 获取最后一次计划生成的工单 */
                    EccmInspectionOrderBLL order_bll = new EccmInspectionOrderBLL();
                    EccmInspectionOrderModel order_model = new EccmInspectionOrderModel();
                    order_model = order_bll.GetModel(plan_model.plan_id);

                    if (order_model == null)//该计划从未生成过工单
                    {
                        /** step5: 生成一个新的工单 */
                        AddInspectionOrder(plan_model);
                    }
                    else
                    {
                        if (plan_model.plan_cycle == 1)//当计划为重复执行时，才进入下面流程
                        {
                            /** step5: 判断时间间隔，是否生成一个新的工单 */
                            DateTime order_time = Convert.ToDateTime(order_model.order_time);//工单时间
                            DateTime now_time = DateTime.Now;//当前时间 
                            if (TimeLogic(plan_model, now_time, order_time))//当为true时 生成新工单
                            {
                                //生成新工单
                                AddInspectionOrder(plan_model);
                            }
                        }
                    }
                }
                else if (plan_model.plan_type == 2)//维保
                {
                    /** step4: 获取最后一次计划生成的工单 */
                    EccmMaintenanceOrderBLL order_bll = new EccmMaintenanceOrderBLL();
                    EccmMaintenanceOrderModel order_model = new EccmMaintenanceOrderModel();
                    order_model = order_bll.GetModel(plan_model.plan_id);

                    /** step4: 判断最后一次计划生成的工单，是否生成新的工单 */
                    if (order_model == null)//该计划从未生成过工单
                    {
                        /** step5: 生成一个新的工单 */
                        AddMaintenanceOrder(plan_model);
                    }
                    else
                    {
                        if (plan_model.plan_cycle == 1)//当计划为重复执行时，才进入下面流程
                        {
                            /** step5: 判断时间间隔，是否生成一个新的工单 */
                            DateTime order_time = Convert.ToDateTime(order_model.order_time);//工单时间
                            DateTime now_time = DateTime.Now;//当前时间 
                            if (TimeLogic(plan_model, now_time, order_time))//当为true时 生成新工单
                            {
                                //生成一个新工单
                                AddMaintenanceOrder(plan_model);
                            }
                        }
                    }
                }
                else { }
            }
        }

        /// <summary>
        /// 时间逻辑处理：判断是否生成新订单
        /// </summary>
        /// <param name="plan_model">计划对象</param>
        /// <param name="now_time">当前时间</param>
        /// <param name="order_time">最后一次订单生成时间</param>
        /// <returns></returns>
        public static bool TimeLogic(EccmPlanModel plan_model, DateTime now_time, DateTime order_time)
        {
            bool is_order = false;
            if (plan_model.plan_role == "0")//规则：年
            {
                int year = now_time.Year - order_time.Year;
                if (year == Convert.ToInt32(plan_model.execution_frequency))//当前时间-最后一次生成工单时间=计划的间隔时间，就需要生成新的工单
                {
                    is_order = true;
                }
            }
            else if (plan_model.plan_role == "1")//规则：季
            {
                int Month = (now_time.Year - order_time.Year) * 12 + (now_time.Month - order_time.Month);
                if (Month == Convert.ToInt32(plan_model.execution_frequency) * 3)//当前时间-最后一次生成工单时间=计划的间隔时间，就需要生成新的工单
                {
                    is_order = true;
                }
            }
            else if (plan_model.plan_role == "2")//规则：月
            {
                int Month = (now_time.Year - order_time.Year) * 12 + (now_time.Month - order_time.Month);
                if (Month == Convert.ToInt32(plan_model.execution_frequency))//当前时间-最后一次生成工单时间=计划的间隔时间，就需要生成新的工单
                {
                    is_order = true;
                }
            }
            else if (plan_model.plan_role == "3")//规则：周
            {
                DateTime dt = GetMondayDate(Convert.ToDateTime(order_time).AddDays(Convert.ToInt32(plan_model.execution_frequency) * 7));//获取下一个周期 星期一的日期
                if (DateTime.Now.ToShortDateString() == dt.ToShortDateString())//如果当前日期=下个周期星期一日期则生成
                {
                    is_order = true;
                }
            }
            else if (plan_model.plan_role == "5")//规则：日
            {
                TimeSpan ts = now_time - order_time;
                if (Convert.ToInt32(ts.TotalDays) == Convert.ToInt32(plan_model.execution_frequency))//当前时间-最后一次生成工单时间=计划的间隔时间，就需要生成新的工单
                {
                    is_order = true;
                }
            }
            else { }
            return is_order;
        }

        /// <summary>
        /// 生成一个巡检工单
        /// </summary>
        /// <param name="plan_model">计划对象</param>
        public static void AddInspectionOrder(EccmPlanModel plan_model)
        {
            EccmPlanBLL plan_bll = new EccmPlanBLL();

            //获取设备
            string equCodes = "";
            DataTable dt = plan_bll.GetPlanDeviceCode(plan_model.plan_id, Convert.ToInt32(plan_model.choose_type));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                equCodes += dt.Rows[i][0].ToString() + ",";
            }
            equCodes = equCodes.Substring(0, equCodes.Length - 1);

            //生成工单
            EccmInspectionOrderModel model = new EccmInspectionOrderModel();
            model.order_sn = GetOrderSN("XJ");
            model.order_stats = 0;
            model.order_time = DateTime.Now;
            model.order_type = 0;
            model.term_time = DateTime.Now.AddDays(Convert.ToInt32(plan_model.term_day));
            model.community_id = plan_model.communityID;
            model.uid = plan_model.uid;
            model.plan_id = plan_model.plan_id;

            EccmInspectionOrderBLL order_bll = new EccmInspectionOrderBLL();
            PlanLog(plan_model, order_bll.Add(model, equCodes));

        }

        /// <summary>
        /// 生成一个维保工单
        /// </summary>
        /// <param name="plan_model">计划对象</param>
        public static void AddMaintenanceOrder(EccmPlanModel plan_model)
        {
            EccmPlanBLL plan_bll = new EccmPlanBLL();

            //获取设备
            string equCodes = "";
            DataTable dt = plan_bll.GetPlanDeviceCode(plan_model.plan_id, Convert.ToInt32(plan_model.choose_type));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                equCodes += dt.Rows[i][0].ToString() + ",";
            }
            equCodes = equCodes.Substring(0, equCodes.Length - 1);

            //生成工单
            EccmMaintenanceOrderModel model = new EccmMaintenanceOrderModel();
            model.order_sn = GetOrderSN("WB");
            model.order_stats = 0;
            model.order_time = DateTime.Now;
            model.order_type = 0;
            model.term_order = DateTime.Now.AddDays(Convert.ToInt32(plan_model.term_day));
            model.community_id = Convert.ToInt32(plan_model.communityID);
            model.uid = Convert.ToInt32(plan_model.uid);
            model.plan_id = plan_model.plan_id;

            EccmMaintenanceOrderBLL order_bll = new EccmMaintenanceOrderBLL();
            PlanLog(plan_model, order_bll.Add(model, equCodes));
        }

        /// <summary>
        /// 生成工单记录日志
        /// </summary>
        /// <param name="plan_model"></param>
        /// <param name="b"></param>
        public static void PlanLog(EccmPlanModel plan_model, bool b)
        {
            if (b)
            {
                string msg = "计划生成日志：计划id为" + plan_model.plan_id + "生成一个新的";
                msg += plan_model.plan_type == 1 ? "巡检" : "维保";
                msg += "工单成功";
                LogHelper.Dbbug(msg);
            }
            else
            {
                string msg = "计划生成日志：计划id为" + plan_model.plan_id + "生成一个新的";
                msg += plan_model.plan_type == 1 ? "巡检" : "维保";
                msg += "工单失败";
                LogHelper.Dbbug(msg);
            }
        }

        /// <summary>
        /// 启动定时计划
        /// </summary>
        public static void StartClient()
        {
            try
            {
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(x =>
                    {
                        do
                        {
                            BulidOrder();//执行计划
                            Thread.Sleep(2000);
                        } while (1 == 1);
                    })
                );
            }
            catch (Exception e)
            {
                LogHelper.Dbbug("定时计划运行异常：原因如下：" + e.Message);
            }
        }


        #region Extension Method
        /// <summary>
        /// 计算某日起始日期（礼拜一的日期）
        /// </summary>
        /// <param name="someDate">该周中任意一天</param>
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns>
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }

        private static object obj = new object();
        /// <summary>
        /// 生产订单号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public static string GetOrderSN(string prefix)
        {
            lock (obj)
            {
                return prefix + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            }
        }
        #endregion
    }
}
