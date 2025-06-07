using Q10.StudentManagement.Domain.Subject.Queries.GetById;

namespace Q10.StudentManagement.Application.Subject.Queries.GetById;

public record AppGetByIdSubjectQueryResponse(Domain.Subject.Subject? Subject) : GetByIdSubjectQueryResponse(Subject);