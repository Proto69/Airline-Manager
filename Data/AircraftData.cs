namespace Airline_Manager.Data
{
    public static class AircraftData
    {
        public static string AddAircraft(Aircraft aircraft, Route route)
        {
            MySqlConnection conn = Database.GetConnection();

            string result = RouteData.AddRoute(route) + "\n";

            string query_add_aircraft = "INSERT INTO aircrafts (route, name) VALUES (@route, @name);";

            MySqlCommand cmd_add_aircraft = new MySqlCommand(query_add_aircraft, conn);

            cmd_add_aircraft.Parameters.AddWithValue("@route", route.Name);
            cmd_add_aircraft.Parameters.AddWithValue("@name", aircraft.Model);

            conn.Open();
            cmd_add_aircraft.ExecuteNonQuery();
            conn.Close();

            return result + "Aircraft added successfully!";

        }
    }
}
