using Microsoft.Extensions.DependencyInjection;

namespace Q10.StudentManagement.Library.Cqrs.Commands.Implementations;

public class CommandDispatcher(
    IServiceProvider serviceProvider
) : ICommandDispatcher
{
    public async Task<TResult> ExecAsync<TCommand, TResult>(TCommand command,
        CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
        where TResult : class
    {
        var handler = serviceProvider.GetService<ICommandHandler<TCommand, TResult>>()
                      ?? throw new Exception(
                          $"No handler found for {typeof(ICommandHandler<TCommand, TResult>).FullName}");

        return await handler.HandleAsync(command, cancellationToken);
    }
}