using IERM.Common;
using IERM.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.WCFService.DevHouse
{
    public class SwitchRoom : BaseDevHouse
    {
        private readonly BLL.SwitchRoomRdBLL switchroom_bll = new BLL.SwitchRoomRdBLL();

        /// <summary>
        /// 抽屉柜断路状态
        /// </summary>
        private readonly BLL.DrawerStateBLL drawerstate_bll = new BLL.DrawerStateBLL();

        public SwitchRoom(int _devnum, List<AlarmSettingModel> _alarmSettinglist)
        {
            if (_devnum < 0 || _devnum > 10000)
            {
                Common.LogHelper.Dbbug("设备房编号超出范围！");
            }
            DevNum = _devnum;
            AlarmSettingList = _alarmSettinglist;
            InsertTime = DateTime.MinValue;
        }

        #region ===================配电室字段和属性======================== 

        #region ------字段------
        private decimal _t_room;
        private decimal _h_room;
        private bool _alarm_fire;
        private bool _alarm_sump;
        private decimal _n1_t_a;
        private decimal _n1_t_b;
        private decimal _n1_t_c;
        private decimal _n1_uab;
        private decimal _n1_ubc;
        private decimal _n1_uca;
        private decimal _n1_ia;
        private decimal _n1_ib;
        private decimal _n1_ic;
        private decimal _n1_pf;
        private int _n1_kwh;
        private int _n1_kvarh;
        private bool _n1_jxg;
        private bool _n1_drg;
        private bool _n1_llg;
        private MODEL.DrawerStateModel _n1_g1;
        private MODEL.DrawerStateModel _n1_g2;
        private MODEL.DrawerStateModel _n1_g3;
        private MODEL.DrawerStateModel _n1_g4;
        private MODEL.DrawerStateModel _n1_g5;
        private MODEL.DrawerStateModel _n1_g6;
        private MODEL.DrawerStateModel _n1_g7;
        private MODEL.DrawerStateModel _n1_g8;
        private MODEL.DrawerStateModel _n1_g9;
        private MODEL.DrawerStateModel _n1_g10;
        private decimal _n2_t_a;
        private decimal _n2_t_b;
        private decimal _n2_t_c;
        private decimal _n2_uab;
        private decimal _n2_ubc;
        private decimal _n2_uca;
        private decimal _n2_ia;
        private decimal _n2_ib;
        private decimal _n2_ic;
        private decimal _n2_pf;
        private int _n2_kwh;
        private int _n2_kvarh;
        private bool _n2_jxg;
        private bool _n2_drg;
        private bool _n2_llg;
        private MODEL.DrawerStateModel _n2_g1;
        private MODEL.DrawerStateModel _n2_g2;
        private MODEL.DrawerStateModel _n2_g3;
        private MODEL.DrawerStateModel _n2_g4;
        private MODEL.DrawerStateModel _n2_g5;
        private MODEL.DrawerStateModel _n2_g6;
        private MODEL.DrawerStateModel _n2_g7;
        private MODEL.DrawerStateModel _n2_g8;
        private MODEL.DrawerStateModel _n2_g9;
        private MODEL.DrawerStateModel _n2_g10;
        #endregion


        /// <summary>
        /// 设备房-环境温度 0 报警
        /// </summary>
        public decimal T_ROOM
        {
            set
            {
                if(_t_room!=value)
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
                if(_alarm_fire!=value)
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
        /// 1#变压器A相温度 3 报警
        /// </summary>
        public decimal N1_T_A
        {
            set
            {
                if(_n1_t_a!=value)
                {
                    GetAnalogAlarm(value, "N1_T_A");
                }
                _n1_t_a = value;
            }
            get { return _n1_t_a; }
        }

        /// <summary>
        /// 1#变压器B相温度 4 报警
        /// </summary>
        public decimal N1_T_B
        {
            set
            {
                if (_n1_t_b != value)
                {
                    GetAnalogAlarm(value, "N1_T_B");
                }
                _n1_t_b = value;
            }
            get { return _n1_t_b; }
        }

        /// <summary>
        /// 1#变压器C相温度 5 报警
        /// </summary>
        public decimal N1_T_C
        {
            set
            {
                if (_n1_t_c != value)
                {
                    GetAnalogAlarm(value, "N1_T_C");
                }
                _n1_t_c = value;
            }
            get { return _n1_t_c; }
        }

        /// <summary>
        /// 1#变压器进线柜AB线电压 6 报警
        /// </summary>
        public decimal N1_UAB
        {
            set
            {
                if (_n1_uab != value)
                {
                    GetAnalogAlarm(value, "N1_UAB");
                }
                _n1_uab = value;
            }
            get { return _n1_uab; }
        }

        /// <summary>
        /// 1#变压器进线柜BC线电压 7 报警
        /// </summary>
        public decimal N1_UBC
        {
            set
            {
                if (_n1_ubc != value)
                {
                    GetAnalogAlarm(value, "N1_UBC");
                }
                _n1_ubc = value;
            }
            get { return _n1_ubc; }
        }

        /// <summary>
        /// 1#变压器进线柜CA线电压 8 报警
        /// </summary>
        public decimal N1_UCA
        {
            set
            {
                if (_n1_uca != value)
                {
                    GetAnalogAlarm(value, "N1_UCA");
                }
                _n1_uca = value;
            }
            get { return _n1_uca; }
        }

        /// <summary>
        /// 1#变压器进线柜A相电流 9 报警
        /// </summary>
        public decimal N1_IA
        {
            set
            {
                if (_n1_ia != value)
                {
                    GetAnalogAlarm(value, "N1_IA");
                }
                _n1_ia = value;
            }
            get { return _n1_ia; }
        }

        /// <summary>
        /// 1#变压器进线柜B相电流 10 报警
        /// </summary>
        public decimal N1_IB
        {
            set
            {
                if (_n1_ib != value)
                {
                    GetAnalogAlarm(value, "N1_IB");
                }
                _n1_ib = value;
            }
            get { return _n1_ib; }
        }

        /// <summary>
        /// 1#变压器进线柜C相电流 11 报警
        /// </summary>
        public decimal N1_IC
        {
            set
            {
                if (_n1_ic != value)
                {
                    GetAnalogAlarm(value, "N1_IC");
                }
                _n1_ic = value;
            }
            get { return _n1_ic; }
        }

        /// <summary>
        /// 1#变压器进线柜功率因素 12 报警
        /// </summary>
        public decimal N1_PF
        {
            set
            {
                if (_n1_pf != value)
                {
                    GetAnalogAlarm(value, "N1_PF");
                }
                _n1_pf = value;
            }
            get { return _n1_pf; }
        }

        /// <summary>
        /// 1#变压器进线柜有功电能 13 
        /// </summary>
        public int N1_KWH
        {
            set { _n1_kwh = value; }
            get { return _n1_kwh; }
        }

        /// <summary>
        /// 1#变压器进线柜无功电能 14
        /// </summary>
        public int N1_KVARH
        {
            set { _n1_kvarh = value; }
            get { return _n1_kvarh; }
        }

        /// <summary>
        /// 1#变压器进线柜断路器状态 15 0
        /// </summary>
        public bool N1_JXG
        {
            set { _n1_jxg = value; }
            get { return _n1_jxg; }
        }

        /// <summary>
        /// 1#变压器电容柜断路器状态 15 1
        /// </summary>
        public bool N1_DRG
        {
            set { _n1_drg = value; }
            get { return _n1_drg; }
        }

        /// <summary>
        /// 1#变压器联络柜断路器状态 15 2
        /// </summary>
        public bool N1_LLG
        {
            set { _n1_llg = value; }
            get { return _n1_llg; }
        }

        /// <summary>
        /// 1#变压器 1#抽屉柜断路器状态 16 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G1
        {
            set { _n1_g1 = value; }
            get { return _n1_g1; }
        }

        /// <summary>
        /// 1#变压器 2#抽屉柜断路器状态 17 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G2
        {
            set { _n1_g2 = value; }
            get { return _n1_g2; }
        }

        /// <summary>
        /// 1#变压器 3#抽屉柜断路器状态 18 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G3
        {
            set { _n1_g3 = value; }
            get { return _n1_g3; }
        }

        /// <summary>
        /// 1#变压器 4#抽屉柜断路器状态 19 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G4
        {
            set { _n1_g4 = value; }
            get { return _n1_g4; }
        }

        /// <summary>
        /// 1#变压器 5#抽屉柜断路器状态 20 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G5
        {
            set { _n1_g5 = value; }
            get { return _n1_g5; }
        }

        /// <summary>
        /// 1#变压器 6#抽屉柜断路器状态 21 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G6
        {
            set { _n1_g6 = value; }
            get { return _n1_g6; }
        }

        /// <summary>
        /// 1#变压器 7#抽屉柜断路器状态 22 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G7
        {
            set { _n1_g7 = value; }
            get { return _n1_g7; }
        }

        /// <summary>
        /// 1#变压器 8#抽屉柜断路器状态 23 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G8
        {
            set { _n1_g8 = value; }
            get { return _n1_g8; }
        }

        /// <summary>
        /// 1#变压器 9#抽屉柜断路器状态 24 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G9
        {
            set { _n1_g9 = value; }
            get { return _n1_g9; }
        }

        /// <summary>
        /// 1#变压器 10#抽屉柜断路器状态 25 (0--16)
        /// </summary>
        public MODEL.DrawerStateModel N1_G10
        {
            set { _n1_g10 = value; }
            get { return _n1_g10; }
        }

        /// <summary>
        /// 2#变压器 变压器A相温度 26 报警
        /// </summary>
        public decimal N2_T_A
        {
            set
            {
                if(_n2_t_a!=value)
                {
                    GetAnalogAlarm(value, "N2_T_A");
                }
                _n2_t_a = value;
            }
            get { return _n2_t_a; }
        }

        /// <summary>
        /// 2#变压器 变压器B相温度 27 报警
        /// </summary>
        public decimal N2_T_B
        {
            set
            {
                if (_n2_t_b != value)
                {
                    GetAnalogAlarm(value, "N2_T_B");
                }
                _n2_t_b = value;
            }
            get { return _n2_t_b; }
        }

        /// <summary>
        /// 2#变压器 变压器C相温度 28 报警
        /// </summary>
        public decimal N2_T_C
        {
            set
            {
                if (_n2_t_c != value)
                {
                    GetAnalogAlarm(value, "N2_T_C");
                }
                _n2_t_c = value;
            }
            get { return _n2_t_c; }
        }

        /// <summary>
        /// 2#变压器 进线柜AB线电压 29 报警
        /// </summary>
        public decimal N2_UAB
        {
            set
            {
                if (_n2_uab != value)
                {
                    GetAnalogAlarm(value, "N2_UAB");
                }
                _n2_uab = value;
            }
            get { return _n2_uab; }
        }

        /// <summary>
        /// 2#变压器 进线柜BC线电压 30 报警
        /// </summary>
        public decimal N2_UBC
        {
            set
            {
                if (_n2_ubc != value)
                {
                    GetAnalogAlarm(value, "N2_UBC");
                }
                _n2_ubc = value;
            }
            get { return _n2_ubc; }
        }

        /// <summary>
        /// 2#变压器 进线柜CA线电压 31 报警
        /// </summary>
        public decimal N2_UCA
        {
            set
            {
                if (_n2_uca != value)
                {
                    GetAnalogAlarm(value, "N2_UCA");
                }
                _n2_uca = value;
            }
            get { return _n2_uca; }
        }

        /// <summary>
        /// 2#变压器 进线柜A相电流 32 报警
        /// </summary>
        public decimal N2_IA
        {
            set
            {
                if (_n2_ia != value)
                {
                    GetAnalogAlarm(value, "N2_IA");
                }
                _n2_ia = value;
            }
            get { return _n2_ia; }
        }

        /// <summary>
        /// 2#变压器 进线柜B相电流 33 报警
        /// </summary>
        public decimal N2_IB
        {
            set
            {
                if (_n2_ib != value)
                {
                    GetAnalogAlarm(value, "N2_IB");
                }
                _n2_ib = value;
            }
            get { return _n2_ib; }
        }

        /// <summary>
        /// 2#变压器 进线柜C相电流 34 报警
        /// </summary>
        public decimal N2_IC
        {
            set
            {
                if (_n2_ic != value)
                {
                    GetAnalogAlarm(value, "N2_IC");
                }
                _n2_ic = value;
            }
            get { return _n2_ic; }
        }

        /// <summary>
        /// 2#变压器 进线柜功率因素 35 报警
        /// </summary>
        public decimal N2_PF
        {
            set
            {
                if (_n2_pf != value)
                {
                    GetAnalogAlarm(value, "N2_PF");
                }
                _n2_pf = value;
            }
            get { return _n2_pf; }
        }

        /// <summary>
        /// 2#变压器 进线柜有功电能 36
        /// </summary>
        public int N2_KWH
        {
            set { _n2_kwh = value; }
            get { return _n2_kwh; }
        }

        /// <summary>
        /// 2#变压器 进线柜无功电能 37 
        /// </summary>
        public int N2_KVARH
        {
            set { _n2_kvarh = value; }
            get { return _n2_kvarh; }
        }

        /// <summary>
        /// 2#变压器 进线柜断路器状态 38 0
        /// </summary>
        public bool N2_JXG
        {
            set { _n2_jxg = value; }
            get { return _n2_jxg; }
        }

        /// <summary>
        /// 2#变压器 电容柜断路器状态 38 1
        /// </summary>
        public bool N2_DRG
        {
            set { _n2_drg = value; }
            get { return _n2_drg; }
        }

        /// <summary>
        /// 2#变压器 联络柜断路器状态 38 2
        /// </summary>
        public bool N2_LLG
        {
            set { _n2_llg = value; }
            get { return _n2_llg; }
        }

        /// <summary>
        /// 2#变压器 1#抽屉柜断路器状态 39 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G1
        {
            set { _n2_g1 = value; }
            get { return _n2_g1; }
        }

        /// <summary>
        /// 2#变压器 2#抽屉柜断路器状态 40 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G2
        {
            set { _n2_g2 = value; }
            get { return _n2_g2; }
        }

        /// <summary>
        /// 2#变压器 3#抽屉柜断路器状态 41 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G3
        {
            set { _n2_g3 = value; }
            get { return _n2_g3; }
        }

        /// <summary>
        /// 2#变压器 4#抽屉柜断路器状态 42 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G4
        {
            set { _n2_g4 = value; }
            get { return _n2_g4; }
        }

        /// <summary>
        /// 2#变压器 5#抽屉柜断路器状态 43 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G5
        {
            set { _n2_g5 = value; }
            get { return _n2_g5; }
        }

        /// <summary>
        /// 2#变压器 6#抽屉柜断路器状态 44 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G6
        {
            set { _n2_g6 = value; }
            get { return _n2_g6; }
        }

        /// <summary>
        /// 2#变压器 7#抽屉柜断路器状态 45 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G7
        {
            set { _n2_g7 = value; }
            get { return _n2_g7; }
        }

        /// <summary>
        /// 2#变压器 8#抽屉柜断路器状态 46 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G8
        {
            set { _n2_g8 = value; }
            get { return _n2_g8; }
        }

        /// <summary>
        /// 2#变压器 9#抽屉柜断路器状态 47 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G9
        {
            set { _n2_g9 = value; }
            get { return _n2_g9; }
        }

        /// <summary>
        /// 2#变压器 10#抽屉柜断路器状态 48 0-16
        /// </summary>
        public MODEL.DrawerStateModel N2_G10
        {
            set { _n2_g10 = value; }
            get { return _n2_g10; }
        }

        /// <summary>
        /// 判断是否应该入库
        /// </summary>
        private bool isInsert = false;

        #endregion
        public override BaseDevHouse Decode(byte[] data)
        {
            if ((DateTime.Now - InsertTime).TotalMinutes >= 10)
            {
                InsertTime = DateTime.Now;
                isInsert = true;
            }

            #region ------解码并赋值---------
            //环境温度 T_ROOM   0
            T_ROOM = BinaryHelper.GetNumByByteRange(data, GetRange(0)) / 100M;
            //环境湿度 H_ROOM   1
            H_ROOM = BinaryHelper.GetNumByByteRange(data, GetRange(1)) / 100M;
            //烟雾报警 ALARM_FIRE  2   0
            ALARM_FIRE = BinaryHelper.GetbitValue(data, GetRange(2), 0);
            //水浸报警 ALARM_SUMP  2   1
            ALARM_SUMP = BinaryHelper.GetbitValue(data, GetRange(2), 1);
            //变压器A相温度 N1_T_A   3
            N1_T_A = BinaryHelper.GetNumByByteRange(data, GetRange(3)) / 100M;
            //变压器B相温度 N1_T_B   4
            N1_T_B = BinaryHelper.GetNumByByteRange(data, GetRange(4)) / 100M;
            //变压器C相温度 N1_T_C    5
            N1_T_C = BinaryHelper.GetNumByByteRange(data, GetRange(5)) / 100M;
            //进线柜AB线电压 N1_UAB   6
            N1_UAB = BinaryHelper.GetNumByByteRange(data, GetRange(6)) / 100M;
            //进线柜BC线电压 N1_UBC  7
            N1_UBC = BinaryHelper.GetNumByByteRange(data, GetRange(7)) / 100M;
            //进线柜CA线电压 N1_UCA   8
            N1_UCA = BinaryHelper.GetNumByByteRange(data, GetRange(8)) / 100M;
            //进线柜A相电流 N1_IA  9
            N1_IA = BinaryHelper.GetNumByByteRange(data, GetRange(9)) / 100M;
            //进线柜B相电流 N1_IB    10
            N1_IB = BinaryHelper.GetNumByByteRange(data, GetRange(10)) / 100M;
            //进线柜C相电流 N1_IC   11
            N1_IC = BinaryHelper.GetNumByByteRange(data, GetRange(11)) / 100M;
            //进线柜功率因素 N1_PF   12
            N1_PF = BinaryHelper.GetNumByByteRange(data, GetRange(12)) / 100M;
            //进线柜有功电能 N1_KWH   13
            N1_KWH = BinaryHelper.GetNumByByteRange(data, GetRange(13));
            //进线柜无功电能 N1_KVARH    14
            N1_KVARH = BinaryHelper.GetNumByByteRange(data, GetRange(14));


            //进线柜断路器状态 N1_JXG   15  0
            N1_JXG = BinaryHelper.GetbitValue(data, GetRange(15), 0);
            //电容柜断路器状态 N1_DRG   1
            N1_DRG = BinaryHelper.GetbitValue(data, GetRange(15), 1);
            //联络柜断路器状态 N1_LLG    2
            N1_LLG = BinaryHelper.GetbitValue(data, GetRange(15), 2);
            //1#抽屉柜断路器状态	N1_G1_F1…F16	16	0…16
            N1_G1 = GetDrawerState(data, 16);
            //2#抽屉柜断路器状态	N1_G2_F1…F16	17	0…16
            N1_G2 = GetDrawerState(data, 17);
            //3#抽屉柜断路器状态	N1_G3_F1…F16   18	0…16
            N1_G3 = GetDrawerState(data, 18);
            //4#抽屉柜断路器状态	N1_G4_F1…F1	19	0…16
            N1_G4 = GetDrawerState(data, 19);
            //5#抽屉柜断路器状态	N1_G5_F1…F16	20	0…16
            N1_G5 = GetDrawerState(data, 20);
            //6#抽屉柜断路器状态	N1_G6_F1…F16	21	0…16
            N1_G6 = GetDrawerState(data, 21);
            //7#抽屉柜断路器状态	N1_G7_F1…F16	22	0…16
            N1_G7 = GetDrawerState(data, 22);
            //8#抽屉柜断路器状态	N1_G8_F1…F16	23	0…16
            N1_G8 = GetDrawerState(data, 23);
            //9#抽屉柜断路器状态	N1_G9_F1…F16	24	0…16
            N1_G9 = GetDrawerState(data, 24);
            //10#抽屉柜断路器状态	N1_G10_F1…F16	25	0…16
            N1_G10 = GetDrawerState(data, 25);

            //变压器A相温度 N2_T_A  26
            N2_T_A = BinaryHelper.GetNumByByteRange(data, GetRange(26)) / 100M;
            //变压器B相温度 N2_T_B  27
            N2_T_B = BinaryHelper.GetNumByByteRange(data, GetRange(27)) / 100M;
            //变压器C相温度 N2_T_C  28
            N2_T_C = BinaryHelper.GetNumByByteRange(data, GetRange(28)) / 100M;
            //进线柜AB线电压 N2_UAB 29
            N2_UAB = BinaryHelper.GetNumByByteRange(data, GetRange(29)) / 100M;
            //进线柜BC线电压 N2_UBC 30
            N2_UBC = BinaryHelper.GetNumByByteRange(data, GetRange(30)) / 100M;
            //进线柜CA线电压 N2_UCA 31
            N2_UCA = BinaryHelper.GetNumByByteRange(data, GetRange(31)) / 100M;
            //进线柜A相电流 N2_IA   32
            N2_IA = BinaryHelper.GetNumByByteRange(data, GetRange(32)) / 100M;
            //进线柜B相电流 N2_IB   33
            N2_IB = BinaryHelper.GetNumByByteRange(data, GetRange(33)) / 100M;
            //进线柜C相电流 N2_IC   34
            N2_IC = BinaryHelper.GetNumByByteRange(data, GetRange(34)) / 100M;
            //进线柜功率因素 N2_PF  35
            N2_PF = BinaryHelper.GetNumByByteRange(data, GetRange(35)) / 100M;
            //进线柜有功电能 N2_KWH 36
            N2_KWH = BinaryHelper.GetNumByByteRange(data, GetRange(36));
            //进线柜无功电能 N2_KVARH  37
            N2_KVARH = BinaryHelper.GetNumByByteRange(data, GetRange(37));

            //进线柜断路器状态 N2_JXG  38
            N2_JXG = BinaryHelper.GetbitValue(data, GetRange(38), 0);
            //电容柜断路器状态 N2_DRG   1
            N2_DRG = BinaryHelper.GetbitValue(data, GetRange(38), 1);
            //联络柜断路器状态 N2_LLG   2
            N2_LLG = BinaryHelper.GetbitValue(data, GetRange(38), 2);
            //1#抽屉柜断路器状态	N2_G1_F1…F16	39	0…16
            N2_G1 = GetDrawerState(data, 39);
            //2#抽屉柜断路器状态	N2_G2_F1…F16	40	0…16
            N2_G2 = GetDrawerState(data, 40);
            //3#抽屉柜断路器状态	N2_G3_F1…F16	41	0…16
            N2_G3 = GetDrawerState(data, 41);
            //4#抽屉柜断路器状态	N2_G4_F1…F16	42	0…16
            N2_G4 = GetDrawerState(data, 42);
            //5#抽屉柜断路器状态	N2_G5_F1…F16	43	0…16
            N2_G5 = GetDrawerState(data, 43);
            //6#抽屉柜断路器状态	N2_G6_F1…F16	44	0…16
            N2_G6 = GetDrawerState(data, 44);
            //7#抽屉柜断路器状态	N2_G7_F1…F16	45	0…16
            N2_G7 = GetDrawerState(data, 45);
            //8#抽屉柜断路器状态	N2_G8_F1…F16	46	0…16
            N2_G8 = GetDrawerState(data, 46);
            //9#抽屉柜断路器状态	N2_G9_F1…F16	47	0…16
            N2_G9 = GetDrawerState(data, 47);
            //10#抽屉柜断路器状态	N2_G10_F1…F16	48	0…16
            N2_G10 = GetDrawerState(data, 48); 
            #endregion

            Add();
            isInsert = false;
            return this;
        }

        /// <summary>
        /// 添加一条新数据
        /// </summary>
        private void Add()
        {
            if(isInsert)
            {
                switchroom_bll.Add(new MODEL.SwitchRoomRdModel()
                {
                    devID = DevNum,
                    T_ROOM = this.T_ROOM,
                    H_ROOM = this.H_ROOM,
                    ALARM_FIRE = this.ALARM_FIRE,
                    ALARM_SUMP = this.ALARM_SUMP,
                    N1_T_A = this.N1_T_A,
                    N1_T_B = this.N1_T_B,
                    N1_T_C = this.N1_T_C,
                    N1_UAB = this.N1_UAB,
                    N1_UBC = this.N1_UBC,
                    N1_UCA = this.N1_UCA,
                    N1_IA = this.N1_IA,
                    N1_IB = this.N1_IB,
                    N1_IC = this.N1_IC,
                    N1_PF = this.N1_PF,
                    N1_KWH = this.N1_KWH,
                    N1_KVARH = this.N1_KVARH,
                    N1_JXG = this.N1_JXG,
                    N1_DRG = this.N1_DRG,
                    N1_LLG = this.N1_LLG,
                    N1_G1 = this.N1_G1.ToString(),
                    N1_G2 = this.N1_G2.ToString(),
                    N1_G3 = this.N1_G3.ToString(),
                    N1_G4 = this.N1_G4.ToString(),
                    N1_G5 = this.N1_G5.ToString(),
                    N1_G6 = this.N1_G6.ToString(),
                    N1_G7 = this.N1_G7.ToString(),
                    N1_G8 = this.N1_G8.ToString(),
                    N1_G9 = this.N1_G9.ToString(),
                    N1_G10 = this.N1_G10.ToString(),
                    N2_T_A = this.N2_T_A,
                    N2_T_B = this.N2_T_B,
                    N2_T_C = this.N2_T_C,
                    N2_UAB = this.N2_UBC,
                    N2_UBC = this.N2_UCA,
                    N2_UCA = this.N2_UCA,
                    N2_IA = this.N2_IA,
                    N2_IB = this.N2_IB,
                    N2_IC = this.N2_IC,
                    N2_PF = this.N2_PF,
                    N2_KWH = this.N2_KWH,
                    N2_KVARH = this.N2_KVARH,
                    N2_JXG = this.N2_JXG,
                    N2_DRG = this.N2_DRG,
                    N2_LLG = this.N2_LLG,
                    N2_G1 = this.N2_G1.ToString(),
                    N2_G2 = this.N2_G2.ToString(),
                    N2_G3 = this.N2_G3.ToString(),
                    N2_G4 = this.N2_G4.ToString(),
                    N2_G5 = this.N2_G5.ToString(),
                    N2_G6 = this.N2_G6.ToString(),
                    N2_G7 = this.N2_G7.ToString(),
                    N2_G8 = this.N2_G8.ToString(),
                    N2_G9 = this.N2_G9.ToString(),
                    N2_G10 = this.N2_G10.ToString(),
                    insertTime = DateTime.Now

                });
            }           
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

        /// <summary>
        /// 获取指定抽屉柜状态信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cellnum"></param>
        /// <returns></returns>
        private DrawerStateModel GetDrawerState(byte[] data,int cellnum)
        {
            var model= new DrawerStateModel()
            {
                f1 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 0),
                f2 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 1),
                f3 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 2),
                f4 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 3),
                f5 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 4),
                f6 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 5),
                f7 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 6),
                f8 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 7),
                f9 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 8),
                f10 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 9),
                f11 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 10),
                f12 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 11),
                f13 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 12),
                f14 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 13),
                f15 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 14),
                f16 = BinaryHelper.GetbitValue(data, GetRange(cellnum), 15)
            };
            ////不再保存子表中 直接以字符串形式保存到字段里
            //if (isInsert)
            //{
            //    int newid = drawerstate_bll.Add(model);
            //    if (newid > 0)
            //    {
            //        model.id = newid;
            //    }
            //}            
            return model;
        }
    }
}
