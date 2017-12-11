using IERM.Common;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public partial class PropertyInfoDAL
    {
        /// <summary>
        /// 获取物业公司信息表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPropertyinfo()
        {
            return MySQLHelper.ExecuteToDataTable("select propertyID,propertyName from propertyinfo where isDel=0", null);
        }

        public List<PropertyInfoModel> GetAllPropertyinfoList()
        {
            return MySQLHelper.ExecuteToList<PropertyInfoModel>("select propertyID,propertyName from propertyinfo where isDel=0");
        }


        /// <summary>
        /// 根据条件查询物业公司信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPropertyinfoList(string sqlwhere)
        {
           
            return MySQLHelper.ExecuteToDataTable("select propertyID,propertyName from propertyinfo where isDel=0 "+ sqlwhere);
        }

        /// <summary>
        /// 根据公司名称获取公司ID
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public List<PropertyInfoModel> GetPropertyID(string pName)
        {
            return MySQLHelper.ExecuteToList<PropertyInfoModel>(string.Format("select propertyID from propertyinfo where isDel=0 AND propertyName='{0}'",pName),null);
        }
        
    }
}
