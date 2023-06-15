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

        public static string GetInfo( string message)
        {
            Console.WriteLine("\n" + message);
            return Console.ReadLine();
        }

        public static Aircraft GetAircraft(List<Aircraft> aircrafts)
        {
            Console.WriteLine("Choose between these aircrafts: (write the number) \n");
            ConsoleColor.Blue();
            for (int i = 0; i < aircrafts.Count; i++)
            {
                Console.WriteLine($"{i + 1}:");
                Console.WriteLine(aircrafts[i]);
            }
            ConsoleColor.Reset();
            int n = int.Parse(Console.ReadLine());
            return aircrafts[n - 1];
        }
    }
}
