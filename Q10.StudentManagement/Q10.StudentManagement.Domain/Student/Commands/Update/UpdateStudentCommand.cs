using Q10.StudentManagement.Library.Cqrs.Commands;

namespace Q10.StudentManagement.Domain.Student.Commands.Update;

public record UpdateStudentCommand(Student Student) : ICommand;