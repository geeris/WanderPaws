using WanderPaws.Domain.Entities;

namespace WanderPaws.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string email);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> IsValidUserCredentialsAsync(string email, string password);
        Task RegisterUserAsync(User user);
    }
}
