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
            //initializing variables
            Student[] student = new Student[23];
            Student[] finalists = new Student[10];
            Student selectedPlayer = new Student();

            //call the text file
            LoadStudents(student);
            
            //runs the program while userChoice is not the exit code
            do
            {
               selectedPlayer = Output(student, finalists, selectedPlayer);
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
        public static void TaskOne(Student[] student, Student selectedPlayer)
        {
            Console.Write("First Name".PadRight(25));
            Console.Write("Last Name".PadRight(25));
            Console.Write("Interest".PadRight(50));
            Console.WriteLine("Score".PadRight(25));
            Console.WriteLine();

            //display students
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
                    default:
                        Console.WriteLine("Invalid input! Please try again!");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 0 || choice != 1);
            
        }

        public static void TaskThree(Student[] student, Student[] finalists)
        {
            Random rand = new Random();
            int[] arrayRandom = new int[finalists.Length];
            int randomGenerator;
            Console.WriteLine("Generating 10 finalists:");
            Console.WriteLine();
            Console.Write("First Name".PadRight(25));
            Console.Write("Last Name".PadRight(25));
            Console.Write("Interest".PadRight(50));
            Console.WriteLine("Score".PadRight(25));
            Console.WriteLine();
            for (int i = 0; i < finalists.Length; i++)
            {
                randomGenerator = rand.Next(0, student.Length);
                for(int k = 0; k < i; k++)
                {
                    while (arrayRandom[k] == randomGenerator)
                    {
                        randomGenerator = rand.Next(1, 23);
                        k = 0;
                    }
                }
                arrayRandom[i] = randomGenerator;
                finalists[i] = student[randomGenerator];
            }
            for(int i = 0; i < finalists.Length; i++)
            {
                Console.Write($"{finalists[i].firstName}".PadRight(25));
                Console.Write($"{finalists[i].lastName}".PadRight(25));
                Console.Write($"{finalists[i].interest}".PadRight(50));
                Console.WriteLine($"{finalists[i].score}".PadRight(25));
            }
        }

        public static Student TaskFour(Student[] finalists, Student selectedPlayer)
        {
            Random rand = new Random();
            int randomGenerator;
            randomGenerator = rand.Next(0, finalists.Length); 
            Console.WriteLine("Congratulations! You have selected");

            selectedPlayer = finalists[randomGenerator];
            Console.WriteLine($"{selectedPlayer.firstName} {selectedPlayer.lastName} {selectedPlayer.score}");
            Console.WriteLine("Press enter to go back.");
            return selectedPlayer;
        }

        public static Student TaskFive(Student selectedPlayer)
        {
            //initialize variables
            Random rand = new Random();
            string[] wordToGuessArray = { "characterize","programming", "mathematics", "computerized", "electricity"};
            string wordToGuess = "", userInput = "";
            string updatedWord = "";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] alphabetArray = alphabet.ToCharArray();
            string[] guessedLetters = new string[26];
            bool wordGuess = false, letterGuess = false, letterFound = false;
            int wordGenerator = rand.Next(0, wordToGuessArray.Length);
            wordToGuess = wordToGuessArray[wordGenerator];
            int randomGenerator, letterOccurrences = 0, guessedLetterCount = 0;
            const double VOWEL_REDUCE = -250;
            double[] wheelOfFortune = { 300, 400, 500, 600, 750, 800, 950, 1000, 1100, 1250, 1500, 1750, 2000, 2150, 2250, 2450, 2750, 3000, 3500, 4000, 4500 ,5000, -2000, -3000 };
            double spinValue = 0;
            
            //initial start
            Console.WriteLine("Play the game!\n");

            //add blanks
            char[] wordArray = new char[wordToGuess.Length];
            for (int i = 0; i < wordArray.Length; i++)
            {
                wordArray[i] = '_';
            }

            do
            {
                Console.Clear();
                Console.Write("Letters: ");
                for (int i = 0; i < alphabetArray.Length; i++)
                {
                    Console.Write($"{alphabetArray[i]} ");
                }
                Console.WriteLine();
                letterGuess = false;
                letterFound = false;
                letterOccurrences = 0;
                randomGenerator = rand.Next(0, wheelOfFortune.Length);


                //display blanks, name and score
                Console.WriteLine(wordArray);
                Console.WriteLine($"{selectedPlayer.firstName} {selectedPlayer.lastName} {selectedPlayer.score}");
                Console.WriteLine($"The wheel landed on: {wheelOfFortune[randomGenerator]:C2}");

                //userinput loop
                while (letterGuess == false)
                {
                    Console.Write("Guess a letter: ");
                    userInput = Console.ReadLine();
                    userInput = userInput.ToLower();
                    userInput = userInput.Trim();
                    if (userInput.Length == 1 && char.IsLetter(userInput[0]))
                    {
                        bool alreadyGuessed = false;

                        for (int i = 0; i < guessedLetterCount; i++)
                        {
                            if (userInput == guessedLetters[i])
                            {
                                alreadyGuessed = true;
                            }
                        }

                        if (alreadyGuessed == true)
                        {
                            Console.WriteLine("You already guessed that letter!");
                        }
                        else
                        {
                            guessedLetters[guessedLetterCount] = userInput;
                            guessedLetterCount++;
                            letterGuess = true;
                            Console.WriteLine($"You guessed: {userInput}");
                            alphabetArray[userInput[0] - 'a'] = '_';
                        }
                    }

                }

                //guessed letter loop
                for (int i = 0; i < wordArray.Length; i++)
                {
                    if (wordToGuess[i] == userInput[0])
                    {
                        wordArray[i] = userInput[0];
                        letterFound = true;
                        letterOccurrences++;
                    }
                }

                spinValue = wheelOfFortune[randomGenerator];

                //display letter of occurences
                if (wheelOfFortune[randomGenerator] < 0)
                {
                    spinValue = wheelOfFortune[randomGenerator];
                    Console.WriteLine($"You lost {spinValue}!");
                }
                else if (userInput[0] == 'a' ||
                    userInput[0] == 'e' ||
                    userInput[0] == 'i' ||
                    userInput[0] == 'o' ||
                    userInput[0] == 'u')
                {
                    spinValue = VOWEL_REDUCE;
                }
                else if (letterFound == true)
                {
                    spinValue = letterOccurrences * wheelOfFortune[randomGenerator];
                    Console.WriteLine($"Correct guess! The letter appeared {letterOccurrences} time(s).");
                    Console.WriteLine($"You gained {spinValue}");
                }
                else
                {
                    spinValue = 0;
                    Console.WriteLine("That letter is not in the word!");
                }
                updatedWord = new string(wordArray);
                Console.WriteLine($"Round score change: {spinValue}");
                selectedPlayer.score += (int)spinValue;

                if(updatedWord == wordToGuess)
                {
                    wordGuess = true;
                    Console.WriteLine("Congratulations! You completed the word!");
                }
                Console.ReadLine();
            } while (wordGuess == false);
            return selectedPlayer;
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

        public static void DisplayTopFive(Student[] student)
        {
            for(int i = 0; i < student.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (student[i].score > student[j].score)
                    {
                        Student temp = student[i];
                        student[i] = student[j];
                        student[j] = temp;
                    }
                }
            }
            Console.Write("Ranking".PadRight(25));
            Console.Write("First Name".PadRight(25));
            Console.Write("Last Name".PadRight(25));
            Console.Write("Interest".PadRight(50));
            Console.WriteLine("Score".PadRight(25));
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{i + 1}.".PadRight(25));
                Console.Write($"{student[i].firstName}".PadRight(25));
                Console.Write($"{student[i].lastName}".PadRight(25));
                Console.Write($"{student[i].interest}".PadRight(50));
                Console.WriteLine($"{student[i].score}".PadRight(25));
            }
        }

        public static void UpdateScore(Student[]student, Student selectedPlayer)
        {
            sw = new StreamWriter(@"wheelOfFortune.txt");

            //update score
            for(int i = 0; i < student.Length; i++)
            {
                if (student[i].firstName == selectedPlayer.firstName && student[i].lastName == selectedPlayer.lastName)
                {
                    student[i].score = selectedPlayer.score;
                }
            }
            
            //write into the streamwriter
            for(int i = 0; i < student.Length; i++)
            {
                sw.WriteLine(student[i].firstName);
                sw.WriteLine(student[i].lastName);
                sw.WriteLine(student[i].interest);
                sw.WriteLine(student[i].score);
            }
            sw.Close();
        }

        public static Student Output(Student[] student, Student[] finalists, Student selectedPlayer)
        {
            TaskChoices();
            switch (userChoice)
            {
                case 1:
                    TaskOne(student, selectedPlayer);
                    Console.WriteLine();
                    break;
                case 2:
                    TaskTwo(student);
                    break;
                case 3:
                    TaskThree(student, finalists);
                    break;
                case 4:
                    selectedPlayer = TaskFour(finalists, selectedPlayer);
                    break;
                case 5:
                    selectedPlayer = TaskFive(selectedPlayer);
                    //update score method
                    UpdateScore(student, selectedPlayer);
                    DisplayTopFive(student);
                    break;
                case 0:
                    TaskZero();
                    break;
                default:
                    ErrorMessage();
                    break;
            }
            Console.ReadLine();
            return selectedPlayer;
        }
    }
}
