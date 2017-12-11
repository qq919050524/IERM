using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IERM.Common
{
    public static class ConfigerHelper
    {
       
        /// <summary>
        /// 获取AppSetting中的配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString() ?? string.Empty;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string connstr = null;
            try
            {
                connstr = ConfigurationManager.ConnectionStrings["mysqlConnstr"].ConnectionString;
            }
            catch
            {
                connstr = null;
            }
            return connstr;
        }

        /// <summary>
        /// 读取appSettings(设备通讯)
        /// </summary>
        public static Dictionary<int, string> GetAppSettings()
        {
            try
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                string value = ConfigerHelper.GetAppSetting("ComunicationKey");
                if (!string.IsNullOrEmpty(value))
                {
                    dic.Add(0, value);
                }
                return dic;
            }
            catch
            {
                return new Dictionary<int, string>();
            }
        }
    }
}
