namespace Airline_Manager.Data
{
    // This file creates the needed tables in the database
    // RUN IT ONLY ONCE, IT DELETES THE OLD TABLES THEREFORE THE INFO
    public static class DatabaseSetup
    {
        // Dropping all tables that can have the names
        private static string DropTables()
        {
            MySqlConnection conn = Database.GetConnection();

            // Removing the checks so there are no errors while deleting
            string query_remove_checks = "SET FOREIGN_KEY_CHECKS = 0;";

            // Droping the tables `user_info, hubs, routes, aircrafts`
            string query_delete = "DROP TABLES IF EXISTS user_info, hubs, routes, aircrafts;";

            // Adding the checks after the deleting has been done
            string query_add_checks = "SET FOREIGN_KEY_CHECKS = 1;";

            // Creating the commands
            MySqlCommand cmd_remove_checks = new MySqlCommand(query_remove_checks, conn);

            MySqlCommand cmd_delete = new MySqlCommand(query_delete, conn);

            MySqlCommand cmd_add_checks = new MySqlCommand(query_add_checks, conn);
            
            // Openning the connection
            conn.Open();
            
            // Running all the commands
            cmd_remove_checks.ExecuteNonQuery();
            cmd_delete.ExecuteNonQuery();
            cmd_add_checks.ExecuteNonQuery();

            // Closing the connection
            conn.Close();

            return "Tables deleted successfully!";
        }

        // Creating all the needed tables 
        private static string CreateTables()
        {
            MySqlConnection conn = Database.GetConnection();

            // Creating the query for any table needed
            string query_hubs = "CREATE TABLE IF NOT EXISTS hubs ( name VARCHAR(225) PRIMARY KEY );";
            string query_user = "CREATE TABLE IF NOT EXISTS user_info ( company_name VARCHAR(50) PRIMARY KEY, balance DOUBLE(10,2) NOT NULL DEFAULT 0, fuel INT NOT NULL DEFAULT 0, main_hub VARCHAR(225) NOT NULL, CONSTRAINT fk_hubs FOREIGN KEY (main_hub) REFERENCES hubs(name) );";
            string query_routes = "CREATE TABLE IF NOT EXISTS routes ( name VARCHAR(225) PRIMARY KEY, `from` VARCHAR(225) NOT NULL, `to` VARCHAR(225) NOT NULL, km INT NOT NULL);";
            string query_aircrafts = "CREATE TABLE IF NOT EXISTS aircrafts ( id INT AUTO_INCREMENT PRIMARY KEY, model VARCHAR(255) NOT NULL, route VARCHAR(225) NOT NULL, wear INT NOT NULL DEFAULT 0, airborne BOOLEAN NOT NULL DEFAULT FALSE, landing DATETIME NULL, CONSTRAINT fk_routes FOREIGN KEY (route) REFERENCES routes (name) );";

            // Creating the commands corresponding to the query
            MySqlCommand cmd_hubs = new MySqlCommand(query_hubs, conn);
            MySqlCommand cmd_user = new MySqlCommand(query_user, conn);
            MySqlCommand cmd_routes = new MySqlCommand(query_routes, conn);
            MySqlCommand cmd_aircrafts = new MySqlCommand(query_aircrafts, conn);

            // Opening the connection
            conn.Open();

            // Running the commands
            cmd_hubs.ExecuteNonQuery();
            cmd_user.ExecuteNonQuery();
            cmd_routes.ExecuteNonQuery();
            cmd_aircrafts.ExecuteNonQuery();
            
            // Closing the connection
            conn.Close();

            return "Tables created successfully!";
        }

        // The method that should be used to setup the game
        public static string SetupGame()
        {
            // Runs the previous methods
            string delete = DropTables();
            string create = CreateTables();

            string result = delete + "\n" + create + "\n";

            return result;
        }
    }
}
