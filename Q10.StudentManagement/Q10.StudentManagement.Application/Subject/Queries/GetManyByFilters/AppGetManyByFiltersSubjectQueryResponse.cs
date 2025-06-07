using Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;

namespace Q10.StudentManagement.Application.Subject.Queries.GetManyByFilters;

public record AppGetManyByFiltersSubjectQueryResponse(IEnumerable<Domain.Subject.Subject> Subjects)
    : GetManyByFiltersSubjectQueryResponse(Subjects);