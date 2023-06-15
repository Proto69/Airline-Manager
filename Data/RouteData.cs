namespace Airline_Manager.Data
{
    public static class RouteData
    {
        public static string AddRoute(Route route)
        {
            MySqlConnection conn = Database.GetConnection();

            string query_add_route = "INSERT INTO routes (name, `from`, `to`, km) VALUES (@name, @from, @to, @km);";
            MySqlCommand cmd_add_route = new MySqlCommand(query_add_route, conn);

            cmd_add_route.Parameters.AddWithValue("@from", route.From);
            cmd_add_route.Parameters.AddWithValue("@to", route.To);
            cmd_add_route.Parameters.AddWithValue("@km", route.Km);
            cmd_add_route.Parameters.AddWithValue("@name", route.Name);

            conn.Open();
            cmd_add_route.ExecuteNonQuery();
            conn.Close();

            return "Route added successfully!";
        }
    }
}
