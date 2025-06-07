using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Subject.Queries.GetById;

public class GetByIdSubjectQueryHandler(
    IUnitOfWork unitOfWork
): IQueryHandler<GetByIdSubjectQuery, GetByIdSubjectQueryResponse>
{
    public async Task<GetByIdSubjectQueryResponse> HandleAsync(GetByIdSubjectQuery query,
        CancellationToken cancellationToken = default)
    {
        var subjectResponse = await unitOfWork.SubjectRepository.GetByIdAsync(query.Id);
        return new GetByIdSubjectQueryResponse(subjectResponse);
    }
}