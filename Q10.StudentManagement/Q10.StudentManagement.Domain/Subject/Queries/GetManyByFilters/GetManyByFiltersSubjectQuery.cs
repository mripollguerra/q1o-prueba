using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;

public record GetManyByFiltersSubjectQuery(SubjectFilters Filters) : IQuery;

public record SubjectFilters(
    string OrderBy,
    int Page,
    int ItemPerPage
);