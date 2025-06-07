using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.RegistrationSubject.Queries.GetManyByFilters;

public class GetManyByFiltersRegistrationSubjectQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetManyByFiltersRegistrationSubjectQuery, GetManyByFiltersRegistrationSubjectQueryResponse>
{
    public async Task<GetManyByFiltersRegistrationSubjectQueryResponse> HandleAsync(
        GetManyByFiltersRegistrationSubjectQuery query,
        CancellationToken cancellationToken = default)
    {
        var registrationSubjectsResponse =
            await unitOfWork.RegistrationSubjectRepository.GetManyByFiltersAsync(query.Filters);
        return new GetManyByFiltersRegistrationSubjectQueryResponse(registrationSubjectsResponse);
    }
}