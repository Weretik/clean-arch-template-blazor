﻿namespace Application.Common.Logging;

internal static partial class ValidationLog
{
    [LoggerMessage(EventId = 1101, Level = LogLevel.Warning,
        Message = "📝 Validation failed for {MessageType}. Errors: {@Failures}")]
    public static partial void Failed(ILogger logger, string messageType, object failures);
}
