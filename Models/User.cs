using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Models
{
    public class User
    {
        public string UserID { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; } = string.Empty;
        public byte[]? profileImage { get; set; }
        public ICollection<Connection> Connections { get; set; } = [];
    }
}
