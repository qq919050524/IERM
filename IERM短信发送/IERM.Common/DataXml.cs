using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace IERM.Message.Common
{
    public class DataXml
    {
        /// <summary>
        /// 解析云融正通返回的XML结果
        /// </summary>
        /// <param name="messageXML">返回的XML结果</param>
        /// <returns></returns>
        public static string GetResultCode(string messageXML)
        {
            //string strXML = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><message><body><field name=\"resultCode\">1</field ><field name=\"errorCode\">555</field ></body></message>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(messageXML);
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodeList = root.FirstChild.ChildNodes;
            if (nodeList.Count > 0)
            {
                string strResultCode = nodeList[0].FirstChild.InnerText;
                if (strResultCode != "0")
                {
                    return nodeList[1].FirstChild.InnerText;
                }
                else
                {
                    return strResultCode;
                }
            }
            return "1";
        }
    }
}
