using Q10.StudentManagement.Domain.Subject.Commands.Create;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Subject.Commands.Create;

public record AppCreateSubjectCommand(
    string Name,
    string Code,
    decimal Credits
) : ICommand
{
    public CreateSubjectCommand CommandDomain()
    {
        var subject = new Domain.Subject.Subject()
        {
            Name = Name,
            Code = Code,
            Credits = Credits
        };

        return new CreateSubjectCommand(subject);
    }
}