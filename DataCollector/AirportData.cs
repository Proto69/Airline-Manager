namespace Airline_Manager.DataCollector
{
    public static class AirportData
    {
        private static string filePath = "C:\\Users\\mnogo\\source\\repos\\Airline Manager\\TextFiles\\GlobalAirportDatabase.txt";

        public static string GetAirport(string keyword)
        {
            string[] lines = File.ReadAllLines(filePath);

            string result = "";

            foreach (string line in lines)
            {
                if (line.Contains(keyword.ToUpper()))
                {
                    string[] infoArray = line.Split(':');
                    string code = infoArray[1];
                    string city = infoArray[2];
                    string country = infoArray[4];
                    string n = infoArray[14];
                    string e = infoArray[15];
                    result = code + ";" + city + ";" + country + ";" + n + ";" + e;
                    break;
                }
            }
            return result;
        }
    }
}
