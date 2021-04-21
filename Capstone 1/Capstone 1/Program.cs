using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone_1_Model;
using Capstone_1_DataAccess;

namespace Capstone_1_UI //view
{
    class Program
    {
        static void Main(string[] args)
        {
            /*courses.Add(new Course() { Name = "coding" , Id = 0 });
            courses.Add(new Course() { Name = "phonics" , Id = 1 });
            courses.Add(new Course() { Name = "IT" , Id = 2 });*/


            UserInput();
        }

        private static void UserInput()
        {
            Console.WriteLine("\nWelcome to Contonso University Learning Management System");
            Console.WriteLine("=========================================================");

            Console.WriteLine("\n1 - Add new course \n" +
                                "2 - Add new student to course \n" +
                                "3 - Display all courses \n" +
                                "4 - Display all students \n" +
                                "5 - Edit student particulars \n" +
                                "6 - Delete student \n" +
                                "7 - Edit course \n" +
                                "8 - Delete course \n" +
                                "9 - Quit"
                              );

            bool toLoop = true;
            while (toLoop)
            {
                Console.WriteLine("\n >> SELECT ACTION (1-9) \n");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddCourse(); break;
                    case "2": AddStudentToCourse(); break;
                    case "3": DisplayAllCourses(); break;
                    case "4": DisplayAllStudents(); break;
                    case "5": EditStudent(); break;
                    case "6": DeleteStudent(); break;
                    case "7": EditCourse(); break;
                    case "8": DeleteCourse(); break;
                    case "9": toLoop = false; break; //quit
                    default:
                        break;
                }
            }

        }

        private static void AddCourse()
        {
            Course newCourse = new Course();

            bool toLoop = true;
            while (toLoop)
            {
                Console.WriteLine("Please enter new course name");
                newCourse.Name = Console.ReadLine();

                if(newCourse.Name != "")
                {
                    toLoop = false;
                }
                else
                {
                    Console.WriteLine("Course name cannot be empty");
                }

            }

            Console.WriteLine("==========================");

            //dataaccess call
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            db.SaveCourseToDB(newCourse);
            Console.WriteLine("COURSE CREATED: " + newCourse.Name);

            //finding the corresponding ID from sql table primary key ID
            List<Course> coursesDB = db.GetCoursesFromDB();

            foreach (Course c in coursesDB)
            {
                if(c.Name == newCourse.Name) //found the course that just got created and saved to DB
                {
                    newCourse.Id = c.Id;
                    Console.WriteLine("Found course");
                    break;
                }
            }
            
            Console.WriteLine("Course ID set as: " + newCourse.Id);

        }

        private static void AddStudentToCourse()
        {
            Course courseChosen = null; //temp var

            Console.WriteLine("ADDING STUDENT TO COURSE");
            Student newStudent = new Student();
            DisplayAllCourses(); //for user to select which course to add student in

            bool toLoop = true;
            while (toLoop)
            {
                Console.WriteLine("\n Select Course ID to add student into");
                string inputID = Console.ReadLine();

                if (int.TryParse(inputID, out _)) //check if it is a number
                {
                    CourseStudentDataAccess db = new CourseStudentDataAccess();
                    List<Course> coursesDB = db.GetCoursesFromDB();

                    foreach (Course c in coursesDB)
                    {
                        if (c.Id == Convert.ToInt32(inputID)) //course id exists
                        {
                            Console.WriteLine(c.Name + " selected");
                            courseChosen = c;
                            newStudent.CourseId = c.Id;
                            toLoop = false;
                            break;
                        }
                    }

                    if (courseChosen == null)
                    {
                        Console.WriteLine("Invalid Course Id, doesn't exist");
                        //invalid course id selected
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Course Id, non-numerical");
                    //invalid course id selected
                }
            }

            bool toLoop2 = true;
            while (toLoop2)
            {
                Console.WriteLine("Please input student name");
                newStudent.Name = Console.ReadLine();

                if (newStudent.Name != "")
                {
                    toLoop2 = false;
                }
                else
                {
                    Console.WriteLine("Student name cannot be empty");
                }
            }


            /*Random r = new Random();
            int rand = r.Next(0, 100); //get random marks
            Console.WriteLine("Student obtained marks: " + rand);
            newStudent.marks = rand;*/

            bool toLoop3 = true;
            while (toLoop3)
            {
                Console.WriteLine("Please input student marks");

                newStudent.Marks = -1; //init as -1 so if it is not changed below, then it means no valid marks were entered
                string inputMarks = Console.ReadLine();
                if (int.TryParse(inputMarks, out _)) //check if it is a number
                {
                    newStudent.Marks = Convert.ToInt32(inputMarks);
                }

                if (newStudent.Marks <= 100 && newStudent.Marks >= 0)
                {
                    toLoop3 = false;
                }
                else
                {
                    Console.WriteLine("Student marks must be within 0 to 100");
                }
            }

            //dataaccess call
            CourseStudentDataAccess db1 = new CourseStudentDataAccess();
            db1.SaveStudentToDB(newStudent);
            Console.WriteLine("Student: " + newStudent.Name + ", added to course: " + courseChosen.Name);

        }

        private static void DisplayAllCourses()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("DISPLAYING LIST OF COURSES:");

            //dataaccess call
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            List<Course> coursesDB =  db.GetCoursesFromDB();
            if (coursesDB.Count == 0)  //no courses created yet, return
            {
                Console.WriteLine("No courses created yet");
                return;
            }

            foreach (Course c in coursesDB)
            {
                List<Student> studentsDB = db.GetStudentsOfCourseFromDB(c.Id);

                //calculate average marks
                int averageMarks = 0;
                if (studentsDB.Count != 0)
                {
                    foreach (Student s in studentsDB)
                    {
                        averageMarks += s.Marks; //total marks from all student
                    }
                    averageMarks /= studentsDB.Count; //divide by number of students for average
                }
                else //no students
                {
                    averageMarks = 0; //prevent division by 0
                }

                //Console.WriteLine("Course ID: " + c.Id + ", Course Name: " + c.Name);
                Console.WriteLine("Course" + "(" + c.Id + "): " + c.Name + ", Students(Total): " + studentsDB.Count + ", Marks(Average): " + averageMarks);
            }

        }

