using GitFlightApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitFlightApp.Repositories
{
    public class PlaneRepository
    {
        private readonly DataContext context;

        public PlaneRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Plane>> GetAllPlanesAsync()
        {
            return await context.Planes.AsNoTracking().ToListAsync();
        }

        public async Task<Plane?> GetPlaneByIdAsync(int id)
        {
            return await context.Planes.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPlaneAsync(Plane plane)
        {
            await context.Planes.AddAsync(plane);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePlaneAsync(Plane plane)
        {
            var existing = await context.Planes.FindAsync(plane.Id);
            if (existing == null)
            {
                throw new InvalidOperationException("Plane not found.");
            }

            existing.Model = plane.Model;
            existing.Manufacturer = plane.Manufacturer;
            existing.ImagePath = plane.ImagePath;

            context.Planes.Update(existing);
            await context.SaveChangesAsync();
        }

        public async Task DeletePlaneAsync(int id)
        {
            var plane = await context.Planes.FindAsync(id);
            if (plane != null)
            {
                context.Planes.Remove(plane);
                await context.SaveChangesAsync();
            }
        }
    }
}
