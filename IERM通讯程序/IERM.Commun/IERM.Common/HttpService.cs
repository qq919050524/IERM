using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Policy;
using System.Text;

namespace IERM.Common
{
    public class HttpService
    {
        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="requestdata"></param>
        /// <param name="url"></param>
        /// <param name="timeout">秒</param>
        /// <returns></returns>
        public static string Post(string requestdata, string url, string contenttype = "application/x-www-form-urlencoded", int timeout = 30)
        {
            //System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;
            try
            {
                if (!url.Contains("http://") && !url.Contains("https://"))
                {
                    url = "http://" + url;
                }
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = timeout * 1000;
                request.ContentType = contenttype;
                byte[] data = System.Text.Encoding.UTF8.GetBytes(requestdata);
                request.ContentLength = data.Length;
                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();
                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }

        /// <summary>
        /// 获取post的数据
        /// </summary>
        /// <returns></returns>
        public static string PostInput(Stream s)
        {
            try
            {
                int count = 0;
                s.Position = 0;
                byte[] buffer = new byte[1024];
                StringBuilder builder = new StringBuilder();
                while ((count = s.Read(buffer, 0, 1024)) > 0)
                {
                    builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
                }
                s.Flush();
                s.Close();
                s.Dispose();
                return builder.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
