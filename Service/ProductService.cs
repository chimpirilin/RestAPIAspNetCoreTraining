namespace RestApi.Services;
using RestApi.Interfaces;
using RestApi.Entities;
public class ProductService : IProductsService
{
    private readonly IRepository<Products> _repository;

    public ProductService(IRepository<Products> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Products>> GetProductsAsync() => await _repository.GetAllAsync();

    public async Task<Products> GetProductByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task AddProductAsync(Products product) => await _repository.AddAsync(product);

    public async Task UpdateProductAsync(Products product) => await _repository.UpdateAsync(product);

    public async Task DeleteProductAsync(int id) => await _repository.DeleteAsync(id);
}
