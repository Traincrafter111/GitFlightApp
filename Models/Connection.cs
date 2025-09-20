using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Models
{
    public class Connection
    {
        public string ConnectionID { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string DepartureCity { get; set; } = string.Empty;
        public string ArrivalCity { get; set; } = string.Empty;
        public ICollection<FlightConnection> FlightConnections { get; set; } = [];
    }
}
