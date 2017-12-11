using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;

namespace IERM.Common
{
    public static class YunRongSDK
    {

        // 表示服务器端的url
        private static string url = ConfigurationManager.AppSettings["PostUrl"];
        private static string userName = ConfigurationManager.AppSettings["UserName"];
        private static string passWord = ConfigurationManager.AppSettings["PassWord"];
        private static string Pwd
        {
            get
            {
                //解密密码
                return MD5Encrypt.Decrypt(passWord, "Fuxing2016");
            }
        }


        /// <summary>
        /// 发送单条短信
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Dictionary<string, object> SendSMS(string phone, string body)
        {
            Dictionary<string, object> responseResult = new Dictionary<string, object>();
            string postReturn = string.Empty;
            try
            {
                string strReturnXML = PostWebRequest(url, sendMessage(phone, body));
                postReturn = DataXml.GetResultCode(strReturnXML);
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetPostReturn(postReturn);
        }

        /// <summary>
        /// 批量发送同内容短信
        /// </summary>
        /// <param name="strPhone"> 多个号码之间用英文逗号分割,最多支持200个</param>
        /// <param name="strContent">发送短信内容</param>
        /// <returns></returns>
        public static Dictionary<string, object> SendBatchSMS(string phone, string body)
        {
            Dictionary<string, object> responseResult = null;
            string postReturn = string.Empty;
            try
            {
                string strReturnXML = PostWebRequest(url, sendBatchMessage(phone, body));
                postReturn = DataXml.GetResultCode(strReturnXML);
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetPostReturn(postReturn);
        }

        private static Dictionary<string, object> GetPostReturn(string postReturn)
        {
            Dictionary<string, object> responseResult = null;
            switch (postReturn)
            {
                case "0":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "发送成功" } };
                    break;
                case "-1":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "用户名或口令错误" } };
                    break;
                case "-2":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "IP验证错误" } };
                    break;
                case "-3":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "定时日期错误 " } };
                    break;
                case "-10":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "余额不足" } };
                    break;
                case "-101":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "userId为空" } };
                    break;
                case "-102":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "目标号码为空" } };
                    break;
                case "-103":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "内容为空" } };
                    break;
                case "200":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "目标号码错误 " } };
                    break;
                case "201":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "目标号码在黑名单中 " } };
                    break;
                case "202":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "内容包含敏感单词 " } };
                    break;
                case "203":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "特服号未分配 " } };
                    break;
                case "204":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "分配通道错误 " } };
                    break;
                case "999":
                    responseResult = new Dictionary<string, object> { { "statusCode", postReturn }, { "statusMsg", "发送三次都超时 " } };
                    break;
            }
            return responseResult;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="strPhone">电话</param>
        /// <param name="strContent">发送内容</param>
        /// <returns></returns>
        private static string sendMessage(string strPhone, string strContent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}={1}", "cmd", "sendMessage");
            sb.AppendFormat("&{0}={1}", "userName", userName);
            sb.AppendFormat("&{0}={1}", "passWord", Pwd);
            sb.AppendFormat("&{0}={1}", "messageId", DateTime.Now.ToString("YYYYmmddHHmmss"));
            sb.AppendFormat("&{0}={1}", "contentType", "sms/mt");   //消息类型  短信为：sms/mt 彩信为：mm/mt
            sb.AppendFormat("&{0}={1}", "phoneNumber", strPhone);   //手机号码
            sb.AppendFormat("&{0}={1}", "body", "【福星智慧家】" + strContent); //短信内容	短信内容；短信内容长度+短信签名长度不要超过500;超过500字符系统会自动分割成多条发送。
            //sb.AppendFormat("&{0}={1}", "serviceCode", "");       特服号	手机上显示的长号码，短信平台为应用系统分配。
            //sb.AppendFormat("&{0}={1}", "serviceCodeExt", "");    特服号扩展码	应用自己扩展，为支持上行短信设置为空
            //sb.AppendFormat("&{0}={1}", "scheduleDateStr", "");   定时发送时间	yyyyMMddhhmmss(为空则立即发送)
            return sb.ToString();
        }

        /// <summary>
        /// 批量发送同内容短信
        /// </summary>
        /// <param name="strPhone"> 多个号码之间用英文逗号分割,最多支持200个</param>
        /// <param name="strContent">发送短信内容</param>
        /// <returns></returns>
        private static string sendBatchMessage(string strPhone, string strContent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}={1}", "cmd", "sendBatchMessage");
            sb.AppendFormat("&{0}={1}", "userName", userName);
            sb.AppendFormat("&{0}={1}", "passWord", Pwd);
            sb.AppendFormat("&{0}={1}", "messageId", DateTime.Now.ToString("YYYYmmddHHmmssfff"));  //应用系统消息ID 如需要状态报告则不能为空，最长50位
            sb.AppendFormat("&{0}={1}", "contentType", "sms/mt");   //消息类型	短信为：sms/mt(默认值) 彩信为：mm/mt
            sb.AppendFormat("&{0}={1}", "mobilePhones", strPhone);  //手机号码(支持多个)    多个号码之间用英文逗号分割,最多支持200个。
            sb.AppendFormat("&{0}={1}", "body", "【福星智慧家】" + strContent);        //短信内容
            //sb.AppendFormat("&{0}={1}", "serviceCode", "");       //特服号	短信平台为应用系统分配
            //sb.AppendFormat("&{0}={1}", "serviceCodeExt", "");    //特服号扩展码	短信平台为应用系统分配
            sb.AppendFormat("&{0}={1}", "messagePriority", "5");    //发送优先级	短信平台为应用系统分配,取值为0--5，默认为0,数值大优先级高。
            //sb.AppendFormat("&{0}={1}", "scheduleDateStr", "");   //定时发送时间	格式 yyyyMMddHHmmss
            //sb.AppendFormat("&{0}={1}", "appNumber", "");         //应用系统编码       
            //sb.AppendFormat("&{0}={1}", "srcNumber", "");         //渠道编码
            //sb.AppendFormat("&{0}={1}", "appBusinessNumber", ""); //业务编码
            //sb.AppendFormat("&{0}={1}", "costCenterNumber", "");  //成本中心编码
            //sb.AppendFormat("&{0}={1}", "sendUserName", "");      //发送者用户
            //sb.AppendFormat("&{0}={1}", "sendUserFullName", "");  //发送者全称
            return sb.ToString();
        }

        /// <summary>
        /// 批量发送不同内容短信
        /// </summary>
        /// <returns></returns>
        private static string sendBatchMessageX()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}={1}", "cmd", "sendBatchMessageX");
            sb.AppendFormat("&{0}={1}", "userName", "nvtest");
            sb.AppendFormat("&{0}={1}", "passWord", "nvtest");
            sb.AppendFormat("&{0}={1}", "contentType", "sms/mt");
            sb.AppendFormat("&{0}={1}", "messageQty", "3");


            sb.AppendFormat("&{0}={1}", "messageId1", "20160417000003");
            sb.AppendFormat("&{0}={1}", "phoneNumber1", "18610809756");
            sb.AppendFormat("&{0}={1}", "subject1", "");
            sb.AppendFormat("&{0}={1}", "body1", "奔跑吧 少年");
            sb.AppendFormat("&{0}={1}", "serviceCode1", "");
            sb.AppendFormat("&{0}={1}", "serviceCodeExt1", "");
            sb.AppendFormat("&{0}={1}", "messagePriority1", "5");
            sb.AppendFormat("&{0}={1}", "scheduleDateStr1", "");
            sb.AppendFormat("&{0}={1}", "appNumber1", "");
            sb.AppendFormat("&{0}={1}", "srcNumber1", "");
            sb.AppendFormat("&{0}={1}", "appBusinessNumber1", "");
            sb.AppendFormat("&{0}={1}", "costCenterNumber1", "");
            sb.AppendFormat("&{0}={1}", "sendUserName1", "王林");
            sb.AppendFormat("&{0}={1}", "sendUserFullName1", "王林");

            sb.AppendFormat("&{0}={1}", "messageId2", "20160417000003");
            sb.AppendFormat("&{0}={1}", "phoneNumber2", "18610809756");
            sb.AppendFormat("&{0}={1}", "subject2", "");
            sb.AppendFormat("&{0}={1}", "body2", "奔跑吧 少年");
            sb.AppendFormat("&{0}={1}", "serviceCode2", "");
            sb.AppendFormat("&{0}={1}", "serviceCodeExt2", "");
            sb.AppendFormat("&{0}={1}", "messagePriority2", "5");
            sb.AppendFormat("&{0}={1}", "scheduleDateStr2", "");
            sb.AppendFormat("&{0}={1}", "appNumber2", "");
            sb.AppendFormat("&{0}={1}", "srcNumber2", "");
            sb.AppendFormat("&{0}={1}", "appBusinessNumber2", "");
            sb.AppendFormat("&{0}={1}", "costCenterNumber2", "");
            sb.AppendFormat("&{0}={1}", "sendUserName2", "王林");
            sb.AppendFormat("&{0}={1}", "sendUserFullName2", "王林");


            sb.AppendFormat("&{0}={1}", "messageId3", "20160417000003");
            sb.AppendFormat("&{0}={1}", "phoneNumber3", "18636632712");
            sb.AppendFormat("&{0}={1}", "subject3", "");
            sb.AppendFormat("&{0}={1}", "body3", "奔跑吧 少年");
            sb.AppendFormat("&{0}={1}", "serviceCode3", "");
            sb.AppendFormat("&{0}={1}", "serviceCodeExt3", "");
            sb.AppendFormat("&{0}={1}", "messagePriority3", "5");
            sb.AppendFormat("&{0}={1}", "scheduleDateStr3", "");
            sb.AppendFormat("&{0}={1}", "appNumber3", "");
            sb.AppendFormat("&{0}={1}", "srcNumber3", "");
            sb.AppendFormat("&{0}={1}", "appBusinessNumber3", "");
            sb.AppendFormat("&{0}={1}", "costCenterNumber3", "");
            sb.AppendFormat("&{0}={1}", "sendUserName3", "王林");
            sb.AppendFormat("&{0}={1}", "sendUserFullName3", "王林");

            return sb.ToString();

        }

        /// <summary>
        /// 地址请求
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="paramData">请求参数</param>
        /// <returns></returns>
        private static string PostWebRequest(string postUrl, string paramData)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }
    }
}
