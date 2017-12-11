using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 树形控件数据模型
    /// </summary>
    [Serializable]
    public class TreeViewModel
    {
        private string _id;
        private string _text;
        private bool _selectable=true;
        private string _color= "Default";
        private List<TreeViewModel> _nodes;
        private string _backColor = "Default";
        private TreeNoteState _state = new TreeNoteState();

        /// <summary>
        /// 编号
        /// </summary>
        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// 子集合
        /// </summary>
        public List<TreeViewModel> nodes
        {
            get
            {
                return _nodes;
            }

            set
            {
                _nodes = value;
            }
        }

        /// <summary>
        /// 是否可被选中
        /// </summary>
        public bool selectable
        {
            get
            {
                return _selectable;
            }

            set
            {
                _selectable = value;
            }
        }

        /// <summary>
        /// 节点前景色
        /// </summary>
        public string color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        /// <summary>
        ///背景颜色
        /// </summary>
        public string backColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                _backColor = value;
            }
        }

        /// <summary>
        /// 菜单状态
        /// </summary>
        public TreeNoteState state
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
    }

    [Serializable]
    public class TreeNoteState
    {
        private bool _selected = false;
        private bool _expanded = false;

        public bool expanded
        {
            get
            {
                return _expanded;
            }

            set
            {
                _expanded = value;
            }
        }

        public bool selected
        {
            get
            {
                return _selected;
            }

            set
            {
                _selected = value;
            }
        }
    }
}
