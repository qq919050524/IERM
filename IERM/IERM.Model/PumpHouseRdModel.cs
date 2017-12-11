using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Model
{
    /// <summary>
    /// 泵房  JINXIN
    /// </summary>
    [Serializable]
    public partial class PumpHouseRdModel
    {
        public PumpHouseRdModel()
        {
        }
        /// <summary>
        /// 主键
        /// </summary>
        private int _pid;
        /// <summary>
        /// 设备房编号
        /// </summary>
       // private int _devid;
        /// <summary>
        /// 设备房-环境温度
        /// </summary>
        private decimal _T_ROOM;
        /// <summary>
        /// 设备房-环境湿度
        /// </summary>
        private decimal _H_ROOM;
        /// <summary>
        /// 设备房-烟雾报警
        /// </summary>
        private int _ALARM_FIRE;
        /// <summary>
        /// 设备房-水淹报警
        /// </summary>
        private int _ALARM_SUMP;
        /// <summary>
        /// 生活供水-电源柜AB线电压
        /// </summary>
        private decimal _UAB_SH;
        /// <summary>
        /// 生活供水-电源柜BC线电压
        /// </summary>
        private decimal _UBC_SH;
        /// <summary>
        /// 生活供水-电源柜CA线电压
        /// </summary>
        private decimal _UCA_SH;
        /// <summary>
        /// 生活供水-电源柜A相电流
        /// </summary>
        private decimal _IA_SH;
        /// <summary>
        /// 生活供水-电源柜B相电流
        /// </summary>
        private decimal _IB_SH;
        /// <summary>
        /// 生活供水-电源柜C相电流
        /// </summary>
        private decimal _IC_SH;
        /// <summary>
        /// 生活供水-电源柜有功电能
        /// </summary>
        private int _KWH_SH;
        /// <summary>
        /// 生活供水-电源柜无功电能
        /// </summary>
        private int _KVARH_SH;
        /// <summary>
        /// 生活供水-电源柜功率因素
        /// </summary>
        private decimal _PF_SH;
        /// <summary>
        /// 生活供水-生活水箱液位
        /// </summary>
        private decimal _L_SHSX;
        /// <summary>
        /// 生活供水-市政进水压力
        /// </summary>
        private decimal _P_IN;
        /// <summary>
        /// 生活供水-低区供水压力
        /// </summary>
        private decimal _P_LO;
        /// <summary>
        /// 生活供水-中区供水压力
        /// </summary>
        private decimal _P_MI;
        /// <summary>
        /// 生活供水-高区供水压力
        /// </summary>
        private decimal _P_HI;
        /// <summary>
        /// 生活供水-超高区供水压力
        /// </summary>
        private decimal _P_SP;
        /// <summary>
        /// 消防供水-电源柜AB线电压
        /// </summary>
        private decimal _UAB_XF;
        /// <summary>
        /// 消防供水-电源柜BC线电压
        /// </summary>
        private decimal _UBC_XF;
        /// <summary>
        /// 消防供水-电源柜CA线电压
        /// </summary>
        private decimal _UCA_XF;
        /// <summary>
        /// 消防供水-电源柜A相电流
        /// </summary>
        private decimal _IA_XF;
        /// <summary>
        /// 消防供水-电源柜B相电流
        /// </summary>
        private decimal _IB_XF;
        /// <summary>
        /// 消防供水-电源柜C相电流
        /// </summary>
        private decimal _IC_XF;
        /// <summary>
        /// 消防供水-电源柜有功电能
        /// </summary>
        private int _KWH_XF;
        /// <summary>
        /// 消防供水-电源柜无功电能
        /// </summary>
        private int _KVARH_XF;
        /// <summary>
        /// 消防供水-电源柜功率因素
        /// </summary>
        private decimal _PF_XF;
        /// <summary>
        /// 消防供水-消防水箱液位
        /// </summary>
        private decimal _L_XFSX;
        /// <summary>
        /// 消防供水-消防1#供水压力
        /// </summary>
        private decimal _P_XF1;
        /// <summary>
        /// 消防供水-喷淋1#供水压力
        /// </summary>
        private decimal _P_PL1;
        /// <summary>
        /// 消防供水-消防2#供水压力
        /// </summary>
        private decimal _P_XF2;
        /// <summary>
        /// 消防供水-喷淋2#供水压力
        /// </summary>
        private decimal _P_PL2;
        /// <summary>
        /// 录入时间
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

        public int ALARM_FIRE
        {
            get
            {
                return _ALARM_FIRE;
            }

            set
            {
                _ALARM_FIRE = value;
            }
        }

        public int ALARM_SUMP
        {
            get
            {
                return _ALARM_SUMP;
            }

            set
            {
                _ALARM_SUMP = value;
            }
        }

        public decimal UAB_SH
        {
            get
            {
                return _UAB_SH;
            }

            set
            {
                _UAB_SH = value;
            }
        }

        public decimal UBC_SH
        {
            get
            {
                return _UBC_SH;
            }

            set
            {
                _UBC_SH = value;
            }
        }

        public decimal UCA_SH
        {
            get
            {
                return _UCA_SH;
            }

            set
            {
                _UCA_SH = value;
            }
        }

        public decimal IA_SH
        {
            get
            {
                return _IA_SH;
            }

            set
            {
                _IA_SH = value;
            }
        }

        public decimal IB_SH
        {
            get
            {
                return _IB_SH;
            }

            set
            {
                _IB_SH = value;
            }
        }

        public decimal IC_SH
        {
            get
            {
                return _IC_SH;
            }

            set
            {
                _IC_SH = value;
            }
        }

        public int KWH_SH
        {
            get
            {
                return _KWH_SH;
            }

            set
            {
                _KWH_SH = value;
            }
        }

        public int KVARH_SH
        {
            get
            {
                return _KVARH_SH;
            }

            set
            {
                _KVARH_SH = value;
            }
        }

        public decimal PF_SH
        {
            get
            {
                return _PF_SH / 100;
            }

            set
            {
                _PF_SH = value;
            }
        }

        public decimal L_SHSX
        {
            get
            {
                return _L_SHSX;
            }

            set
            {
                _L_SHSX = value;
            }
        }

        public decimal P_IN
        {
            get
            {
                return _P_IN;
            }

            set
            {
                _P_IN = value;
            }
        }

        public decimal P_LO
        {
            get
            {
                return _P_LO;
            }

            set
            {
                _P_LO = value;
            }
        }

        public decimal P_MI
        {
            get
            {
                return _P_MI;
            }

            set
            {
                _P_MI = value;
            }
        }

        public decimal P_HI
        {
            get
            {
                return _P_HI;
            }

            set
            {
                _P_HI = value;
            }
        }

        public decimal P_SP
        {
            get
            {
                return _P_SP;
            }

            set
            {
                _P_SP = value;
            }
        }

        public decimal UAB_XF
        {
            get
            {
                return _UAB_XF;
            }

            set
            {
                _UAB_XF = value;
            }
        }

        public decimal UBC_XF
        {
            get
            {
                return _UBC_XF;
            }

            set
            {
                _UBC_XF = value;
            }
        }

        public decimal UCA_XF
        {
            get
            {
                return _UCA_XF;
            }

            set
            {
                _UCA_XF = value;
            }
        }

        public decimal IA_XF
        {
            get
            {
                return _IA_XF;
            }

            set
            {
                _IA_XF = value;
            }
        }

        public decimal IB_XF
        {
            get
            {
                return _IB_XF;
            }

            set
            {
                _IB_XF = value;
            }
        }

        public decimal IC_XF
        {
            get
            {
                return _IC_XF;
            }

            set
            {
                _IC_XF = value;
            }
        }

        public int KWH_XF
        {
            get
            {
                return _KWH_XF;
            }

            set
            {
                _KWH_XF = value;
            }
        }

        public int KVARH_XF
        {
            get
            {
                return _KVARH_XF;
            }

            set
            {
                _KVARH_XF = value;
            }
        }

        public decimal PF_XF
        {
            get
            {
                return _PF_XF / 100;
            }

            set
            {
                _PF_XF = value;
            }
        }

        public decimal L_XFSX
        {
            get
            {
                return _L_XFSX;
            }

            set
            {
                _L_XFSX = value;
            }
        }

        public decimal P_XF1
        {
            get
            {
                return _P_XF1;
            }

            set
            {
                _P_XF1 = value;
            }
        }

        public decimal P_PL1
        {
            get
            {
                return _P_PL1;
            }

            set
            {
                _P_PL1 = value;
            }
        }

        public decimal P_XF2
        {
            get
            {
                return _P_XF2;
            }

            set
            {
                _P_XF2 = value;
            }
        }

        public decimal P_PL2
        {
            get
            {
                return _P_PL2;
            }

            set
            {
                _P_PL2 = value;
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

        public int Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }
    }

    /// <summary>
    /// 给排水
    /// </summary>
    public partial class PumpHouseModel
    {
        public PumpHouseModel()
        {
        }
        /// <summary>
        /// 主键
        /// </summary>
        private int _pid;
        /// <summary>
        /// 设备房编号
        /// </summary>
       // private int _devid;
        /// <summary>
        /// 设备房-环境温度
        /// </summary>
        private decimal _T_ROOM;
        /// <summary>
        /// 设备房-环境湿度
        /// </summary>
        private decimal _H_ROOM;
        /// <summary>
        /// 设备房-烟雾报警
        /// </summary>
        private int _ALARM_FIRE;
        /// <summary>
        /// 设备房-水淹报警
        /// </summary>
        private int _ALARM_SUMP;
        /// <summary>
        /// 生活供水-电源柜AB线电压
        /// </summary>
        private decimal _UAB_SH;
        /// <summary>
        /// 生活供水-电源柜BC线电压
        /// </summary>
        private decimal _UBC_SH;
        /// <summary>
        /// 生活供水-电源柜CA线电压
        /// </summary>
        private decimal _UCA_SH;
        /// <summary>
        /// 生活供水-电源柜A相电流
        /// </summary>
        private decimal _IA_SH;
        /// <summary>
        /// 生活供水-电源柜B相电流
        /// </summary>
        private decimal _IB_SH;
        /// <summary>
        /// 生活供水-电源柜C相电流
        /// </summary>
        private decimal _IC_SH;
        /// <summary>
        /// 生活供水-电源柜有功电能
        /// </summary>
        private int _KWH_SH;
        /// <summary>
        /// 生活供水-电源柜无功电能
        /// </summary>
        private int _KVARH_SH;
        /// <summary>
        /// 生活供水-电源柜功率因素
        /// </summary>
        private decimal _PF_SH;
        /// <summary>
        /// 生活供水-生活水箱液位
        /// </summary>
        private decimal _L_SHSX;
        /// <summary>
        /// 生活供水-市政进水压力
        /// </summary>
        private decimal _P_IN;
        /// <summary>
        /// 生活供水-低区供水压力
        /// </summary>
        private decimal _P_LO;
        /// <summary>
        /// 生活供水-中区供水压力
        /// </summary>
        private decimal _P_MI;
        /// <summary>
        /// 生活供水-高区供水压力
        /// </summary>
        private decimal _P_HI;
        /// <summary>
        /// 生活供水-超高区供水压力
        /// </summary>
        private decimal _P_SP;

        /// <summary>
        /// 录入时间
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

        public int ALARM_FIRE
        {
            get
            {
                return _ALARM_FIRE;
            }

            set
            {
                _ALARM_FIRE = value;
            }
        }

        public int ALARM_SUMP
        {
            get
            {
                return _ALARM_SUMP;
            }

            set
            {
                _ALARM_SUMP = value;
            }
        }

        public decimal UAB_SH
        {
            get
            {
                return _UAB_SH;
            }

            set
            {
                _UAB_SH = value;
            }
        }

        public decimal UBC_SH
        {
            get
            {
                return _UBC_SH;
            }

            set
            {
                _UBC_SH = value;
            }
        }

        public decimal UCA_SH
        {
            get
            {
                return _UCA_SH;
            }

            set
            {
                _UCA_SH = value;
            }
        }

        public decimal IA_SH
        {
            get
            {
                return _IA_SH;
            }

            set
            {
                _IA_SH = value;
            }
        }

        public decimal IB_SH
        {
            get
            {
                return _IB_SH;
            }

            set
            {
                _IB_SH = value;
            }
        }

        public decimal IC_SH
        {
            get
            {
                return _IC_SH;
            }

            set
            {
                _IC_SH = value;
            }
        }

        public int KWH_SH
        {
            get
            {
                return _KWH_SH;
            }

            set
            {
                _KWH_SH = value;
            }
        }

        public int KVARH_SH
        {
            get
            {
                return _KVARH_SH;
            }

            set
            {
                _KVARH_SH = value;
            }
        }

        public decimal PF_SH
        {
            get
            {
                return _PF_SH / 100;
            }

            set
            {
                _PF_SH = value;
            }
        }

        public decimal L_SHSX
        {
            get
            {
                return _L_SHSX;
            }

            set
            {
                _L_SHSX = value;
            }
        }

        public decimal P_IN
        {
            get
            {
                return _P_IN;
            }

            set
            {
                _P_IN = value;
            }
        }

        public decimal P_LO
        {
            get
            {
                return _P_LO;
            }

            set
            {
                _P_LO = value;
            }
        }

        public decimal P_MI
        {
            get
            {
                return _P_MI;
            }

            set
            {
                _P_MI = value;
            }
        }

        public decimal P_HI
        {
            get
            {
                return _P_HI;
            }

            set
            {
                _P_HI = value;
            }
        }

        public decimal P_SP
        {
            get
            {
                return _P_SP;
            }

            set
            {
                _P_SP = value;
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

        public int Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }
    }


    /// <summary>
    /// 消防
    /// </summary>
    public partial class FirePumpHouseModel
    {
        public FirePumpHouseModel()
        {
        }
        /// <summary>
        /// 主键
        /// </summary>
        private int _pid;
        /// <summary>
        /// 设备房编号
        /// </summary>
       // private int _devid;
        /// <summary>
        /// 设备房-环境温度
        /// </summary>
        private decimal _T_ROOM;
        /// <summary>
        /// 设备房-环境湿度
        /// </summary>
        private decimal _H_ROOM;
        /// <summary>
        /// 设备房-烟雾报警
        /// </summary>
        private int _ALARM_FIRE;
        /// <summary>
        /// 设备房-水淹报警
        /// </summary>
        private int _ALARM_SUMP;


        /// <summary>
        /// 消防供水-电源柜AB线电压
        /// </summary>
        private decimal _UAB_XF;
        /// <summary>
        /// 消防供水-电源柜BC线电压
        /// </summary>
        private decimal _UBC_XF;
        /// <summary>
        /// 消防供水-电源柜CA线电压
        /// </summary>
        private decimal _UCA_XF;
        /// <summary>
        /// 消防供水-电源柜A相电流
        /// </summary>
        private decimal _IA_XF;
        /// <summary>
        /// 消防供水-电源柜B相电流
        /// </summary>
        private decimal _IB_XF;
        /// <summary>
        /// 消防供水-电源柜C相电流
        /// </summary>
        private decimal _IC_XF;
        /// <summary>
        /// 消防供水-电源柜有功电能
        /// </summary>
        private int _KWH_XF;
        /// <summary>
        /// 消防供水-电源柜无功电能
        /// </summary>
        private int _KVARH_XF;
        /// <summary>
        /// 消防供水-电源柜功率因素
        /// </summary>
        private decimal _PF_XF;
        /// <summary>
        /// 消防供水-消防水箱液位
        /// </summary>
        private decimal _L_XFSX;
        /// <summary>
        /// 消防供水-消防1#供水压力
        /// </summary>
        private decimal _P_XF1;
        /// <summary>
        /// 消防供水-喷淋1#供水压力
        /// </summary>
        private decimal _P_PL1;
        /// <summary>
        /// 消防供水-消防2#供水压力
        /// </summary>
        private decimal _P_XF2;
        /// <summary>
        /// 消防供水-喷淋2#供水压力
        /// </summary>
        private decimal _P_PL2;
        /// <summary>
        /// 录入时间
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

        public int ALARM_FIRE
        {
            get
            {
                return _ALARM_FIRE;
            }

            set
            {
                _ALARM_FIRE = value;
            }
        }

        public int ALARM_SUMP
        {
            get
            {
                return _ALARM_SUMP;
            }

            set
            {
                _ALARM_SUMP = value;
            }
        }

        public decimal UAB_XF
        {
            get
            {
                return _UAB_XF;
            }

            set
            {
                _UAB_XF = value;
            }
        }

        public decimal UBC_XF
        {
            get
            {
                return _UBC_XF;
            }

            set
            {
                _UBC_XF = value;
            }
        }

        public decimal UCA_XF
        {
            get
            {
                return _UCA_XF;
            }

            set
            {
                _UCA_XF = value;
            }
        }

        public decimal IA_XF
        {
            get
            {
                return _IA_XF;
            }

            set
            {
                _IA_XF = value;
            }
        }

        public decimal IB_XF
        {
            get
            {
                return _IB_XF;
            }

            set
            {
                _IB_XF = value;
            }
        }

        public decimal IC_XF
        {
            get
            {
                return _IC_XF;
            }

            set
            {
                _IC_XF = value;
            }
        }

        public int KWH_XF
        {
            get
            {
                return _KWH_XF;
            }

            set
            {
                _KWH_XF = value;
            }
        }

        public int KVARH_XF
        {
            get
            {
                return _KVARH_XF;
            }

            set
            {
                _KVARH_XF = value;
            }
        }

        public decimal PF_XF
        {
            get
            {
                return _PF_XF / 100;
            }

            set
            {
                _PF_XF = value;
            }
        }

        public decimal L_XFSX
        {
            get
            {
                return _L_XFSX;
            }

            set
            {
                _L_XFSX = value;
            }
        }

        public decimal P_XF1
        {
            get
            {
                return _P_XF1;
            }

            set
            {
                _P_XF1 = value;
            }
        }

        public decimal P_PL1
        {
            get
            {
                return _P_PL1;
            }

            set
            {
                _P_PL1 = value;
            }
        }

        public decimal P_XF2
        {
            get
            {
                return _P_XF2;
            }

            set
            {
                _P_XF2 = value;
            }
        }

        public decimal P_PL2
        {
            get
            {
                return _P_PL2;
            }

            set
            {
                _P_PL2 = value;
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

        public int Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }
    }
}
