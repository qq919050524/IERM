using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Configuration;

namespace IERM.Common
{
    /// <summary>
    /// 在config文件中添加如下节点
    ///   <appSettings>
    ///		<add key = "encryptKey"	value="32E35872597989D14CC1D5D9F5B1E9423BCAB04EF1D085481C61496F693DF5F4" />
    ///	  </appSettings>
    /// </summary>
    public static class CookieProtectionHelperWrapper
    {
        private static byte[] _IV = { 0x40, 0x71, 0x64, 0x7A, 0x80, 0x73, 0x6C, 0x78, 0x51, 0x6B, 0x6C, 0x75, 0x6B, 0x61, 0x6E, 0x3F, 0x42, 0x73, 0x66, 0x7A, 0x7F, 0x76, 0x6E, 0x7A, 0x54, 0x6F, 0x70, 0x78, 0x6E, 0x62, 0x6F, 0x40 };

        public static string Encode(CookieProtection cookieProtection, byte[] buf, int count)
        {
            if (cookieProtection == CookieProtection.All || cookieProtection == CookieProtection.Validation)
            {
                byte[] array = HashData(buf, null, 0, count);
                if (array == null || array.Length != 20)
                {
                    return null;
                }
                if (buf.Length >= count + 20)
                {
                    Buffer.BlockCopy(array, 0, buf, count, 20);
                }
                else
                {
                    byte[] src = buf;
                    buf = new byte[count + 20];
                    Buffer.BlockCopy(src, 0, buf, 0, count);
                    Buffer.BlockCopy(array, 0, buf, count, 20);
                }
                count += 20;
            }
            if (cookieProtection == CookieProtection.All || cookieProtection == CookieProtection.Encryption)
            {
                buf = EncryptOrDecryptData(true, buf, null, 0, count);
                count = buf.Length;
            }
            if (count < buf.Length)
            {
                byte[] src2 = buf;
                buf = new byte[count];
                Buffer.BlockCopy(src2, 0, buf, 0, count);
            }
            return HttpServerUtility.UrlTokenEncode(buf);
        }

        public static byte[] Decode(CookieProtection cookieProtection, string data)
        {
            byte[] array = HttpServerUtility.UrlTokenDecode(data);
            if (array == null || cookieProtection == CookieProtection.None)
            {
                return array;
            }
            if (cookieProtection == CookieProtection.All || cookieProtection == CookieProtection.Encryption)
            {
                array = EncryptOrDecryptData(false, array, null, 0, array.Length);
                if (array == null)
                {
                    return null;
                }
            }
            if (cookieProtection == CookieProtection.All || cookieProtection == CookieProtection.Validation)
            {
                if (array.Length <= 20)
                {
                    return null;
                }
                byte[] array2 = new byte[array.Length - 20];
                Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
                byte[] array3 = HashData(array2, null, 0, array2.Length);
                if (array3 == null || array3.Length != 20)
                {
                    return null;
                }
                for (int i = 0; i < 20; i++)
                {
                    if (array3[i] != array[array2.Length + i])
                    {
                        return null;
                    }
                }
                array = array2;
            }
            return array;
        }

        #region PrivateMethod
        private static byte[] HashData(byte[] buf, byte[] modifier, int start, int length)
        {
            if (length < 0 || buf == null || length > buf.Length)
            {
                throw new ArgumentException("InvalidArgumentValue");
            }
            if (start < 0 || start >= length)
            {
                throw new ArgumentException("InvalidArgumentValue");
            }
            byte[] array = new byte[20];

            array = HashData(buf, start, length);

            return array;
        }
        private static byte[] EncryptOrDecryptData(bool fEncrypt, byte[] buf, byte[] modifier, int start, int length)
        {
            var pwd = ConfigurationManager.AppSettings["encryptKey"];
            if (string.IsNullOrEmpty(pwd))
            {
                throw new ArgumentNullException("encryptKey");
            }

            if (fEncrypt)
            {
                var res = AESEncrypt(buf, start, length, pwd, _IV);
                return res;
            }
            else
            {
                var res = AESDecrypt(buf, start, length, pwd, _IV);
                return res;
            }
        }

        private static byte[] HashData(byte[] buf, int start, int length)
        {
            using (SHA1 sha = SHA1CryptoServiceProvider.Create())
            {
                var r = new byte[20];
                var res = sha.ComputeHash(buf, start, length);
                Buffer.BlockCopy(res, 0, r, 0, r.Length);
                return r;
            }
        }

        private static byte[] AESEncrypt(byte[] buf, int start, int length, string password, byte[] iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Mode = CipherMode.CBC;

            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 256;

            rijndaelCipher.BlockSize = 256;

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] keyBytes = new byte[32];

            int len = pwdBytes.Length;

            if (len > keyBytes.Length) len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);

            rijndaelCipher.Key = keyBytes;

            rijndaelCipher.IV = iv;

            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();

            byte[] cipherBytes = transform.TransformFinalBlock(buf, start, length);

            return cipherBytes;

        }

        private static byte[] AESDecrypt(byte[] buf, int start, int length, string password, byte[] iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Mode = CipherMode.CBC;

            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 256;

            rijndaelCipher.BlockSize = 256;

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] keyBytes = new byte[32];

            int len = pwdBytes.Length;

            if (len > keyBytes.Length) len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);

            rijndaelCipher.Key = keyBytes;

            rijndaelCipher.IV = iv;

            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();

            byte[] plainText = transform.TransformFinalBlock(buf, start, length);

            return plainText;

        }

        #endregion

    }
    //public static class CookieProtectionHelperWrapper
    //{

    //    private static MethodInfo _encode;
    //    private static MethodInfo _decode;

    //    static CookieProtectionHelperWrapper()
    //    {
    //        // obtaining a reference to System.Web assembly
    //        Assembly systemWeb = typeof(HttpContext).Assembly;
    //        if (systemWeb == null)
    //        {
    //            throw new InvalidOperationException(
    //                "Unable to load System.Web.");
    //        }
    //        // obtaining a reference to the internal class CookieProtectionHelper
    //        Type cookieProtectionHelper = systemWeb.GetType(
    //                "System.Web.Security.CookieProtectionHelper");
    //        if (cookieProtectionHelper == null)
    //        {
    //            throw new InvalidOperationException(
    //                "Unable to get the internal class CookieProtectionHelper.");
    //        }
    //        // obtaining references to the methods of CookieProtectionHelper class
    //        _encode = cookieProtectionHelper.GetMethod(
    //                "Encode", BindingFlags.NonPublic | BindingFlags.Static);
    //        _decode = cookieProtectionHelper.GetMethod(
    //                "Decode", BindingFlags.NonPublic | BindingFlags.Static);

    //        if (_encode == null || _decode == null)
    //        {
    //            throw new InvalidOperationException(
    //                "Unable to get the methods to invoke.");
    //        }
    //    }

    //    public static string Encode(CookieProtection cookieProtection,
    //                                byte[] buf, int count)
    //    {
    //        return (string)_encode.Invoke(null,
    //                new object[] { cookieProtection, buf, count });
    //    }

    //    public static byte[] Decode(CookieProtection cookieProtection,
    //                                string data)
    //    {
    //        return (byte[])_decode.Invoke(null,
    //                new object[] { cookieProtection, data });
    //    }

    //}
}