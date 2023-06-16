namespace Airline_Manager.DataCollector
{
    // Class to get airport data from a file and turn it into a model
    public static class AirportDataCollector
    {
        // Address of the file
        private static string file = @"TextFiles\GlobalAirportDatabase.txt"; 
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        private static string filePath = Path.Combine(projectDirectory, file);

        // Method to get a specific airport with a keyword
        public static Airport GetAirport(string keyword)
        {
            // Filling an array with all the airports from the file
            string[] lines = File.ReadAllLines(filePath);

            // Going through every line (airport)
            foreach (string line in lines)
            {
                // Checking if the line contains the keyword
                if (line.Contains(keyword.ToUpper()))
                {
                    // Filling an array with the info of the airport which is separated by `;`
                    string[] infoArray = line.Split(':');
                    
                    // Extracting the different informations
                    string code = infoArray[1];
                    string city = infoArray[3];
                    string country = infoArray[4];
                    double n = double.Parse(infoArray[14]);
                    double e = double.Parse(infoArray[15]);

                    // Creating a model with the previously extracted information
                    Airport airport = new(city, country, code, n, e);
                    
                    // Returning the previously created model
                    return airport;
                }
            }
            // If the airport is not found, the method returns null
            // Should be handled in the used context
            return null;
        }
    }
}
