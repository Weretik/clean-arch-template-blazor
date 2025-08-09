namespace Domain.ExampleAgregate.Rules;

public class NameMustNotBeEmptyRule(string name)
    : BusinessRule
{
    public override string Message => "Назва не повинна бути порожньою.";
    public override bool IsBroken() => string.IsNullOrWhiteSpace(name);
}
