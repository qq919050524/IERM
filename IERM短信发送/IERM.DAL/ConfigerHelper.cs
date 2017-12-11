using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IERM.Message.DAL
{
    public static class ConfigerHelper
    {
        private static string configPath = "App.config";

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string connstr = null;
            try
            {
                connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            }
            catch
            {
                connstr = null;
            }
            return connstr;
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public static bool SaveConnctiongString(string connstr)
        {
            try
            {
                XDocument xdoc = XDocument.Load(configPath);
                xdoc.Root.Element("connectionStrings").Element("add").SetAttributeValue("connectionString", connstr);
                xdoc.Save(configPath);
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取appSettings
        /// </summary>
        public static Dictionary<int, string> GetAppSettings()
        {
            try
            {
                return XDocument.Load(configPath).Root.Element("appSettings").Elements("add").ToDictionary(k => Convert.ToInt32(k.Attribute("key").Value), v => v.Attribute("value").Value);
            }
            catch
            {
                return new Dictionary<int, string>();
            }
        }

        /// <summary>
        /// 添加新的AppSettings
        /// </summary>
        public static bool AddAppSetting(string key, string value)
        {
            try
            {
                XDocument xdoc = XDocument.Load(configPath);
                var t = xdoc.Root.Element("appSettings").Elements("add").Where(s => s.Attribute("key").Value == "0");
                if (t.Count() > 0)
                {
                    t.FirstOrDefault().SetAttributeValue("value", value);
                }
                else
                {
                    xdoc.Root.Element("appSettings").Add(new XElement("add", new XAttribute("key", key), new XAttribute("value", value)));
                }
                xdoc.Save(configPath);
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
