using Q10.StudentManagement.Domain.Subject.Queries.GetById;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.Subject.Queries.GetById;

public class AppGetByIdSubjectQueryHandler(
    IQueryDispatcher queryDispatcher
) : IQueryHandler<AppGetByIdSubjectQuery, AppGetByIdSubjectQueryResponse>
{
    public async Task<AppGetByIdSubjectQueryResponse> HandleAsync(AppGetByIdSubjectQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryResponse = await queryDispatcher.QueryAsync<GetByIdSubjectQuery, GetByIdSubjectQueryResponse>(
            query, cancellationToken
        );

        return new AppGetByIdSubjectQueryResponse(queryResponse.Subject);
    }
}