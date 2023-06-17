using Airline_Manager.Models;

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

            // Getting the first and main airport
            Airport firstAirport = GetFirstAirport(information[1]);

            // We set the main hub to the whole name of the city
            information[1] = firstAirport.City;

            // We save the user in the database and display the feedback
            feedback = UserData.CreateUser(information[0], information[1]);
            DatabaseMessageView.DatabaseSuccess(feedback);

            // The user chooses his first aircraft
            List<Aircraft> aircrafts = GlobalVariables.AircraftsTxtFile.Where(x => x.Model == "B737-800" || x.Model == "A320-200").ToList();
            Aircraft aircraft = ModelView.GetAircraft(aircrafts);

            // The user chooses the first route for the aircraft
            Airport secondAirport = GetSecondAirport(firstAirport);

            // Chose the name of the route
            string route_name = ModelView.GetInfo("What will be the name of this route: ");

            // Creating the full route
            Route final_route = new Route(route_name, firstAirport, secondAirport);

            // Saving the route and aircraft to the database
            feedback = AircraftData.AddAircraft(aircraft, final_route);
            DatabaseMessageView.DatabaseSuccess(feedback);

            // Saving the game
            GameSaver.SaveGame();
            ModelView.SendMessage("Successfully created the profile!");
        }

        private static Airport GetFirstAirport(string airportName)
        {
            Airport firstAirport = AirportDataCollector.GetAirport(airportName);

            // Checking if the airport is found
            while (firstAirport == null)
            {
                // If it's not found, we throw error and get new main hub
                ErrorView.ThrowError("This airport could not be found!");
                airportName = ModelView.GetInfo("Name or ICAO code of the main airport: ");
                firstAirport = AirportDataCollector.GetAirport(airportName);
            }
            return firstAirport;
        }

        private static Airport GetSecondAirport(Airport firstAirport)
        {
            while (true)
            {
                string destination = ModelView.GetInfo("Write the airport to which will be your first route: ");
                Airport secondAirport = AirportDataCollector.GetAirport(destination);

                if (secondAirport == null)
                {
                    // If it's not found, we throw an error and continue to the next iteration
                    ErrorView.ThrowError("\nThis airport could not be found!");
                    continue;
                }

                if (firstAirport.City == secondAirport.City)
                {
                    ErrorView.ThrowError("\nThe two airports can't be the same!");
                    continue;
                }

                return secondAirport;
            }
        }

    }
}
