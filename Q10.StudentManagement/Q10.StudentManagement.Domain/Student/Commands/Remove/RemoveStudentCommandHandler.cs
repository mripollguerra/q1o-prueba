using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Student.Commands.Remove;

public class RemoveStudentCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<RemoveStudentCommand, RemoveStudentCommandResponse>
{
    public async Task<RemoveStudentCommandResponse> HandleAsync(RemoveStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var removeStudent = await unitOfWork.StudentRepository.RemoveByIdAsync(command.Id);
        return new RemoveStudentCommandResponse(removeStudent);
    }
}