namespace RestApi.Services;
using RestApi.Interfaces;
using RestApi.Entities;
public class OrderService : IOrdersService
{
    private readonly IRepository<Orders> _repository;

    public OrderService(IRepository<Orders> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Orders>> GetOrderAsync() => await _repository.GetAllAsync();

    public async Task<Orders> GetOrderByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task AddOrderAsync(Orders order) => await _repository.AddAsync(order);

    public async Task UpdateOrderAsync(Orders order) => await _repository.UpdateAsync(order);

    public async Task DeleteOrderAsync(int id) => await _repository.DeleteAsync(id);
}
