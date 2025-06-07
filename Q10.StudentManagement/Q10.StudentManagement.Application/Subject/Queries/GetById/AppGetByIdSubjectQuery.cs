using Q10.StudentManagement.Domain.Subject.Queries.GetById;

namespace Q10.StudentManagement.Application.Subject.Queries.GetById;

public record AppGetByIdSubjectQuery(int Id) : GetByIdSubjectQuery(Id);