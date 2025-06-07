namespace Q10.StudentManagement.Library.Cqrs.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class, IQuery
        where TResult : class;
}