using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data.Common;
using System.Data;

namespace DAL
{
    public class Class1
    {
        public string returnMD5Value(string UserName,string UserPassword,string UserType)
        {
            string commandString = "exec [AddUser] '" + UserName + "','" + UserPassword + "','" + UserType + "'";
            return DbHelper.ExecuteNonQuery(DbHelper.connectionString, commandString);
        }
        public DataTable returnDataTable()
        {
            string commandString = "exec [selectUserInfo]";
            return DbHelper.returnDataTable(DbHelper.connectionString, commandString);
        }
    }
}
