using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
            
        }
        static void menu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("        Welcome to FILIPI-HULA         ");
            Console.WriteLine("=====================================");
            Console.WriteLine("[1].Login");
            Console.WriteLine("[2].Register");
            Console.WriteLine("[3].Exit");
            Console.Write("choose an option: ");
            string output = Console.ReadLine();
            switch(output)
            {
                case "1":
                    login();
                    break;
                case "2":
                    regist();
                    break;
                case "3":
                    Console.WriteLine("Thank you for Playing!");
                    break;
            }
        }
        static void login()
        {
            Console.Write("Enter Username: ");
            string usern = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            string[] lines2 = File.ReadAllLines("login.txt");
            if (!lines2.Contains(usern))
            {
                Console.WriteLine("No accounts found. Please register first.");
                menu();
                return;
            }

            string[] lines = File.ReadAllLines("login.txt");

            for (int i = 0; i + 1 < lines.Length; i += 2)
            {
                if (lines[i] == usern && lines[i + 1] == pass)
                {
                    Console.WriteLine("Login successful! Welcome, " + usern + "!");
                    return;
                }
            }

            Console.WriteLine("Invalid username or password. Try again.");
            menu();
        }
        static void regist()
        {
            Console.Write("Enter new username: ");
            string newuser = Console.ReadLine();
            Console.WriteLine("Enter new password");
            string newpass = Console.ReadLine();
            string[]newaccount = {newuser, newpass };
            File.AppendAllLines("login.txt", newaccount);
        }
    }
}
