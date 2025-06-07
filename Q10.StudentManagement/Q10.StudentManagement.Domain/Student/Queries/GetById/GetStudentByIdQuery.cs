using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Student.Queries.GetById;

public record GetStudentByIdQuery(int Id): IQuery;