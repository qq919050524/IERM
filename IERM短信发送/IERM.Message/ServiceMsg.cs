using IERM.Message.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace IERM.Message
{
    partial class ServiceMsg : ServiceBase
    {
        public ServiceMsg()
        {
            InitializeComponent();
        }
        private static Timer tmr = null;


        protected override void OnStart(string[] args)
        {

            LogHelper.Info("OnStart", "启动服务!");
            // TODO: 在此处添加代码以启动服务。
            tmr = new Timer();
            //设置配置文件为启动状态
            //ConfigerHelper.SetAppSetting("SendMessage", "true");
            tmr.Interval = 60000;
            tmr.Elapsed += Tmr_Elapsed; ;  //执行事件
            tmr.AutoReset = true;   //是否执行一直执行
            tmr.Enabled = true;   //是否立即调用
            tmr.Start();          // 开启定时器


            //dueTime：调用 callback 之前延迟的时间量（以毫秒为单位）。指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。
            //Period：调用 callback 的时间间隔（以毫秒为单位）。指定 Timeout.Infinite 可以禁用定期终止。
        }


        protected override void OnStop()
        {
            LogHelper.Info("OnStop", "停止服务!");
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            if (tmr != null)
            {
                tmr.Close();
                tmr.Dispose();
            }
        }


        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {

            AlarmMessage msg = new AlarmMessage();
            msg.GetAlarmInfo();

            //发送电梯报警短信
            ElevatorAlarmMessage eam = new ElevatorAlarmMessage();
            eam.SendElevatorAlarm();
        }
    }
}
