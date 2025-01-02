namespace RestApi.Services;
using RestApi.Interfaces;
using RestApi.Entities;
public class UserService : IUsersService
{
    private readonly IRepository<Users> _repository;

    public UserService(IRepository<Users> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Users>> GetUserAsync() => await _repository.GetAllAsync();

    public async Task<Users> GetUserByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task AddUserAsync(Users order) => await _repository.AddAsync(order);

    public async Task UpdateUserAsync(Users order) => await _repository.UpdateAsync(order);

    public async Task DeleteUserAsync(int id) => await _repository.DeleteAsync(id);
}
