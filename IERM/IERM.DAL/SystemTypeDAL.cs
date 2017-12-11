using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class SystemTypeDAL
    {
        /// <summary>
        /// 获取系统类型列表
        /// </summary>
        /// <returns></returns>
        public List<SystemTypeModel> GetSystemType()
        {
            return MySQLHelper.ExecuteToList<SystemTypeModel>("select * from systemtype where isDel=0", null);
        }

        /// <summary>
        /// 获取系统类型  JIXNIN
        /// </summary>
        /// <returns></returns>
        public List<SystemTypeModel> GetAllSystemType()
        {
            return MySQLHelper.ExecuteToList<SystemTypeModel>("SELECT *  FROM systemtype  WHERE isDel = 0 ORDER BY tID", null);
        }


        public List<CodeInformationModel> GetAllCode()
        {
            return MySQLHelper.ExecuteToList<CodeInformationModel>("SELECT *  FROM codeinformation  WHERE isDel = 0 ORDER BY cID", null);
        }
    }
}
