using Microsoft.Extensions.DependencyInjection;

namespace Q10.StudentManagement.Library.Cqrs.Queries.Implementations;

public class QueryDispatcher(
    IServiceProvider serviceProvider
) : IQueryDispatcher
{
    public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class, IQuery
        where TResult : class
    {
        var handler = serviceProvider.GetService<IQueryHandler<TQuery, TResult>>()
                      ?? throw new Exception(
                          $"No handler found for {typeof(IQueryHandler<TQuery, TResult>).FullName}");

        return await handler.HandleAsync(query, cancellationToken);
    }
}