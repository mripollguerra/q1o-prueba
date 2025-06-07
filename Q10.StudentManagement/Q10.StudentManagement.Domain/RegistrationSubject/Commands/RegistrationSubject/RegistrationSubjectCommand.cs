using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.RegistrationSubject.Commands.RegistrationSubject;

public record RegistrationSubjectCommand(Domain.RegistrationSubject.RegistrationSubject RegistrationSubject) : ICommand;