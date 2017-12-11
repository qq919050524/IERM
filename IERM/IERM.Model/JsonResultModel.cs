using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    [Serializable]
    public class JsonResultModel<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSucceed { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回结果数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 重定向地址
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}
