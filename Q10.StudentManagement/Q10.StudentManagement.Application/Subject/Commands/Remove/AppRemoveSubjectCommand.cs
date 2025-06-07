using Q10.StudentManagement.Domain.Subject.Commands.Remove;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Subject.Commands.Remove;

public record AppRemoveSubjectCommand(int Id) : ICommand
{
    public RemoveSubjectCommand CommandDomain()
    {
        return new RemoveSubjectCommand(Id);
    }
}