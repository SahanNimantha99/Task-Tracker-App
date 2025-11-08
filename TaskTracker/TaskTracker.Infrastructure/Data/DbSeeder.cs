using BCrypt.Net;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    Email = "admin@tasktracker.com",
                    Role = "Admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!")
                };

                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
