using Q10.StudentManagement.Domain.Student.Commands.Update;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Student.Commands.Update;

public class AppUpdateStudentCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppUpdateStudentCommand, AppUpdateStudentCommandResponse>
{
    public async Task<AppUpdateStudentCommandResponse> HandleAsync(AppUpdateStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<UpdateStudentCommand, UpdateStudentCommandResponse>(
                command.CommandDomain(), cancellationToken
            );

        return new AppUpdateStudentCommandResponse(commandResponse.IsUpdate);
    }
}