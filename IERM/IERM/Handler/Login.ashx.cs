
using IERM.BLL;
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
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private readonly UserInfoBLL ui_bll = new UserInfoBLL();

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod.ToLower() == "get")
            {
                context.Response.Write(IsRemember(context));
            }
            else
            {
                context.Response.Write(CheckLogin(context));
            }
            context.Response.End();
        }

        /// <summary>
        /// 判断是否被记住的用户
        /// </summary>
        private string IsRemember(HttpContext context)
        {
            string ui = context.Server.HtmlEncode(context.Request.Cookies["userid"].Value);
            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = string.Empty,
                Msg = string.Empty,
                RedirectUrl = "../Views/Home/Home.aspx"
            };

            //session判断
            if (context.Session["EccmUserinfo"] != null)
            {
                jr.IsSucceed = true;
                jr.Msg = "登录成功";
            }
            else
            {
                //判断cookie
                if (context.Request.Cookies["userid"] != null)
                {

                    string uid = context.Server.HtmlEncode(context.Request.Cookies["userid"].Value);
                    if (System.Text.RegularExpressions.Regex.IsMatch(uid, "^\\d+$"))
                    {
                        var userModel = ui_bll.GetModel(int.Parse(uid));
                        if (userModel.uid > 0)
                        {
                            jr.IsSucceed = true;
                            jr.Msg = "登录成功";
                            //登录成功，将用户 用户的实体对象 存入 Session
                            context.Session["EccmUserinfo"] = userModel;
                        }
                    }
                    else
                    {
                        context.Request.Cookies["userid"].Expires = DateTime.Now.AddMinutes(-10);
                    }

                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string CheckLogin(HttpContext context)
        {

            var jr = new JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = string.Empty,
                Msg = string.Empty,
                RedirectUrl = "../Views/Home/Home.aspx"
            };

            if (context.Session["vcode"] == null || context.Session["vcode"].ToString() != context.Request.Params["txtcode"].ToString())
            {
                jr.Msg = "验证码错误";
            }
            else
            {
                string loginname = context.Request.Params["txtusername"];
                string password = context.Request.Params["txtpassword"];
                if (!string.IsNullOrEmpty(loginname) && !string.IsNullOrEmpty(password))
                {
                    UserInfoModel model = null;
                    //登录成功
                    if (ui_bll.CheckLogin(loginname, password, out model))
                    {

                        HttpCookie cookie = new HttpCookie("EccmUserinfo");

                        cookie.Values.Add("loginname", model.loginName.ToString());
                        cookie.Values.Add("userid", model.uid.ToString());
                        cookie.Values.Add("userpwd", model.password.ToString());
                        //cookie.Domain = "eccm.fxzhj.com";
                        //cookie.Path = "/ECMM";
                        //cookie.Secure = true;
                        //把用户ID保存在cookie中
                        if (!string.IsNullOrEmpty(context.Request.Params["reb"]))
                        {
                            //7天过期
                            cookie.Expires = DateTime.Now.AddDays(7);
                        }
                        else
                        {
                            //缓存用户ID，关闭网站失效
                            cookie.Expires = DateTime.Now.AddDays(1);
                        }

                        //cookie.Value = HttpUtility.UrlEncode(cookie.Value); //HttpSecureCookie.Encode(cookie.Value);
                        //context.Response.Cookies.Add(cookie);
                        //加密Cookie
                        HttpCookie encodeCookie = HttpSecureCookie.Encode(cookie);
                        context.Response.Cookies.Add(encodeCookie);
                        //把用户信息保存在session中
                        context.Session["EccmUserinfo"] = model;
                        jr.IsSucceed = true;
                        jr.Msg = "登录成功";
                    }
                    else
                    {
                        jr.IsSucceed = false;
                        jr.Msg = "账号或密码错误";
                    }
                }
            }

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