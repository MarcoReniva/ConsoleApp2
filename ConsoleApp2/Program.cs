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
        static void Main(string[] args)
        {
            mainmenu();

        }
        static void mainmenu()
        {
            bool try2 = false;
            while(!try2)
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
                        try2=true;
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
            if (!lines2.Contains(usern))
            {
                Console.Clear();
                Console.WriteLine("No accounts found. Please register first.");
                mainmenu();
                return;
            }
            string[] lines = File.ReadAllLines("login.txt");
            for (int i = 0; i + 1 < lines.Length; i += 2)
            {

                if (lines[i] == usern && lines[i + 1] == pass)
                {
                    Console.Clear();
                    currentUser = usern;
                    Console.WriteLine("Login successful! Welcome, " + usern + "!");
                    gamemenu();
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

    }
}
