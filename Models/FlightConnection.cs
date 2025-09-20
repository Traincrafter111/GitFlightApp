using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Models
{
    public class FlightConnection
    {
        public string FlightNumber { get; set; } = string.Empty;
        public string ConnectionID { get; set; } = string.Empty;
        public Flight Flight { get; set; } = new ();
        public Connection Connection { get; set; } = new ();

    }
}
