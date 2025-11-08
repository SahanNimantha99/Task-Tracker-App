using System;

namespace TaskTracker.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; } // Use enum
        public DateTime DueDate { get; set; }
        public int? AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public TaskItem(int id, string title, string description, TaskStatus status, User assignedUser)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            AssignedUser = assignedUser;
            AssignedUserId = assignedUser?.Id;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
