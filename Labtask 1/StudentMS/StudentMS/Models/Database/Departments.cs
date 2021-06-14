using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentMS.Models.Database
{
    public class Departments
    {
        private SqlConnection sqlConnection;

        public Departments(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Insert(Department department)
        {

        }

        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            string query = "SELECT * FROM Department";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                Department department = new Department()
                {
                    Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                    Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                };
                departments.Add(department);
            }
            sqlConnection.Close();
            return departments;
        }

        public Department Get(int id)
        {
            Department department = null;
            string query = "SELECT * FROM Department Where Id=@id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                department = new Department()
                {
                    Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                    Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                };
            }
            sqlConnection.Close();
            return department;
        }

        public void Edit(Department department)
        {

        }

        public void Delete(Department department)
        {

        }
    }
}