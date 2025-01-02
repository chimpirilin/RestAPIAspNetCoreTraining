namespace RestApi.Interfaces;
using RestApi.Entities;

public interface IOrdersService
{
    Task<IEnumerable<Orders>> GetOrderAsync();
    Task<Orders> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Orders orders);
    Task UpdateOrderAsync(Orders orders);
    Task DeleteOrderAsync(int id);
}
