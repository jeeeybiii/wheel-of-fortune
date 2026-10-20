namespace WheelOfFortune
{
    internal class Program
    {
        private static int userChoice;
        public static void Main(string[] args)
        {
            //Skeleton Program
            do
            {
                Output();
            } while (userChoice != 0);
        }

        public static void TaskOne()
        {
            Console.WriteLine("This is task 1\n");
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
            Console.WriteLine("Task 1 - 1");
            Console.WriteLine("Task 2 - 2");
            Console.WriteLine("Task 3 - 3");
            Console.WriteLine("Task 4 - 4");
            Console.WriteLine("Exit menu system - 0");
            Console.Write("Please Enter a task number: ");
            userChoice = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public static void Output()
        {
            TaskChoices();
            switch (userChoice)
            {
                case 1:
                    TaskOne();
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
                case 0:
                    TaskZero();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
        }
    }
}
