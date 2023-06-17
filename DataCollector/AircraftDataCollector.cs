namespace Airline_Manager.DataCollector
{
    // Class to get aircraft data from a file and turn it into a model
    public static class AircraftDataCollector
    {
        // The main file path
        private static string file = @"TextFiles\AirCraftDatabase.txt";
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        private static string filePath = Path.Combine(projectDirectory, file);

        // A method to get all the aircrafts from the file
        public static List<Aircraft> GetAllAircrafts()
        {
            // Filling an array with all the lines (aircrafts)
            string[] lines = File.ReadAllLines(filePath);
            
            // Creating the list which will be returned
            List<Aircraft> aircrafts = new List<Aircraft>();

            // Looping through all the lines (aircrafts)
            foreach (string line in lines)
            {
                // Getting all the information for an aircraft
                string[] infoArray = line.Split(";");

                // Assigning the values
                string man = infoArray[0];
                string mod = infoArray[1];
                int pax = int.Parse(infoArray[2]);
                int fuel = int.Parse(infoArray[3]);
                int speed = int.Parse(infoArray[4]);
                int range = int.Parse(infoArray[5]);
                int cost = int.Parse(infoArray[6]);

                // Creating a new model with the values 
                Aircraft aircraft = new(man, mod, pax, fuel, speed, range, cost, 0);

                // Adding the new model to the list
                aircrafts.Add(aircraft);
            }
            // Returning the list with aircraft models
            return aircrafts;
        } 
    }
}
