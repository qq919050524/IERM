using System;
namespace IERM.Model
{
    /// <summary>
    /// EccmStandardModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class EccmStandardModel
    {
        public EccmStandardModel()
        { }
        #region Model
        private int _standard_id;
        private string _inspection_standard;
        private int _standard_type;
        private string _ext1;
        private string _ext2;
        private string _ext3;
        /// <summary>
        /// 
        /// </summary>
        public int standard_id
        {
            set { _standard_id = value; }
            get { return _standard_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inspection_standard
        {
            set { _inspection_standard = value; }
            get { return _inspection_standard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int standard_type
        {
            set { _standard_type = value; }
            get { return _standard_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ext1
        {
            set { _ext1 = value; }
            get { return _ext1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ext2
        {
            set { _ext2 = value; }
            get { return _ext2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ext3
        {
            set { _ext3 = value; }
            get { return _ext3; }
        }
        #endregion Model

    }
}

