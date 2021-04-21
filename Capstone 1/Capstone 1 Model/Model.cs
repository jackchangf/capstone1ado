using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_1_Model //business logic
{
    /*public class Course
    {
        public int courseId;
        public string courseName;

        public List<Student> students = new List<Student>();

    }

    public class Student
    {
        public int studentId;
        public string studentName;
        public int courseId; //from course class
        public string courseName; //from course class
        public int marks; //max 100 value

    }*/

    public abstract class BaseModel
    {
        public int Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; } //logic
        }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastEdit { get; protected set; }

        public abstract bool Validate();
    }

    public class Course : BaseModel
    {
        /*public Course() //constructor
        {
            students = new List<Student>(); //init
        }*/

        /*public int Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; } //logic
        }*/

        public List<Student> students { get; set; } = new List<Student>();

        public override bool Validate()
        {
            return true;
        }

    }

    public class Student : BaseModel
    {

        /*public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { 
                _name = value;
                LastEdit = DateTime.Now;
            }
        }*/

        private int _marks;
        public int Marks
        {
            get { return _marks; }
            set
            {
                /*if (value <= 100 && value >= 0) //setter condition check, need to disable init in UI where marks set to -1 if use this check
                {
                    _marks = value;
                }
                else
                {
                    throw new Exception();
                }*/

                _marks = value;
            }
        }


        public int CourseId { get; set; } //set in UI during student creation. taken from course class


        private string _courseName; 
        public string CourseName //set in UI during student creation. taken from course class
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
