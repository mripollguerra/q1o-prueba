using Q10.StudentManagement.Domain.Subject.Commands.Update;

namespace Q10.StudentManagement.Application.Subject.Commands.Update;

public record AppUpdateSubjectCommandResponse(bool IsUpdate) : UpdateSubjectCommandResponse(IsUpdate);