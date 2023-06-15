namespace Airline_Manager.Controllers
{
    public static class ProfileSetup
    {
        public static void NewSetup()
        {
            // Seting up the new game
            string feedback = DatabaseSetup.SetupGame();
            DatabaseMessageView.DatabaseSuccess(feedback);

            // Getting the name and main hub of the new user
            List<string> information = ModelView.GetInformation();

            // Getting the airport
            Airport airport = AirportData.GetAirport(information[1]);

            // Checking if the airport is found
            while (airport == null)
            {
                // If it's not found, we throw error and get new main hub
                ErrorView.ThrowError("This airport could not be found!");
                information[1] = ModelView.GetInfo("Name or ICAO code of the main airport: ");
                airport = AirportData.GetAirport(information[1]);
            }

            // We set the main hub to the whole name of the city
            information[1] = airport.City;

            // We save the user in the database and display the feedback
            feedback = UserData.CreateUser(information[0], information[1]);
            DatabaseMessageView.DatabaseSuccess(feedback);

            // The user chooses his first aircraft
            List<Aircraft> aircrafts = GlobalVariables.Aircrafts.Where(x => x.Model == "B737-800" || x.Model == "A320-200").ToList();
            Aircraft aircraft = ModelView.GetAircraft(aircrafts);

            // The user chooses the first route for the aircraft
            string destination = ModelView.GetInfo("Write the airport to which will be your first route: ");
            Airport airport1 = AirportData.GetAirport(destination);
            while (airport1 == null)
            {
                // If it's not found, we throw error and get new main hub
                ErrorView.ThrowError("This airport could not be found!");
                destination = ModelView.GetInfo("Name or ICAO code of the main airport: ");
                airport = AirportData.GetAirport(destination);
            }

            // Chose the name of the route
            string route_name = ModelView.GetInfo("What will be the name of this route: ");

            // Creating the full route
            Route final_route = new Route(route_name, airport, airport1);

            // Saving the route and aircraft to the database
            feedback = AircraftData.AddAircraft(aircraft, final_route);
            DatabaseMessageView.DatabaseSuccess(feedback);
        }
    }
}
