using System.Net.Http.Headers;

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
            //Skeleton Program
            do
            {
                Output(student);
            } while (userChoice != 0);
        }

        public static Student[] TaskOne(Student[] student)
        {
            int i = 0;
            sr = new StreamReader(@"wheelOfFortune.txt");
            Console.WriteLine("List all contestants\n");
            while (!sr.EndOfStream && i < student.Length)
            {
                student[i].firstName = sr.ReadLine();
                student[i].lastName = sr.ReadLine();
                student[i].interest = sr.ReadLine();
                student[i].score = int.Parse(sr.ReadLine());
                i++;
            }
            Console.Write("First Name".PadRight(25));
            Console.Write("Last Name".PadRight(25));
            Console.Write("Interest".PadRight(50));
            Console.WriteLine("Score".PadRight(25));
            for(i = 0; i < student.Length; i++)
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

            for(i = 0; i < student.Length; i++)
            {
                Console.Write($"{student[i].firstName}".PadRight(25));
                Console.Write($"{student[i].lastName}".PadRight(25));
                Console.Write($"{student[i].interest}".PadRight(50));
                Console.WriteLine($"{student[i].score}".PadRight(25));
            }
            sr.Close();
            return student;
        }

        public static void TaskTwo()
        {
            Console.WriteLine("This is task 2\n");
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
            Environment.Exit(0);
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Wrong input! Please try again!\n");
        }

        public static void TaskChoices()
        {
            Console.Clear();
            Console.WriteLine("1 - List all contestants");
            Console.WriteLine("2 - Locate a player");
            Console.WriteLine("3 - Generate 10 finalists");
            Console.WriteLine("4 - Select the player from the finalists");
            Console.WriteLine("5 - Play the game");
            Console.WriteLine("0 - Exit the game");
            Console.Write("Please Enter a task number: ");
            userChoice = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public static void Output(Student[] student)
        {
            TaskChoices();
            switch (userChoice)
            {
                case 1:
                    TaskOne(student);
                    break;
                case 2:
                    TaskTwo();
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
