namespace Domain.Common.Exception;

public static class RuleChecker
{
    public static void Check(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
