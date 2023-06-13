namespace Airline_Manager.Data
{
    public static class Database
    {
        // The connection string (put your info here)
        private static string connectionString = "Server=localhost;Database=airline_manager;Uid=root;Pwd=12345";

        // Method that returns a connection created with the string
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
