using Q10.StudentManagement.Domain.Subject.Commands.Create;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Subject.Commands.Create;

public class AppCreateSubjectCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppCreateSubjectCommand, AppCreateSubjectCommandResponse>
{
    public async Task<AppCreateSubjectCommandResponse> HandleAsync(AppCreateSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<CreateSubjectCommand, CreateSubjectCommandResponse>(
                command.CommandDomain(), cancellationToken
            );

        return new AppCreateSubjectCommandResponse(commandResponse.Id);
    }
}