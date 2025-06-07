using Q10.StudentManagement.Domain.RegistrationSubject.Commands.RegistrationSubject;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.RegistrationSubject.Commands.RegistrationSubject;

public class AppRegistrationSubjectCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppRegistrationSubjectCommand, AppRegistrationSubjectCommandResponse>
{
    public async Task<AppRegistrationSubjectCommandResponse> HandleAsync(AppRegistrationSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<RegistrationSubjectCommand, RegistrationSubjectCommandResponse>(
                command.CommandDomain(), cancellationToken
            );

        return new AppRegistrationSubjectCommandResponse(commandResponse.IsRegistration, commandResponse.Message);
    }
}