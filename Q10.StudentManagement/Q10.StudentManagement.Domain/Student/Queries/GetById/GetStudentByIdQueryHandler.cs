using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Student.Queries.GetById;

public class GetStudentByIdQueryHandler(
    IUnitOfWork unitOfWork
    ): IQueryHandler<GetStudentByIdQuery, GetStudentByIdQueryResponse>
{
    public async Task<GetStudentByIdQueryResponse> HandleAsync(GetStudentByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var studentResponse = await unitOfWork.StudentRepository.GetByIdAsync(query.Id);
        return new GetStudentByIdQueryResponse(studentResponse);
    }
}