        private static void DisplayAllStudents()
        {
            Course courseChosen = null; //temp var

            Console.WriteLine("==========================");
            Console.WriteLine("DISPLAYING ALL STUDENTS IN SELECTED COURSE");
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            List<Course> coursesDB = db.GetCoursesFromDB();
            if (coursesDB.Count == 0)  //no courses created yet, return
            {
                Console.WriteLine("No courses created yet");
                return;
            }

            DisplayAllCourses();

            bool toLoop = true;
            while (toLoop)
            {
                Console.WriteLine("\nSelect Course ID to display all students");
                string inputID = Console.ReadLine();

                if (int.TryParse(inputID, out _)) //check if it is a number
                {
                    foreach (Course c in coursesDB)
                    {
                        if (c.Id == Convert.ToInt32(inputID)) //course id exists
                        {
                            Console.WriteLine("==========================");
                            Console.WriteLine(c.Name.ToUpper() + " SELECTED");
                            courseChosen = c;

                            List<Student> studentsDB = db.GetStudentsOfCourseFromDB(Convert.ToInt32(inputID));

                            foreach (Student s in studentsDB)
                            {
                                Console.WriteLine("Student(name): " + s.Name + ", Student(ID): " + s.Id + ", Student(Marks): " + s.Marks);
                            }

                            if(studentsDB.Count == 0) //no students yet
                            {
                                Console.WriteLine("No students in course yet");
                            }

                            toLoop = false;
                            break;
                        }
                    }

                    if (courseChosen == null)
                    {
                        Console.WriteLine("Invalid Course Id, doesn't exist");
                        //invalid course id selected
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Course Id, non-numerical");
                    //invalid course id selected
                }
            }

        }

        private static void EditStudent()
        {
            Console.WriteLine("edit student"); //pass parameters courseid, student id into sql update in dataaccess layer
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("delete student"); //pass parameters courseid, student id into sql delete in dataaccess layer
        }

        private static void EditCourse() //same logic as above
        {
            DisplayAllCourses();
            Console.WriteLine("\nPLease choose course Id to change");
            int courseId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("PLease enter new course name");
            string newCourseName = Console.ReadLine();

            CourseStudentDataAccess db = new CourseStudentDataAccess();
            db.UpdateCourseInDB(courseId, newCourseName);

            Console.WriteLine("Course name changed");

        }

        private static void DeleteCourse() //cannot delete if course have students, if want to force delete, have to remove all students from said course first
        {
            DisplayAllCourses();
            Console.WriteLine("\nPLease choose course Id to delete");
            int courseId = Convert.ToInt32(Console.ReadLine());

            CourseStudentDataAccess db = new CourseStudentDataAccess();
            db.DeleteCourseInDB(courseId);

            Console.WriteLine("Course Deleted"); //use sql delete
        }

    }
}
