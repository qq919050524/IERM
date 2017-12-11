using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class EquipmentAccBLL
    {
        private readonly EquipmentAccDAL equacc_dal = new EquipmentAccDAL();

        /// <summary>
        /// 获取指定设备房内所有设备的附件
        /// </summary>
        /// <param name="houseid"></param>
        /// <returns></returns>
        public List<EquipmentaccModel> GetEquAccByequID(int equid)
        {
            return equacc_dal.GetEquAccByequID(equid);
        }

        /// <summary>
        /// 一次插入多个设备附件
        /// </summary>
        /// <param name="cmdstrs"></param>
        /// <returns>操作成功的数量</returns>
        public int AddequAcc(List<string> cmdstrs)
        {
            return equacc_dal.AddequAcc(cmdstrs);
        }

        /// <summary>
        /// 删除指定附件编号的设备附件
        /// </summary>
        /// <param name="accid"></param>
        /// <returns></returns>
        public bool DeleteAcc(int accid)
        {
            return equacc_dal.DeleteAcc(accid);
        }
    }
}
