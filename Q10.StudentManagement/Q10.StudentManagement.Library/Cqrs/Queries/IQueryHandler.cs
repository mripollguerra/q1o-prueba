namespace Q10.StudentManagement.Library.Cqrs.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : class, IQuery
    where TResult : class
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}