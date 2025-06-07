using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Subject.Commands.Update;

public record UpdateSubjectCommand(Subject Subject) : ICommand;