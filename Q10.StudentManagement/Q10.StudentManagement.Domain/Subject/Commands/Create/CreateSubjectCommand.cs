using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Subject.Commands.Create;

public record CreateSubjectCommand(Subject Subject) : ICommand;