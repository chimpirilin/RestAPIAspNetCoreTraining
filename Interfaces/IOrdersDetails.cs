namespace RestApi.Interfaces;
using RestApi.Entities;

public interface IOrdersDetailsService
{
    Task<IEnumerable<OrdersDetails>> GetOrderDetailAsync();
    Task<OrdersDetails> GetOrderDetailByIdAsync(int id);
    Task AddOrderDetailAsync(OrdersDetails ordersDetails);
    Task UpdateOrderDetailAsync(OrdersDetails ordersDetails);
    Task DeleteOrderDetailAsync(int id);
}
