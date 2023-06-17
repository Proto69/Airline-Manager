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
            int max = 0;
            foreach (Aircraft aircraft in aircrafts)
            {
                int n = aircraft.Model.Length + aircraft.Route.Name.Length;
                if (n > max)
                    max = n;
            }
        }
    }
}
