using System;
using System.IO;

class Program
{
    static readonly string OutputFolder = "Orders"; // Specify the output folder

    static void Main()
    {
        Console.WriteLine("Velkommen til biografen!");

        while (true)
        {
            Console.WriteLine("Vælg en handling:");
            Console.WriteLine("1. Køb billetter");
            Console.WriteLine("2. Se gamle køb fra filer");
            Console.WriteLine("3. Afslut");
            Console.Write("Indtast dit valg (1/2/3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BuyTickets();
                    break;
                case "2":
                    ReadOldPurchases();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                    break;
            }
        }
    }

    static void BuyTickets()
    {
        Console.Write("Indtast beløb: ");
        double availableFunds = Convert.ToDouble(Console.ReadLine());

        int maxTickets = (int)(availableFunds / 120);
        Console.WriteLine($"Du kan købe op til {maxTickets} billetter.");

        Console.Write("Indtast antal billetter: ");
        int numTickets = Convert.ToInt32(Console.ReadLine());

        if (numTickets * 120 > availableFunds)
        {
            Console.WriteLine("Beløb overskredet. Prøv igen.");
        }
        else
        {
            double totalPrice = numTickets * 120;
            double remainingFunds = availableFunds - totalPrice;

            Console.WriteLine($"Pris: {totalPrice} kr");
            Console.WriteLine($"Resterende penge: {remainingFunds} kr");
            Console.WriteLine($"Antal billetter købt: {numTickets}");

            int orderNumber = GetNextOrderNumber();
            string fileName = Path.Combine(OutputFolder, $"ordre_{orderNumber}.txt"); // Specify the output folder

            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine($"Pris: {totalPrice} kr");
                sw.WriteLine($"Resterende penge: {remainingFunds} kr");
                sw.WriteLine($"Antal billetter købt: {numTickets}");
            }

            Console.WriteLine($"Ordre gemt som {fileName}");
            Console.WriteLine($"Filen blev gemt i følgende mappe: {Path.GetFullPath(fileName)}"); // Display the file path
        }
    }

    static void ReadOldPurchases()
    {
        Console.WriteLine("Tidligere køb:");

        int orderNumber = 1;

        while (File.Exists(Path.Combine(OutputFolder, $"ordre_{orderNumber}.txt"))) // Specify the output folder
        {
            string fileName = Path.Combine(OutputFolder, $"ordre_{orderNumber}.txt"); // Specify the output folder

            using (StreamReader sr = File.OpenText(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine(); // Separation between orders
            orderNumber++;
        }

        if (orderNumber == 1)
        {
            Console.WriteLine("Ingen tidligere køb fundet.");
        }
    }

    static int GetNextOrderNumber()
    {
        int orderNumber = 1;
        while (File.Exists(Path.Combine(OutputFolder, $"ordre_{orderNumber}.txt"))) // Specify the output folder
        {
            orderNumber++;
        }
        return orderNumber;
    }
}
