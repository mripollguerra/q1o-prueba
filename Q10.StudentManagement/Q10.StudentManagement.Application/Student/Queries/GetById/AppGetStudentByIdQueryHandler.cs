using Q10.StudentManagement.Domain.Student.Queries.GetById;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.Student.Queries.GetById;

public class AppGetStudentByIdQueryHandler(
    IQueryDispatcher queryDispatcher
) : IQueryHandler<AppGetByIdStudentQuery, AppGetByIdStudentQueryResponse>
{
    public async Task<AppGetByIdStudentQueryResponse> HandleAsync(AppGetByIdStudentQuery query,
        CancellationToken cancellationToken = default)
    {
        var queryResponse = await queryDispatcher.QueryAsync<GetStudentByIdQuery, GetStudentByIdQueryResponse>(
            query, cancellationToken
        );

        return new AppGetByIdStudentQueryResponse(queryResponse.Student);
    }
}