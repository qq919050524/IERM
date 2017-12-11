using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using IERM.Common;
using IERM.Model;

namespace IERM.DAL
{
    /// <summary>
    /// 数据访问类:EccmStandardDAL
    /// </summary>
    public partial class EccmStandardDAL
    {
        public EccmStandardDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("standard_id", "eccm_standard");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int standard_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eccm_standard");
            strSql.Append(" where standard_id=@standard_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@standard_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = standard_id;

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(strSql.ToString(), parameters)) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmStandardModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_standard(");
            strSql.Append("inspection_standard,standard_type,ext1,ext2,ext3)");
            strSql.Append(" values (");
            strSql.Append("@inspection_standard,@standard_type,@ext1,@ext2,@ext3)");
            MySqlParameter[] parameters = {
                    //new MySqlParameter("@standard_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@inspection_standard", MySqlDbType.VarChar,2000),
                    new MySqlParameter("@standard_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,50)};
            //parameters[0].Value = model.standard_id;
            parameters[0].Value = model.inspection_standard;
            parameters[1].Value = model.standard_type;
            parameters[2].Value = model.ext1;
            parameters[3].Value = model.ext2;
            parameters[4].Value = model.ext3;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(EccmStandardModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_standard set ");
            strSql.Append("inspection_standard=@inspection_standard,");
            strSql.Append("standard_type=@standard_type,");
            strSql.Append("ext1=@ext1,");
            strSql.Append("ext2=@ext2,");
            strSql.Append("ext3=@ext3");
            strSql.Append(" where standard_id=@standard_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@inspection_standard", MySqlDbType.VarChar,2000),
                    new MySqlParameter("@standard_type", MySqlDbType.Int32,11),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,50),
                    new MySqlParameter("@standard_id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.inspection_standard;
            parameters[1].Value = model.standard_type;
            parameters[2].Value = model.ext1;
            parameters[3].Value = model.ext2;
            parameters[4].Value = model.ext3;
            parameters[5].Value = model.standard_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int standard_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_standard ");
            strSql.Append(" where standard_id=@standard_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@standard_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = standard_id;

            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string standard_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_standard ");
            strSql.Append(" where standard_id in (" + standard_idlist + ")  ");
            int rows = MySQLHelper.ExecuteNonQuery(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public EccmStandardModel GetModel(int standard_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select standard_id,inspection_standard,standard_type,ext1,ext2,ext3 from eccm_standard ");
            strSql.Append(" where standard_id=@standard_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@standard_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = standard_id;
            return MySQLHelper.ExecuteToList<EccmStandardModel>(strSql.ToString(), parameters).FirstOrDefault();
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmStandardModel DataRowToModel(DataRow row)
        {
            EccmStandardModel model = new EccmStandardModel();
            if (row != null)
            {
                if (row["standard_id"] != null && row["standard_id"].ToString() != "")
                {
                    model.standard_id = int.Parse(row["standard_id"].ToString());
                }
                if (row["inspection_standard"] != null)
                {
                    model.inspection_standard = row["inspection_standard"].ToString();
                }
                if (row["standard_type"] != null && row["standard_type"].ToString() != "")
                {
                    model.standard_type = int.Parse(row["standard_type"].ToString());
                }
                if (row["ext1"] != null)
                {
                    model.ext1 = row["ext1"].ToString();
                }
                if (row["ext2"] != null)
                {
                    model.ext2 = row["ext2"].ToString();
                }
                if (row["ext3"] != null)
                {
                    model.ext3 = row["ext3"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public DataTable GetList(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            StringBuilder strcmd = new StringBuilder("select standard_id,inspection_standard,standard_type,ext1,ext2,ext3 from eccm_standard ");
            string strqur = "select count(1) from eccm_standard ";
            if (strWhere.Trim() != "")
            {
                strcmd.Append(" where " + strWhere);
                strqur = strqur + " where " + strWhere;
            }
            rowCount = Convert.ToInt32(MySQLHelper.ExecuteScalar(strqur, null));

            int startIndex = (pageIndex - 1) * pageSize;
            strcmd.AppendFormat(" LIMIT {0},{1}", startIndex, pageSize);
            return MySQLHelper.ExecuteToDataTable(strcmd.ToString(), null);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM eccm_standard ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = MySQLHelper.ExecuteScalar(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion  BasicMethod
    }
}

