using Q10.StudentManagement.Domain.Student.Commands.Create;

namespace Q10.StudentManagement.Application.Student.Commands.Create;

public record AppCreateStudentCommandResponse(int Id) : CreateStudentCommandResponse(Id);