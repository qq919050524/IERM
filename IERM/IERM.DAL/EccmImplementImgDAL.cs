using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using IERM.Common;
using IERM.Model;

namespace IERM.DAL
{
    /// <summary>
    /// 数据访问类:EccmImplementImgDAL
    /// </summary>
    public partial class EccmImplementImgDAL
    {
        public EccmImplementImgDAL()
        { }
        #region  BasicMethod     

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmImplementImgModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into eccm_implement_img(implement_id, img_path, img_type) values ");
            foreach (string s in model.img_path.Split(','))
            {
                strSql.Append("(" + model.implement_id + ",'" + s + "'," + model.img_type + "),");
            }
            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString().Substring(0, strSql.Length - 1));
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 根据条件获取图片数据
        /// </summary>
        public DataTable GetList(int implement_id,int img_type)
        {
            StringBuilder strcmd = new StringBuilder("select * from eccm_implement_img ");
            strcmd.AppendFormat(" where implement_id={0}", implement_id);
            strcmd.AppendFormat(" and img_type={0}", img_type);//1巡检2维保3维修
            return MySQLHelper.ExecuteToDataTable(strcmd.ToString(), null);
        }
        #endregion  BasicMethod
    }
}

