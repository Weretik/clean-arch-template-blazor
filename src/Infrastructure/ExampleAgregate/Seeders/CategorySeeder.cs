namespace Infrastructure.ExampleAgregate.Seeders;

public class CategorySeeder(
    ILogger<CategorySeeder> logger, IDateTimeProvider clock)
    : ICatalogSeeder
{
    public async Task SeedAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var dbContext = serviceProvider.GetRequiredService<CatalogDbContext>();
        var xmlPath = Path.Combine("wwwroot", "xml", "category.xml");

        if (await dbContext.Categories.AnyAsync(cancellationToken))
        {
            logger.LogInformation("Категорії вже існують - category seeder пропущено.");
            return;
        }

        if (!File.Exists(xmlPath))
        {
            logger.LogError("XML-файл не знайдено: {xmlPath}", xmlPath);

            Throw.Application(AppErrors.File.NotFound.WithDetails($"Шлях: {xmlPath}"));
        }

        var doc = XDocument.Load(xmlPath);
        if (doc.Root == null || !doc.Root.Elements("category").Any())
        {
            logger.LogError("XML-файл порожній або не містить елементів <category>.");

            Throw.Application(AppErrors.Seeder.DataMissing
                .WithDetails($"XML-файл {xmlPath} не містить елементів <category>."));
        }

        try
        {
            var categories = doc.Root
                .Elements("category")
                .Select(c =>
                {
                    var id = int.Parse(c.Element("id")?.Value ?? "0");
                    var name = c.Element("name")?.Value ?? string.Empty;
                    var parentRaw = c.Element("parent")?.Value;
                    var parentId = string.IsNullOrWhiteSpace(parentRaw) ? null : new CategoryId(int.Parse(parentRaw));
                    return new { Id = id, Name = name, ParentId = parentId };
                })
                .DistinctBy(c => c.Id)
                .Select(c => Category.Create(new CategoryId(c.Id), c.Name, clock.UtcToday, c.ParentId))
                .ToList();

            await dbContext.Categories.AddRangeAsync(categories, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Category seeding завершено: Створено {categoriesCount} записів.",
                categories.Count);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Помилка при обробці XML-файлу: {XmlPath}",
                xmlPath);

            Throw.Application(AppErrors.Seeder.Failure
                .WithDetails($"XML-файл {xmlPath} містить некоректні дані.{ex}"));
        }
    }
}
