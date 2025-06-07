using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;

public class GetManyByFiltersSubjectQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetManyByFiltersSubjectQuery, GetManyByFiltersSubjectQueryResponse>
{
    public async Task<GetManyByFiltersSubjectQueryResponse> HandleAsync(GetManyByFiltersSubjectQuery query,
        CancellationToken cancellationToken = default)
    {
        var subjectsResponse = await unitOfWork.SubjectRepository.GetManyByFiltersAsync(query.Filters);
        return new GetManyByFiltersSubjectQueryResponse(subjectsResponse);
    }
}