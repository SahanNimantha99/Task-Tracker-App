using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // ---------------- Users ----------------
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User { Id = 1, Username = "admin", Role = "Admin" },
                    new User { Id = 2, Username = "employee", Role = "Employee" }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            // ---------------- Tasks ----------------
            if (!context.Tasks.Any())
            {
                var tasks = new List<TaskItem>
                {
                    new TaskItem
                    {
                        Id = 1,
                        Title = "Setup Database",
                        Description = "Setup MySQL database",
                        Status = "Pending",
                        AssignedUserId = 2,
                        AssignedUser = context.Users.First(u => u.Id == 2),
                        DueDate = DateTime.UtcNow.AddDays(5),
                        CreatedAt = DateTime.UtcNow
                    },
                    new TaskItem
                    {
                        Id = 2,
                        Title = "API Development",
                        Description = "Create REST APIs for Task Tracker",
                        Status = "InProgress",
                        AssignedUserId = 2,
                        AssignedUser = context.Users.First(u => u.Id == 2),
                        DueDate = DateTime.UtcNow.AddDays(10),
                        CreatedAt = DateTime.UtcNow
                    }
                };

                context.Tasks.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}
