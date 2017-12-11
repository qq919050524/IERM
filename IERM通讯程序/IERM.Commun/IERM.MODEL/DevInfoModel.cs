using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    public class DevInfoModel
    {
        public DevInfoModel()
        { }

        private int _devid;
        private string _devname;
        private int _devtype = 0;
        private int _communityid;
        private bool _isdel = false;
        private int _sort = 1000;

        /// <summary>
        /// 设备房编号
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }

        /// <summary>
        /// 设备房名称
        /// </summary>
        public string devName
        {
            set { _devname = value; }
            get { return _devname; }
        }

        /// <summary>
        /// 设备类型编号
        /// </summary>
        public int devType
        {
            set { _devtype = value; }
            get { return _devtype; }
        }

        /// <summary>
        /// 小区编号
        /// </summary>
        public int communityID
        {
            set { _communityid = value; }
            get { return _communityid; }
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
    }
}
