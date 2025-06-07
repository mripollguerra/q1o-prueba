using Q10.StudentManagement.Domain.Student.Queries.GetById;

namespace Q10.StudentManagement.Application.Student.Queries.GetById;

public record AppGetByIdStudentQuery(int Id): GetStudentByIdQuery(Id);