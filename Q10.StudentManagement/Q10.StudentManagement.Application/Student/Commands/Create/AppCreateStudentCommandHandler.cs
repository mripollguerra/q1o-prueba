using Q10.StudentManagement.Domain.Student.Commands.Create;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Student.Commands.Create;

public class AppCreateStudentCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppCreateStudentCommand, AppCreateStudentCommandResponse>
{
    public async Task<AppCreateStudentCommandResponse> HandleAsync(AppCreateStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<CreateStudentCommand, CreateStudentCommandResponse>(
                command.CommandDomain(), cancellationToken
            );
        
        return new AppCreateStudentCommandResponse(commandResponse.Id);
    }
}