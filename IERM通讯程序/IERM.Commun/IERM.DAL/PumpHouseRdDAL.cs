using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class PumpHouseRdDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MODEL.PumpHouseRdModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pumphouse_rd(");
            strSql.Append("devid,T_ROOM,H_ROOM,ALARM_FIRE,ALARM_SUMP,UAB_SH,UBC_SH,UCA_SH,IA_SH,IB_SH,IC_SH,KWH_SH,KVARH_SH,PF_SH,L_SHSX,P_IN,P_LO,P_MI,P_HI,P_SP,DI_LP_POW,DI_LP_AL,DI_LP1,DI_LP2,DI_LP3,DI_LP4,DI_MP_POW,DI_MP_AL,DI_MP1,DI_MP2,DI_MP3,DI_MP4,DI_HP_POW,DI_HP_AL,DI_HP1,DI_HP2,DI_HP3,DI_HP4,DI_SP_POW,DI_SP_AL,DI_SP1,DI_SP2,DI_SP3,DI_SP4,UAB_XF,UBC_XF,UCA_XF,IA_XF,IB_XF,IC_XF,KWH_XF,KVARH_XF,PF_XF,L_XFSX,P_XF1,P_PL1,P_XF2,P_PL2,insertTime,DI_LP_JNB,DI_MP_JNB,DI_HP_JNB,DI_SP_JNB)");
            strSql.Append(" values (");
            strSql.Append("@devid,@T_ROOM,@H_ROOM,@ALARM_FIRE,@ALARM_SUMP,@UAB_SH,@UBC_SH,@UCA_SH,@IA_SH,@IB_SH,@IC_SH,@KWH_SH,@KVARH_SH,@PF_SH,@L_SHSX,@P_IN,@P_LO,@P_MI,@P_HI,@P_SP,@DI_LP_POW,@DI_LP_AL,@DI_LP1,@DI_LP2,@DI_LP3,@DI_LP4,@DI_MP_POW,@DI_MP_AL,@DI_MP1,@DI_MP2,@DI_MP3,@DI_MP4,@DI_HP_POW,@DI_HP_AL,@DI_HP1,@DI_HP2,@DI_HP3,@DI_HP4,@DI_SP_POW,@DI_SP_AL,@DI_SP1,@DI_SP2,@DI_SP3,@DI_SP4,@UAB_XF,@UBC_XF,@UCA_XF,@IA_XF,@IB_XF,@IC_XF,@KWH_XF,@KVARH_XF,@PF_XF,@L_XFSX,@P_XF1,@P_PL1,@P_XF2,@P_PL2,@insertTime,@DI_LP_JNB,@DI_MP_JNB,@DI_HP_JNB,@DI_SP_JNB)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devid", MySqlDbType.Int32,10),
                    new MySqlParameter("@T_ROOM", MySqlDbType.Decimal),
                    new MySqlParameter("@H_ROOM", MySqlDbType.Decimal),
                    new MySqlParameter("@ALARM_FIRE", MySqlDbType.Bit),
                    new MySqlParameter("@ALARM_SUMP", MySqlDbType.Bit),
                    new MySqlParameter("@UAB_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@UBC_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@UCA_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@IA_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@IB_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@IC_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@KWH_SH", MySqlDbType.Int32),
                    new MySqlParameter("@KVARH_SH", MySqlDbType.Int32),
                    new MySqlParameter("@PF_SH", MySqlDbType.Decimal),
                    new MySqlParameter("@L_SHSX", MySqlDbType.Decimal),
                    new MySqlParameter("@P_IN", MySqlDbType.Decimal),
                    new MySqlParameter("@P_LO", MySqlDbType.Decimal),
                    new MySqlParameter("@P_MI", MySqlDbType.Decimal),
                    new MySqlParameter("@P_HI", MySqlDbType.Decimal),
                    new MySqlParameter("@P_SP", MySqlDbType.Decimal),
                    new MySqlParameter("@DI_LP_POW", MySqlDbType.Bit),
                    new MySqlParameter("@DI_LP_AL", MySqlDbType.Bit),
                    new MySqlParameter("@DI_LP1", MySqlDbType.Bit),
                    new MySqlParameter("@DI_LP2", MySqlDbType.Bit),
                    new MySqlParameter("@DI_LP3", MySqlDbType.Bit),
                    new MySqlParameter("@DI_LP4", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP_POW", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP_AL", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP1", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP2", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP3", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP4", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP_POW", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP_AL", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP1", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP2", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP3", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP4", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP_POW", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP_AL", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP1", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP2", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP3", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP4", MySqlDbType.Bit),
                    new MySqlParameter("@UAB_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@UBC_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@UCA_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@IA_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@IB_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@IC_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@KWH_XF", MySqlDbType.Int32),
                    new MySqlParameter("@KVARH_XF", MySqlDbType.Int32),
                    new MySqlParameter("@PF_XF", MySqlDbType.Decimal),
                    new MySqlParameter("@L_XFSX", MySqlDbType.Decimal),
                    new MySqlParameter("@P_XF1", MySqlDbType.Decimal),
                    new MySqlParameter("@P_PL1", MySqlDbType.Decimal),
                    new MySqlParameter("@P_XF2", MySqlDbType.Decimal),
                    new MySqlParameter("@P_PL2", MySqlDbType.Decimal),
                    new MySqlParameter("@insertTime", MySqlDbType.DateTime),
                    new MySqlParameter("@DI_LP_JNB", MySqlDbType.Bit),
                    new MySqlParameter("@DI_MP_JNB", MySqlDbType.Bit),
                    new MySqlParameter("@DI_HP_JNB", MySqlDbType.Bit),
                    new MySqlParameter("@DI_SP_JNB", MySqlDbType.Bit)
            };
            parameters[0].Value = model.devid;
            parameters[1].Value = model.T_ROOM;
            parameters[2].Value = model.H_ROOM;
            parameters[3].Value = model.ALARM_FIRE;
            parameters[4].Value = model.ALARM_SUMP;
            parameters[5].Value = model.UAB_SH;
            parameters[6].Value = model.UBC_SH;
            parameters[7].Value = model.UCA_SH;
            parameters[8].Value = model.IA_SH;
            parameters[9].Value = model.IB_SH;
            parameters[10].Value = model.IC_SH;
            parameters[11].Value = model.KWH_SH;
            parameters[12].Value = model.KVARH_SH;
            parameters[13].Value = model.PF_SH;
            parameters[14].Value = model.L_SHSX;
            parameters[15].Value = model.P_IN;
            parameters[16].Value = model.P_LO;
            parameters[17].Value = model.P_MI;
            parameters[18].Value = model.P_HI;
            parameters[19].Value = model.P_SP;
            parameters[20].Value = model.DI_LP_POW;
            parameters[21].Value = model.DI_LP_AL;
            parameters[22].Value = model.DI_LP1;
            parameters[23].Value = model.DI_LP2;
            parameters[24].Value = model.DI_LP3;
            parameters[25].Value = model.DI_LP4;
            parameters[26].Value = model.DI_MP_POW;
            parameters[27].Value = model.DI_MP_AL;
            parameters[28].Value = model.DI_MP1;
            parameters[29].Value = model.DI_MP2;
            parameters[30].Value = model.DI_MP3;
            parameters[31].Value = model.DI_MP4;
            parameters[32].Value = model.DI_HP_POW;
            parameters[33].Value = model.DI_HP_AL;
            parameters[34].Value = model.DI_HP1;
            parameters[35].Value = model.DI_HP2;
            parameters[36].Value = model.DI_HP3;
            parameters[37].Value = model.DI_HP4;
            parameters[38].Value = model.DI_SP_POW;
            parameters[39].Value = model.DI_SP_AL;
            parameters[40].Value = model.DI_SP1;
            parameters[41].Value = model.DI_SP2;
            parameters[42].Value = model.DI_SP3;
            parameters[43].Value = model.DI_SP4;
            parameters[44].Value = model.UAB_XF;
            parameters[45].Value = model.UBC_XF;
            parameters[46].Value = model.UCA_XF;
            parameters[47].Value = model.IA_XF;
            parameters[48].Value = model.IB_XF;
            parameters[49].Value = model.IC_XF;
            parameters[50].Value = model.KWH_XF;
            parameters[51].Value = model.KVARH_XF;
            parameters[52].Value = model.PF_XF;
            parameters[53].Value = model.L_XFSX;
            parameters[54].Value = model.P_XF1;
            parameters[55].Value = model.P_PL1;
            parameters[56].Value = model.P_XF2;
            parameters[57].Value = model.P_PL2;
            parameters[58].Value = DateTime.Now;
            parameters[59].Value = model.DI_LP_JNB;
            parameters[60].Value = model.DI_MP_JNB;
            parameters[61].Value = model.DI_HP_JNB;
            parameters[62].Value = model.DI_SP_JNB;

            return Common.MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0 ? true : false;
        }
    }
}
