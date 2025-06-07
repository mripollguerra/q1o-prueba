namespace Q10.StudentManagement.Library.Cqrs.Commands;

public interface ICommandHandler<in TCommand, TResult>
    where TCommand : class, ICommand
    where TResult : class
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}