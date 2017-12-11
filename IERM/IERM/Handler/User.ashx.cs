
using IERM.BLL;
using IERM.Common;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class User : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private readonly UserInfoBLL user_bll = new UserInfoBLL();
        private readonly UserLogBLL userlog_bll = new UserLogBLL();
        public void ProcessRequest(HttpContext context)
        {

            ////liuli 报警日志 TODO：需要页面选择对接
            //userlog_bll.Add(uid);
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
                    case "getuserwithrole"://获取所有激活的用户列表
                        result = GetUserWithRole(context);
                        break;
                    case "getauthcommunity"://获取所有激活的用户列表
                        result = GetAuthCommunity(context);
                        break;
                    case "adduser"://添加新用户
                        result = AddUser(context);
                        break;
                    case "updateuser"://编辑用户
                        result = UpdateUser(context);
                        break;
                    case "deleteuser"://删除用户
                        result = DeleteUser(context);
                        break;
                    case "getuserbycommunity"://获取小区下的用户
                        result = GetUserByCommunity(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetUserWithRole(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize = context.Request.Params["pageSize"];
            string _role = context.Request.Params["roleType"];
            string _nickname = context.Request.Params["nickname"];
            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }
            if (!string.IsNullOrEmpty(_role))
            {
                if (int.Parse(_role) > 0)
                {
                    strWhere.AppendFormat("where rid={0}", _role);
                }
            }
            if (!string.IsNullOrEmpty(_nickname))
            {
                if (strWhere.Length > 4)
                {
                    strWhere.AppendFormat(" and nickName like '%{0}%'", _nickname);
                }
                else
                {
                    strWhere.AppendFormat(" where nickName like '%{0}%'", _nickname);
                }
            }

            var pr = new PagingResultModel<DataTable>()
            {
                total = 0,
                rows = new DataTable()
            };
            pr.rows = user_bll.GetPagingUserinfoWithRole(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 加载授权小区
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAuthCommunity(HttpContext context)
        {
            var jr = new JsonResultModel<List<AuthCommunityModel>>()
            {
                IsSucceed = false,
                Data = new List<AuthCommunityModel>(),
                Msg = "获取小区信息失败",
                RedirectUrl = ""
            };
            try
            {
                //用户编号

                int userid = string.IsNullOrEmpty(context.Request.Params["uid"]) ? 0 : Convert.ToInt32(context.Request.Params["uid"]);
                string cityid = context.Request.Params["cityid"];
                string partname = context.Request.Params["partname"];


                var authlist = user_bll.GetAuthCommunity(userid, int.Parse(cityid), partname);

                if (authlist != null && authlist.Count > 0)
                {
                    jr.Data = authlist;
                    jr.Msg = "获取小区信息成功";
                    jr.IsSucceed = true;
                }

            }
            catch (Exception err)
            {
                LogHelper.Debug("获取小区信息失败+原因:" + err.Message);
            }
            return JsonConvert.SerializeObject(jr);

        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        private string AddUser(HttpContext context)
        {
            //================必填=====================
            string loginName = context.Request.Params["loginName"];
            string password = context.Request.Params["password"];
            string nickName = context.Request.Params["nickName"];

            string headimg = context.Request.Params["headimg"];
            string mobile = context.Request.Params["mobile"];
            string companyName = context.Request.Params["property"];
            string departmentName = context.Request.Params["departmentName"];
            string remark = context.Request.Params["remark"];
            //角色信息
            string radioRole = context.Request.Params["radio_role"];
            //授权小区
            string authcommunity = context.Request.Params["authcommunity"];

            //新用户
            var newuser = new UserInfoModel()
            {
                loginName = loginName,
                password = ConvertHelper.StringToMD5(password),
                nickName = nickName,
                mobile = mobile,
                headimg = headimg,
                companyName = companyName,
                departmentName = departmentName,
                remark = remark
            };

            try
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "添加用户失败",
                    RedirectUrl = ""
                };
                HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
                if (cook != null)
                {
                    //解密Cookie 
                    HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                    string uid = decodeCookie.Values["userid"];
                    if (user_bll.Add(newuser, radioRole, authcommunity, int.Parse(uid)))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "添加用户成功";
                    }
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
               LogHelper.Debug("添加新用户（AddUser）---" + err.Message);
                throw err;
            }



        }

        /// <summary>
        /// 更新用户
        /// </summary>
        private string UpdateUser(HttpContext context)
        {
            //================必填=====================
            string userid = context.Request.Params["uid"];
            string loginName = context.Request.Params["loginName"];
            //string password = context.Request.Params["password"];
            string nickName = context.Request.Params["nickName"];

            string headimg = context.Request.Params["headimg"];
            string mobile = context.Request.Params["mobile"];
            string companyName = context.Request.Params["property"];
            string departmentName = context.Request.Params["departmentName"];
            string remark = context.Request.Params["remark"];
            //角色信息
            string radioRole = context.Request.Params["radio_role"];
            //授权小区
            string authcommunity = context.Request.Params["authcommunity"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "修改用户失败",
                RedirectUrl = ""
            };

            try
            {
                //新用户
                HttpCookie cook = HttpContext.Current.Request.Cookies["EccmUserinfo"];
                if (cook != null)
                {
                    //解密Cookie 
                    HttpCookie decodeCookie = HttpSecureCookie.Decode(cook);
                    string uid = decodeCookie.Values["userid"];
                    var newuser = new UserInfoModel()
                    {
                        uid = Convert.ToInt32(userid),
                        loginName = loginName,
                        //password = COMMON.ConvertHelper.StringToMD5(password),
                        nickName = nickName,
                        mobile = mobile,
                        headimg = headimg,
                        companyName = companyName,
                        departmentName = departmentName,
                        remark = remark
                    };
                    if (user_bll.Update(newuser, radioRole, authcommunity, int.Parse(uid)))
                    {
                        jr.IsSucceed = true;
                        jr.Msg = "修改用户成功";
                    }
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
                LogHelper.Debug("添加新用户（UpdateUser）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        private string DeleteUser(HttpContext context)
        {
            string userid = context.Request.Params["uid"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除用户失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(userid))
            {
                int uid = 0;
                int.TryParse(userid, out uid);

                if (user_bll.DeleteUser(uid) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "删除用户成功";
                    jr.Data = uid;
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 根据小区获取，用户
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetUserByCommunity(HttpContext context)
        {
            int communityID = string.IsNullOrEmpty(context.Request.Params["communityID"]) ? 0 : Convert.ToInt32(context.Request.Params["communityID"]);
            var jr = new JsonResultModel<List<UserInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<UserInfoModel>(),
                Msg = "获取用户失败失败",
                RedirectUrl = string.Empty
            };
            if (communityID > 0)
            {
                jr.IsSucceed = true;
                jr.Data = user_bll.GetUserByCommunity(communityID);
                jr.Msg = "获取设备房系统类型成功";
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