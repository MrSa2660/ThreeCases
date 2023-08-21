using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class Fodbold
    {
        static void Main(string[] args)
        {

            
            string goal = Console.ReadLine().ToLower();


            Console.WriteLine("Hvor mange afleveringer");
            int.TryParse(Console.ReadLine(), out int Passes);


            if (goal == "mål")
            {
                Console.WriteLine("Olé olé olé");
            } else if (Passes >= 1 && Passes <= 10)
            {

            }
        }
    }
}
