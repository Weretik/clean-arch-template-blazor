﻿namespace Application.ExampleAggregate.Specifications;

public sealed class AllCategoriesDtoSpecification : Specification<Category, CategoryDto>
{
    public AllCategoriesDtoSpecification()
    {
        Query.AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CategoryDto
            {
                Id = c.Id.Value,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId.HasValue
                    ? (int?)c.ParentCategoryId
                    : null,
                Children = Array.Empty<CategoryDto>()
            });

    }
}
