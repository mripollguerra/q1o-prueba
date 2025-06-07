using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Domain.RegistrationSubject.Queries.GetManyByFilters;

public record GetManyByFiltersRegistrationSubjectQuery(RegistrationSubjectFilters Filters) : IQuery;

public record RegistrationSubjectFilters(
    string OrderBy,
    int Page,
    int ItemPerPage
);