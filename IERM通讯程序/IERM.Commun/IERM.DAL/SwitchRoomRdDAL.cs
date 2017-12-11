using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class SwitchRoomRdDAL
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MODEL.SwitchRoomRdModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into switchroom_rd(");
            strSql.Append("devID,T_ROOM,H_ROOM,ALARM_FIRE,ALARM_SUMP,N1_T_A,N1_T_B,N1_T_C,N1_UAB,N1_UBC,N1_UCA,N1_IA,N1_IB,N1_IC,N1_PF,N1_KWH,N1_KVARH,N1_JXG,N1_DRG,N1_LLG,N1_G1,N1_G2,N1_G3,N1_G4,N1_G5,N1_G6,N1_G7,N1_G8,N1_G9,N1_G10,N2_T_A,N2_T_B,N2_T_C,N2_UAB,N2_UBC,N2_UCA,N2_IA,N2_IB,N2_IC,N2_PF,N2_KWH,N2_KVARH,N2_JXG,N2_DRG,N2_LLG,N2_G1,N2_G2,N2_G3,N2_G4,N2_G5,N2_G6,N2_G7,N2_G8,N2_G9,N2_G10,insertTime)");
            strSql.Append(" values (");
            strSql.Append("@devID,@T_ROOM,@H_ROOM,@ALARM_FIRE,@ALARM_SUMP,@N1_T_A,@N1_T_B,@N1_T_C,@N1_UAB,@N1_UBC,@N1_UCA,@N1_IA,@N1_IB,@N1_IC,@N1_PF,@N1_KWH,@N1_KVARH,@N1_JXG,@N1_DRG,@N1_LLG,@N1_G1,@N1_G2,@N1_G3,@N1_G4,@N1_G5,@N1_G6,@N1_G7,@N1_G8,@N1_G9,@N1_G10,@N2_T_A,@N2_T_B,@N2_T_C,@N2_UAB,@N2_UBC,@N2_UCA,@N2_IA,@N2_IB,@N2_IC,@N2_PF,@N2_KWH,@N2_KVARH,@N2_JXG,@N2_DRG,@N2_LLG,@N2_G1,@N2_G2,@N2_G3,@N2_G4,@N2_G5,@N2_G6,@N2_G7,@N2_G8,@N2_G9,@N2_G10,@insertTime)");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@devID", MySqlDbType.Int32,10),
                    new MySqlParameter("@T_ROOM", MySqlDbType.Decimal,4),
                    new MySqlParameter("@H_ROOM", MySqlDbType.Decimal,4),
                    new MySqlParameter("@ALARM_FIRE", MySqlDbType.Bit),
                    new MySqlParameter("@ALARM_SUMP", MySqlDbType.Bit),
                    new MySqlParameter("@N1_T_A", MySqlDbType.Decimal,4),
                    new MySqlParameter("@N1_T_B", MySqlDbType.Decimal,4),
                    new MySqlParameter("@N1_T_C", MySqlDbType.Decimal,4),
                    new MySqlParameter("@N1_UAB", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_UBC", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_UCA", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_IA", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_IB", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_IC", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_PF", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N1_KWH", MySqlDbType.Int32,10),
                    new MySqlParameter("@N1_KVARH", MySqlDbType.Int32,10),
                    new MySqlParameter("@N1_JXG", MySqlDbType.Bit),
                    new MySqlParameter("@N1_DRG", MySqlDbType.Bit),
                    new MySqlParameter("@N1_LLG", MySqlDbType.Bit),
                    new MySqlParameter("@N1_G1", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G2", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G3", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G4", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G5", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G6", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G7", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G8", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G9", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N1_G10", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_T_A", MySqlDbType.Decimal,4),
                    new MySqlParameter("@N2_T_B", MySqlDbType.Decimal,4),
                    new MySqlParameter("@N2_T_C", MySqlDbType.Decimal,4),
                    new MySqlParameter("@N2_UAB", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_UBC", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_UCA", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_IA", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_IB", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_IC", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_PF", MySqlDbType.Decimal,5),
                    new MySqlParameter("@N2_KWH", MySqlDbType.Int32,10),
                    new MySqlParameter("@N2_KVARH", MySqlDbType.Int32,10),
                    new MySqlParameter("@N2_JXG", MySqlDbType.Bit),
                    new MySqlParameter("@N2_DRG", MySqlDbType.Bit),
                    new MySqlParameter("@N2_LLG", MySqlDbType.Bit),
                    new MySqlParameter("@N2_G1", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G2", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G3", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G4", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G5", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G6", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G7", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G8", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G9", MySqlDbType.VarChar,10),
                    new MySqlParameter("@N2_G10", MySqlDbType.VarChar,10),
                    new MySqlParameter("@insertTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.devID;
            parameters[1].Value = model.T_ROOM;
            parameters[2].Value = model.H_ROOM;
            parameters[3].Value = model.ALARM_FIRE;
            parameters[4].Value = model.ALARM_SUMP;
            parameters[5].Value = model.N1_T_A;
            parameters[6].Value = model.N1_T_B;
            parameters[7].Value = model.N1_T_C;
            parameters[8].Value = model.N1_UAB;
            parameters[9].Value = model.N1_UBC;
            parameters[10].Value = model.N1_UCA;
            parameters[11].Value = model.N1_IA;
            parameters[12].Value = model.N1_IB;
            parameters[13].Value = model.N1_IC;
            parameters[14].Value = model.N1_PF;
            parameters[15].Value = model.N1_KWH;
            parameters[16].Value = model.N1_KVARH;
            parameters[17].Value = model.N1_JXG;
            parameters[18].Value = model.N1_DRG;
            parameters[19].Value = model.N1_LLG;
            parameters[20].Value = model.N1_G1;
            parameters[21].Value = model.N1_G2;
            parameters[22].Value = model.N1_G3;
            parameters[23].Value = model.N1_G4;
            parameters[24].Value = model.N1_G5;
            parameters[25].Value = model.N1_G6;
            parameters[26].Value = model.N1_G7;
            parameters[27].Value = model.N1_G8;
            parameters[28].Value = model.N1_G9;
            parameters[29].Value = model.N1_G10;
            parameters[30].Value = model.N2_T_A;
            parameters[31].Value = model.N2_T_B;
            parameters[32].Value = model.N2_T_C;
            parameters[33].Value = model.N2_UAB;
            parameters[34].Value = model.N2_UBC;
            parameters[35].Value = model.N2_UCA;
            parameters[36].Value = model.N2_IA;
            parameters[37].Value = model.N2_IB;
            parameters[38].Value = model.N2_IC;
            parameters[39].Value = model.N2_PF;
            parameters[40].Value = model.N2_KWH;
            parameters[41].Value = model.N2_KVARH;
            parameters[42].Value = model.N2_JXG;
            parameters[43].Value = model.N2_DRG;
            parameters[44].Value = model.N2_LLG;
            parameters[45].Value = model.N2_G1;
            parameters[46].Value = model.N2_G2;
            parameters[47].Value = model.N2_G3;
            parameters[48].Value = model.N2_G4;
            parameters[49].Value = model.N2_G5;
            parameters[50].Value = model.N2_G6;
            parameters[51].Value = model.N2_G7;
            parameters[52].Value = model.N2_G8;
            parameters[53].Value = model.N2_G9;
            parameters[54].Value = model.N2_G10;
            parameters[55].Value = DateTime.Now;

            return Common.MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0 ? true : false;
        }
    }
}
