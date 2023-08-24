using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class Football
    {
        public static void FootballPasses()
        {
            int numberOfPasses = GetNumberOfPasses();
            string goalType = GetGoalType();

            string result = DetermineResult(numberOfPasses, goalType);

            Console.WriteLine(result);
        }

        private static int GetNumberOfPasses()
        {
            Console.WriteLine("Enter the number of passes:");
            int.TryParse(Console.ReadLine(), out int passes);
            return passes;
        }

        private static string GetGoalType()
        {
            Console.WriteLine("Enter the goal type:");
            string goal = Console.ReadLine();
            return goal.ToLower();
        }

        private static string DetermineResult(int passes, string goal)
        {
            if (goal == "mål")
            {
                return "Olé olé olé";
            }
            else
            {
                if (passes == 0)
                {
                    return "Shh";
                }
                else if (passes >= 1 && passes < 10)
                {
                    string huh = "";
                    for (int i = 0; i < passes; i++)
                    {
                        if (i == passes - 1)
                        {
                            huh = huh + "Huh!";
                        }
                        else
                        {
                            huh = huh + "Huh! ";
                        }
                    }
                    return huh;
                }
                else if (passes >= 10)
                {
                    return "High Five - Jubel!!!";
                }
                else
                {
                    return "Invalid pass amount";
                }
            }
        }
    }
}
