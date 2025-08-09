namespace Domain.ExampleAgregate.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetAllProductAsync();
    Task<Product?> GetByIdAsync(ProductId id, CancellationToken cancellationToken = default);
    Task<List<Product>> GetByCategoryIdAsync(CategoryId categoryId, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(ProductId id, CancellationToken cancellationToken = default);
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task DeleteAsync(ProductId id, CancellationToken cancellationToken = default);
}

