namespace Airline_Manager.DataCollector
{
    public static class GameSaver
    {
        private static string file = @"TextFiles\CurrentGame.txt";
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        private static string filePath = Path.Combine(projectDirectory, file);

        public static bool CheckGame()
        {
            string line = File.ReadAllLines(filePath)[0];

            if (line == "yes")
                return true;
            return false;
        }

        public static void SaveGame()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("no");
            }
        }
    }

}
