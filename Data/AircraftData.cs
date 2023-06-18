using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Airline_Manager.Data
{
    public static class AircraftData
    {
        public static string AddAircraft(Aircraft aircraft, Route route)
        {
            MySqlConnection conn = Database.GetConnection();

            string result = RouteData.AddRoute(route) + "\n";

            string query_add_aircraft = "INSERT INTO aircrafts (route, model) VALUES (@route, @model);";

            MySqlCommand cmd_add_aircraft = new MySqlCommand(query_add_aircraft, conn);

            cmd_add_aircraft.Parameters.AddWithValue("@route", route.Name);
            cmd_add_aircraft.Parameters.AddWithValue("@model", aircraft.Model);

            conn.Open();
            cmd_add_aircraft.ExecuteNonQuery();
            conn.Close();

            return result + "Aircraft added successfully!";
        }

        public static List<Aircraft> GetAll()
        {
            List<Aircraft> aircrafts = new();

            List<Route> routes = RouteData.GetAllRoutes();

            MySqlConnection conn = Database.GetConnection();

            string query = "SELECT * FROM aircrafts";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string route = reader["route"].ToString();
                int wear = int.Parse(reader["wear"].ToString());
                bool airborne = bool.Parse(reader["airborne"].ToString());
                string model = reader["model"].ToString();
                DateTime landing = DateTime.Now;
                if (airborne)
                {
                    string time = reader["landing"].ToString();
                    landing = DateTime.Parse(time);
                }
                Aircraft aircraft = GlobalVariables.AircraftsTxtFile.Where(x => x.Model == model).ToList()[0];
                aircraft.Airborne = airborne;
                aircraft.Wear = wear;
                routes = routes.Where(x => x.Name == route).ToList();
                aircraft.Route = routes[0];
                if (airborne)
                    aircraft.Landing = landing;
                aircrafts.Add(aircraft);
            }
            conn.Close();

            return aircrafts;
        }

        public static string Depart(Aircraft aircraft)
        {
            MySqlConnection conn = Database.GetConnection();

            string query = "UPDATE aircrafts SET airborne = true, wear = @wear, landing = @landing WHERE route = @route;";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@wear", aircraft.Wear);
            cmd.Parameters.AddWithValue("@landing", aircraft.Landing);
            cmd.Parameters.AddWithValue("@route", aircraft.Route);

            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                return $"Aircraft {aircraft.Model} departured! \nExpected landing at {aircraft.Landing.ToString("HH:mm:ss")}";
            conn.Close();
            throw new InvalidOperationException("Something went wrong!");
        }

        public static string Land(Aircraft aircraft)
        {
            MySqlConnection conn = Database.GetConnection();

            string query = "UPDATE aircrafts SET airborne = false, landing = null WHERE landing = @landing;";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@landing", aircraft.Landing);

            conn.Open();
            int n = cmd.ExecuteNonQuery();
            conn.Close();
            return $"Aircraft {aircraft.Model} on route {aircraft.Route.Name} landed!";

        }
    }
}
