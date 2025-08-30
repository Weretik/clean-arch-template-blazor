namespace Application.ExampleAggregate.Queries.GetProducts;

public sealed record GetProductsQuery(
    string? SearchTerm,
    CategoryId? CategoryId,
    decimal? MinPrice,
    decimal? MaxPrice,
    string? Manufacturer,
    string? Sort,
    int PageNumber = 1,
    int PageSize   = 12)
    : IQuery<Result<PaginatedList<ProductDto>>>;

