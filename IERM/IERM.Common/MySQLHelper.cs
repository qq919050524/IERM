using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IERM.Common
{
    /// <summary>
    /// MySQL帮助类
    /// </summary>
    public static class MySQLHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connectionString = ConfigerHelper.GetConnectionString();

        /// <summary>
        /// 数据库连接测试
        /// </summary>
        /// <returns></returns>
        public static bool DBConnTest()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception err)
                {
                    LogHelper.Debug("数据库连接测试失败，原因：" + err.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// 返回单个数据
        /// </summary>
        public static object ExecuteScalar(string sqlStr, CommandType sqlType, params MySqlParameter[] pms)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sqlStr, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }

                    cmd.CommandType = sqlType;

                    try
                    {
                        con.Open();
                        var res = cmd.ExecuteScalar();
                        if (res == null || Convert.IsDBNull(res))
                        {
                            return -1;
                        }
                        else
                        {
                            return res;
                        }
                    }
                    catch (Exception err)
                    {
                        LogHelper.Debug(string.Format("cmdstr:{0}---ExecuteScalar:{1}", sqlStr, err.Message));
                        throw err;
                    }
                }
            }
        }

        /// <summary>
        /// 返回单个数据
        /// </summary>
        public static object ExecuteScalar(string sqlStr, params MySqlParameter[] pms)
        {
            return ExecuteScalar(sqlStr, CommandType.Text, pms);
        }

        /// <summary>
        /// 执行增删改SQL语句  返回受影响的行数
        /// </summary>
        public static int ExecuteNonQuery(string sqlStr, CommandType sqlType, params MySqlParameter[] pms)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sqlStr, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }

                    cmd.CommandType = sqlType;

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery();

                    }
                    catch (Exception err)
                    {
                        LogHelper.Debug(string.Format("cmdstr:{0}---ExecuteNonQuery:{1}", sqlStr, err.Message));
                        throw err;
                    }
                }
            }
        }

        /// <summary>
        /// 执行增删改SQL语句  返回受影响的行数
        /// </summary>
        public static int ExecuteNonQuery(string sqlStr, params MySqlParameter[] pms)
        {
            return ExecuteNonQuery(sqlStr, CommandType.Text, pms);
        }

        /// <summary>
        /// 执行SQL语句  返回数据表
        /// </summary>
        public static DataTable ExecuteToDataTable(string sqlStr, CommandType sqlType, params MySqlParameter[] pms)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adp = new MySqlDataAdapter(sqlStr, con))
                {
                    if (pms != null)
                    {
                        adp.SelectCommand.Parameters.AddRange(pms);
                    }
                    adp.SelectCommand.CommandType = sqlType;
                    DataTable dtb = new DataTable();
                    try
                    {
                        adp.Fill(dtb);
                        return dtb;
                    }
                    catch (Exception err)
                    {
                        LogHelper.Debug(string.Format("cmdstr:{0}---ExecuteToDataTable:{1}", sqlStr, err.Message));
                        return new DataTable();
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句  返回数据表
        /// </summary>
        public static DataTable ExecuteToDataTable(string sqlStr, params MySqlParameter[] pms)
        {
            return ExecuteToDataTable(sqlStr, CommandType.Text, pms);
        }

        private static List<T> DataTableToList<T>(DataTable dtb) where T : class
        {
            Type t = typeof(T);
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            foreach (var item in t.GetProperties())
            {
                if (dtb.Columns.Contains(item.Name))
                {
                    dic.Add(item.Name, item);
                }
            }

            List<T> list = new List<T>();
            try
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    T tmpobj = Activator.CreateInstance<T>();
                    foreach (var item in dic.Keys)
                    {
                        try
                        {
                            if (dr[item] != System.DBNull.Value)
                            {
                                dic[item].SetValue(tmpobj, Convert.ChangeType(dr[item], dic[item].PropertyType), null);
                            }
                        }
                        catch
                        {
                            
                        }
                    }
                    list.Add(tmpobj);
                }
            }
            catch (Exception err)
            {
                list.Clear();
                LogHelper.Debug(string.Format("ExecuteToDataTable:{0}", err.Message));
            }

            return list;
        }

        /// <summary>
        /// 执行SQL语句  返回List集合
        /// </summary>
        public static List<T> ExecuteToList<T>(string sqlStr, CommandType sqlType, params MySqlParameter[] pms) where T : class
        {
            return DataTableToList<T>(ExecuteToDataTable(sqlStr, sqlType, pms));
        }

        /// <summary>
        /// 执行SQL语句  返回List集合
        /// </summary>
        public static List<T> ExecuteToList<T>(string sqlStr, params MySqlParameter[] pms) where T : class
        {
            return DataTableToList<T>(ExecuteToDataTable(sqlStr, pms));
        }

        /// <summary>
        /// 执行SQL语句  返回DataReader
        /// </summary>
        public static MySqlDataReader ExecuteReader(string sqlStr, CommandType sqlType, params MySqlParameter[] pms)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sqlStr, con);
            try
            {
                con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception err)
            {
                LogHelper.Debug(string.Format("cmdstr:{0}---ExecuteReader:{1}", sqlStr, err.Message));
                throw err;
            }
        }
        /// <summary>
        /// 执行SQL语句  返回DataReader
        /// </summary>
        public static MySqlDataReader ExecuteReader(string sqlStr, params MySqlParameter[] pms)
        {
            return ExecuteReader(sqlStr, CommandType.Text, pms);
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>	
        public static int ExecuteSqlByTran(List<String> SQLStringList)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch (Exception err)
                {
                    tx.Rollback();
                    LogHelper.Debug(string.Format("ExecuteSqlByTran:{0}", err.Message));
                    return 0;
                }
            }
        }


        /// <summary>
        /// 执行主从模式事务
        /// </summary>
        /// <param name="maincmdstr">主sql语句</param>
        /// <param name="subcmdlist">从sql语句集合</param>
        /// <returns></returns>
        public static int ExecuteMasterslaveByTran(string maincmdstr, List<string> subcmdlist)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    cmd.CommandText = maincmdstr;
                    int newid = Convert.ToInt32(cmd.ExecuteScalar());
                    if (newid > 0)
                    {
                        count++;
                        string strsql = string.Empty;
                        for (int n = 0; n < subcmdlist.Count; n++)
                        {
                            if (n != 0)
                            {
                                strsql = subcmdlist[n].Replace("[@]", newid.ToString());
                                if (strsql.Trim().Length > 1)
                                {
                                    cmd.CommandText = strsql;
                                    count += cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        tx.Commit();
                        return count;
                    }
                    tx.Rollback();
                    return 0;
                }
                catch (Exception err)
                {
                    LogHelper.Debug(string.Format("ExecuteSqlByTran:{1}", err.Message)); tx.Rollback();
                    return 0;
                }
            }
        }

        /// <summary>
        /// 得到最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = ExecuteScalar(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

    }
}
