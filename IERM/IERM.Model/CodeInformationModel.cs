using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// JINXIN
    /// </summary>
    public partial  class CodeInformationModel
    {
        /// <summary>
        /// 主键（自增长，唯一）
        /// </summary>
        private int _cid;
        /// <summary>
        /// 编码
        /// </summary>
        private string _code;
        /// <summary>
        /// 编码名
        /// </summary>
        private string _codeName;

        /// <summary>
        /// 删除标识
        /// </summary>
        private int _isDel;

        public int Cid
        {
            get
            {
                return _cid;
            }

            set
            {
                _cid = value;
            }
        }

        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public string CodeName
        {
            get
            {
                return _codeName;
            }

            set
            {
                _codeName = value;
            }
        }

        public int IsDel
        {
            get
            {
                return _isDel;
            }

            set
            {
                _isDel = value;
            }
        }
    }
}
