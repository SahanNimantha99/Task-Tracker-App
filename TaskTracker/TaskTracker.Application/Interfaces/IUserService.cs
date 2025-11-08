using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
        
        // Admin/Management methods
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
    }
}
