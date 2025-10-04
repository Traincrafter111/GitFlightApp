using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<FlightConnection> FlightConnections { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Override this method to configure the model
        /// </summary>
        /// <param name="modelBuilder">Define shape of the entities and the relation between them</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys Settings
            modelBuilder.Entity<Flight>().
                HasKey(F => F.FlightNumber);

            modelBuilder.Entity<Connection>().
                HasKey(C => C.ConnectionID);

            modelBuilder.Entity<FlightConnection>().
                HasKey(C => new { C.ConnectionID, C.FlightNumber });

            // Relationships Settings
            modelBuilder.Entity<FlightConnection>().
                HasOne(FC => FC.Flight).
                WithMany(F => F.FlightConnections).
                HasForeignKey(FC => FC.FlightNumber);

            modelBuilder.Entity<FlightConnection>().
                HasOne(FC => FC.Connection).
                WithMany(C => C.FlightConnections).
                HasForeignKey(FC => FC.ConnectionID);

            modelBuilder.Entity<User>().
                HasKey(C => C.UserID);

            modelBuilder.Entity<User>().
                Property(U => U.Username).IsRequired();

        }

    }
}
