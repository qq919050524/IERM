using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;

namespace IERM.Message
{
    static class Program
    {
        /// <summary>
		/// 应用程序的主入口点。
		/// </summary>
        [STAThread]
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceMsg()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

