using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Student.Commands.Create;

public record CreateStudentCommand(Student Student) : ICommand;