namespace Q10.StudentManagement.Library.Cqrs.Commands;

public interface ICommandDispatcher
{
    Task<TResult> ExecAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
        where TResult : class;
}