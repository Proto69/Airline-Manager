namespace Airline_Manager.Views
{
    public static class ModelView
    {
        public static List<string> GetInformation()
        {
            Console.WriteLine("Name of your company: ");
            string company_name = Console.ReadLine();
            Console.WriteLine("Name or ICAO code of the main airport: ");
            string airport = Console.ReadLine();

            return new List<string>() { company_name, airport };
        }

        public static string GetAirportName()
        {
            Console.WriteLine("Name or ICAO code of the airport: ");
            string airport = Console.ReadLine();

            return airport;
        }
    }
}
