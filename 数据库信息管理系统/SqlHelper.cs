using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace 数据库信息管理系统
{
    public class SqlHelper
    {
        private static readonly string connStr = "Data Source=.;Initial Catalog=Management;Integrated Security=True";
        public static SqlConnection sc;

        /// <summary>
        /// SQL增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteSql(string sql)
        {
            try
            {
                using (sc = new SqlConnection(connStr))
                {
                    sc.Open();
                    SqlCommand sqlCommand = new SqlCommand(sql, sc);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sc.State ==System.Data.ConnectionState.Open)
                {
                    sc.Close();
                }
            }
            
        }
        /// <summary>
        /// SQL查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (sc = new SqlConnection(connStr))
                {
                    sc.Open();
                    SqlCommand sqlCommand = new SqlCommand(sql, sc);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sc.State != ConnectionState.Closed)
                {
                    sc.Close();
                }
            }
        }
        /// <summary>
        /// 进行查询的静态方法（用于登录窗口）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader Reader(string sql)
        {
            sc = new SqlConnection(connStr);
            sc.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sc);
            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            
        }
    }
}
