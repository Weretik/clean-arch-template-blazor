﻿namespace Presentation.Shared.States.ExampleAggregate;

public static class CatalogActions
{
    public sealed record SetParams(CatalogParams Params);
    public sealed record ResetParams;
    public sealed record SetPageNumber(int PageNumber);

    public sealed record Load;
    public sealed record LoadSuccess(PaginatedList<ProductDto> PageList);
    public sealed record LoadFailure(string Error);
}
