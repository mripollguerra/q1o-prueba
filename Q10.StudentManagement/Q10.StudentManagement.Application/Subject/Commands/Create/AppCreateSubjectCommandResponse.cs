using Q10.StudentManagement.Domain.Subject.Commands.Create;

namespace Q10.StudentManagement.Application.Subject.Commands.Create;

public record AppCreateSubjectCommandResponse(int Id) : CreateSubjectCommandResponse(Id);