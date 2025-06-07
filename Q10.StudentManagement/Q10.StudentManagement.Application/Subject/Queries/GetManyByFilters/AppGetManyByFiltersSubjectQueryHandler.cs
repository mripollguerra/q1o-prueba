using Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.Subject.Queries.GetManyByFilters;

public class AppGetManyByFiltersSubjectQueryHandler(
    IQueryDispatcher queryDispatcher
) : IQueryHandler<AppGetManyByFiltersSubjectQuery, AppGetManyByFiltersSubjectQueryResponse>
{
    public async Task<AppGetManyByFiltersSubjectQueryResponse> HandleAsync(AppGetManyByFiltersSubjectQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryResponse =
            await queryDispatcher.QueryAsync<GetManyByFiltersSubjectQuery, GetManyByFiltersSubjectQueryResponse>(
                query.QueryDomain(), cancellationToken
            );

        return new AppGetManyByFiltersSubjectQueryResponse(queryResponse.Subjects);
    }
}