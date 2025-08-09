﻿namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators,
    ILoggingService loggingService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IUseCase
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next(cancellationToken);

        var requestName = typeof(TRequest).Name;

        loggingService.LogValidationStarted(requestName);

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count == 0)
            return await next(cancellationToken);


        var message = string.Join("; ", failures.Select(f => f.ErrorMessage));
        var details = string.Join("; ", failures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}"));

        loggingService.LogValidationFailed(requestName, message, details);

        if (typeof(TResponse).IsGenericType &&
            typeof(TResponse).GetGenericTypeDefinition() == typeof(AppResult<>))
        {
            var error = AppErrors.System.Validation(message).WithDetails(details);

            var result = AppResult.CreateFailureResult(typeof(TResponse).GetGenericArguments()[0], error);
            return (TResponse)result;
        }

        if (typeof(TResponse) == typeof(AppResult))
        {
            var error = AppErrors.System.Validation(message).WithDetails(details);
            return (TResponse)(object)AppResult.Failure(error);
        }

        //throw new ValidationException(failures);
        Throw.Application(AppErrors.System.UnsupportedResponseType.WithDetails(typeof(TResponse).Name));
        return default!;
    }
}
