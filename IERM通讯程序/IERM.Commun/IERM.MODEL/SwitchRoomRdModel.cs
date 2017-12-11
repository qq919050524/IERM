using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    public class SwitchRoomRdModel
    {
        public SwitchRoomRdModel()
        { }

        private int _sid;
        private int _devid;
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
        private string _n1_g1;
        private string _n1_g2;
        private string _n1_g3;
        private string _n1_g4;
        private string _n1_g5;
        private string _n1_g6;
        private string _n1_g7;
        private string _n1_g8;
        private string _n1_g9;
        private string _n1_g10;
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
        private string _n2_g1;
        private string _n2_g2;
        private string _n2_g3;
        private string _n2_g4;
        private string _n2_g5;
        private string _n2_g6;
        private string _n2_g7;
        private string _n2_g8;
        private string _n2_g9;
        private string _n2_g10;
        private DateTime _inserttime;

        /// <summary>
        /// 流水号（主键）
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
        }

        /// <summary>
        /// 设备房编号
        /// </summary>
        public int devID
        {
            set { _devid = value; }
            get { return _devid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal T_ROOM
        {
            set { _t_room = value; }
            get { return _t_room; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal H_ROOM
        {
            set { _h_room = value; }
            get { return _h_room; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ALARM_FIRE
        {
            set { _alarm_fire = value; }
            get { return _alarm_fire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ALARM_SUMP
        {
            set { _alarm_sump = value; }
            get { return _alarm_sump; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_T_A
        {
            set { _n1_t_a = value; }
            get { return _n1_t_a; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_T_B
        {
            set { _n1_t_b = value; }
            get { return _n1_t_b; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_T_C
        {
            set { _n1_t_c = value; }
            get { return _n1_t_c; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_UAB
        {
            set { _n1_uab = value; }
            get { return _n1_uab; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_UBC
        {
            set { _n1_ubc = value; }
            get { return _n1_ubc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_UCA
        {
            set { _n1_uca = value; }
            get { return _n1_uca; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_IA
        {
            set { _n1_ia = value; }
            get { return _n1_ia; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_IB
        {
            set { _n1_ib = value; }
            get { return _n1_ib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_IC
        {
            set { _n1_ic = value; }
            get { return _n1_ic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N1_PF
        {
            set { _n1_pf = value; }
            get { return _n1_pf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int N1_KWH
        {
            set { _n1_kwh = value; }
            get { return _n1_kwh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int N1_KVARH
        {
            set { _n1_kvarh = value; }
            get { return _n1_kvarh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool N1_JXG
        {
            set { _n1_jxg = value; }
            get { return _n1_jxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool N1_DRG
        {
            set { _n1_drg = value; }
            get { return _n1_drg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool N1_LLG
        {
            set { _n1_llg = value; }
            get { return _n1_llg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G1
        {
            set { _n1_g1 = value; }
            get { return _n1_g1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G2
        {
            set { _n1_g2 = value; }
            get { return _n1_g2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G3
        {
            set { _n1_g3 = value; }
            get { return _n1_g3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G4
        {
            set { _n1_g4 = value; }
            get { return _n1_g4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G5
        {
            set { _n1_g5 = value; }
            get { return _n1_g5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G6
        {
            set { _n1_g6 = value; }
            get { return _n1_g6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G7
        {
            set { _n1_g7 = value; }
            get { return _n1_g7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G8
        {
            set { _n1_g8 = value; }
            get { return _n1_g8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G9
        {
            set { _n1_g9 = value; }
            get { return _n1_g9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N1_G10
        {
            set { _n1_g10 = value; }
            get { return _n1_g10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_T_A
        {
            set { _n2_t_a = value; }
            get { return _n2_t_a; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_T_B
        {
            set { _n2_t_b = value; }
            get { return _n2_t_b; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_T_C
        {
            set { _n2_t_c = value; }
            get { return _n2_t_c; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_UAB
        {
            set { _n2_uab = value; }
            get { return _n2_uab; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_UBC
        {
            set { _n2_ubc = value; }
            get { return _n2_ubc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_UCA
        {
            set { _n2_uca = value; }
            get { return _n2_uca; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_IA
        {
            set { _n2_ia = value; }
            get { return _n2_ia; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_IB
        {
            set { _n2_ib = value; }
            get { return _n2_ib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_IC
        {
            set { _n2_ic = value; }
            get { return _n2_ic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal N2_PF
        {
            set { _n2_pf = value; }
            get { return _n2_pf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int N2_KWH
        {
            set { _n2_kwh = value; }
            get { return _n2_kwh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int N2_KVARH
        {
            set { _n2_kvarh = value; }
            get { return _n2_kvarh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool N2_JXG
        {
            set { _n2_jxg = value; }
            get { return _n2_jxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool N2_DRG
        {
            set { _n2_drg = value; }
            get { return _n2_drg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool N2_LLG
        {
            set { _n2_llg = value; }
            get { return _n2_llg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G1
        {
            set { _n2_g1 = value; }
            get { return _n2_g1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G2
        {
            set { _n2_g2 = value; }
            get { return _n2_g2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G3
        {
            set { _n2_g3 = value; }
            get { return _n2_g3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G4
        {
            set { _n2_g4 = value; }
            get { return _n2_g4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G5
        {
            set { _n2_g5 = value; }
            get { return _n2_g5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G6
        {
            set { _n2_g6 = value; }
            get { return _n2_g6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G7
        {
            set { _n2_g7 = value; }
            get { return _n2_g7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G8
        {
            set { _n2_g8 = value; }
            get { return _n2_g8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G9
        {
            set { _n2_g9 = value; }
            get { return _n2_g9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string N2_G10
        {
            set { _n2_g10 = value; }
            get { return _n2_g10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime insertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
    }
}
