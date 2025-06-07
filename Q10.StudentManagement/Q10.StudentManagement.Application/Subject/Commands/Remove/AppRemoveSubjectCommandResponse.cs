using Q10.StudentManagement.Domain.Subject.Commands.Remove;

namespace Q10.StudentManagement.Application.Subject.Commands.Remove;

public record AppRemoveSubjectCommandResponse(bool IsRemove) : RemoveSubjectCommandResponse(IsRemove);