using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone_1_Model;
using System.Data.SqlClient;
using System.Data;

namespace Capstone_1_DataAccess
{
    public class CourseStudentDataAccess
    {
        private string connectionString = "Data Source=DESKTOP-V3MJISD\\JACK;Initial Catalog=ContonsoDB;Integrated Security=True";

        public bool SaveCourseToDB(Course obj) //add course to sql
        {
            //step 1 open connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2 create sql insert into
            // SqlCommand comm = new SqlCommand("commandtext", conn); //shortcut
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblCourse(CourseName) values (' " + obj.Name + " ')"; //synthax is " + obj.Name + " to force it be string in c#, the outer ' ' is sql synthax
            comm.Connection = conn;

            //step 3 executed
            comm.ExecuteNonQuery();

            //step 4 close connection
            conn.Close();
            return true;
        }

        public List<Course> GetCoursesFromDB()
        {
            List<Course> courses = new List<Course>();
            //step 1 open connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2 create sql insert into
            // SqlCommand comm = new SqlCommand("commandtext", conn); //shortcut
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT ID,CourseName FROM tblCourse ORDER BY ID ASC";


            SqlDataReader DR = comm.ExecuteReader();
            while (DR.Read()) //means if there still is data
            {
                Course temp = new Course();
                temp.Id = Convert.ToInt32(DR["Id"]);
                temp.Name = DR["CourseName"].ToString().Trim();
                //temp.students = 
                courses.Add(temp);

                //Console.WriteLine(DR["CourseName"]);
            }

            //DR.Close(); //auto close?
            conn.Close();



            return courses;
        }

        /*public int FindCourseFromDB(string courseName)
        {
            //step 1 open connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2 create sql insert into
            // SqlCommand comm = new SqlCommand("commandtext", conn); //shortcut
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT Id FROM tblCourse where CourseName= '" + courseName + "'";


            SqlDataReader DR = comm.ExecuteReader();

            DR.Read(); //go to first row and read, if not called, reader will be on top
            int id = Convert.ToInt32(DR["id"]);


            conn.Close();
            return id;
        }*/


        public bool SaveStudentToDB(Student obj) //add student to sql
        {
            //step 1 open connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2 create sql insert into
            // SqlCommand comm = new SqlCommand("commandtext", conn); //shortcut
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "insert into tblStudent(StudentName, StudentMarks, CourseId_fk) values (' " + obj.Name + " ', " + obj.Marks + ", " + obj.CourseId + ")"; //synthax is " + obj.Name + " to force it be string in c#, the outer ' ' is sql synthax, '' is for string in sql, if int no need
            comm.Connection = conn;

            //step 3 executed
            comm.ExecuteNonQuery();

            //step 4 close connection
            conn.Close();
            return true;
        }

        public List<Student> GetStudentsOfCourseFromDB(int courseId) //checks sql tblStudent and return all students with courseID
        {
            List<Student> students = new List<Student>();
            //step 1 open connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //step 2 create sql insert into
            // SqlCommand comm = new SqlCommand("commandtext", conn); //shortcut
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT ID,StudentName,StudentMarks FROM tblStudent WHERE courseId_fk = " + courseId + "";


            SqlDataReader DR = comm.ExecuteReader();
            while (DR.Read()) //means if there still is data
            {
                Student temp = new Student();
                temp.Id = Convert.ToInt32(DR["Id"]);
                temp.Name = DR["StudentName"].ToString().Trim();
                temp.Marks = Convert.ToInt32(DR["StudentMarks"]);
                students.Add(temp);

            }

            //DR.Close(); //auto close?
            conn.Close();

            return students;

        }


        public void UpdateCourseInDB(int courseId, string name)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Update tblCourse SET CourseName = '" + name + "' WHERE Id = " + courseId + " ";
            comm.Connection = conn;

            comm.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteCourseInDB(int courseId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "DELETE tblCourse WHERE Id = " + courseId + " ";
            comm.Connection = conn;

            comm.ExecuteNonQuery();

            conn.Close();

        }


    }

}
