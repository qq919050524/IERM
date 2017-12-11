using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Common
{
    public static class BinaryHelper
    {
        public static bool GetbitValue(byte input, int index)
        {
            bool tmp = ((input & (1 << index)) > 0) ? true : false;
            return ((input & (1 << index)) > 0) ? true : false;
        }

        public static bool GetbitValue(byte[] input, int[] range, int index)
        {
            int byte_step = (int)(index / 8);
            int index_step = index % 8;
            return GetbitValue(input[range[0] + byte_step], index_step);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes, int len)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < len; i++)
                {
                    returnStr += bytes[i].ToString("X2").ToUpper() + " ";
                }
            }
            return returnStr;
        }

        public static byte[] ushortToBytes(ushort value)
        {
            return System.BitConverter.GetBytes(value).Reverse().ToArray();
        }

        public static ushort bytesToUshort(byte[] data)
        {
            return System.BitConverter.ToUInt16(data.Reverse().ToArray(), 0);
        }

        public static int GetNumByByteRange(byte[] data, int[] range)
        {
            if (data.Length == 0 || data.Length < range[1])
            {
                LogHelper.Dbbug("索引超出范围！");
                return -1;
            }

            byte[] tmp = data.Skip(range[0]).Take(range[1] - range[0] + 1).Reverse().ToArray();
            int t = System.BitConverter.ToInt32(tmp, 0);
            return System.BitConverter.ToInt32(data.Skip(range[0]).Take(range[1] - range[0] + 1).Reverse().ToArray(), 0);
        }

        /// <summary>
        /// 比较两个byte数组是否相等
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool BytesEquals(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) return false;
            if (b1 == null || b2 == null) return false;
            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }


    }
}
