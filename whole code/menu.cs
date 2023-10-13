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
        // Hovedfunktionen i programmet
        public static void Main()
        {
            Console.WriteLine("Velkommen til Menu-appen!");

            while (true)
            {
                Console.WriteLine("1. Fodboldprogram");
                Console.WriteLine("2. Dansepræstationsprogram");
                Console.WriteLine("3. Log ind-program");
                Console.WriteLine("4. Afslut");
                Console.Write("Vælg venligst en mulighed: ");
                string choice = Console.ReadLine();

                Console.Clear(); // Ryd skærmen før visning af nyt indhold

                switch (choice)
                {
                    case "1":
                        FootballPasses();
                        break;

                    case "2":
                        DancePerformance dancePerformance = new DancePerformance();
                        RecordPerformance();
                        break;

                    case "3":
                        RunLoginProgram();
                        break;

                    case "4":
                        Console.WriteLine("Farvel!");
                        return;

                    default:
                        Console.WriteLine("Ugyldigt valg. Vælg venligst en gyldig mulighed.");
                        break;
                }
            }
        }
        
        // Funktion til håndtering af "Fodboldprogram"
        public static void FootballPasses()
        {
            int numberOfPasses = GetNumberOfPasses();
            string goalType = GetGoalType();

            string result = DetermineResult(numberOfPasses, goalType);

            Console.WriteLine(result);
        }

        // Funktion til at indhente antallet af pasninger
        private static int GetNumberOfPasses()
        {
            Console.WriteLine("Indtast antallet af pasninger:");
            int.TryParse(Console.ReadLine(), out int passes);
            return passes;
        }

        // Funktion til at indhente måltypen
        private static string GetGoalType()
        {
            Console.WriteLine("Indtast måltypen:");
            string goal = Console.ReadLine();
            return goal.ToLower();
        }

        // Funktion til at bestemme resultatet af pasningerne
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
                    return "Ugyldigt antal pasninger";
                }
            }
        }

        // Egenskaber for dansepræstationer
        public string DancerName { get; set; }
        public int PerformanceScore { get; set; }

        // Funktion til at registrere en dansepræstation
        public void RecordPerformance()
        {
            Console.WriteLine("Indtast dansearens navn:");
            string dancerName = Console.ReadLine();

            Console.WriteLine("Indtast præstationsscore:");
            int score = int.Parse(Console.ReadLine());

            DancerName = dancerName;
            PerformanceScore = score;

            Console.WriteLine("Præstationen er registreret med succes.");
        }

        // Operatoroverlægning for at kombinere dansepræstationer
        public static DancePerformance operator +(DancePerformance performance1, DancePerformance performance2)
        {
            DancePerformance duoPerformance = new DancePerformance();
            duoPerformance.PerformanceScore = performance1.PerformanceScore + performance2.PerformanceScore;
            duoPerformance.DancerName = $"{performance1.DancerName} og {performance2.DancerName}";
            return duoPerformance;
        }

        // Sti til brugerdatafil
        static string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\UserData.txt";

        // Funktion til at køre "Log ind-programmet"
        public static void RunLoginProgram()
        {
            Console.WriteLine("Velkommen til log ind-siden!");

            if (!File.Exists(userDataPath))
            {
                File.Create(userDataPath).Close();
                Console.WriteLine("Fil oprettet.");
            }
            // Test
            Thread.Sleep(1000);

            while (true)
            {
                Console.WriteLine("1. Log ind");
                Console.WriteLine("2. Opret ny bruger");
                Console.WriteLine("3. Afslut");
                Console.Write("Vælg venligst en mulighed: ");
                string choice = Console.ReadLine();

                Console.Clear(); // Ryd skærmen før visning af nyt indhold

                switch (choice)
                {
                    case "1":
                        Console.Write("Brugernavn: ");
                        string username = Console.ReadLine();
                        Console.Write("Adgangskode: ");
                        string password = Console.ReadLine();
                        if (Login(username, password))
                        {
                            Console.WriteLine("Log ind lykkedes!");

                        }
                        else
                        {
                            Console.WriteLine("Log ind mislykkedes. Ugyldige legitimationsoplysninger.");
                        }
                        break;

                    case "2":
                        Console.Write("Brugernavn: ");
                        string newUsername = Console.ReadLine();
                        Console.Write("Adgangskode: ");
                        string newPassword = Console.ReadLine();
                        if (CreateNewUser(newUsername, newPassword))
                        {
                            Console.WriteLine("Bruger oprettet med succes!");
                        }
                        else
                        {
                            Console.WriteLine("Brugeroprettelse mislykkedes. Ugyldigt adgangskodeformat.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Farvel!");
                        return;

                    default:
                        Console.WriteLine("Ugyldigt valg. Vælg venligst en gyldig mulighed.");
                        break;
                }
            }
        }

        // Funktion til at validere brugerens log ind-oplysninger
        static bool Login(string username, string password)
        {
            string[] userDataLines = File.ReadAllLines(userDataPath);

            foreach (string userDataLine in userDataLines)
            {
                string[] parts = userDataLine.Split(',');
                if (parts.Length == 2)
                {
                    string storedUsername = parts[0].Trim().Replace("Brugernavn: ", "");
                    string storedPassword = parts[1].Trim().Replace("Adgangskode: ", "");

                    if (storedUsername == username && storedPassword == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Funktion til at oprette en ny bruger
        static bool CreateNewUser(string username, string password)
        {
            string passwordPattern = @"^(?=\w{12,32}$)(?=[A-Za-z])((?=.*\d)|(?=.*[A-Z])|(?=.*[a-z]))[A-Za-z\d]*$";

            if (Regex.IsMatch(password, passwordPattern))
            {
                // Gem brugerdata i filen
                using (StreamWriter writer = File.AppendText(userDataPath))
                {
                    writer.WriteLine($"Brugernavn: {username}, Adgangskode: {password}");
                }
                return true;
            }
            return false;
        }
    }
}
