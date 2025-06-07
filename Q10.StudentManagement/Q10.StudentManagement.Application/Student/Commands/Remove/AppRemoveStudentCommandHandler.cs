using Q10.StudentManagement.Domain.Student.Commands.Remove;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Student.Commands.Remove;

public class AppRemoveStudentCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppRemoveStudentCommand, AppRemoveStudentCommandResponse>
{
    public async Task<AppRemoveStudentCommandResponse> HandleAsync(AppRemoveStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<RemoveStudentCommand, RemoveStudentCommandResponse>(
                command.CommandDomain(), cancellationToken
            );

        return new AppRemoveStudentCommandResponse(commandResponse.IsRemove);
    }
}