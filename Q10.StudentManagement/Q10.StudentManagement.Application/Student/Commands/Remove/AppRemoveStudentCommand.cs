using Q10.StudentManagement.Domain.Student.Commands.Remove;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Student.Commands.Remove;

public record AppRemoveStudentCommand(int Id) : ICommand
{
    public RemoveStudentCommand CommandDomain()
    {
        return new RemoveStudentCommand(Id);
    }
}