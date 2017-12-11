using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.MODEL
{
    public class PumpHouseRdModel
    {
        public PumpHouseRdModel()
        { }

        private int _pid;
        private int _devid = 0;
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
        private DateTime _inserttime;

        /// <summary>
        /// 流水号（主键  自增）
        /// </summary>
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
        }

        /// <summary>
        /// 设备房编号
        /// </summary>
        public int devid
        {
            set { _devid = value; }
            get { return _devid; }
        }

        /// <summary>
        /// 设备房-环境温度
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
        public decimal UAB_SH
        {
            set { _uab_sh = value; }
            get { return _uab_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UBC_SH
        {
            set { _ubc_sh = value; }
            get { return _ubc_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UCA_SH
        {
            set { _uca_sh = value; }
            get { return _uca_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IA_SH
        {
            set { _ia_sh = value; }
            get { return _ia_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IB_SH
        {
            set { _ib_sh = value; }
            get { return _ib_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IC_SH
        {
            set { _ic_sh = value; }
            get { return _ic_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KWH_SH
        {
            set { _kwh_sh = value; }
            get { return _kwh_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KVARH_SH
        {
            set { _kvarh_sh = value; }
            get { return _kvarh_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PF_SH
        {
            set { _pf_sh = value; }
            get { return _pf_sh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal L_SHSX
        {
            set { _l_shsx = value; }
            get { return _l_shsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_IN
        {
            set { _p_in = value; }
            get { return _p_in; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_LO
        {
            set { _p_lo = value; }
            get { return _p_lo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_MI
        {
            set { _p_mi = value; }
            get { return _p_mi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_HI
        {
            set { _p_hi = value; }
            get { return _p_hi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_SP
        {
            set { _p_sp = value; }
            get { return _p_sp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_LP_POW
        {
            set { _di_lp_pow = value; }
            get { return _di_lp_pow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_LP_AL
        {
            set { _di_lp_al = value; }
            get { return _di_lp_al; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_LP1
        {
            set { _di_lp1 = value; }
            get { return _di_lp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_LP2
        {
            set { _di_lp2 = value; }
            get { return _di_lp2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_LP3
        {
            set { _di_lp3 = value; }
            get { return _di_lp3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_LP4
        {
            set { _di_lp4 = value; }
            get { return _di_lp4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_MP_POW
        {
            set { _di_mp_pow = value; }
            get { return _di_mp_pow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_MP_AL
        {
            set { _di_mp_al = value; }
            get { return _di_mp_al; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_MP1
        {
            set { _di_mp1 = value; }
            get { return _di_mp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_MP2
        {
            set { _di_mp2 = value; }
            get { return _di_mp2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_MP3
        {
            set { _di_mp3 = value; }
            get { return _di_mp3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_MP4
        {
            set { _di_mp4 = value; }
            get { return _di_mp4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_HP_POW
        {
            set { _di_hp_pow = value; }
            get { return _di_hp_pow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_HP_AL
        {
            set { _di_hp_al = value; }
            get { return _di_hp_al; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_HP1
        {
            set { _di_hp1 = value; }
            get { return _di_hp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_HP2
        {
            set { _di_hp2 = value; }
            get { return _di_hp2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_HP3
        {
            set { _di_hp3 = value; }
            get { return _di_hp3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_HP4
        {
            set { _di_hp4 = value; }
            get { return _di_hp4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_SP_POW
        {
            set { _di_sp_pow = value; }
            get { return _di_sp_pow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_SP_AL
        {
            set { _di_sp_al = value; }
            get { return _di_sp_al; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_SP1
        {
            set { _di_sp1 = value; }
            get { return _di_sp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_SP2
        {
            set { _di_sp2 = value; }
            get { return _di_sp2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_SP3
        {
            set { _di_sp3 = value; }
            get { return _di_sp3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DI_SP4
        {
            set { _di_sp4 = value; }
            get { return _di_sp4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UAB_XF
        {
            set { _uab_xf = value; }
            get { return _uab_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UBC_XF
        {
            set { _ubc_xf = value; }
            get { return _ubc_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UCA_XF
        {
            set { _uca_xf = value; }
            get { return _uca_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IA_XF
        {
            set { _ia_xf = value; }
            get { return _ia_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IB_XF
        {
            set { _ib_xf = value; }
            get { return _ib_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IC_XF
        {
            set { _ic_xf = value; }
            get { return _ic_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KWH_XF
        {
            set { _kwh_xf = value; }
            get { return _kwh_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KVARH_XF
        {
            set { _kvarh_xf = value; }
            get { return _kvarh_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PF_XF
        {
            set { _pf_xf = value; }
            get { return _pf_xf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal L_XFSX
        {
            set { _l_xfsx = value; }
            get { return _l_xfsx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_XF1
        {
            set { _p_xf1 = value; }
            get { return _p_xf1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_PL1
        {
            set { _p_pl1 = value; }
            get { return _p_pl1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_XF2
        {
            set { _p_xf2 = value; }
            get { return _p_xf2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal P_PL2
        {
            set { _p_pl2 = value; }
            get { return _p_pl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime insertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }

        public bool DI_LP_JNB
        {
            get
            {
                return _di_lp_jnb;
            }

            set
            {
                _di_lp_jnb = value;
            }
        }

        public bool DI_HP_JNB
        {
            get
            {
                return _di_hp_jnb;
            }

            set
            {
                _di_hp_jnb = value;
            }
        }

        public bool DI_SP_JNB
        {
            get
            {
                return _di_sp_jnb;
            }

            set
            {
                _di_sp_jnb = value;
            }
        }

        public bool DI_MP_JNB
        {
            get
            {
                return _di_mp_jnb;
            }

            set
            {
                _di_mp_jnb = value;
            }
        }
    }
}
