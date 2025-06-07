using Q10.StudentManagement.Domain.Student.Commands.Remove;

namespace Q10.StudentManagement.Application.Student.Commands.Remove;

public record AppRemoveStudentCommandResponse(bool IsRemove) : RemoveStudentCommandResponse(IsRemove);