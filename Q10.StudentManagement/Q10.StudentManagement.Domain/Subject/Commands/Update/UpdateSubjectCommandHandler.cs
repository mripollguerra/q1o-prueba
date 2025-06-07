using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Subject.Commands.Update;

public class UpdateSubjectCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdateSubjectCommand, UpdateSubjectCommandResponse>
{
    public async Task<UpdateSubjectCommandResponse> HandleAsync(UpdateSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var updateSubject = await unitOfWork.SubjectRepository.UpdateByIdAsync(command.Subject);
        return new UpdateSubjectCommandResponse(updateSubject);
    }
}