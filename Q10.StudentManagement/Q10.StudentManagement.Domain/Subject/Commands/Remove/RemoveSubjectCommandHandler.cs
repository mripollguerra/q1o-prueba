using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Subject.Commands.Remove;

public class RemoveSubjectCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<RemoveSubjectCommand, RemoveSubjectCommandResponse>
{
    public async Task<RemoveSubjectCommandResponse> HandleAsync(RemoveSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var removeSubject = await unitOfWork.SubjectRepository.RemoveByIdAsync(command.Id);
        return new RemoveSubjectCommandResponse(removeSubject);
    }
}