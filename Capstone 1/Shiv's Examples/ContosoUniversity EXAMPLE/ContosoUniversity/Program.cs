using System;

namespace ContosoUniversity
{
    class Program
    {
        static string mainAction = "A"; // A -- Add , D- Dsiplay , Edit
        static int subAction = 2; // 1 - Add Course , 2 - Add student...

        static void Main(string[] args)
        {
            while (mainAction != "Q")
            {
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
                    DisplayAllAddOptions();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        AddNewCourse();
                    }
                    if (subAction == 2)
                    {
                        AddNewCourse();
                    }
                }
                if (mainAction == "E")
                {
                    DisplayAllAddOptions();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        AddNewCourse();
                    }
                    if (subAction == 2)
                    {
                        AddNewCourse();
                    }
                }
                

            }

        }
        static void DisplayAllAddOptions()
        {
            Console.WriteLine("1 - Add new Course , 2 Add Students");
            Console.WriteLine("Enter Which Add action you want to execute");
        }
        static void AddStudent()
        {
            Console.WriteLine("This section will add a new students");
        }
        static void AddNewCourse()
        {
            Console.WriteLine("This section will add a new Course");
        }
    }
}
