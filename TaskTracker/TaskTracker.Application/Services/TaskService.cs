using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Application.DTOs;

// Aliases
using DomainTask = TaskTracker.Domain.Entities.TaskItem;
using DomainUser = TaskTracker.Domain.Entities.User;
using DomainTaskStatus = TaskTracker.Domain.Entities.TaskStatus;

namespace TaskTracker.Application.Services
{
    public class TaskService
    {
        private readonly List<DomainTask> _tasks;
        private readonly List<DomainUser> _users;

        public TaskService(List<DomainTask> tasks, List<DomainUser> users)
        {
            _tasks = tasks;
            _users = users;
        }

        public List<TaskDto> GetAllTasks()
        {
            return _tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,  // Already a string in Domain
                AssignedUser = t.AssignedUser?.Username
            }).ToList();
        }

        public TaskDto? GetTaskById(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                AssignedUser = task.AssignedUser?.Username
            };
        }

        public DomainTask CreateTask(TaskDto dto)
        {
            // Parse status from string to enum (optional validation)
            DomainTaskStatus status = Enum.TryParse<DomainTaskStatus>(dto.Status, out var parsedStatus)
                ? parsedStatus
                : DomainTaskStatus.Pending;

            DomainUser? assignedUser = !string.IsNullOrEmpty(dto.AssignedUser)
                ? _users.FirstOrDefault(u => u.Username == dto.AssignedUser)
                : null;

            int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;

            // Convert enum to string when creating the domain task
            var newTask = new DomainTask(newId, dto.Title, dto.Description, status.ToString(), assignedUser);

            _tasks.Add(newTask);
            return newTask;
        }

        public DomainTask? UpdateTask(int id, TaskDto dto)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask == null) return null;

            DomainTaskStatus status = Enum.TryParse<DomainTaskStatus>(dto.Status, out var parsedStatus)
                ? parsedStatus
                : Enum.TryParse<DomainTaskStatus>(existingTask.Status, out var existingStatus)
                    ? existingStatus
                    : DomainTaskStatus.Pending;

            DomainUser? assignedUser = !string.IsNullOrEmpty(dto.AssignedUser)
                ? _users.FirstOrDefault(u => u.Username == dto.AssignedUser)
                : existingTask.AssignedUser;

            var updatedTask = new DomainTask(
                existingTask.Id,
                dto.Title ?? existingTask.Title,
                dto.Description ?? existingTask.Description,
                status.ToString(), // <-- convert enum to string
                assignedUser
            );

            int index = _tasks.IndexOf(existingTask);
            _tasks[index] = updatedTask;

            return updatedTask;
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            _tasks.Remove(task);
            return true;
        }
    }
}
