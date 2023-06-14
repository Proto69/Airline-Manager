namespace Airline_Manager.Data
{
    public static class RouteData
    {
        public static string AddRoute(Route route)
        {
            MySqlConnection conn = Database.GetConnection();

            string query_add_route = "INSERT INTO routes (`from`, `to`, km) VALUES (@from, @to, @km, @daily_demand);";
            MySqlCommand cmd_add_route = new MySqlCommand(query_add_route, conn);

            cmd_add_route.Parameters.AddWithValue("@from", route.From);
            cmd_add_route.Parameters.AddWithValue("@to", route.To);
            cmd_add_route.Parameters.AddWithValue("@km", route.Km);

            conn.Open();
            cmd_add_route.ExecuteNonQuery();
            conn.Close();

            return "Route added successfully!";
        }
    }
}
