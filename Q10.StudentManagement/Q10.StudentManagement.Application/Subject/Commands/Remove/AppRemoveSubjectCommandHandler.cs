using Q10.StudentManagement.Domain.Student.Commands.Remove;
using Q10.StudentManagement.Domain.Subject.Commands.Remove;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Subject.Commands.Remove;

public class AppRemoveSubjectCommandHandler(
    ICommandDispatcher commandDispatcher
) : ICommandHandler<AppRemoveSubjectCommand, AppRemoveSubjectCommandResponse>
{
    public async Task<AppRemoveSubjectCommandResponse> HandleAsync(AppRemoveSubjectCommand command,
        CancellationToken cancellationToken = default)
    {
        var commandResponse = await commandDispatcher
            .ExecAsync<RemoveSubjectCommand, RemoveStudentCommandResponse>(
                command.CommandDomain(), cancellationToken
            );

        return new AppRemoveSubjectCommandResponse(commandResponse.IsRemove);
    }
}