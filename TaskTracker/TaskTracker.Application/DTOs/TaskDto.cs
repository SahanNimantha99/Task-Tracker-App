namespace TaskTracker.Application.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Will map to TaskStatus enum in Domain
        public string AssignedUser { get; set; }
        public string DueDate { get; set; } // Optional: for API serialization
    }
}
