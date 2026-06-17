using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ConsoleApp2
{
    internal class Program
    {
        static string currentUser = "";
        static Random rng = new Random();

        static void Main(string[] args)
        {
            mainmenu();
        }

        static void mainmenu()
        {
            bool try2 = false;
            while (!try2)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("        Welcome to FILIPI-HULA         ");
                Console.WriteLine("=====================================");
                Console.WriteLine("[A].Login");
                Console.WriteLine("[B].Register");
                Console.WriteLine("[C].Exit");
                Console.Write("choose an option: ");
                string output = Console.ReadLine().ToUpper();
                switch (output)
                {
                    case "A":
                        login();
                        try2 = true;
                        break;
                    case "B":
                        regist();
                        try2 = true;
                        break;
                    case "C":
                        Console.WriteLine("Thank you for Playing!");
                        try2 = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option pls enter either A, B or C");
                        try2 = false;
                        break;
                }
            }
        }

        static void login()
        {
            Console.Write("Enter Username: ");
            string usern = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            string[] lines2 = File.ReadAllLines("login.txt");
            if (usern == "" || pass == "")
            {
                Console.Clear();
                Console.WriteLine("Username and Password cannot be empty");
                return;
            }
            string[] lines = File.ReadAllLines("login.txt");
            bool userExists = lines.Any(line => line.Split(',')[0] == usern);
            if (!userExists)
            {
                Console.Clear();
                Console.WriteLine("No accounts found. Please register first.");
                mainmenu();
                return;
            }
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 2 && parts[0] == usern && parts[1] == pass)
                {
                    Console.Clear();
                    currentUser = usern;
                    Console.WriteLine("Login successful! Welcome, " + usern + "!");
                    gamemenu();
                    return;
                }
            }
            Console.WriteLine("Invalid username or password. Try again.");
            mainmenu();
        }

        static void regist()
        {
            bool regis = false;
            Console.Clear();
            while (!regis)
            {
                Console.WriteLine("========Account Registration=====");
                Console.Write("Enter new username: ");
                string newuser = Console.ReadLine();
                Console.Write("Enter new password: ");
                string newpass = Console.ReadLine();
                Console.Write("Confirm Password: ");
                string confpass = Console.ReadLine();
                Console.WriteLine("=================================");
                if (newuser.Trim() == "" || newpass.Trim() == "" || confpass.Trim() == "")
                {
                    Console.Clear();
                    Console.WriteLine("Username and Password cannot be empty!");
                    continue;
                }
                if (confpass != newpass)
                {
                    Console.Clear();
                    Console.WriteLine("Password does not match!");
                    continue;
                }
                if (File.Exists("login.txt") && File.ReadAllText("login.txt").Contains(newuser + ","))
                {
                    Console.Clear();
                    Console.WriteLine("Account already exists!");
                    continue;
                }
                else
                {
                    string[] newaccount = { newuser + "," + confpass };
                    File.AppendAllLines("login.txt", newaccount);
                    Console.WriteLine("Registration Successfull!");
                    mainmenu();
                    break;
                }
            }
        }

        static void gamemenu()
        {
            bool try3 = false;
            while (!try3)
            {
                Console.WriteLine("Playing as: " + currentUser);
                Console.WriteLine("=====================================");
                Console.WriteLine("        Welcome to FILIPI-HULA         ");
                Console.WriteLine("=====================================");
                Console.WriteLine("Choose your gamemode");
                Console.WriteLine("[A]. Hangman");
                Console.WriteLine("[B]. Reading Comprehension");
                Console.WriteLine("[C]. Go back");
                Console.Write("Enter choice: ");
                string output2 = Console.ReadLine().ToUpper();
                switch (output2)
                {
                    case "A":
                        try3 = true;
                        break;
                    case "B":
                        Readingcomp();
                        try3 = true;
                        break;
                    case "C":
                        currentUser = "";
                        try3 = true;
                        Console.Clear();
                        mainmenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option pls enter either A, B or C");
                        try3 = false;
                        break;
                }
            }
        }
         static void DrawHangman(int stage) //HANGMAN ANIMATION
         {
             Console.WriteLine(" +---+");
             Console.WriteLine(" |   |");
             Console.WriteLine($" |   {(stage >= 1 ? "O" : " ")}");
             Console.WriteLine($" |  {(stage >= 3 ? "/" : " ")}{(stage >= 2 ? "|" : " ")}{(stage >= 4 ? "\\" : " ")}");
             Console.WriteLine($" |  {(stage >= 5 ? "/" : " ")} {(stage >= 6 ? "\\" : " ")}");
             Console.WriteLine(" |");
             Console.WriteLine("_|_");
        }
            static void HangmanMenu(string currentUser, int points)
         {
             bool exitchoice = false;
             for (int wrongGuesses = 1; wrongGuesses <= 6; wrongGuesses++)
             {
                 Console.Clear();
                 Console.Write("Playing as: " + currentUser); Console.Write("        Points: " + points);
                 Console.WriteLine("\n=====================================");
                 Console.WriteLine("        Hangman Game         ");
                 Console.WriteLine("=====================================");
        
                 DrawHangman(wrongGuesses);
                 Thread.Sleep(500);
             }
             Console.WriteLine("Choose your hangman mode:");
             Console.WriteLine("[1] Easy");
             Console.WriteLine("[2] Normal");
             Console.WriteLine("[3] Hard");
             Console.WriteLine("[0] Go Back to Main Menu");
             Console.Write("Enter choice: ");
             while (!exitchoice)
             { 
             string choice = Console.ReadLine();
        
                 switch (choice)
                 {
                     case "1":
                         exitchoice = true;
                         Console.Clear();
                         HangmanEasy();
                         break;
                     case "2":
                         exitchoice = true;
                         Console.Clear();
                         HangmanNormal();
                         break;
                     case "3":
                         exitchoice = true;
                         Console.Clear();
                         HangmanHard();
                         break;
                     case "0":
                         exitchoice = true;
                         Console.Clear();
                         //MAIN MENU HERE
                         break;
                     default:
                         Console.WriteLine(" [Please enter a correct option.]");
                         break;
                 }
             }
         }
         static void HangmanEasy()
         {
             Console.WriteLine("EASY MODE");
         }
         static void HangmanNormal()
         {
             Console.WriteLine("NORMAL MODE");
         }
         static void HangmanHard()
         {
             Console.WriteLine("HARD MODE");
         }

        // =================== PARSER ===================
        static List<(string Title, string Text, List<(string Prompt, string[] Choices, char Answer)> Questions)>
            LoadStories(string filePath)
        {
            var stories = new List<(string, string, List<(string, string[], char)>)>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return stories;
            }

            string[] lines = File.ReadAllLines(filePath);

            string currentTitle = "";
            List<string> storyLines = new List<string>();
            List<(string, string[], char)> currentQuestions = null;
            string currentPrompt = "";
            string[] currentChoices = new string[4];
            char currentAnswer = ' ';
            bool readingQuestions = false;
            bool inStory = false;

            foreach (string line in lines)
            {
                if (line.Trim() == "---STORY---")
                {
                    if (inStory)
                    {
                        if (currentPrompt != "")
                            currentQuestions.Add((currentPrompt, currentChoices, currentAnswer));
                        stories.Add((currentTitle, string.Join("\n", storyLines).Trim(), currentQuestions));
                    }
                    currentTitle = "";
                    storyLines = new List<string>();
                    currentQuestions = new List<(string, string[], char)>();
                    currentPrompt = "";
                    currentChoices = new string[4];
                    currentAnswer = ' ';
                    readingQuestions = false;
                    inStory = true;
                }
                else if (line.Trim() == "---QUESTIONS---")
                {
                    readingQuestions = true;
                }
                else if (line.StartsWith("Title:") && !readingQuestions)
                {
                    currentTitle = line.Substring(6).Trim();
                }
                else if (!readingQuestions && inStory && !line.StartsWith("Title:"))
                {
                    storyLines.Add(line);
                }
                else if (readingQuestions && line.StartsWith("Q:"))
                {
                    if (currentPrompt != "")
                        currentQuestions.Add((currentPrompt, currentChoices, currentAnswer));
                    currentPrompt = line.Substring(2).Trim();
                    currentChoices = new string[4];
                    currentAnswer = ' ';
                }
                else if (readingQuestions && line.Length > 1 && line[1] == '.')
                {
                    int index = line[0] - 'A';
                    if (index >= 0 && index < 4)
                        currentChoices[index] = line.Trim();
                }
                else if (readingQuestions && line.StartsWith("ANS:"))
                {
                    currentAnswer = line.Substring(4).Trim()[0];
                }
            }

            // Save last story
            if (inStory)
            {
                if (currentPrompt != "")
                    currentQuestions.Add((currentPrompt, currentChoices, currentAnswer));
                stories.Add((currentTitle, string.Join("\n", storyLines).Trim(), currentQuestions));
            }

            return stories;
        }

        // =================== DISPLAY ===================
        static void DisplayStory(string title, string text, List<(string Prompt, string[] Choices, char Answer)> questions)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║  " + title.PadRight(38) + "║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + text + "\n");
            Console.ResetColor();

            Console.WriteLine("Press any key to answer the questions...");
            Console.ReadKey();

            int score = 0;
            foreach (var q in questions)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + q.Prompt);
                Console.ResetColor();

                foreach (var choice in q.Choices)
                    Console.WriteLine(choice);

                Console.Write("\nYour answer: ");
                string ans = Console.ReadLine().ToUpper();

                if (ans.Length > 0 && ans[0] == q.Answer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong! The correct answer is {q.Answer}.");
                    Console.ResetColor();
                }
                Console.ReadKey();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nYou got {score}/{questions.Count} correct!");
            Console.ResetColor();
            Console.ReadKey();
        }

        // =================== LEVELS ===================
        static void easy()
        {
            var stories = LoadStories("easy1.txt");
            if (stories.Count == 0) return;
            var picked = stories[rng.Next(stories.Count)];
            DisplayStory(picked.Title, picked.Text, picked.Questions);
        }

        static void medium()
        {
            var stories = LoadStories("medium.txt");
            if (stories.Count == 0) return;
            var picked = stories[rng.Next(stories.Count)];
            DisplayStory(picked.Title, picked.Text, picked.Questions);
        }

        static void hard()
        {
            var stories = LoadStories("hard.txt");
            if (stories.Count == 0) return;
            var picked = stories[rng.Next(stories.Count)];
            DisplayStory(picked.Title, picked.Text, picked.Questions);
        }
    }
}
