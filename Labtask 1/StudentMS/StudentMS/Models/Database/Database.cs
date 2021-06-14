using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentMS.Models.Database
{
    public class Database
    {
        public Admins Admins { get; set; }
        public Departments Departments { get; set; }
        public Students Students { get; set; }

        public Database()
        {
            string connectionstring = @"Server=DESKTOP-SBPPQVR\SQLEXPRESS;Database=StudentMS;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);

            Admins = new Admins(sqlConnection);
            Departments = new Departments(sqlConnection);
            Students = new Students(sqlConnection);
        }
    }
}