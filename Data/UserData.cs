namespace Airline_Manager.Data
{
    public static class UserData
    {
        public static string CreateUser(string name, string main_hub)
        {
            MySqlConnection conn = Database.GetConnection();

            string query_add_hub = "INSERT INTO hubs (name) VALUES (@main_hub);";
            string query_add_user = "INSERT INTO user_info (company_name, main_hub) VALUES (@name, @main_hub);";

            MySqlCommand cmd_add_hub = new MySqlCommand(query_add_hub, conn);
            MySqlCommand cmd_add_user = new MySqlCommand(query_add_user, conn);

            cmd_add_hub.Parameters.AddWithValue("@main_hub", main_hub);
            cmd_add_user.Parameters.AddWithValue("@name", name);
            cmd_add_user.Parameters.AddWithValue("@main_hub", main_hub);

            conn.Open();
            cmd_add_hub.ExecuteNonQuery();
            cmd_add_user.ExecuteNonQuery();
            conn.Close();

            return "Successfully saved the user! \n";
        }

        public static User GetUser()
        {
            User user = new();

            MySqlConnection conn = Database.GetConnection();

            string query = "SELECT * FROM user_info";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                user.Name = reader["company_name"].ToString();
                user.Fuel = int.Parse(reader["fuel"].ToString());
                user.Balance = int.Parse(reader["balance"].ToString());
                user.MainHub = reader["main_hub"].ToString();
            }

            return user;
        }
    }
}
