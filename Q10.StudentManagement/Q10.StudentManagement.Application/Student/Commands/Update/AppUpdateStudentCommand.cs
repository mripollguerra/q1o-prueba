using Q10.StudentManagement.Domain.Student.Commands.Update;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Student.Commands.Update;

public record AppUpdateStudentCommand(
    int Id,
    string FullName,
    string DocumentNumber,
    string Email
) : ICommand
{
    public UpdateStudentCommand CommandDomain()
    {
        var student = new Domain.Student.Student()
        {
            Id = Id,
            FullName = FullName,
            DocumentNumber = DocumentNumber,
            Email = Email
        };

        return new UpdateStudentCommand(student);
    }
}