using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 分页JSON数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResultModel<T>
    {
        private int _total = 0;
        private T _rows;

        /// <summary>
        /// 集合总数
        /// </summary>
        public int total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        /// <summary>
        /// 当前页面数据集合
        /// </summary>
        public T rows
        {
            get
            {
                return _rows;
            }

            set
            {
                _rows = value;
            }
        }
    }
}
