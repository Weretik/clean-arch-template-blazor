﻿namespace Infrastructure.Common.Abstractions;

public interface ISeeder
{
    Task SeedAsync(IServiceProvider services, CancellationToken cancellationToken = default);
}

