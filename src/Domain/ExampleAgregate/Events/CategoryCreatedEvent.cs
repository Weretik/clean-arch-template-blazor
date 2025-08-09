namespace Domain.ExampleAgregate.Events;

public sealed class CategoryCreatedEvent(CategoryId categoryId) : BaseDomainEvent
{
    public CategoryId CategoryId { get; } = categoryId;
}
