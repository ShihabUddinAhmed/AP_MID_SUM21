using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentMS.Models.Database
{
    public class Students
    {
        private SqlConnection sqlConnection;

        public Students(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Insert(Student student)
        {
            string query = "INSERT INTO Students VALUES(@name,@dob,@credit,@cgpa,@dept)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", student.Name);
            sqlCommand.Parameters.AddWithValue("@dob", student.Dob);
            sqlCommand.Parameters.AddWithValue("@credit", student.Credit);
            sqlCommand.Parameters.AddWithValue("@cgpa", student.CGPA);
            sqlCommand.Parameters.AddWithValue("@dept", student.Dept_id);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM Students";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while(sqlDataReader.Read())
            {
                Student student = new Student()
                {
                    Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                    Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                    Dob = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Dob")).ToString(),
                    Credit = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Credit")),
                    CGPA = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("CGPA")),
                    Dept_id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Dept_Id")),
                };
                students.Add(student);
            }
            sqlConnection.Close();
            return students;
        }

        public Student Get(int id)
        {
            Student student = null;
            string query = "SELECT * FROM Students Where Id=@id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                student = new Student()
                {
                    Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                    Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                    Dob = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Dob")).ToString(),
                    Credit = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Credit")),
                    CGPA = sqlDataReader.GetDouble(sqlDataReader.GetOrdinal("CGPA")),
                    Dept_id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Dept_Id")),
                };
            }
            sqlConnection.Close();
            return student;
        }

        public void Edit(Student student)
        {
            string query = "UPDATE Students SET Name=@name, Dob=@dob, Credit=@credit, CGPA=@cgpa, Dept_Id=@dept WHERE Id=@id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", student.Id);
            sqlCommand.Parameters.AddWithValue("@name", student.Name);
            sqlCommand.Parameters.AddWithValue("@dob", student.Dob);
            sqlCommand.Parameters.AddWithValue("@credit", student.Credit);
            sqlCommand.Parameters.AddWithValue("@cgpa", student.CGPA);
            sqlCommand.Parameters.AddWithValue("@dept", student.Dept_id);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Students WHERE Id=@id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}