using System;

namespace TaskTracker.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // keep as string
        public DateTime DueDate { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Parameterless constructor (needed for EF & seeder)
        public TaskItem() { }

        // Optional: constructor with parameters if needed
        public TaskItem(int id, string title, string description, string status, User assignedUser)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            AssignedUser = assignedUser;
        }
    }
}
