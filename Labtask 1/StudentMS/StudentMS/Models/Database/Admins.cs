using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentMS.Models.Database
{
    public class Admins
    {
        SqlConnection sQLConnection;

        public Admins(SqlConnection sqlConnection)
        {
            this.sQLConnection = sqlConnection;
        }

        public bool AuthenticateAdmin(Admin admin)
        {
            string sql = "SELECT * FROM Admins WHERE Username = @username AND Password = @password";
            SqlCommand sqlCommand = new SqlCommand(sql, sQLConnection);
            sqlCommand.Parameters.AddWithValue("@username", admin.UserName);
            sqlCommand.Parameters.AddWithValue("@password", admin.Password);
            sQLConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if(sqlDataReader.Read())
            {
                sQLConnection.Close();
                return true;
            }
            sQLConnection.Close();
            return false;
        }
    }
}