namespace RestApi.Interfaces;
using RestApi.Entities;

public interface IUsersService
{
    Task<IEnumerable<Users>> GetUserAsync();
    Task<Users> GetUserByIdAsync(int id);
    Task AddUserAsync(Users users);
    Task UpdateUserAsync(Users users);
    Task DeleteUserAsync(int id);
}
