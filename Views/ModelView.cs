using Airline_Manager.Models;

namespace Airline_Manager.Views
{
    public static class ModelView
    {
        public static List<string> GetInformation()
        {
            Console.WriteLine("Name of your company:");
            string company_name = Console.ReadLine();
            Console.WriteLine(" \nName or ICAO code of the main airport:");
            string airport = Console.ReadLine();

            return new List<string>() { company_name, airport };
        }

        public static void SendMessage(string message)
        {
            ConsoleColor.Green();
            Console.WriteLine("\n" + message);
            ConsoleColor.Reset();
        }

        public static string GetInfo(string message)
        {
            Console.WriteLine("\n" + message);
            return Console.ReadLine();
        }

        public static Aircraft GetAircraft(List<Aircraft> aircrafts)
        {
            Console.WriteLine("Choose between these aircrafts: (write the number) \n");

            for (int i = 0; i < aircrafts.Count; i++)
            {
                ConsoleColor.Yellow();
                Console.WriteLine($"{i + 1}:");
                ConsoleColor.Blue();
                Console.WriteLine(aircrafts[i]);
            }
            ConsoleColor.Reset();
            int n = int.Parse(Console.ReadLine());
            while (n <= 0 || n > aircrafts.Count)
            {
                ErrorView.ThrowError($"\nInvalid number, please choose a number between 1 and {aircrafts.Count}!");
                n = int.Parse(Console.ReadLine());
            }
            return aircrafts[n - 1];
        }

        public static void DisplayAllAircrafts(List<Aircraft> aircrafts)
        {
            Console.WriteLine();
            int max = 10;
            foreach (Aircraft aircraft in aircrafts)
            {
                int n = aircraft.Model.Length;
                if (n > max)
                    max = n;
                n = aircraft.Route.Name.Length;
                if (n > max)
                    max = n;
            }
            max += 2;
            PrintWord(" Model", max);
            PrintCol("|");
            PrintWord(" Route name", max);
            PrintCol("|");
            PrintWord(" Status", max);
            PrintCol("|");
            PrintWord(" Landing in", max);

            NewRow(max);

            foreach (Aircraft aircraft in aircrafts)
            {
                PrintAircraft(aircraft, max);
            }
        }

        private static void PrintCol(string n)
        {
            ConsoleColor.Blue();
            Console.Write(n);
            ConsoleColor.Reset();
        }

        private static void PrintWord(string word, int max)
        {
            int a = word.Length;
            int b = max - a;
            string result = word + new string(' ', b);
            Console.Write(result);
        }

        private static void NewRow(int max)
        {
            Console.WriteLine();
            ConsoleColor.Blue();
            Console.Write(new string('-', max));
            PrintCol("|");
            ConsoleColor.Blue();
            Console.Write(new string('-', max));
            PrintCol("|");
            ConsoleColor.Blue();
            Console.Write(new string('-', max));
            PrintCol("|");
            ConsoleColor.Blue();
            Console.WriteLine(new string('-', max));
            ConsoleColor.Reset();
        }

        private static void PrintAircraft(Aircraft aircraft, int max)
        {
            PrintWord(" " + aircraft.Model, max);
            PrintCol("|");
            PrintWord(" " + aircraft.Route.Name, max);
            PrintCol("|");
            if (aircraft.Airborne)
            {
                PrintWord(" Flying", max);
                PrintCol("|");
                ConsoleColor.Green();
                PrintWord(" " + TimeChecker.TimeLeft(aircraft), max);
                ConsoleColor.Reset();
            }
            else
            {
                PrintWord(" Landed", max);
                PrintCol("|");
                ConsoleColor.Red();
                PrintWord(" N/A", max);
                ConsoleColor.Reset();
            }

            NewRow(max);
        }
    }
}
