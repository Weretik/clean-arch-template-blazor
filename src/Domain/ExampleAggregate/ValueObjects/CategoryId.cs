namespace Domain.ExampleAggregate.ValueObjects;

public readonly record struct CategoryId(int Value)
{
    public override string ToString() => Value.ToString();
    public static implicit operator int(CategoryId id) => id.Value;
    public static explicit operator CategoryId(int value) => new(value);
}
