using ConstosoModel;
using System;
using System.Collections.Generic;
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
        public bool SaveStudent(Student obj)
        {
            // Step 1 :- open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            // Step 2 :- Create SQL insert into..
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblstudent(studentname,studentmarks,courseid_fk) values('" 
                                + obj.name + "'," + obj.marks  + "," + obj.courseId + ")";
            comm.Connection = conn;
            // Step 3 :- Executed
            comm.ExecuteNonQuery();
            // Step 4 :- Close connection 
            conn.Close();
            return true;
        }
        public int FindCourse(string courseName)
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Id from tblCourse where CourseName='" + courseName +"'";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            dr.Read(); // go to first row and get the id
            int id = Convert.ToInt32(dr["id"]);
            conn.Close();
            return id;
           
            
        }
        public List<Course> getCourses()
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select id,CourseName from tblCourse";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Course temp = new Course();
                temp.id = Convert.ToInt32(dr["id"]);
                temp.name = dr["CourseName"].ToString();
                courses.Add(temp);
            }
           
            conn.Close();
            return courses;
        }
    }
   


}
