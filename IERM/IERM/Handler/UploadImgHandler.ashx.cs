
using IERM.Common;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// UploadImgHandler 的摘要说明
    /// </summary>
    public class UploadImgHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            var result = string.Empty;
            if (string.IsNullOrEmpty(action))
            {
                result = JsonConvert.SerializeObject(new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "行为参数未传递",
                    RedirectUrl = string.Empty
                });
            }
            else
            {
                switch (action.ToLower())
                {
                    case "uploadimg"://上传图片
                        result = UploadImg(context);
                        break;
                }
            }
            context.Response.Write(result);
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string UploadImg(HttpContext context)
        {
            string imgurl = "";
            if (context.Request.Files.Count > 0)
            {
                HttpPostedFile file = context.Request.Files[0];
                string filename = file.FileName;
                string uname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + filename.Substring(filename.LastIndexOf('.'));
                imgurl += "/upload/order/" + uname;
                FileUpload.UploadFile(file.InputStream, "/upload/order", uname);
            }
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = imgurl == "" ? false : true,
                Data = imgurl,
                Msg = "",
                RedirectUrl = string.Empty
            };
            return JsonConvert.SerializeObject(jr);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}