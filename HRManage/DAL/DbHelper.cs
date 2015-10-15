using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    class DbHelper
    {
        //从配置文件中获取数据库连接字符串
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRManage"].ToString();
        //写一个测试方法，用于调用数据库中的MD5加密存储过程
        public static string ExecuteSql(string SqlConnectionString, string SqlCommandString)
        {
            string resultString = "";
            using (SqlConnection sqlcon = new SqlConnection(SqlConnectionString))
            {
                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand(SqlCommandString, sqlcon))
                {
                    try
                    {
                        resultString = sqlcom.ExecuteScalar().ToString();
                    }
                    catch (Exception)
                    {

                        sqlcon.Close();
                    }
                }
                sqlcon.Close();
                sqlcon.Dispose();
            }
            return resultString;
        }
    }
}
