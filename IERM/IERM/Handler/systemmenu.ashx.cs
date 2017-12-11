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
    /// systemmenu 的摘要说明
    /// </summary>
    public class systemmenu : IHttpHandler
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
                    case "menulist"://获取菜单列表
                        result = GetMenuList(context);
                        break;
                    case "deletemenu"://删除菜单
                        result = DeleteMenu(context);
                        break;
                    case "updatemenu"://编辑菜单
                        result = UpdateMenu(context);
                        break;
                    case "addmenu"://添加菜单
                        result = AddMenu(context);
                        break;
                    case "getmenu"://获取菜单
                        result = GetMenu(context);
                        break;
                    case "getmenutreelist": //获取角色列表
                        result = GetMenuTreeList(context);
                        break;
                }
            }
            context.Response.Write(result);
        }


        /// <summary>
        /// 获取菜单列表
        /// </summary>
        private string GetMenuList(HttpContext context)
        {
            int pagesize = 10;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageNumber"];
            string _psize = context.Request.Params["pageSize"];

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }

            var pr = new PagingResultModel<List<SysMenuModel>>()
            {
                total = 0,
                rows = new List<SysMenuModel>()
            };
            SysMenuBLL menu_bll = new SysMenuBLL();
            List<SysMenuModel> list = menu_bll.GetMenuList(string.Empty, out rowcount);
            pr.rows = list.Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList(); ;
            pr.total = rowcount;
            return JsonConvert.SerializeObject(pr);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        private string DeleteMenu(HttpContext context)
        {
            string mid = context.Request.Params["mid"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除菜单失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(mid))
            {
                SysMenuBLL menu_bll = new SysMenuBLL();
                if (menu_bll.DeleteMenu(int.Parse(mid)) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "删除菜单成功";
                    jr.Data = int.Parse(mid);
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        private string UpdateMenu(HttpContext context)
        {
            //================必填=====================
            string mid = context.Request.Params["mid"];
            string menuname = context.Request.Params["menuname"];
            string menuico = context.Request.Params["menuico"];
            string menuurl = context.Request.Params["menuurl"];
            string msort = context.Request.Params["msort"];

            SysMenuModel model = new SysMenuModel();
            model.mid = int.Parse(mid);
            model.menuName = menuname;
            model.menuIco = menuico;
            model.menuUrl = menuurl;
            model.mSort = int.Parse(msort);

            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "更新菜单失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(mid))
            {
                SysMenuBLL menu_bll = new SysMenuBLL();
                if (menu_bll.Update(model) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "更新菜单["+ menuname + "]成功";
                    jr.Data = int.Parse(mid);
                }
            }
            return JsonConvert.SerializeObject(jr);
        }


        /// <summary>
        /// 增加菜单
        /// </summary>
        private string AddMenu(HttpContext context)
        {
            //================必填=====================
            string mpid = context.Request.Params["mpid"];
            string menuname = context.Request.Params["menuname"];
            string menuico = context.Request.Params["menuico"];
            string menuurl = context.Request.Params["menuurl"];
            string msort = context.Request.Params["msort"];

            SysMenuModel model = new SysMenuModel();
            //model.mid = int.Parse(mid);
            model.menuName = menuname;
            model.menuIco = menuico;
            model.menuUrl = menuurl;
            model.mSort = int.Parse(msort);
            model.mPID = int.Parse(mpid);
            model.isDel = false;

            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "增加菜单失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(menuname))
            {
                SysMenuBLL menu_bll = new SysMenuBLL();
                if (menu_bll.Add(model) > 0)
                {
                    jr.IsSucceed = true;
                    jr.Msg = "增加菜单[" + menuname + "]成功";
                    //jr.Data = int.Parse(mid);
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetMenu(HttpContext context)
        {
            int rowcount = 0;
            SysMenuBLL menu_bll = new SysMenuBLL();
            List<SysMenuModel> list = menu_bll.GetMenuList(string.Empty, out rowcount);
            var jr = new JsonResultModel<List<SysMenuModel>>()
            {
                IsSucceed = false,
                Data = new List<SysMenuModel>(),
                Msg = "获取菜单失败",
            };
            if (list != null && list.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = list;
                jr.Msg = "获取菜单成功";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取菜单树列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetMenuTreeList(HttpContext context)
        {
            int rowcount = 0;
            SysMenuBLL menu_bll = new SysMenuBLL();
            List<SysMenuModel> list = menu_bll.GetMenuList(string.Empty, out rowcount);//先获取所有菜单

            //所有菜单遍历成树状格式
            List<TreeViewModel> menutreelist = ToMenuTreeList(list, 0);

            var jr = new JsonResultModel<List<TreeViewModel>>()
            {
                IsSucceed = false,
                Data = new List<TreeViewModel>(),
                Msg = "获取树菜单失败",
                RedirectUrl = string.Empty
            };


            if (menutreelist != null && menutreelist.Count > 0)
            {
                jr.IsSucceed = true;
                jr.Data = menutreelist;
                jr.Msg = "获取树菜单成功";
            }
            string s = JsonConvert.SerializeObject(jr);
            return JsonConvert.SerializeObject(jr);
        }


        /// <summary>
        /// 获取菜单转化为树
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="parentID"></param>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        private List<TreeViewModel> ToMenuTreeList(List<SysMenuModel> menuList, int parentID, int menu_id = 0)
        {
            List<SysMenuModel> menuTree = menuList.FindAll(c => c.mPID == parentID && c.isDel == false);
            List<TreeViewModel> treeList = new List<TreeViewModel>();
            foreach (SysMenuModel menu in menuTree)
            {
                TreeViewModel tree = new TreeViewModel();
                tree.id = menu.mid.ToString();
                tree.text = menu.menuName;
                //tree.state.expanded = false;
                //tree.state.selected = false;
                //递归 
                tree.nodes = ToMenuTreeList(menuList, menu.mid);
                if (tree.nodes.Count == 0)
                {
                    tree.nodes = null;
                }
                treeList.Add(tree);
            }
            return treeList;
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