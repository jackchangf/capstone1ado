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
            Console.WriteLine("This section will add a new students");
            Console.ReadLine();
        }
        static void AddNewCourse()
        {
            Console.WriteLine("This section will add a new Course");
            Console.ReadLine();
        }
        static void DisplayStudent()
        {
            Console.WriteLine("This section will Display students");
            Console.ReadLine();
        }
        static void DisplayCourse()
        {
            Console.WriteLine("This section will Display Course");
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
