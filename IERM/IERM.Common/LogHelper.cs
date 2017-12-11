using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Common
{
    public class LogHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("logApp");

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug(string msg)
        {
            log.Debug(msg);
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            log.Error(msg);
        }
    }
}
