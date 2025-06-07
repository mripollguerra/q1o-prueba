using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Subject.Commands.Remove;

public record RemoveSubjectCommand(int Id): ICommand;