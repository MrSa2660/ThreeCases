using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class Football
    {
        
        public static string FootballPasses()
        {
            


            int.TryParse(Console.ReadLine(), out int passes);
            string goal = Console.ReadLine();

            // Logic here

            if (goal.ToLower() == "mål")
            {
                return "Olé olé olé";
            }
            else
            {
                if (passes == 0) return "Shh";
                else if (passes >= 1 && passes < 10)
                {
                    string huh = "";
                    for (int i = 0; i < passes; i++)
                    {
                        if (i == passes - 1) huh = huh + "Huh!";
                        else huh = huh + "Huh! ";
                    }
                    return huh;
                }
                else if (passes >= 10) return "High Five - Jubel!!!";
                else return "Invalid pass amount";
            }
        }
        
    }
}