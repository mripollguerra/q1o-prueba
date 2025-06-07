using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Student.Commands.Remove;

public record RemoveStudentCommand(int Id) : ICommand;