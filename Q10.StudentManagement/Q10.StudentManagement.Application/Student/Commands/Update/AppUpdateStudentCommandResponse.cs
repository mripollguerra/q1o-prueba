using Q10.StudentManagement.Domain.Student.Commands.Update;

namespace Q10.StudentManagement.Application.Student.Commands.Update;

public record AppUpdateStudentCommandResponse(bool IsUpdate) : UpdateStudentCommandResponse(IsUpdate);