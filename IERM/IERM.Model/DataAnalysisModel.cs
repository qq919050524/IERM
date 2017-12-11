using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// JINXIN
    /// </summary>
    [Serializable]
    public partial class DataAnalysisModel
    {
        public DataAnalysisModel()
        {

        }

        /// <summary>
        /// 最大值
        /// </summary>
        private decimal _max;
       /// <summary>
       /// 最小值
       /// </summary>
        private decimal _min;
        /// <summary>
        /// 平均值
        /// </summary>
        private decimal _avg;
        /// <summary>
        /// 差值
        /// </summary>
        private decimal _difference;

        public decimal Max
        {
            get
            {
                return _max;
            }

            set
            {
                _max = value;
            }
        }

        public decimal Min
        {
            get
            {
                return _min;
            }

            set
            {
                _min = value;
            }
        }

        public decimal Avg
        {
            get
            {
                return _avg;
            }

            set
            {
                _avg = value;
            }
        }

        public decimal Difference
        {
            get
            {
                return _difference;
            }

            set
            {
                _difference = value;
            }
        }
    }
}
