using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace IERM.Common
{
    public static class  ConvertHelper
    {
        /// <summary>
        /// 返回 MD5 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringToMD5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        public static int MyCeiling(object input,int nSpan) 
        {
            try
            {
                return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(input) / nSpan) * nSpan);
            }
            catch
            {
                return -1;
            }
        }
    }
}
