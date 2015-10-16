using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
using System.Data;

namespace DAL
{
    class DbHelper
    {
        //从配置文件中获取数据库连接字符串
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRManage_SqlConnectionString"].ToString();
        //写一个测试方法，用于调用数据库中的MD5加密存储过程
        public static string ExecuteScalar(string SqlConnectionString, string SqlCommandString)
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
        public static string ExecuteNonQuery(string SqlConnectionString, string SqlCommandString)
        {
            string resultString = "";
            using (SqlConnection sqlcon = new SqlConnection(SqlConnectionString))
            {
                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand(SqlCommandString, sqlcon))
                {
                    try
                    {
                        resultString = sqlcom.ExecuteNonQuery().ToString();
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
        public static SqlDataReader ExecuteReader(string SqlConnectionString, string SqlCommandString)
        {
            SqlDataReader resultString=null;
            using (SqlConnection sqlcon = new SqlConnection(SqlConnectionString))
            {
                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand(SqlCommandString, sqlcon))
                {
                    try
                    {
                        resultString = sqlcom.ExecuteReader();
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
        public static XmlReader ExecuteXmlReader(string SqlConnectionString, string SqlCommandString)
        {
            XmlReader resultString = null;
            using (SqlConnection sqlcon = new SqlConnection(SqlConnectionString))
            {
                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand(SqlCommandString, sqlcon))
                {
                    try
                    {
                        resultString = sqlcom.ExecuteXmlReader();
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
        public static DataTable returnDataTable(string SqlConnectionString, string SqlCommandString)
        {
            DataTable result = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(SqlCommandString, SqlConnectionString);
            sda.Fill(result);
            return result;
        }
    }
}
