using System;
using System.Collections.Generic;
using ConstosoModel;
using System.Linq;
using ContosoDataAccess;
namespace ContosoUniversity
{
    class Program
    {
        
        static string mainAction = "A"; // A -- Add , D- Dsiplay , Edit
        static int subAction = 2; // 1 - Add Course , 2 - Add student...

        static void Main(string[] args)
        {
            // Add some courses by default
            
            
            // string -- series CHAR
            while (mainAction != "Q")
            {
                Console.Clear();
                DisplayAllOptions();
                mainAction = Console.ReadLine();
               
                if (mainAction == "A")
                {
                    DisplayAllAddOptions();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        AddNewCourse();
                    }
                    if (subAction == 2)
                    {
                        AddStudent();
                    }
                }
                if (mainAction == "D")
                {
                    DisplayAllDisplayOptions();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 3)
                    {
                        DisplayCourse();
                    }
                    if (subAction == 4)
                    {
                        DisplayStudent();
                    }
                }
                if (mainAction == "E")
                {
                    DisplayAllEditAndDelete();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 5)
                    {
                        EditCourse();
                    }
                    if (subAction == 7)
                    {
                        EditStudent();
                    }
                }
                

            }

        }
        static void DisplayAllOptions()
        {
            Console.WriteLine("A - Add , D - Display , E - Edit");
            Console.WriteLine("Enter Which  action you want to execute");
        }
        static void DisplayAllAddOptions()
        {
            Console.WriteLine("1 - Add new Course , 2 Add Students");
            Console.WriteLine("Enter Which  action you want to execute");
        }
        static void DisplayAllDisplayOptions()
        {
            Console.WriteLine("3- Display all courses , 4 - Display Al students");
            Console.WriteLine("Enter Which  action you want to execute");
        }
        static void DisplayAllEditAndDelete()
        {
            Console.WriteLine("5,,7 for edit");
            Console.WriteLine("Enter Which  action you want to execute");
        }
        static void AddStudent()
        {
            Console.WriteLine("Enter the course name");
            string coursename = Console.ReadLine();
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            int courseid = db.FindCourse(coursename);
            if (courseid == 0)
            {
                Console.WriteLine("No such course exists");
            }
            else
            {
                Student student = new Student();
                Console.WriteLine("Enter student name");
                student.name = Console.ReadLine();
                
                Console.WriteLine("Enter student marks");
                string marks = Console.ReadLine();
                int markschecked = 0;
                if (int.TryParse(marks, out markschecked) == true) // Try parse return
                {
                    student.marks = markschecked;
                    student.courseId = courseid;
                    db.SaveStudent(student);
                }
                else
                {
                    Console.WriteLine("Marks should be numeric");

                }
                
                
            }
            Console.ReadLine();
        }
        static void AddNewCourse()
        {
            Course course = new Course();
            Console.WriteLine("Enter Course name");
            course.name = Console.ReadLine();
            // make the datacess call
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            db.SaveCourse(course);
            Console.ReadLine();
        }
        static void DisplayStudent()
        {
            Console.WriteLine("This section will Display students");
            Console.ReadLine();
        }
        static void DisplayCourse()
        {
            CourseStudentDataAccess db = new CourseStudentDataAccess();

            List<Course> courses = db.getCourses();
            foreach (var temp in courses)
            {
                Console.WriteLine("Id :- " + temp.id
                            + " Course Name :- " + temp.name);
            }
            Console.ReadLine();
        }
       
        static void EditCourse()
        {
            Console.WriteLine("This section will Edit Course");
            Console.ReadLine();
        }
        static void EditStudent()
        {
            Console.WriteLine("This section will edit students");
            Console.ReadLine();
        }
       

    }

    
}
