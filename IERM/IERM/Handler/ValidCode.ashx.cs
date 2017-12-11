using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// ValidCode 的摘要说明
    /// </summary>
    public class ValidCode : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
           
            //生成随机验证码字符串
            string code = MakeRanStr();
            context.Session["vcode"] = code;
            //生成验证码图片
            using (Image img = new Bitmap(100, 35))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.White);
                    //DrawGanRaoDian(50, g, img);#f9fafc
                    g.DrawRectangle(Pens.White, new Rectangle(0, 0, img.Width - 1, img.Height - 1));
                    g.DrawString(code, new Font("微软雅黑", 16), Brushes.Red, 0, 2);
                    //DrawGanRaoDian(50, g, img);
                }
                //将生成 图片 保存到 响应报文体流中，以jpg图片格式保存
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        #region 1.0 画干扰点 -DrawGanRaoDian(int count, Graphics g, Image img)
        /// <summary>
        /// 画干扰点
        /// </summary>
        /// <param name="count"></param>
        /// <param name="g"></param>
        /// <param name="img"></param>
        void DrawGanRaoDian(int count, Graphics g, Image img)
        {
            Pen[] pens = { Pens.Blue, Pens.Black, Pens.Red, Pens.Green };
            Point p1;
            Point p2;
            int length = 1;
            for (int i = 0; i < 50; i++)
            {
                p1 = new Point(random.Next(79), random.Next(29));
                p2 = new Point(p1.X - length, p1.Y - length);
                length = random.Next(5);
                g.DrawLine(pens[random.Next(pens.Length)], p1, p2);
            }
        }
        #endregion

        /// <summary>
        /// 准备的字符
        /// </summary>
        //初始化 字符
        private readonly char[] charArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'j', 'k', 'm', 'n',  'p', 's', 'u', 'w', 'y', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        /// <summary>
        /// 随机对象
        /// </summary>
        Random random = new Random();

        #region 1.随机生成字符串 -string MakeRanStr()
        /// <summary>
        /// 1.随机生成字符串
        /// </summary>
        /// <returns></returns>
        string MakeRanStr()
        {
            string str = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(charArr.Length);
                str += charArr[index];
            }
            return str;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}