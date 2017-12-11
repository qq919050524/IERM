using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
	/// sysmenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class SysMenuModel
    {
        public SysMenuModel()
        { }
        #region Model
        private int _mid;
        private string _menuname;
        private string _menuico;
        private string _menuurl;
        private int _mpid = 0;
        private bool _isdel = false;
        private int _msort = 1000;

        private List<SysMenuModel> _cmlist = new List<SysMenuModel>();

        /// <summary>
        /// 菜单id
        /// </summary>
        public int mid
        {
            set { _mid = value; }
            get { return _mid; }
        }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string menuName
        {
            set { _menuname = value; }
            get { return _menuname; }
        }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string menuIco
        {
            set { _menuico = value; }
            get { return _menuico; }
        }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string menuUrl
        {
            set { _menuurl = value; }
            get { return _menuurl; }
        }

        /// <summary>
        /// 菜单父id
        /// </summary>
        public int mPID
        {
            set { _mpid = value; }
            get { return _mpid; }
        }

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int mSort
        {
            set { _msort = value; }
            get { return _msort; }
        }

        /// <summary>
        /// 子菜单集合
        /// </summary>
        public List<SysMenuModel> cmList
        {
            get
            {
                return _cmlist;
            }

            set
            {
                _cmlist = value;
            }
        }
        #endregion Model

    }
}
