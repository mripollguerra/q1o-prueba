using Q10.StudentManagement.Domain.Subject.Commands.Update;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.Subject.Commands.Update;

public record AppUpdateSubjectCommand(
    int Id,
    string Name,
    string Code,
    decimal Credits
) : ICommand
{
    public UpdateSubjectCommand CommandDomain()
    {
        var subject = new Domain.Subject.Subject()
        {
            Id = Id,
            Name = Name,
            Code = Code,
            Credits = Credits
        };

        return new UpdateSubjectCommand(subject);
    }
}