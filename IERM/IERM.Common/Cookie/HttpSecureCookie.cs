/************************************************************
Design:By GroupFly(�人Ⱥ��)
WebSite:http://www.groupfly.com
ShopNum1 WebSite:http://www.shopnum1.cn
Coder:WFK
Date:2008-11-12
************************************************************/
using System;
using System.Web;
using System.Text;
using System.Web.Security;
namespace IERM.Common
{
    /// <summary>
    /// Provides cookie cyphering services.
    /// </summary>
    public static class HttpSecureCookie
    {
        /// <summary>
        /// Encodes a cookie with all protection levels
        /// </summary>
        /// <param name="cookie">The cookie to encode</param>
        /// <returns>A clone of the cookie in encoded format</returns>
        public static HttpCookie Encode(HttpCookie cookie)
        {
            return Encode(cookie, CookieProtection.All);
        }
        /// <summary>
        /// Encodes a cookie
        /// </summary>
        /// <param name="cookie">The cookie to encode</param>
        /// <param name="cookieProtection">The cookie protection to set</param>
        /// <returns>A clone of the cookie in encoded format</returns>
        public static HttpCookie Encode(HttpCookie cookie, CookieProtection cookieProtection)
        {
            HttpCookie encodedCookie = CloneCookie(cookie);
            encodedCookie.Value = MachineKeyCryptography.Encode(cookie.Value, cookieProtection);
            return encodedCookie;
        }
        /// <summary>
        /// Decodes a cookie that has all levels of cookie protection. Throws InvalidCypherTextException if unable to decode.
        /// </summary>
        /// <param name="cookie">The cookie to decode</param>
        /// <returns>A clone of the cookie in decoded format</returns>
        public static HttpCookie Decode(HttpCookie cookie)
        {
            if (cookie == null) { return null; }
            return Decode(cookie, CookieProtection.All);
        }
        /// <summary>
        /// Decodes a cookie. Throws InvalidCypherTextException if unable to decode.
        /// </summary>
        /// <param name="cookie">The cookie to decode</param>
        /// <param name="cookieProtection">The protection level to use when decoding</param>
        /// <returns>A clone of the cookie in decoded format</returns>
        public static HttpCookie Decode(HttpCookie cookie, CookieProtection cookieProtection)
        {
            try
            {
                HttpCookie decodedCookie = CloneCookie(cookie);
                decodedCookie.Value = MachineKeyCryptography.Decode(cookie.Value, cookieProtection);
                return decodedCookie;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Creates a clone of the given cookie
        /// </summary>
        /// <param name="cookie">A cookie to clone</param>
        /// <returns>The cloned cookie</returns>
        public static HttpCookie CloneCookie(HttpCookie cookie)
        {
            if (cookie == null) { return null; }
            HttpCookie clonedCookie = new HttpCookie(cookie.Name, cookie.Value);
            clonedCookie.Domain = cookie.Domain;
            clonedCookie.Expires = cookie.Expires;
            clonedCookie.HttpOnly = cookie.HttpOnly;
            clonedCookie.Path = cookie.Path;
            clonedCookie.Secure = cookie.Secure;
            clonedCookie.Expires = cookie.Expires;
            return clonedCookie;
        }
    }
}
