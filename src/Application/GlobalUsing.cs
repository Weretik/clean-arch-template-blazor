// System namespaces
global using System;
global using System.Collections.Generic;
global using System.Reflection;
global using System.Security.Claims;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Diagnostics;
global using System.Linq.Expressions;

// Microsoft namespaces
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging.Abstractions;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Infrastructure;


// Application namespaces
global using Application.Common.Behaviors;
global using Application.Common.Results;
global using Application.Common.Pagination;
global using Application.Common.Events;
global using Application.Common.Exceptions;
global using Application.Common.Errors;
global using Application.Interfaces;
global using Application.DTOs;
//Abstractions
global using Application.Common.Abstractions.Events;
global using Application.Common.Abstractions.UseCase;
global using Application.Common.Abstractions.Pagination;
global using Application.Common.Abstractions.Mapping;
global using Application.Common.Abstractions.Result;
global using Application.Common.Abstractions.Background;
global using Application.Common.Abstractions.Logging;
global using Application.Common.Mapping;

// Domain namespaces
global using Domain.Common.Exception;
global using Domain.Common.Abstractions;

// External libraries
global using AutoMapper;
global using AutoMapper.QueryableExtensions;
global using MediatR;
global using FluentValidation;

// Example Agregate Domain
global using Domain.ExampleAgregate.Entities;
global using Domain.ExampleAgregate.ValueObjects;
global using Domain.ExampleAgregate.Repositories;
global using Domain.ExampleAgregate.Specifications;

// Example Agregate Application
global using Application.ExampleAgregate.DTOs;
