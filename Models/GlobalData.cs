using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Models
{
    public class GlobalData
    {
        private static ObservableCollection<Flight> flights = [new Flight()
        {
            FlightNumber = "LH123",
            DepartureDate = DateTime.Now,
            Price = 900
        }, 
            new Flight()
        {
            FlightNumber = "LH456",
            DepartureDate = new DateTime(2025, 9, 1),
            Price = 7600
        },
            new Flight()
        {
            FlightNumber = "AB890",
            DepartureDate = new DateTime(2025, 10, 10),
            Price = 300
        }];

        private static ObservableCollection<FlightConnection> flightConnections = [new FlightConnection()
        {
           Airline = "Lufthansa",
           ConnectionID = "LH001",
           DepartuteCity = "Frankfurt",
           ArrivalCity = "New York", 
           Flights = [flights.FirstOrDefault()]


        }];

        public static ObservableCollection<Flight> Flights { get => flights; set => flights = value; }
        public static ObservableCollection<FlightConnection> FlightConnections { get => flightConnections; set => flightConnections = value; }

    }
}
