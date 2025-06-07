using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Subject.Commands.Create;

public class CreateSubjectCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<CreateSubjectCommand, CreateSubjectCommandResponse>
{
    public async Task<CreateSubjectCommandResponse> HandleAsync(CreateSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var createSubject = await unitOfWork.SubjectRepository.AddAsync(command.Subject);
        return new CreateSubjectCommandResponse(createSubject);
    }
}