using System;
namespace IERM.Model
{
    /// <summary>
    /// EccmImplementImgModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EccmImplementImgModel
    {
        public EccmImplementImgModel()
        { }
        #region Model
        private int _img_id;
        private int? _implement_id;
        private string _img_path;
        private int? _img_type;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int img_id
        {
            set { _img_id = value; }
            get { return _img_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? implement_id
        {
            set { _implement_id = value; }
            get { return _implement_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string img_path
        {
            set { _img_path = value; }
            get { return _img_path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? img_type
        {
            set { _img_type = value; }
            get { return _img_type; }
        }
        #endregion Model
    }
}

