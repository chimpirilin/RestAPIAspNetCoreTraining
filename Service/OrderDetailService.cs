namespace RestApi.Services;
using RestApi.Interfaces;
using RestApi.Entities;
public class OrderDetailService : IOrdersDetailsService
{
    private readonly IRepository<OrdersDetails> _repository;

    public OrderDetailService(IRepository<OrdersDetails> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrdersDetails>> GetOrderDetailAsync() => await _repository.GetAllAsync();

    public async Task<OrdersDetails> GetOrderDetailByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task AddOrderDetailAsync(OrdersDetails orderDetail) => await _repository.AddAsync(orderDetail);

    public async Task UpdateOrderDetailAsync(OrdersDetails orderDetail) => await _repository.UpdateAsync(orderDetail);

    public async Task DeleteOrderDetailAsync(int id) => await _repository.DeleteAsync(id);
}
