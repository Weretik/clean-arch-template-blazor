// System namespaces
global using System.Xml.Linq;
global using System.Globalization;
global using System.Security.Claims;

// Microsoft namespaces
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Options;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Hosting;

// Infrastructure Identity namespaces
global using Infrastructure.Identity;
global using Infrastructure.Identity.Entities;
global using Infrastructure.Identity.Seeders;
global using Infrastructure.Identity.Configuration;
global using Infrastructure.Identity.Utils;
global using Infrastructure.Identity.Security;
global using Infrastructure.Identity.Interfaces;

global using Infrastructure.Common.Abstractions;
global using Infrastructure.Common.Services;

global using Infrastructure.Identity.Migrations;

// Domain namespaces
global using Domain.Identity.Constants;
global using Domain.Common.Abstractions;

// Application namespaces
global using Application.Common.Abstractions.Events;
global using Application.Common.Abstractions.Security;
global using Application.Interfaces;
global using Application.Common.Errors;



// Application Example Aggregate
global using Application.ExampleAgregate.Interfaces;

// Infrastructura Example Aggregate
global using Infrastructure.ExampleAgregate.Interfaces;
global using Infrastructure.ExampleAgregate.Migrations;
global using Infrastructure.ExampleAgregate.Persistence;
global using Infrastructure.ExampleAgregate.Interfaces;
global using Infrastructure.ExampleAgregate;
global using Infrastructure.ExampleAgregate.Repositories;
global using Infrastructure.ExampleAgregate.Seeders;

// Domain Example Aggregate
global using Domain.ExampleAgregate.Entities;
global using Domain.ExampleAgregate.ValueObjects;
global using Domain.ExampleAgregate.Repositories;
