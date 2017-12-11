using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Common
{
    public static class LogHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("logApp");

        public static void Dbbug(string msg)
        {
            log.Debug(msg);
        }
    }
}
