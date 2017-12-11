using IERM.BLL;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// 角色权限相关接口
    /// </summary>
    public class RoleRelated : IHttpHandler
    {
        private readonly RoleInfoBLL role_bll = new RoleInfoBLL();
        private readonly RightInfoBLL right_bll = new RightInfoBLL();
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
                    case "getallroles"://获取所有激活的角色列表
                        result = GetAllRoles(context);
                        break;                  
                    case "delroles": //删除指定id的角色
                        result = DelRoles(context);
                        break;
                    case "getallright": //获取全部权限
                        result = GetAllRight(context);
                        break;
                    case "gerrightsbyroleid": //获取指定角色的权限集合
                        result = GerRightsByRoleID(context);
                        break;
                    case "addrightstorole": //添加角色权限
                        result = AddRightsToRole(context);
                        break;
                    case "updaterole": //编辑角色
                        result = UpdateRole(context);
                        break;
                    case "addrole": //添加角色
                        result = AddRole(context);
                        break;
                    case "addrolemenu": //添加角色权限
                        result = AddRoleMenu(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取全部启用角色列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAllRoles(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize= context.Request.Params["pageSize"];

            if(!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if(!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }

            var pr = new PagingResultModel<List<RoleInfoModel>>()
            {
                total = 0,
                rows = new List<RoleInfoModel>()
            };
            pr.rows = role_bll.GetPagingRoles(" isDel=0",pageindex,pagesize,out rowcount);

            pr.total = rowcount;
            
            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 删除一条角色
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DelRoles(HttpContext context)
        {
            string rid = context.Request.Params["rid"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = string.Empty,
                RedirectUrl = string.Empty
            };
            if (string.IsNullOrEmpty(rid))
            {
                jr.Msg = "参数错误";
            }
            else
            {
                if(role_bll.Delete(int.Parse(rid))>0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "删除成功";
                }
                else
                {
                    jr.Msg = "删除失败";
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取全部权限列表
        /// </summary>
        private string GetAllRight(HttpContext context)
        {
            var jr = new JsonResultModel<List<RightInfoModel>>() {
            IsSucceed=false,
            Data=new List<RightInfoModel>(),
            Msg="获取权限失败",
            RedirectUrl=string.Empty
            };

            var tmpdata = right_bll.GetAllRight();
            if(tmpdata!=null&&tmpdata.Count>0)
            {
                jr.IsSucceed = true;
                jr.Data = tmpdata;
                jr.Msg = "获取权限成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 根据角色ID获取权限列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GerRightsByRoleID(HttpContext context)
        {
            var jr = new JsonResultModel<List<RightInfoModel>>()
            {
                IsSucceed = false,
                Data = new List<RightInfoModel>(),
                Msg = "获取权限失败",
                RedirectUrl = string.Empty
            };
            string roleid = context.Request.Params["roleID"];
            int _roleID = 0;
            int.TryParse(roleid, out _roleID);
            var tmpdata = right_bll.GetRightByRoleID(_roleID);

            if (tmpdata != null && tmpdata.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = tmpdata;
                jr.Msg = "获取权限成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 为角色添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string AddRightsToRole(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "获取权限失败",
                RedirectUrl = string.Empty
            };
            string roleid = context.Request.Params["roleID"];
            string rights = context.Request.Params["rights"];

            int _roleID = 0;
            int.TryParse(roleid, out _roleID);
            var tmpdata = right_bll.AddRightsToRole(_roleID, rights);

            if (tmpdata > 0)
            {
                jr.IsSucceed = true;
                jr.Data = tmpdata;
                jr.Msg = "添加权限成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        private string UpdateRole(HttpContext context)
        {
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "编辑角色失败",
                RedirectUrl = string.Empty
            };
            int roleid = string.IsNullOrEmpty(context.Request.Params["roleid"])?0:Convert.ToInt32(context.Request.Params["roleid"]);
            string _rolecode = context.Request.Params["roleCode"];
            string _rolename = context.Request.Params["roleName"];
            string _intro = context.Request.Params["intro"];
            string _rights = context.Request.Params["rights"];

            if (role_bll.Update(new RoleInfoModel()
            {
                rid = roleid,
                roleCode = _rolecode,
                roleName = _rolename,
                intro = _intro
            }, _rights))
            {
                jr.IsSucceed = true;
                jr.Data = 1;
                jr.Msg = "编辑角色成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        private string AddRole(HttpContext context)
        {
            //================必填=====================
            string propertyID = context.Request.Params["propertyID"];
            //string rid = context.Request.Params["roleid"];
            string roleCode = context.Request.Params["roleCode"];
            string roleName = context.Request.Params["roleName"];
            string intro = context.Request.Params["intro"];
            string rights = context.Request.Params["rights"];

            RoleInfoModel model = new RoleInfoModel();
            //model.mid = int.Parse(mid);
            model.propertyID = int.Parse(propertyID);
            model.roleCode = roleCode;
            model.roleName = roleName;
            model.intro = intro;
            model.isDel = false;

            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "增加角色失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(roleName))
            {
                SysMenuBLL menu_bll = new SysMenuBLL();
                if (role_bll.Add(model,rights) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "增加角色[" + roleName + "]成功";
                    //jr.Data = int.Parse(mid);
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        private string AddRoleMenu(HttpContext context)
        {
            //================必填=====================
            string mid = context.Request.Params["mid"];
            string ids = context.Request.Params["ids"];

            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "授权失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(mid))
            {
                EccmRoleMenuRelationBLL menu_bll = new EccmRoleMenuRelationBLL();
                if (menu_bll.Add(int.Parse(mid), ids) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "授权成功";
                    //jr.Data = int.Parse(mid);
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