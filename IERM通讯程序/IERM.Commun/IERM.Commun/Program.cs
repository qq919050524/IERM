using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IERM.WCFService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("去系统托盘找找......", "ECCM通信程序正在运行中");
            }
            else
            {
                Application.Run(new WCFStartForm());
            }

        }
    }
}
