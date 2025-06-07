using Q10.StudentManagement.Domain.Subject.Commands.Update;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Subject.Commands.Update;

public class AppUpdateSubjectCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppUpdateSubjectCommand, AppUpdateSubjectCommandResponse>
{
    public async Task<AppUpdateSubjectCommandResponse> HandleAsync(AppUpdateSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<UpdateSubjectCommand, UpdateSubjectCommandResponse>(
                command.CommandDomain(), cancellationToken
            );

        return new AppUpdateSubjectCommandResponse(commandResponse.IsUpdate);
    }
}