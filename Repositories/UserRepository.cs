using GitFlightApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitFlightApp.Repositories
{
    public class UserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existing = await context.Users.FindAsync(user.UserID);
            if (existing == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            existing.Username = user.Username;
            existing.profileImage = user.profileImage;

            context.Users.Update(existing);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await context.Users.FindAsync(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
