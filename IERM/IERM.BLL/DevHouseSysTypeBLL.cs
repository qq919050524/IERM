using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class DevHouseSysTypeBLL
    {
        private readonly DevHouseSysTypeDAL housesys_dal = new DevHouseSysTypeDAL();
        /// <summary>
        /// 获取设备房所含系统类型
        /// </summary>
        /// <param name="devhouseid"></param>
        /// <returns></returns>
        public List<DevHouseSysTypeModel> GetHouseSystype(int devhouseid)
        {
            return housesys_dal.GetHouseSystype(string.Format(" where devhouseID={0}", devhouseid));
        }
    }
}
