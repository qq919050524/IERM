using System;
namespace IERM.Model
{
    /// <summary>
    /// EccmStandardModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EccmDeviceTypeModel
    {
        public EccmDeviceTypeModel()
        { }
        #region Model
        private int _type_id;
        private string _device_type_code;
        private string _devide_type_name;
        /// <summary>
        /// 
        /// </summary>
        public int type_id
        {
            set { _type_id = value; }
            get { return _type_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string device_type_code
        {
            set { _device_type_code = value; }
            get { return _device_type_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string devide_type_name
        {
            set { _devide_type_name = value; }
            get { return _devide_type_name; }
        }
        
        #endregion Model

    }
}

