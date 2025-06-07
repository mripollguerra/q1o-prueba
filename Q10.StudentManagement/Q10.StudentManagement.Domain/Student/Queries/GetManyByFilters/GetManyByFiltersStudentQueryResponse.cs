namespace Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;

public record GetManyByFiltersStudentQueryResponse(IEnumerable<Student> Students);