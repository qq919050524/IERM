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
        private static string configPath = System.AppDomain.CurrentDomain.BaseDirectory + "Web.config";

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
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["mysqlconn"].ConnectionString;
        }

        /// <summary>
        /// 获取AppSetting中的配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool SetAppSetting(string key, string value)
        {
            //string strValue = ConfigurationManager.AppSettings[key].ToString();
            XDocument xdoc = XDocument.Load(configPath);
            //xdoc.Root.Element("appSettings").Element("add").SetAttributeValue(key, value);
            XElement element = xdoc.Root.Element("appSettings").LastNode as XElement;
            element.SetAttributeValue("value", value);
            xdoc.Save(configPath);
            ConfigurationManager.RefreshSection("connectionStrings");
            return true;
        }

    }
}
