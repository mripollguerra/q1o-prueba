using Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.Student.Queries.GetManyByFilters;

public class AppGetManyByFiltersStudentQueryHandler(
    IQueryDispatcher queryDispatcher
) : IQueryHandler<AppGetManyByFiltersStudentQuery, AppGetManyByFiltersStudentQueryResponse>
{
    public async Task<AppGetManyByFiltersStudentQueryResponse> HandleAsync(AppGetManyByFiltersStudentQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryResponse =
            await queryDispatcher.QueryAsync<GetManyByFiltersStudentQuery, GetManyByFiltersStudentQueryResponse>(
                query.QueryDomain(), cancellationToken
            );

        return new AppGetManyByFiltersStudentQueryResponse(queryResponse.Students);
    }
}