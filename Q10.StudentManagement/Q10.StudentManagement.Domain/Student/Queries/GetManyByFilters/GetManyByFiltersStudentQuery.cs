using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;

public record GetManyByFiltersStudentQuery(StudentFilters Filters) : IQuery;

public record StudentFilters(
    string OrderBy,
    int Page,
    int ItemPerPage
);