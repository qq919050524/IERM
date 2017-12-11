using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EquipmentAccDAL
    {
        /// <summary>
        /// 获取指定设备附件
        /// </summary>
        public List<EquipmentaccModel> GetEquAccByequID(int equid)
        {
            return MySQLHelper.ExecuteToList<EquipmentaccModel>(string.Format("SELECT * from equipmentacc where equID={0}", equid), null);
        }

        /// <summary>
        /// 一次插入多个设备附件
        /// </summary>
        /// <param name="cmdstrs"></param>
        /// <returns>操作成功的数量</returns>
        public int AddequAcc(List<string> cmdstrs)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdstrs);
        }

        /// <summary>
        /// 删除指定附件编号的设备附件
        /// </summary>
        /// <param name="accid"></param>
        /// <returns></returns>
        public bool DeleteAcc(int accid)
        {
            return MySQLHelper.ExecuteNonQuery(string.Format("delete from equipmentacc where aID={0}", accid), null) > 0 ? true : false;
        }
    }
}
