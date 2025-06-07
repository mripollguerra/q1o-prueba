using Q10.StudentManagement.Domain.Student.Commands.Create;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Student.Commands.Create;

public record AppCreateStudentCommand(
    string FullName,
    string DocumentNumber,
    string Email
) : ICommand
{
    public CreateStudentCommand CommandDomain()
    {
        var student = new Domain.Student.Student()
        {
            FullName = FullName,
            DocumentNumber = DocumentNumber,
            Email = Email
        };

        return new CreateStudentCommand(student);
    }
}