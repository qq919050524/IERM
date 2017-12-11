using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IERM.Common
{
    public class FileUpload
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="directoryUrl">目录名/1/2/3</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool UploadFile(Stream file, string directoryUrl, string fileName)
        {
            try
            {
                Stream stream = file;
                stream.Position = 0;
                directoryUrl = "/" + directoryUrl.Trim('/');
                string path = AppDomain.CurrentDomain.BaseDirectory + directoryUrl;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string url = path + "/" + fileName;
                using (FileStream fs = new FileStream(url, FileMode.Create))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    fs.Write(buffer, 0, buffer.Length);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
