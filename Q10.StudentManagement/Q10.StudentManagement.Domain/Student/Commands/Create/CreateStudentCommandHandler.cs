using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Student.Commands.Create;

public class CreateStudentCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<CreateStudentCommand, CreateStudentCommandResponse>
{
    public async Task<CreateStudentCommandResponse> HandleAsync(CreateStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var createStudent = await unitOfWork.StudentRepository.AddAsync(command.Student);
        return new CreateStudentCommandResponse(createStudent);
    }
}