using ConstosoModel;
using System;
using System.Data;
using System.Data.SqlClient;
namespace ContosoDataAccess
{
    public class CourseStudentDataAccess
    {
        private string connectionString = "Data Source=DESKTOP-4BSD0GC;Initial Catalog=ContosoConsoleDB;Integrated Security=True";
        public bool SaveCourse(Course obj)
        {
            // Step 1 :- open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Step 2 :- Create SQL insert into..
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblcourse(coursename) values('" + obj.name + "')";
            comm.Connection = conn;
            // Step 3 :- Executed
            comm.ExecuteNonQuery();
            // Step 4 :- Close connection 
            conn.Close();
            return true;
        }
       
    }
   


}
