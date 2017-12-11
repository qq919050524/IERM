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
    public partial class EccmDeviceTypeDAL
    {
        public EccmDeviceTypeDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("type_id", "eccm_device_type");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int standard_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eccm_device_type");
            strSql.Append(" where type_id=@type_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@type_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = standard_id;

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(strSql.ToString(), parameters)) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EccmDeviceTypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eccm_device_type(");
            strSql.Append("device_type_code,devide_type_name)");
            strSql.Append(" values (");
            strSql.Append("@device_type_code,@devide_type_name)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@device_type_code", MySqlDbType.VarChar,50),
                    new MySqlParameter("@devide_type_name", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.device_type_code;
            parameters[1].Value = model.devide_type_name;

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
        public bool Update(EccmDeviceTypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eccm_device_type set ");
            strSql.Append("device_type_code=@device_type_code,");
            strSql.Append("devide_type_name=@devide_type_name");
            strSql.Append(" where type_id=@type_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@device_type_code", MySqlDbType.VarChar,50),
                    new MySqlParameter("@devide_type_name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@type_id", MySqlDbType.Int32)};
            parameters[0].Value = model.device_type_code;
            parameters[1].Value = model.devide_type_name;
            parameters[2].Value = model.type_id;

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
            strSql.Append("delete from eccm_device_type ");
            strSql.Append(" where type_id=@type_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@type_id", MySqlDbType.Int32,11)            };
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
        public bool DeleteList(string type_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eccm_device_type ");
            strSql.Append(" where type_id in (" + type_idlist + ")  ");
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
        public EccmDeviceTypeModel GetModel(int type_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select type_id,device_type_code,devide_type_name from eccm_device_type ");
            strSql.Append(" where type_id=@type_id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@type_id", MySqlDbType.Int32,11)            };
            parameters[0].Value = type_id;
            return MySQLHelper.ExecuteToList<EccmDeviceTypeModel>(strSql.ToString(), parameters).FirstOrDefault();
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EccmDeviceTypeModel DataRowToModel(DataRow row)
        {
            EccmDeviceTypeModel model = new EccmDeviceTypeModel();
            if (row != null)
            {
                if (row["type_id"] != null && row["type_id"].ToString() != "")
                {
                    model.type_id = int.Parse(row["type_id"].ToString());
                }
                if (row["device_type_code"] != null)
                {
                    model.device_type_code = row["device_type_code"].ToString();
                }
                if (row["devide_type_name"] != null && row["devide_type_name"].ToString() != "")
                {
                    model.devide_type_name = row["devide_type_name"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 根据分页条件获取分页数据
        /// </summary>
        public DataTable GetList(string strWhere, int pageIndex, int pageSize, out int rowCount)
        {
            StringBuilder strcmd = new StringBuilder("select type_id,device_type_code,devide_type_name from eccm_device_type ");
            string strqur = "select count(1) from eccm_device_type ";
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
            strSql.Append("select count(1) FROM eccm_device_type ");
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

        /// <summary>
        /// 添加设备类型标准关联
        /// </summary>
        public int AddRelation(int standard_id, string device_type_code)
        {
            List<string> cmdlist = new List<string>();
            cmdlist.Add(string.Format("delete from eccm_device_relation_standard where device_type_code='{0}'", device_type_code));
            cmdlist.Add(string.Format("insert into eccm_device_relation_standard(standard_id,device_type_code) values ({0},'{1}')", standard_id, device_type_code));
            return MySQLHelper.ExecuteSqlByTran(cmdlist);
        }

        #endregion  BasicMethod
    }
}

