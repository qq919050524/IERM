using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Common
{
    public class OrderHelp
    {
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

    }
}
