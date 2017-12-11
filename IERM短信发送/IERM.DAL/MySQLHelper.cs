using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IERM.Message.DAL
{
    /// <summary>
    /// MySQL帮助类
    /// </summary>
    public static class MySQLHelper
    {

        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";
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
                    //LogHelper.Dbbug(string.Format("{0}---{1}", "DBConnTest", err.Message));
                    return false;
                }
            }
        }

        /// <summary>
        /// 数据库连接测试
        /// </summary>
        /// <returns></returns>
        public static bool StringConnTest(string connstr)
        {
            using (MySqlConnection con = new MySqlConnection(connstr))
            {
                try
                {
                    System.Threading.Thread.Sleep(3000);
                    con.Open();
                    return true;
                }
                catch (Exception err)
                {
                    // LogHelper.Dbbug(string.Format("{0}---{1}", "StringConnTest", err.Message));
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
                        //WriteLog("ExecuteScalar", sqlStr);
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
                        WriteLog("ExecuteScalar", sqlStr + "\r\n" + err.ToString());
                        // LogHelper.Dbbug(string.Format("{0}---{1}---{2}", "ExecuteScalar", err.Message,sqlStr));
                        return -10;
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
        /// 返回单个数据
        /// </summary>
        public static object ExecuteScalar(string sqlStr)
        {
            return ExecuteScalar(sqlStr, CommandType.Text, null);
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
                        WriteLog("ExecuteNonQuery", sqlStr + "\r\n" + err.ToString());
                        //LogHelper.Dbbug(string.Format("{0}---{1}---{2}", "ExecuteNonQuery", err.Message, sqlStr));
                        return -10;
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
        /// 执行增删改SQL语句  返回受影响的行数
        /// </summary>
        public static int ExecuteNonQuery(string sqlStr)
        {
            return ExecuteNonQuery(sqlStr, CommandType.Text, null);
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
                        //WriteLog("ExecuteToDataTable", sqlStr);

                        return dtb;
                    }
                    catch (Exception err)
                    {
                        WriteLog("ExecuteToDataTable", sqlStr + "\r\n" + err.ToString());
                        //LogHelper.Dbbug(string.Format("{0}---{1}---{2}", "ExecuteToDataTable", err.Message, sqlStr));
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
                        if (dr[item] != System.DBNull.Value)
                        {
                            dic[item].SetValue(tmpobj, Convert.ChangeType(dr[item], dic[item].PropertyType), null);
                        }
                    }
                    list.Add(tmpobj);
                }
            }
            catch (Exception err)
            {
                //LogHelper.Dbbug(string.Format("{0}---{1}", "DataTableToList", err.Message));
                list.Clear();
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
                //LogHelper.Dbbug(string.Format("{0}---{1}---{2}", "ExecuteReader", err.Message, sqlStr));
                return null;
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
                string strsql = string.Empty;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        strsql = SQLStringList[n];
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
                    //LogHelper.Dbbug(string.Format("{0}---{1}---{2}", "ExecuteSqlByTran", err.Message, strsql));
                    tx.Rollback();
                    return 0;
                }
            }
        }

        public static void WriteLog(string className, string content)
        {
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //创建或打开日志文件，向日志文件末尾追加记录
            StreamWriter mySw = File.AppendText(filename);

            //向日志文件写入内容
            string write_content = time + "error\r\n" + className + ": " + content;
            mySw.WriteLine(write_content);

            //关闭日志文件
            mySw.Close();
        }

    }
}
