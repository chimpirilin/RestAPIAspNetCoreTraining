namespace RestApi.Interfaces;
using RestApi.Entities;

public interface IProductsService
{
    Task<IEnumerable<Products>> GetProductsAsync();
    Task<Products> GetProductByIdAsync(int id);
    Task AddProductAsync(Products products);
    Task UpdateProductAsync(Products products);
    Task DeleteProductAsync(int id);
}
