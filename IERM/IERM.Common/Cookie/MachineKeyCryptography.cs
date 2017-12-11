using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;

namespace IERM.Common
{
    public class MachineKeyCryptography
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cookieProtection"></param>
        /// <returns></returns>
        public static string Encode(string text, CookieProtection cookieProtection = CookieProtection.All)
        {
            if (string.IsNullOrEmpty(text) || cookieProtection == CookieProtection.None)
            {
                return text;
            }
            byte[] buf = Encoding.UTF8.GetBytes(text);
            return CookieProtectionHelperWrapper.Encode(cookieProtection, buf, buf.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cookieProtection"></param>
        /// <returns></returns>
        public static string Decode(string text, CookieProtection cookieProtection = CookieProtection.All)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            byte[] buf;
            string resStr = string.Empty;
            try
            {
                buf = CookieProtectionHelperWrapper.Decode(cookieProtection, text);
                if (buf == null || buf.Length == 0)
                {
                    //throw new InvalidCypherTextException(
                    //    "Unable to decode the text");
                }
                resStr = Encoding.UTF8.GetString(buf, 0, buf.Length);
            }
            catch (Exception ex)
            {
                //throw new InvalidCypherTextException(
                //    "Unable to decode the text", ex.InnerException);
            }

            return resStr;
        }
    }
}