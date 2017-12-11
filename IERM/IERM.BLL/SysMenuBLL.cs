using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IERM.Model;
using IERM.DAL;

namespace IERM.BLL
{
    public class SysMenuBLL
    {
        private readonly SysMenuDAL menu_dal = new SysMenuDAL();

        public List<SysMenuModel> GetMenuList(string strcmd)
        {
            List<SysMenuModel> result = new List<SysMenuModel>();

            DataTable menus = menu_dal.GetSysMenu(strcmd);
            if (menus.Rows.Count == 0) return result;


            foreach (DataRow item in menus.Rows)
            {
                var tmp = result.Find(m => m.mid == Convert.ToInt32(item["mPID"]));
                if (tmp == null)
                {
                    tmp = new SysMenuModel()
                    {
                        mid = Convert.ToInt32(item["mPID"]),
                        menuName = item["menuName_p"].ToString(),
                        menuIco = item["menuIco_p"].ToString()
                    };
                    tmp.cmList.Add(new SysMenuModel()
                    {
                        mid = Convert.ToInt32(item["mid"]),
                        menuName = item["menuName"].ToString(),
                        menuIco = item["menuIco"].ToString(),
                        menuUrl = item["menuUrl"].ToString(),
                        mPID = Convert.ToInt32(item["mPID"]),
                        isDel = Convert.ToBoolean(item["isDel"]),
                        mSort = Convert.ToInt32(item["mSort"]),
                        cmList = new List<SysMenuModel>()
                    });
                    result.Add(tmp);
                }
                else
                {
                    tmp.cmList.Add(new SysMenuModel()
                    {
                        mid = Convert.ToInt32(item["mid"]),
                        menuName = item["menuName"].ToString(),
                        menuIco = item["menuIco"].ToString(),
                        menuUrl = item["menuUrl"].ToString(),
                        mPID = Convert.ToInt32(item["mPID"]),
                        isDel = Convert.ToBoolean(item["isDel"]),
                        mSort = Convert.ToInt32(item["mSort"]),
                        cmList = new List<SysMenuModel>()
                    });
                }

            }
            return result;
        }

        /// <summary>
        /// 根据用户id获取角色菜单
        /// </summary>
        /// <returns></returns>
        public List<SysMenuModel> GetRoleMenuByUserId(string userid)
        {
            List<SysMenuModel> result = new List<SysMenuModel>();

            DataTable menus = menu_dal.GetRoleMenuByUserId(userid);
            if (menus.Rows.Count == 0) return result;


            foreach (DataRow item in menus.Rows)
            {
                var tmp = result.Find(m => m.mid == Convert.ToInt32(item["mPID"]));
                if (tmp == null)
                {
                    tmp = new SysMenuModel()
                    {
                        mid = Convert.ToInt32(item["mPID"]),
                        menuName = item["menuName_p"].ToString(),
                        menuIco = item["menuIco_p"].ToString()
                    };
                    tmp.cmList.Add(new SysMenuModel()
                    {
                        mid = Convert.ToInt32(item["mid"]),
                        menuName = item["menuName"].ToString(),
                        menuIco = item["menuIco"].ToString(),
                        menuUrl = item["menuUrl"].ToString(),
                        mPID = Convert.ToInt32(item["mPID"]),
                        isDel = Convert.ToBoolean(item["isDel"]),
                        mSort = Convert.ToInt32(item["mSort"]),
                        cmList = new List<SysMenuModel>()
                    });
                    result.Add(tmp);
                }
                else
                {
                    tmp.cmList.Add(new SysMenuModel()
                    {
                        mid = Convert.ToInt32(item["mid"]),
                        menuName = item["menuName"].ToString(),
                        menuIco = item["menuIco"].ToString(),
                        menuUrl = item["menuUrl"].ToString(),
                        mPID = Convert.ToInt32(item["mPID"]),
                        isDel = Convert.ToBoolean(item["isDel"]),
                        mSort = Convert.ToInt32(item["mSort"]),
                        cmList = new List<SysMenuModel>()
                    });
                }

            }
            return result;
        }

        /// <summary>
        /// 查询菜单列表以及总数
        /// </summary>
        /// <param name="strcmd">查询条件</param>
        /// <param name="rowcount">返回总数</param>
        /// <returns></returns>
        public List<SysMenuModel> GetMenuList(string strcmd, out int rowcount)
        {
            List<SysMenuModel> result = new List<SysMenuModel>();

            DataTable menus = menu_dal.GetMenu(strcmd);
            if (menus.Rows.Count == 0)
            {
                rowcount = 0;
                return result;
            }

            rowcount = menus.Rows.Count;

            foreach (DataRow item in menus.Rows)
            {
                SysMenuModel tmp = new SysMenuModel();
                tmp.mid = Convert.ToInt32(item["mid"]);
                tmp.menuName = item["menuName"].ToString();
                tmp.menuIco = item["menuIco"].ToString();
                tmp.menuUrl = item["menuUrl"].ToString();
                tmp.mPID = Convert.ToInt32(item["mPID"]);
                tmp.isDel = Convert.ToBoolean(item["isDel"]);
                tmp.mSort = Convert.ToInt32(item["mSort"]);
                result.Add(tmp);
            }
            return result;
        }

        /// <summary>
        /// 修改系统菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(SysMenuModel model)
        {
            return menu_dal.Update(model);
        }

        /// <summary>
        /// 删除菜单(逻辑删除)
        /// </summary>
        public int DeleteMenu(int mid)
        {
            return menu_dal.Delete(mid);
        }

        /// <summary>
        /// 增加菜单
        /// </summary>
        public int Add(SysMenuModel model)
        {
            return menu_dal.Add(model);
        }
    }
}
