using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Library.Cqrs.Commands;
using Q10.StudentManagement.Library.Cqrs.Commands.Implementations;
using Q10.StudentManagement.Library.Cqrs.Queries;
using Q10.StudentManagement.Library.Cqrs.Queries.Implementations;
using Scrutor;

namespace Q10.StudentManagement.Library.Cqrs;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.Scan(scan => scan.FromApplicationDependencies()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        services.Scan(scan => scan.FromApplicationDependencies()
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}