using TaskTracker.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskTracker.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<TaskDto> CreateTaskAsync(TaskDto taskDto);
        Task<TaskDto> UpdateTaskAsync(int id, TaskDto taskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
