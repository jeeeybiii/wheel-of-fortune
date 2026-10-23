using System.Net.Http.Headers;
using System.IO;
using System.Runtime.CompilerServices;
namespace WheelOfFortune
{
    internal class Program
    {

        //choice
        public static int userChoice;
        

        //struct student
        public struct Student
        {
            public string firstName;
            public string lastName;
            public string interest;
            public int score;
        }

        //create streamwriter and streamreader
        public static StreamWriter sw;
        public static StreamReader sr;

        public static void Main(string[] args)
        {
            Student[] student = new Student[23];
            LoadStudents(student);
            //Skeleton Program
            do
            {
                Output(student);
            } while (userChoice != 0);
        }

        public static void LoadStudents(Student[] student)
        {
            int i = 0;
            sr = new StreamReader(@"wheelOfFortune.txt");
            while(!sr.EndOfStream && i < student.Length)
            {
                student[i].firstName = sr.ReadLine();
                student[i].lastName = sr.ReadLine();
                student[i].interest = sr.ReadLine();
                student[i].score = int.Parse(sr.ReadLine());
                i++;
            }
            sr.Close();
        }
        public static void TaskOne(Student[] student)
        {
            Console.Write("First Name".PadRight(25));
            Console.Write("Last Name".PadRight(25));
            Console.Write("Interest".PadRight(50));
            Console.WriteLine("Score".PadRight(25));
            for(int i = 0; i < student.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (student[j].lastName.CompareTo(student[i].lastName) > 0)
                    {
                        Student temp = student[i];
                        student[i] = student[j];
                        student[j] = temp;
                    }
                }
                
            }

            for(int i = 0; i < student.Length; i++)
            {
                Console.Write($"{student[i].firstName}".PadRight(25));
                Console.Write($"{student[i].lastName}".PadRight(25));
                Console.Write($"{student[i].interest}".PadRight(50));
                Console.WriteLine($"{student[i].score}".PadRight(25));
            }
            sr.Close();
        }

        public static void TaskTwo(Student[] student)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Find a student by last name");
                Console.WriteLine("0 - Go back");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        int studentFoundNumber = 0;
                        bool studentFound = false;
                        do
                        {
                            
                            Console.Write("Enter a student last name: ");
                            string lastNameSearch = Console.ReadLine();
                            for (int i = 0; i < student.Length; i++)
                            {
                                if (lastNameSearch.ToLower() == student[i].lastName.ToLower())
                                {
                                    studentFound = true;
                                    studentFoundNumber = i;
                                }
                            }

                            if (studentFound == true)
                            {
                                Console.WriteLine("Student found!");
                                Console.WriteLine($"{student[studentFoundNumber].firstName} {student[studentFoundNumber].lastName}");
                                Console.Write("Update the interest: ");
                                string interest = Console.ReadLine();
                                student[studentFoundNumber].interest = interest;
                                sw = new StreamWriter(@"wheelOfFortune.txt");
                                Console.WriteLine("List updated! Check the text file.");
                                for (int i = 0; i < student.Length; i++)
                                {
                                    sw.WriteLine(student[i].firstName);
                                    sw.WriteLine(student[i].lastName);
                                    sw.WriteLine(student[i].interest);
                                    sw.WriteLine(student[i].score);
                                }
                                sw.Close();
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Student not found! Try again!");
                            }
                        } while (studentFound == false);
                        
                        
                        break;
                    case 0:
                        Console.WriteLine("Returning to main menu.");
                        return;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please try again!");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 0 || choice != 1);
            
        }

        public static void TaskThree()
        {
            Console.WriteLine("This is task 3\n");
        }

        public static void TaskFour()
        {
            Console.WriteLine("This is task 4\n");
        }

        public static void TaskFive()
        {
            Console.WriteLine("This is task 5\n");
        }
        public static void TaskZero()
        {
            Console.WriteLine("Exiting program. Thank you and have a good day!\n");
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Wrong input! Please try again!\n");
        }

        public static void TaskChoices()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("1 - List all contestants");
            Console.WriteLine("2 - Locate a player");
            Console.WriteLine("3 - Generate 10 finalists");
            Console.WriteLine("4 - Select the player from the finalists");
            Console.WriteLine("5 - Play the game");
            Console.WriteLine("0 - Exit the game");
            Console.Write("Please Enter a task number: ");
            userChoice = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        public static void Output(Student[] student)
        {
            TaskChoices();
            switch (userChoice)
            {
                case 1:
                    TaskOne(student);
                    Console.WriteLine();
                    break;
                case 2:
                    TaskTwo(student);
                    break;
                case 3:
                    TaskThree();
                    break;
                case 4:
                    TaskFour();
                    break;
                case 5:
                    TaskFive();
                    break;
                case 0:
                    TaskZero();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
            Console.ReadLine();
        }
    }
}
