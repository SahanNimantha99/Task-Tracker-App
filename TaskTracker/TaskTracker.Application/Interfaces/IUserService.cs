using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
