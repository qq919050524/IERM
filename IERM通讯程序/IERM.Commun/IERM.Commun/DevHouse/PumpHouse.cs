using IERM.Common;
using IERM.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IERM.WCFService.DevHouse
{
    public class PumpHouse : BaseDevHouse
    {
        private readonly BLL.PumpHouseRdBLL pumphouse_bll = new BLL.PumpHouseRdBLL();

        public PumpHouse(int _devnum, List<AlarmSettingModel> _alarmSettinglist)
        {
            if (_devnum < 0 || _devnum > 10000)
            {
                Common.LogHelper.Dbbug("{0}设备房编号超出范围！");
            }
            DevNum = _devnum;
            AlarmSettingList = _alarmSettinglist;
            InsertTime = DateTime.MinValue;
        }

        /// <summary>
        /// 数据解码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override BaseDevHouse Decode(byte[] data)
        {
            #region -----------解码并赋值--------------
            

            //设备房 - 环境温度    T_ROOM    0
            T_ROOM = BinaryHelper.GetNumByByteRange(data, GetRange(0)) / 100M;
            //设备房 - 环境湿度    H_ROOM    1
            H_ROOM = BinaryHelper.GetNumByByteRange(data, GetRange(1)) / 100M;
            //设备房 - 烟雾报警    ALARM_FIRE     2   0
            ALARM_FIRE = BinaryHelper.GetbitValue(data, GetRange(2), 0);
            //设备房 - 水淹报警    ALARM_SUMP    2     1
            ALARM_SUMP = BinaryHelper.GetbitValue(data, GetRange(2), 1);
            //生活供水 - 电源柜AB线电压   UAB_SH   3
            UAB_SH = BinaryHelper.GetNumByByteRange(data, GetRange(3)) / 100M;
            //生活供水 - 电源柜BC线电压   UBC_SH   4
            UBC_SH = BinaryHelper.GetNumByByteRange(data, GetRange(4)) / 100M;
            //生活供水 - 电源柜CA线电压   UCA_SH   5
            UCA_SH = BinaryHelper.GetNumByByteRange(data, GetRange(5)) / 100M;
            //生活供水 - 电源柜A相电流    IA_SH    6
            IA_SH = BinaryHelper.GetNumByByteRange(data, GetRange(6)) / 100M;
            //生活供水 - 电源柜B相电流    IB_SH    7
            IB_SH = BinaryHelper.GetNumByByteRange(data, GetRange(7)) / 100M;
            //生活供水 - 电源柜C相电流    IC_SH    8
            IC_SH = BinaryHelper.GetNumByByteRange(data, GetRange(8)) / 100M;
            //生活供水 - 电源柜有功电能    KWH_SH    9
            KWH_SH = BinaryHelper.GetNumByByteRange(data, GetRange(9)) ;
            //生活供水 - 电源柜无功电能    KVARH_SH   10
            KVARH_SH = BinaryHelper.GetNumByByteRange(data, GetRange(10));
            //生活供水 - 电源柜功率因素    PF_SH   11
            PF_SH = BinaryHelper.GetNumByByteRange(data, GetRange(11)) ;
            //生活供水 - 生活水箱液位 L_SHSX  12
            L_SHSX = BinaryHelper.GetNumByByteRange(data, GetRange(12)) / 100M;
            //生活供水 - 市政进水压力 P_IN   13
            P_IN = BinaryHelper.GetNumByByteRange(data, GetRange(13)) / 100M;
            //生活供水 - 低区供水压力 P_LO  14
            P_LO = BinaryHelper.GetNumByByteRange(data, GetRange(14)) / 100M;
            //生活供水 - 中区供水压力 P_MI   15
            P_MI = BinaryHelper.GetNumByByteRange(data, GetRange(15)) / 100M;
            //生活供水 - 高区供水压力 P_HI  16
            P_HI = BinaryHelper.GetNumByByteRange(data, GetRange(16)) / 100M;
            //生活供水 - 超高区供水压力    P_SP  17
            P_SP = BinaryHelper.GetNumByByteRange(data, GetRange(17)) / 100M;


            //生活供水 - 低区电源信号 DI_LP_POW   18  0
            DI_LP_POW = BinaryHelper.GetbitValue(data, GetRange(18), 0);
            //生活供水 - 低区泵故障信号    DI_LP_AL 18   1
            DI_LP_AL = BinaryHelper.GetbitValue(data, GetRange(18), 1);
            //生活供水 - 低区1#泵运行	DI_LP1	18	2
            DI_LP1 = BinaryHelper.GetbitValue(data, GetRange(18), 2);
            //生活供水 - 低区2#泵运行	DI_LP2	18	3
            DI_LP2 = BinaryHelper.GetbitValue(data, GetRange(18), 3);
            //生活供水 - 低区3#泵运行	DI_LP3	18	4
            DI_LP3 = BinaryHelper.GetbitValue(data, GetRange(18), 4);
            //生活供水 - 低区4#泵运行	DI_LP4	18	5
            DI_LP4 = BinaryHelper.GetbitValue(data, GetRange(18), 5);
            //+++生活供水—低区节能泵运行 DI_LP_JNB 18 6
            DI_LP_JNB = BinaryHelper.GetbitValue(data, GetRange(18), 6);

            //生活供水 - 中区电源   DI_MP_POW 18  7
            DI_MP_POW = BinaryHelper.GetbitValue(data, GetRange(18), 7);
            //生活供水 - 中区泵故障  DI_MP_AL 18   8
            DI_MP_AL = BinaryHelper.GetbitValue(data, GetRange(18), 8);
            //生活供水 - 中区1#泵运行	DI_MP1	18   9
            DI_MP1 = BinaryHelper.GetbitValue(data, GetRange(18), 9);
            //生活供水 - 中区2#泵运行	DI_MP2	18   10
            DI_MP2 = BinaryHelper.GetbitValue(data, GetRange(18), 10);
            //生活供水 - 中区3#泵运行	DI_MP3	18   11
            DI_MP3 = BinaryHelper.GetbitValue(data, GetRange(18), 11);
            //生活供水 - 中区4#泵运行	DI_MP4	18   12
            DI_MP4 = BinaryHelper.GetbitValue(data, GetRange(18), 12);
            //+++生活供水—中区节能泵运行 DI_LP_JNB 18 13
            DI_MP_JNB = BinaryHelper.GetbitValue(data, GetRange(18), 13);


            //生活供水 - 高区电源   DI_HP_POW 18   14
            DI_HP_POW = BinaryHelper.GetbitValue(data, GetRange(18), 14);
            //生活供水 - 高区泵故障  DI_HP_AL 18   15
            DI_HP_AL = BinaryHelper.GetbitValue(data, GetRange(18), 15);
            //生活供水 - 高区1#泵运行	DI_HP1	18   16
            DI_HP1 = BinaryHelper.GetbitValue(data, GetRange(18), 16);
            //生活供水 - 高区2#泵运行	DI_HP2	18   17
            DI_HP2 = BinaryHelper.GetbitValue(data, GetRange(18), 17);
            //生活供水 - 高区3#泵运行	DI_HP3	18   18
            DI_HP3 = BinaryHelper.GetbitValue(data, GetRange(18), 18);
            //生活供水 - 高区4#泵运行	DI_HP4	18   19
            DI_HP4 = BinaryHelper.GetbitValue(data, GetRange(18), 19);
            //+++生活供水—高区节能泵运行 DI_LP_JNB 18 20
            DI_HP_JNB = BinaryHelper.GetbitValue(data, GetRange(18), 20);


            //生活供水 - 超高区电源  DI_SP_POW 18   21
            DI_SP_POW = BinaryHelper.GetbitValue(data, GetRange(18), 21);
            //生活供水 - 超高区泵故障 DI_SP_AL 18   22
            DI_SP_AL = BinaryHelper.GetbitValue(data, GetRange(18), 22);
            //生活供水 - 超高区1#泵运行	DI_SP1	18   23
            DI_SP1 = BinaryHelper.GetbitValue(data, GetRange(18), 23);
            //生活供水 - 超高区2#泵运行	DI_SP2	18   24
            DI_SP2 = BinaryHelper.GetbitValue(data, GetRange(18), 24);
            //生活供水 - 超高区3#泵运行	DI_SP3	18   25
            DI_SP3 = BinaryHelper.GetbitValue(data, GetRange(18), 25);
            //生活供水 - 超高区4#泵运行	DI_SP4	18   26
            DI_SP4 = BinaryHelper.GetbitValue(data, GetRange(18), 26);
            //+++生活供水—低区节能泵运行 DI_LP_JNB 18 27
            DI_SP_JNB = BinaryHelper.GetbitValue(data, GetRange(18),27);


            //消防供水 - 电源柜AB线电压   UAB_XF   19
            UAB_XF = BinaryHelper.GetNumByByteRange(data, GetRange(19)) / 100M;
            //消防供水 - 电源柜BC线电压   UBC_XF   20
            UBC_XF = BinaryHelper.GetNumByByteRange(data, GetRange(20)) / 100M;
            //消防供水 - 电源柜CA线电压   UCA_XF   21
            UCA_XF = BinaryHelper.GetNumByByteRange(data, GetRange(21)) / 100M;
            //消防供水 - 电源柜A相电流    IA_XF    22
            IA_XF = BinaryHelper.GetNumByByteRange(data, GetRange(22)) / 100M;
            //消防供水 - 电源柜B相电流    IB_XF    23
            IB_XF = BinaryHelper.GetNumByByteRange(data, GetRange(23)) / 100M;
            //消防供水 - 电源柜C相电流    IC_XF    24
            IC_XF = BinaryHelper.GetNumByByteRange(data, GetRange(24)) / 100M;
            //消防供水 - 电源柜有功电能    KWH_XF   25
            KWH_XF = BinaryHelper.GetNumByByteRange(data, GetRange(25));
            //消防供水 - 电源柜无功电能    KVARH_XF    26
            KVARH_XF = BinaryHelper.GetNumByByteRange(data, GetRange(26));
            //消防供水 - 电源柜功率因素    PF_XF    27
            PF_XF = BinaryHelper.GetNumByByteRange(data, GetRange(27)) / 100M;
            //消防供水 - 消防水箱液位 L_XFSX    28
            L_XFSX = BinaryHelper.GetNumByByteRange(data, GetRange(28)) / 100M;
            //消防供水 - 消防1#供水压力	P_XF1 	29	
            P_XF1 = BinaryHelper.GetNumByByteRange(data, GetRange(29)) / 100M;
            //消防供水 - 喷淋1#供水压力	P_PL1   30	
            P_PL1 = BinaryHelper.GetNumByByteRange(data, GetRange(30)) / 100M;
            //消防供水 - 消防2#供水压力	P_XF2 	31	
            P_XF2 = BinaryHelper.GetNumByByteRange(data, GetRange(31)) / 100M;
            //消防供水 - 喷淋2#供水压力	P_PL2 	32	
            P_PL2 = BinaryHelper.GetNumByByteRange(data, GetRange(32)) / 100M;
            #endregion

            if ((DateTime.Now-InsertTime).TotalMinutes>=10)
            {
                InsertTime = DateTime.Now;
                Add();
            }
            return this;
        }

        /// <summary>
        /// 添加一条新泵房数据
        /// </summary>
        private void Add()
        {
            pumphouse_bll.Add(new MODEL.PumpHouseRdModel()
            {
                devid = DevNum,
                T_ROOM = this.T_ROOM,
                H_ROOM = this.H_ROOM,
                ALARM_FIRE = this.ALARM_FIRE,
                ALARM_SUMP = this.ALARM_SUMP,
                UAB_SH = this.UAB_SH,
                UBC_SH = this.UBC_SH,
                UCA_SH = this.UCA_SH,
                IA_SH = this.IA_SH,
                IB_SH = this.IB_SH,
                IC_SH = this.IC_SH,
                KWH_SH = this.KWH_SH,
                KVARH_SH = this.KVARH_SH,
                PF_SH = this.PF_SH,
                L_SHSX = this.L_SHSX,
                P_IN = this.P_IN,
                P_LO = this.P_LO,
                P_MI = this.P_MI,
                P_HI = this.P_HI,
                P_SP = this.P_SP,
                DI_LP_POW = this.DI_LP_POW,
                DI_LP_AL = this.DI_LP_AL,
                DI_LP1 = this.DI_LP1,
                DI_LP2 = this.DI_LP2,
                DI_LP3 = this.DI_LP3,
                DI_LP4 = this.DI_LP4,
                DI_MP_POW = this.DI_MP_POW,
                DI_MP_AL = this.DI_MP_AL,
                DI_MP1 = this.DI_MP1,
                DI_MP2 = this.DI_MP2,
                DI_MP3 = this.DI_MP3,
                DI_MP4 = this.DI_MP4,
                DI_HP_POW = this.DI_HP_POW,
                DI_HP_AL = this.DI_HP_AL,
                DI_HP1 = this.DI_HP1,
                DI_HP2 = this.DI_HP2,
                DI_HP3 = this.DI_HP3,
                DI_HP4 = this.DI_HP4,
                DI_SP_POW = this.DI_SP_POW,
                DI_SP_AL = this.DI_SP_AL,
                DI_SP1 = this.DI_SP1,
                DI_SP2 = this.DI_SP2,
                DI_SP3 = this.DI_SP3,
                DI_SP4 = this.DI_SP4,
                UAB_XF = this.UAB_XF,
                UBC_XF = this.UBC_XF,
                UCA_XF = this.UCA_XF,
                IA_XF = this.IA_XF,
                IB_XF = this.IB_XF,
                IC_XF = this.IC_XF,
                KWH_XF = this.KWH_XF,
                KVARH_XF = this.KVARH_XF,
                PF_XF = this.PF_XF,
                L_XFSX = this.L_XFSX,
                P_XF1 = this.P_XF1,
                P_PL1 = this.P_PL1,
                P_XF2 = this.P_XF2,
                P_PL2 = this.P_PL2,
                insertTime = DateTime.Now,
                DI_LP_JNB = this.DI_LP_JNB,
                DI_MP_JNB = this.DI_MP_JNB,
                DI_HP_JNB = this.DI_HP_JNB,
                DI_SP_JNB = this.DI_SP_JNB
            });
        }


        /// <summary>
        /// 向服务器请求数据
        /// </summary>
        /// <returns></returns>
        public override byte[] Request()
        {
            byte[] byteTitle = BinaryHelper.strToToHexByte("3E 2A");
            byte[] byteDev = BinaryHelper.ushortToBytes((ushort)DevNum);
            byte[] byteStar = BinaryHelper.ushortToBytes(0);
            byte[] byteLength = BinaryHelper.ushortToBytes(200);

            return byteTitle.Concat(byteDev).Concat(byteStar).Concat(byteLength).ToArray();
        }

        public override string ToJson()
        {
            throw new NotImplementedException();
        }

        private int[] GetRange(int index)
        {
            return new int[] { index * 4, (index + 1) * 4 - 1 };
        }

        #region ----------------设备房字段和属性----------------- 

        #region =============字段============
        private decimal _t_room;
        private decimal _h_room;
        private bool _alarm_fire;
        private bool _alarm_sump;
        private decimal _uab_sh;
        private decimal _ubc_sh;
        private decimal _uca_sh;
        private decimal _ia_sh;
        private decimal _ib_sh;
        private decimal _ic_sh;
        private int _kwh_sh;
        private int _kvarh_sh;
        private decimal _pf_sh;
        private decimal _l_shsx;
        private decimal _p_in;
        private decimal _p_lo;
        private decimal _p_mi;
        private decimal _p_hi;
        private decimal _p_sp;
        private bool _di_lp_pow;
        private bool _di_lp_al;
        private bool _di_lp1;
        private bool _di_lp2;
        private bool _di_lp3;
        private bool _di_lp4;
        private bool _di_lp_jnb;
        private bool _di_mp_pow;
        private bool _di_mp_al;
        private bool _di_mp1;
        private bool _di_mp2;
        private bool _di_mp3;
        private bool _di_mp4;
        private bool _di_mp_jnb;
        private bool _di_hp_pow;
        private bool _di_hp_al;
        private bool _di_hp1;
        private bool _di_hp2;
        private bool _di_hp3;
        private bool _di_hp4;
        private bool _di_hp_jnb;
        private bool _di_sp_pow;
        private bool _di_sp_al;
        private bool _di_sp1;
        private bool _di_sp2;
        private bool _di_sp3;
        private bool _di_sp4;
        private bool _di_sp_jnb;
        private decimal _uab_xf;
        private decimal _ubc_xf;
        private decimal _uca_xf;
        private decimal _ia_xf;
        private decimal _ib_xf;
        private decimal _ic_xf;
        private int _kwh_xf;
        private int _kvarh_xf;
        private decimal _pf_xf;
        private decimal _l_xfsx;
        private decimal _p_xf1;
        private decimal _p_pl1;
        private decimal _p_xf2;
        private decimal _p_pl2;
        #endregion

        /// <summary>
        /// 设备房-环境温度 0 报警
        /// </summary>
        public decimal T_ROOM
        {
            private set
            {
                if (_t_room != value)
                {
                    GetAnalogAlarm(value, "T_ROOM");
                }
                _t_room = value;
            }
            get { return _t_room; }
        }

        /// <summary>
        /// 设备房-环境湿度 1 报警
        /// </summary>
        public decimal H_ROOM
        {
            set
            {
                if (_h_room != value)
                {
                    GetAnalogAlarm(value, "H_ROOM");
                }
                _h_room = value;
            }
            get { return _h_room; }
        }

        /// <summary>
        /// 设备房-烟雾报警 2 24 报警
        /// </summary>
        public bool ALARM_FIRE
        {
            set
            {
                if (_alarm_fire != value)
                {
                    GetDigitalAlarm(value, "ALARM_FIRE");
                }
                _alarm_fire = value;
            }
            get { return _alarm_fire; }
        }

        /// <summary>
        /// 设备房-水淹报警 2 25 报警
        /// </summary>
        public bool ALARM_SUMP
        {
            set
            {
                if (_alarm_sump != value)
                {
                    GetDigitalAlarm(value, "ALARM_SUMP");
                }
                _alarm_sump = value;
            }
            get { return _alarm_sump; }
        }

        /// <summary>
        /// 生活供水-电源柜AB线电压 3 报警
        /// </summary>
        public decimal UAB_SH
        {
            set
            {
                if (_uab_sh != value)
                {
                    GetAnalogAlarm(value, "UAB_SH");
                }
                _uab_sh = value;
            }
            get { return _uab_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜BC线电压 4 报警
        /// </summary>
        public decimal UBC_SH
        {
            set
            {
                if (_ubc_sh != value)
                {
                    GetAnalogAlarm(value, "UBC_SH");
                }
                _ubc_sh = value;
            }
            get { return _ubc_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜CA线电压 5 报警
        /// </summary>
        public decimal UCA_SH
        {
            set
            {
                if (_uca_sh != value)
                {
                    GetAnalogAlarm(value, "UCA_SH");
                }
                _uca_sh = value;
            }
            get { return _uca_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜A相电流 6 报警
        /// </summary>
        public decimal IA_SH
        {
            set
            {
                if (_ia_sh != value)
                {
                    GetAnalogAlarm(value, "IA_SH");
                }
                _ia_sh = value;
            }
            get { return _ia_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜B相电流 7 报警
        /// </summary>
        public decimal IB_SH
        {
            set
            {
                if (_ib_sh != value)
                {
                    GetAnalogAlarm(value, "IB_SH");
                }
                _ib_sh = value;
            }
            get { return _ib_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜C相电流 8 报警
        /// </summary>
        public decimal IC_SH
        {
            set
            {
                if (_ic_sh != value)
                {
                    GetAnalogAlarm(value, "IC_SH");
                }
                _ic_sh = value;
            }
            get { return _ic_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜有功电能 9
        /// </summary>
        public int KWH_SH
        {
            set { _kwh_sh = value; }
            get { return _kwh_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜无功电能 10
        /// </summary>
        public int KVARH_SH
        {
            set { _kvarh_sh = value; }
            get { return _kvarh_sh; }
        }

        /// <summary>
        /// 生活供水-电源柜功率因素 11 报警
        /// </summary>
        public decimal PF_SH
        {
            set
            {
                if (_pf_sh != value)
                {
                    GetAnalogAlarm(value, "PF_SH");
                }
                _pf_sh = value;
            }
            get { return _pf_sh; }
        }

        /// <summary>
        /// 生活供水-生活水箱液位 12 报警
        /// </summary>
        public decimal L_SHSX
        {
            set
            {
                if (_l_shsx != value)
                {
                    GetAnalogAlarm(value, "L_SHSX");
                }
                _l_shsx = value;
            }
            get { return _l_shsx; }
        }

        /// <summary>
        /// 生活供水-市政进水压力 13 报警
        /// </summary>
        public decimal P_IN
        {
            set
            {
                if (_p_in != value)
                {
                    GetAnalogAlarm(value, "P_IN");
                }
                _p_in = value;
            }
            get { return _p_in; }
        }

        /// <summary>
        /// 生活供水-低区供水压力 14 报警
        /// </summary>
        public decimal P_LO
        {
            set
            {
                if (_p_lo != value)
                {
                    GetAnalogAlarm(value, "P_LO");
                }
                _p_lo = value;
            }
            get { return _p_lo; }
        }

        /// <summary>
        /// 生活供水-中区供水压力 15 报警
        /// </summary>
        public decimal P_MI
        {
            set
            {
                if (_p_mi != value)
                {
                    GetAnalogAlarm(value, "P_MI");
                }
                _p_mi = value;
            }
            get { return _p_mi; }
        }

        /// <summary>
        /// 生活供水-高区供水压力 16 报警
        /// </summary>
        public decimal P_HI
        {
            set
            {
                if (_p_hi != value)
                {
                    GetAnalogAlarm(value, "P_HI");
                }
                _p_hi = value;
            }
            get { return _p_hi; }
        }

        /// <summary>
        /// 生活供水-超高区供水压力 17 报警
        /// </summary>
        public decimal P_SP
        {
            set
            {
                if (_p_sp != value)
                {
                    GetAnalogAlarm(value, "P_SP");
                }
                _p_sp = value;
            }
            get { return _p_sp; }
        }

        /// <summary>
        /// 生活供水-低区电源信号 18 0 报警
        /// </summary>
        public bool DI_LP_POW
        {
            set
            {
                if (_di_lp_pow != value)
                {
                    GetDigitalAlarm(value, "DI_LP_POW");
                }
                _di_lp_pow = value;
            }
            get { return _di_lp_pow; }
        }

        /// <summary>
        /// 生活供水-低区泵故障信号 18 1 报警 
        /// </summary>
        public bool DI_LP_AL
        {
            set
            {
                if (_di_lp_pow != value)
                {
                    GetDigitalAlarm(value, "DI_LP_POW");
                }
                _di_lp_al = value;
            }
            get { return _di_lp_al; }
        }

        /// <summary>
        /// 生活供水-低区1#泵运行 18 2
        /// </summary>
        public bool DI_LP1
        {
            set { _di_lp1 = value; }
            get { return _di_lp1; }
        }

        /// <summary>
        /// 生活供水-低区2#泵运行 18 3
        /// </summary>
        public bool DI_LP2
        {
            set { _di_lp2 = value; }
            get { return _di_lp2; }
        }

        /// <summary>
        /// 生活供水-低区3#泵运行 18 4
        /// </summary>
        public bool DI_LP3
        {
            set { _di_lp3 = value; }
            get { return _di_lp3; }
        }

        /// <summary>
        /// 生活供水-低区4#泵运行 18 5
        /// </summary>
        public bool DI_LP4
        {
            set { _di_lp4 = value; }
            get { return _di_lp4; }
        }

        /// <summary>
        /// 生活供水—低区节能泵运行 18 6
        /// </summary>
        public bool DI_LP_JNB
        {
            set { _di_lp_jnb = value; }
            get { return _di_lp_jnb; }
        }

        /// <summary>
        /// 生活供水-中区电源 18 7 报警
        /// </summary>
        public bool DI_MP_POW
        {
            set
            {
                if (_di_mp_pow != value)
                {
                    GetDigitalAlarm(value, "DI_MP_POW");
                }
                _di_mp_pow = value;
            }
            get { return _di_mp_pow; }
        }

        /// <summary>
        /// 生活供水-中区泵故障 18 8 报警
        /// </summary>
        public bool DI_MP_AL
        {
            set
            {
                if (_di_mp_al != value)
                {
                    GetDigitalAlarm(value, "DI_MP_AL");
                }
                _di_mp_al = value;
            }
            get { return _di_mp_al; }
        }

        /// <summary>
        /// 生活供水-中区1#泵运行 18 9
        /// </summary>
        public bool DI_MP1
        {
            set { _di_mp1 = value; }
            get { return _di_mp1; }
        }

        /// <summary>
        /// 生活供水-中区2#泵运行 18 10
        /// </summary>
        public bool DI_MP2
        {
            set { _di_mp2 = value; }
            get { return _di_mp2; }
        }

        /// <summary>
        /// 生活供水-中区3#泵运行 18 11
        /// </summary>
        public bool DI_MP3
        {
            set { _di_mp3 = value; }
            get { return _di_mp3; }
        }

        /// <summary>
        /// 生活供水-中区4#泵运行 18 12
        /// </summary>
        public bool DI_MP4
        {
            set { _di_mp4 = value; }
            get { return _di_mp4; }
        }

        /// <summary>
        /// 生活供水—中区节能泵运行 18 13
        /// </summary>
        public bool DI_MP_JNB
        {
            set { _di_mp_jnb = value; }
            get { return _di_mp_jnb; }
        }

        /// <summary>
        /// 生活供水-高区电源 18 14 报警
        /// </summary>
        public bool DI_HP_POW
        {
            set
            {
                if (_di_hp_pow != value)
                {
                    GetDigitalAlarm(value, "DI_HP_POW");
                }
                _di_hp_pow = value;
            }
            get { return _di_hp_pow; }
        }

        /// <summary>
        /// 生活供水-高区泵故障 18 15 报警
        /// </summary>
        public bool DI_HP_AL
        {
            set
            {
                if (_di_hp_al != value)
                {
                    GetDigitalAlarm(value, "DI_HP_AL");
                }
                _di_hp_al = value;
            }
            get { return _di_hp_al; }
        }

        /// <summary>
        /// 生活供水-高区1#泵运行 18 16
        /// </summary>
        public bool DI_HP1
        {
            set { _di_hp1 = value; }
            get { return _di_hp1; }
        }

        /// <summary>
        /// 生活供水-高区2#泵运行 18 17
        /// </summary>
        public bool DI_HP2
        {
            set { _di_hp2 = value; }
            get { return _di_hp2; }
        }

        /// <summary>
        /// 生活供水-高区3#泵运行 18 18
        /// </summary>
        public bool DI_HP3
        {
            set { _di_hp3 = value; }
            get { return _di_hp3; }
        }

        /// <summary>
        /// 生活供水-高区4#泵运行 18 19
        /// </summary>
        public bool DI_HP4
        {
            set { _di_hp4 = value; }
            get { return _di_hp4; }
        }

        /// <summary>
        /// 生活供水—高区节能泵运行 18 20
        /// </summary>
        public bool DI_HP_JNB
        {
            set { _di_hp_jnb = value; }
            get { return _di_hp_jnb; }
        }

        /// <summary>
        /// 生活供水-超高区电源 18 21 报警
        /// </summary>
        public bool DI_SP_POW
        {
            set
            {
                if (_di_sp_pow != value)
                {
                    GetDigitalAlarm(value, "DI_SP_POW");
                }
                _di_sp_pow = value;
            }
            get { return _di_sp_pow; }
        }

        /// <summary>
        /// 生活供水-超高区泵故障 18 22 报警
        /// </summary>
        public bool DI_SP_AL
        {
            set
            {
                if (_di_sp_al != value)
                {
                    GetDigitalAlarm(value, "DI_SP_AL");
                }
                _di_sp_al = value;
            }
            get { return _di_sp_al; }
        }

        /// <summary>
        /// 生活供水-超高区1#泵运行 18 23
        /// </summary>
        public bool DI_SP1
        {
            set { _di_sp1 = value; }
            get { return _di_sp1; }
        }

        /// <summary>
        /// 生活供水-超高区2#泵运行 18 24
        /// </summary>
        public bool DI_SP2
        {
            set { _di_sp2 = value; }
            get { return _di_sp2; }
        }

        /// <summary>
        /// 生活供水-超高区3#泵运行 18 25
        /// </summary>
        public bool DI_SP3
        {
            set { _di_sp3 = value; }
            get { return _di_sp3; }
        }

        /// <summary>
        /// 生活供水-超高区4#泵运行 18 26
        /// </summary>
        public bool DI_SP4
        {
            set { _di_sp4 = value; }
            get { return _di_sp4; }
        }

        /// <summary>
        /// 生活供水—超高区节能泵运行 18 27
        /// </summary>
        public bool DI_SP_JNB
        {
            set { _di_sp_jnb = value; }
            get { return _di_sp_jnb; }
        }

        /// <summary>
        /// 消防供水-电源柜AB线电压 19 报警
        /// </summary>
        public decimal UAB_XF
        {
            set
            {
                if (_uab_xf != value)
                {
                    GetAnalogAlarm(value, "UAB_XF");
                }
                _uab_xf = value;
            }
            get { return _uab_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜BC线电压 20 报警
        /// </summary>
        public decimal UBC_XF
        {
            set
            {
                if (_ubc_xf != value)
                {
                    GetAnalogAlarm(value, "UBC_XF");
                }
                _ubc_xf = value;
            }
            get { return _ubc_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜CA线电压 21 报警
        /// </summary>
        public decimal UCA_XF
        {
            set
            {
                if (_uca_xf != value)
                {
                    GetAnalogAlarm(value, "UCA_XF");
                }
                _uca_xf = value;
            }
            get { return _uca_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜A相电流 22 报警
        /// </summary>
        public decimal IA_XF
        {
            set
            {
                if (_ia_xf != value)
                {
                    GetAnalogAlarm(value, "IA_XF");
                }
                _ia_xf = value;
            }
            get { return _ia_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜B相电流 23 报警
        /// </summary>
        public decimal IB_XF
        {
            set
            {
                if (_ib_xf != value)
                {
                    GetAnalogAlarm(value, "IB_XF");
                }
                _ib_xf = value;
            }
            get { return _ib_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜C相电流 24 报警
        /// </summary>
        public decimal IC_XF
        {
            set
            {
                if (_ic_xf != value)
                {
                    GetAnalogAlarm(value, "IC_XF");
                }
                _ic_xf = value;
            }
            get { return _ic_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜有功电能 25
        /// </summary>
        public int KWH_XF
        {
            set { _kwh_xf = value; }
            get { return _kwh_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜无功电能 26
        /// </summary>
        public int KVARH_XF
        {
            set { _kvarh_xf = value; }
            get { return _kvarh_xf; }
        }

        /// <summary>
        /// 消防供水-电源柜功率因素 27 报警
        /// </summary>
        public decimal PF_XF
        {
            set
            {
                if (_pf_xf != value)
                {
                    GetAnalogAlarm(value, "PF_XF");
                }
                _pf_xf = value;
            }
            get { return _pf_xf; }
        }

        /// <summary>
        /// 消防供水-消防水箱液位 28 报警
        /// </summary>
        public decimal L_XFSX
        {
            set
            {
                if (_l_xfsx != value)
                {
                    GetAnalogAlarm(value, "L_XFSX");
                }
                _l_xfsx = value;
            }
            get { return _l_xfsx; }
        }

        /// <summary>
        /// 消防供水-消防1#供水压力 29 报警
        /// </summary>
        public decimal P_XF1
        {
            set
            {
                if (_p_xf1 != value)
                {
                    GetAnalogAlarm(value, "P_XF1");
                }
                _p_xf1 = value;
            }
            get { return _p_xf1; }
        }

        /// <summary>
        /// 消防供水-喷淋1#供水压力 30 报警
        /// </summary>
        public decimal P_PL1
        {
            set
            {
                if (_p_pl1 != value)
                {
                    GetAnalogAlarm(value, "P_PL1");
                }
                _p_pl1 = value;
            }
            get { return _p_pl1; }
        }

        /// <summary>
        /// 消防供水-消防2#供水压力 31 报警
        /// </summary>
        public decimal P_XF2
        {
            set
            {
                if (_p_xf2 != value)
                {
                    GetAnalogAlarm(value, "P_XF2");
                }
                _p_xf2 = value;
            }
            get { return _p_xf2; }
        }

        /// <summary>
        /// 消防供水-喷淋2#供水压力 32 报警
        /// </summary>
        public decimal P_PL2
        {
            set
            {
                if (_p_pl2 != value)
                {
                    GetAnalogAlarm(value, "P_PL2");
                }
                _p_pl2 = value;
            }
            get { return _p_pl2; }
        }
        #endregion

    }
}
