using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using ThreeCases;
using System.Text.RegularExpressions;


namespace ThreeCases
{
    internal class password
    {
        static string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\UserData.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Login Page!");

            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create New User");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option: ");
                string choice = Console.ReadLine();

                Console.Clear(); // Clear the screen before displaying new content

                switch (choice)
                {
                    case "1":
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        if (Login(username, password))
                        {
                            Console.WriteLine("Login successful!");
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Invalid credentials.");
                        }
                        break;

                    case "2":
                        Console.Write("Username: ");
                        string newUsername = Console.ReadLine();
                        Console.Write("Password: ");
                        string newPassword = Console.ReadLine();
                        if (CreateNewUser(newUsername, newPassword))
                        {
                            Console.WriteLine("User created successfully!");
                        }
                        else
                        {
                            Console.WriteLine("User creation failed. Invalid password format.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static bool Login(string username, string password)
        {
            string[] userDataLines = File.ReadAllLines(userDataPath);

            foreach (string userDataLine in userDataLines)
            {
                string[] parts = userDataLine.Split(',');
                if (parts.Length == 2)
                {
                    string storedUsername = parts[0].Trim().Replace("Username: ", "");
                    string storedPassword = parts[1].Trim().Replace("Password: ", "");

                    if (storedUsername == username && storedPassword == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        static bool CreateNewUser(string username, string password)
        {
            string passwordPattern = @"^(?=\w{12,32}$)(?=[A-Za-z])((?=.*\d)|(?=.*[A-Z])|(?=.*[a-z]))[A-Za-z\d]*$";

            if (Regex.IsMatch(password, passwordPattern))
            {
                // Save user data to file
                using (StreamWriter writer = File.AppendText(userDataPath))
                {
                    writer.WriteLine($"Username: {username}, Password: {password}");
                }
                return true;
            }
            return false;
        }
    }
}