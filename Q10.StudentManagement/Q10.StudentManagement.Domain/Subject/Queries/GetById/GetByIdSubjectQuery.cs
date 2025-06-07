using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Subject.Queries.GetById;

public record GetByIdSubjectQuery(int Id) : IQuery;