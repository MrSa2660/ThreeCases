using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCases
{
    internal class DancePerformance
    {
        public string DancerName { get; set; }
        public int PerformanceScore { get; set; }

        public void RecordPerformance()
        {
            Console.WriteLine("Please enter the dancer's name:");
            string dancerName = Console.ReadLine();

            Console.WriteLine("Please enter the performance score:");
            int score = int.Parse(Console.ReadLine());

            DancerName = dancerName;
            PerformanceScore = score;

            Console.WriteLine("Performance recorded successfully.");
        }

        public static DancePerformance operator +(DancePerformance performance1, DancePerformance performance2)
        {
            DancePerformance duoPerformance = new DancePerformance();
            duoPerformance.PerformanceScore = performance1.PerformanceScore + performance2.PerformanceScore;
            duoPerformance.DancerName = $"{performance1.DancerName} and {performance2.DancerName}";
            return duoPerformance;
        }
    }
}
