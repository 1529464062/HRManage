using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Class1
    {
        public string returnMD5Value(string UserName,string UserPassword,string UserType)
        {
            string commandString = "exec [AddUser] '" + UserName + "','" + UserPassword + "','" + UserType + "'";
            return DbHelper.ExecuteNonQuery(DbHelper.connectionString, commandString);
        }
    }
}
