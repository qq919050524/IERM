using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 配电  JINXIN
    /// </summary>
    [Serializable]
    public partial class SwitchRoomRdModel
    {
        public SwitchRoomRdModel()
        {
        }
        /// <summary>
        /// 环境温度
        /// </summary>
        private decimal _T_ROOM;
        /// <summary>
        /// 环境湿度
        /// </summary>
        private decimal _H_ROOM;
        /// <summary>
        /// 变压器A相温度
        /// </summary>
        private decimal _N1_T_A;
        /// <summary>
        /// 变压器B相温度
        /// </summary>
        private decimal _N1_T_B;
        /// <summary>
        /// 变压器C相温度
        /// </summary>
        private decimal _N1_T_C;
        /// <summary>
        /// 进线柜AB线电压
        /// </summary>
        private decimal _N1_UAB;
        /// <summary>
        /// 进线柜BC线电压
        /// </summary>
        private decimal _N1_UBC;
        /// <summary>
        /// 进线柜CA线电压
        /// </summary>
        private decimal _N1_UCA;
        /// <summary>
        /// 进线柜A相电流
        /// </summary>
        private decimal _N1_IA;
        /// <summary>
        /// 进线柜B相电流
        /// </summary>
        private decimal _N1_IB;
        /// <summary>
        /// 进线柜C相电流
        /// </summary>
        private decimal _N1_IC;
        /// <summary>
        /// 进线柜功率因素
        /// </summary>
        private decimal _N1_PF;
        /// <summary>
        /// 进线柜有功电能
        /// </summary>
        private int _N1_KWH;
        /// <summary>
        /// 进线柜无功电能
        /// </summary>
        private int _N1_KVARH;
        /// <summary>
        /// 变压器A相温度
        /// </summary>
        private decimal _N2_T_A;
        /// <summary>
        /// 变压器B相温度
        /// </summary>
        private decimal _N2_T_B;
        /// <summary>
        /// 变压器C相温度
        /// </summary>
        private decimal _N2_T_C;
        /// <summary>
        /// 进线柜AB线电压
        /// </summary>
        private decimal _N2_UAB;
        /// <summary>
        /// 进线柜BC线电压
        /// </summary>
        private decimal _N2_UBC;
        /// <summary>
        /// 进线柜CA线电压
        /// </summary>
        private decimal _N2_UCA;
        /// <summary>
        /// 进线柜A相电流
        /// </summary>
        private decimal _N2_IA;
        /// <summary>
        /// 进线柜B相电流
        /// </summary>
        private decimal _N2_IB;
        /// <summary>
        /// 进线柜C相电流
        /// </summary>
        private decimal _N2_IC;
        /// <summary>
        /// 进线柜功率因素
        /// </summary>
        private decimal _N2_PF;

        /// <summary>
        /// 进线柜无功电能
        /// </summary>
        private int _N2_KVARH;

        /// <summary>
        /// 进线柜有功电能
        /// </summary>
        private int _N2_KWH;

        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime _insertTime;

        public decimal T_ROOM
        {
            get
            {
                return _T_ROOM;
            }

            set
            {
                _T_ROOM = value;
            }
        }

        public decimal H_ROOM
        {
            get
            {
                return _H_ROOM;
            }

            set
            {
                _H_ROOM = value;
            }
        }

        public decimal N1_T_A
        {
            get
            {
                return _N1_T_A;
            }

            set
            {
                _N1_T_A = value;
            }
        }

        public decimal N1_T_B
        {
            get
            {
                return _N1_T_B;
            }

            set
            {
                _N1_T_B = value;
            }
        }

        public decimal N1_T_C
        {
            get
            {
                return _N1_T_C;
            }

            set
            {
                _N1_T_C = value;
            }
        }

        public decimal N1_UAB
        {
            get
            {
                return _N1_UAB;
            }

            set
            {
                _N1_UAB = value;
            }
        }

        public decimal N1_UBC
        {
            get
            {
                return _N1_UBC;
            }

            set
            {
                _N1_UBC = value;
            }
        }

        public decimal N1_UCA
        {
            get
            {
                return _N1_UCA;
            }

            set
            {
                _N1_UCA = value;
            }
        }

        public decimal N1_IA
        {
            get
            {
                return _N1_IA;
            }

            set
            {
                _N1_IA = value;
            }
        }

        public decimal N1_IB
        {
            get
            {
                return _N1_IB;
            }

            set
            {
                _N1_IB = value;
            }
        }

        public decimal N1_IC
        {
            get
            {
                return _N1_IC;
            }

            set
            {
                _N1_IC = value;
            }
        }

        public decimal N1_PF
        {
            get
            {
                return _N1_PF;
            }

            set
            {
                _N1_PF = value;
            }
        }

        public int N1_KWH
        {
            get
            {
                return _N1_KWH;
            }

            set
            {
                _N1_KWH = value;
            }
        }

        public int N1_KVARH
        {
            get
            {
                return _N1_KVARH;
            }

            set
            {
                _N1_KVARH = value;
            }
        }

        public decimal N2_T_A
        {
            get
            {
                return _N2_T_A;
            }

            set
            {
                _N2_T_A = value;
            }
        }

        public decimal N2_T_B
        {
            get
            {
                return _N2_T_B;
            }

            set
            {
                _N2_T_B = value;
            }
        }

        public decimal N2_T_C
        {
            get
            {
                return _N2_T_C;
            }

            set
            {
                _N2_T_C = value;
            }
        }

        public decimal N2_UAB
        {
            get
            {
                return _N2_UAB;
            }

            set
            {
                _N2_UAB = value;
            }
        }

        public decimal N2_UBC
        {
            get
            {
                return _N2_UBC;
            }

            set
            {
                _N2_UBC = value;
            }
        }

        public decimal N2_UCA
        {
            get
            {
                return _N2_UCA;
            }

            set
            {
                _N2_UCA = value;
            }
        }

        public decimal N2_IA
        {
            get
            {
                return _N2_IA;
            }

            set
            {
                _N2_IA = value;
            }
        }

        public decimal N2_IB
        {
            get
            {
                return _N2_IB;
            }

            set
            {
                _N2_IB = value;
            }
        }

        public decimal N2_IC
        {
            get
            {
                return _N2_IC;
            }

            set
            {
                _N2_IC = value;
            }
        }

        public decimal N2_PF
        {
            get
            {
                return _N2_PF;
            }

            set
            {
                _N2_PF = value;
            }
        }

        public int N2_KVARH
        {
            get
            {
                return _N2_KVARH;
            }

            set
            {
                _N2_KVARH = value;
            }
        }

        public int N2_KWH
        {
            get
            {
                return _N2_KWH;
            }

            set
            {
                _N2_KWH = value;
            }
        }

        public DateTime InsertTime
        {
            get
            {
                return DateTime.Parse(_insertTime.ToString());
            }

            set
            {
                _insertTime = value;
            }
        }
    }
}
