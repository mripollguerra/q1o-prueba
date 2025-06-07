using Microsoft.Extensions.DependencyInjection;
using Q10.StudentManagement.Library.Options;
using Q10.StudentManagement.Library.Repository.Abstracts;

namespace Q10.StudentManagement.Library.Repository;

public static class Extensions
{
    public static IServiceCollection AddRepository<TContext>(this IServiceCollection services)
        where TContext : BaseContext
    {
        services.AddOptions<RepositoryOptions>().BindConfiguration("Q10:Repository");
        services.AddScoped<IRepository, Implementations.Repository>();
        services.AddDbContext<BaseContext, TContext>();

        return services;
    }
}