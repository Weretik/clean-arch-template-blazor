﻿namespace Application.ExampleAggregate.Specifications;

public sealed class ProductExistsSpecification : Specification<Product>
{
    public ProductExistsSpecification(ProductId id)
    {
        Query.Where(p => p.Id == id);
    }
}
