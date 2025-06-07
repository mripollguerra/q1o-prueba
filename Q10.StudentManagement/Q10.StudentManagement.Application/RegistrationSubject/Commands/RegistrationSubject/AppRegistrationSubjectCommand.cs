using Q10.StudentManagement.Domain.RegistrationSubject.Commands.RegistrationSubject;
using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Application.RegistrationSubject.Commands.RegistrationSubject;

public record AppRegistrationSubjectCommand(int StudentId, int SubjectId) : ICommand
{
    public RegistrationSubjectCommand CommandDomain()
    {
        var registrationSubject = new Domain.RegistrationSubject.RegistrationSubject()
        {
            StudentId = StudentId,
            SubjectId = SubjectId
        };

        return new RegistrationSubjectCommand(registrationSubject);
    }
}