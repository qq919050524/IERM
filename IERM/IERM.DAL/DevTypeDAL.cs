using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public partial class DevTypeDAL
    {
        /// <summary>
        /// 获取全部设备类型
        /// </summary>
        public List<DevTypeModel> GetAllType()
        {
            return MySQLHelper.ExecuteToList<DevTypeModel>("select * from devtype order by sort asc", null);
        }
        /// <summary>
        /// 查询类型
        /// </summary>
        /// <param name="TypeCode">编码</param>
        /// <returns></returns>
        public List<DevTypeModel> GetTypeByCode(string TypeCode)
        {
            string strSql = "select * from devtype";
            string strWhere = "";
            if(!string.IsNullOrWhiteSpace(TypeCode))
            {
                strWhere = " devTypeCode='" + TypeCode + "'";
                strSql += " where " + strWhere;
            }
            return MySQLHelper.ExecuteToList<DevTypeModel>(strSql, null);
        }
    }

}
