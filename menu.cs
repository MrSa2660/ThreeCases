using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeCases;

namespace ThreeCases
{
    internal class menu
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Menu App!");

            while (true)
            {
                Console.WriteLine("1. Football Program");
                Console.WriteLine("2. Dance Performance Program");
                Console.WriteLine("3. Login Program");
                Console.WriteLine("4. Exit");
                Console.Write("Please choose an option: ");
                string choice = Console.ReadLine();

                Console.Clear(); // Clear the screen before displaying new content

                switch (choice)
                {
                    case "1":
                        Football.FootballPasses();
                        break;

                    case "2":
                        DancePerformance dancePerformance = new DancePerformance();
                        dancePerformance.RecordPerformance();
                        break;

                    case "3":
                        PasswordProgram.RunLoginProgram();
                        break;

                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
