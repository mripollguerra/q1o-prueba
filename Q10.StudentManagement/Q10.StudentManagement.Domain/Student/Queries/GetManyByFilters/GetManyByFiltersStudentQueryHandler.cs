using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;

public class GetManyByFiltersStudentQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetManyByFiltersStudentQuery, GetManyByFiltersStudentQueryResponse>
{
    public async Task<GetManyByFiltersStudentQueryResponse> HandleAsync(GetManyByFiltersStudentQuery query,
        CancellationToken cancellationToken = default)
    {
        var studentsResponse = await unitOfWork.StudentRepository.GetManyByFiltersAsync(query.Filters);
        return new GetManyByFiltersStudentQueryResponse(studentsResponse);
    }
}