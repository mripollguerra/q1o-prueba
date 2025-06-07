using Q10.StudentManagement.Domain.RegistrationSubject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.RegistrationSubject.Queries.GetManyByFilters;

public class AppGetManyByFiltersRegistrationSubjectQueryHandler(
    IQueryDispatcher queryDispatcher
) : IQueryHandler<AppGetManyByFiltersRegistrationSubjectQuery, AppGetManyByFiltersRegistrationSubjectQueryResponse>
{
    public async Task<AppGetManyByFiltersRegistrationSubjectQueryResponse> HandleAsync(
        AppGetManyByFiltersRegistrationSubjectQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryResponse =
            await queryDispatcher
                .QueryAsync<GetManyByFiltersRegistrationSubjectQuery, GetManyByFiltersRegistrationSubjectQueryResponse>(
                    query.QueryDomain(), cancellationToken
                );

        return new AppGetManyByFiltersRegistrationSubjectQueryResponse(queryResponse.RegistrationSubjects);
    }
}