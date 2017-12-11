using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FX.ECCM.COMMON
{
    /// <summary>
    /// AES加密解密类
    /// </summary>
    public class AESDEncrypt
    {
        /// <summary>  
        /// AES加密(无向量)  
        /// </summary>  
        /// <param name="plainBytes">被加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>密文</returns>  
        public static string AESEncrypt(string Data, string strKey)
        {
            strKey = MD5Encrypt.GetMD5(strKey);
            //分组加密算法
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(Data)));//得到需要加密的字节数组
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.KeySize = 128;
            des.Key = stringToByte(strKey);                     //设置密钥及密钥向量
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            cs.Close();
            ms.Close();
            StringBuilder sb = new StringBuilder();
            foreach (byte item in ms.ToArray())
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>  
        /// AES解密(无向量)  
        /// </summary>  
        /// <param name="encryptedBytes">被加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>明文</returns>  
        public static string AESDecrypt(string Data, string strKey)
        {
            try
            {
                string strNewKey = MD5Encrypt.GetMD5(strKey);
                SymmetricAlgorithm des = Rijndael.Create();
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                des.KeySize = 128;
                des.Key = stringToByte(strNewKey);         //设置密钥及密钥向量

                byte[] newByte = stringToByte(Data);    //得到需要解密的字节数组
                byte[] decryptBytes = new byte[newByte.Length];

                MemoryStream ms = new MemoryStream(newByte);
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
                cs.Read(decryptBytes, 0, decryptBytes.Length);
                cs.Close();
                ms.Close();
                string strBase64 = Encoding.UTF8.GetString(decryptBytes).TrimEnd('\0');
                return Encoding.UTF8.GetString(Convert.FromBase64String(strBase64));

            }
            catch (Exception)
            {
            }

            return string.Empty;
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        private static byte[] stringToByte(string strValue)
        {
            strValue = strValue.Replace(" ", "");
            if ((strValue.Length % 2) != 0)
            {
                strValue += " ";
            }
            byte[] returnBytes = new byte[strValue.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(strValue.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }


        /// <summary>
        /// 解密json数据，转Hashtable，使用AES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="AESKey">解密key</param>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public static Hashtable GetHashtable(string data, string AESKey, string userid = "")
        {
            Hashtable hash = null;
            try
            {
                string jsonStr = string.Empty;
                jsonStr = AESDEncrypt.AESDecrypt(data, AESKey);
                hash = JsonConvert.DeserializeObject<Hashtable>(jsonStr);
                return hash;
            }
            catch (Exception ex)
            {
                return new Hashtable();
            }
        }
    }
}

