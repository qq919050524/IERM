using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
  public  class DeviceRelationModel
    {
        public DeviceRelationModel()
        { }
        private int _deviceID = 0;
        private string _deviceName = "";
        private string _deviceUrl = "";
        private int _devInfoID = 0;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int deviceID
        {
            set { _deviceID = value; }
            get { return _deviceID; }
        }
        /// <summary>
        /// 配电设备名称
        /// </summary>
        public string deviceName
        {
            set { _deviceName = value; }
            get { return _deviceName; }
        }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string deviceUrl
        {
            set { _deviceUrl = value; }
            get { return _deviceUrl; }
        }
        /// <summary>
        /// 设备房ID
        /// </summary>
        public int devInfoID
        {
            set { _devInfoID = value; }
            get { return _devInfoID; }
        }
    }
}
