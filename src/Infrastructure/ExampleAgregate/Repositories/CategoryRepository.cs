namespace Infrastructure.ExampleAgregate.Repositories;

public class CategoryRepository(
    ICatalogDbContext context, IDateTimeProvider clock)
    : ICategoryRepository
{
    public async Task<Category?> GetByIdAsync(CategoryId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<List<Category>> GetChildrenAsync(CategoryId parentId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await context.Categories
            .AsNoTracking()
            .Where(c => c.ParentCategoryId == parentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Category>> GetRootCategoriesAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await context.Categories
            .AsNoTracking()
            .Where(c => c.ParentCategoryId == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(CategoryId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await context.Categories
            .AsNoTracking()
            .AnyAsync(c => c.Id == id, cancellationToken);
    }

    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await context.Categories.AddAsync(category, cancellationToken);
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // Загружаем существующую сущность для отслеживания
        var existingCategory = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == category.Id, cancellationToken);

        if (existingCategory != null)
        {
            existingCategory.Update(
                category.Name,
                clock.UtcToday,
                category.ParentCategoryId);
        }
        else
        {
            throw new InvalidOperationException("Category not found for update.");
        }
    }

    public async Task DeleteAsync(CategoryId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, cancellationToken);

        if (category != null)
        {
            category.MarkAsDeleted(clock.UtcToday);
        }
    }
}
