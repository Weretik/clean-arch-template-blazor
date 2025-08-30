﻿namespace Application.ExampleAggregate.Specifications;

public sealed class CategoryExistsSpecification : Specification<Category>
{
    public CategoryExistsSpecification(CategoryId id)
    {
        Query.Where(c => c.Id == id);
    }
}
