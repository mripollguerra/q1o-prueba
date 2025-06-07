using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Student.Commands.Update;

public class UpdateStudentCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdateStudentCommand, UpdateStudentCommandResponse>
{
    public async Task<UpdateStudentCommandResponse> HandleAsync(UpdateStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var updateStudent = await unitOfWork.StudentRepository.UpdateByIdAsync(command.Student);
        return new UpdateStudentCommandResponse(updateStudent);
    }
}