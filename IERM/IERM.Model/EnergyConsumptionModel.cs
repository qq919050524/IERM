using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{

    /// <summary>
    /// 能耗统计  JINXIN
    /// </summary>
    [Serializable]
    public partial class EnergyConsumptionModel
    {
        /// <summary>
        /// 用电消耗
        /// </summary>
        private Int32 _electricity;
        /// <summary>
        /// 用水消耗
        /// </summary>
        private Int32 __water;
        /// <summary>
        /// 燃气消耗
        /// </summary>
        private Int32 _gas;

        public int Electricity
        {
            get
            {
                return _electricity;
            }

            set
            {
                _electricity = value;
            }
        }

        public int Water
        {
            get
            {
                return __water;
            }

            set
            {
                __water = value;
            }
        }

        public int Gas
        {
            get
            {
                return _gas;
            }

            set
            {
                _gas = value;
            }
        }
    }
}
