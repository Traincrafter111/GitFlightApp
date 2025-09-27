using GitFlightApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Repositories
{
    public class FlightRepository(DataContext context)
    {
        /// <summary>
        ///     Method to get all flights from the database
        /// </summary>
        /// <returns>A list from all flights</returns>
        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await context.Flights.AsNoTracking().ToListAsync();
        }
        public async Task<Flight?> GetFlightByIdAsync(string flightNumber)
        {
            return await context.Flights
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);
        }
        /// <summary>
        ///     Add a new flight to the database
        /// </summary>
        /// <param name="flight"> Flight to be added </param>
        /// <returns>The result of an async operation</returns>
        public async Task AddFlightAsync(Flight flight)
        {
            await context.Flights.AddAsync(flight);
            await context.SaveChangesAsync();
        }
        /// <summary>
        ///     Update an existing flight in the database
        /// </summary>
        /// <param name="flight">Flight to be updated</param>
        /// <returns> The result of an operation</returns>
        public async Task UpdateFlightAsync(Flight flight)
        {
            context.Flights.Update(flight);
            await context.SaveChangesAsync();
        }
        /// <summary>
        ///     Delete a flight from the database
        /// </summary>
        /// <param name="flightNumber"> The Id of the flight to delete</param>
        /// <returns>The result of an operation</returns>
        public async Task DeleteFlightAsync(string flightNumber)
        {
            var flight = await context.Flights.FindAsync(flightNumber);
            if (flight != null)
            {
                context.Flights.Remove(flight);
                await context.SaveChangesAsync();
            }
        }
    }
}
