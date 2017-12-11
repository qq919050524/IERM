using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 省市实体
    /// </summary>
	[Serializable]
    public partial class CityInfoModel
    {
        public CityInfoModel()
        { }
        #region Model
        private int _areaid;
        private string _areaname;
        private int _pid = 0;
        private bool _isdel = false;
        private int _sort = 1000;
        
        /// <summary>
        /// 地区编号
        /// </summary>
        public int areaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }

        /// <summary>
        /// 省份/城市名称
        /// </summary>
        public string areaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }

        /// <summary>
        /// 父级id
        /// </summary>
        public int pID
        {
            set { _pid = value; }
            get { return _pid; }
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
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model

    }
}
