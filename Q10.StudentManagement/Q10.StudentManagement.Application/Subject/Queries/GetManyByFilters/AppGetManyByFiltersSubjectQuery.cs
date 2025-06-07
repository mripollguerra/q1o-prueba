using Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.Subject.Queries.GetManyByFilters;

public record AppGetManyByFiltersSubjectQuery(
    string OrderBy,
    int Page,
    int ItemPerPage
) : IQuery
{
    public GetManyByFiltersSubjectQuery QueryDomain()
    {
        var filters = new SubjectFilters(OrderBy, Page, ItemPerPage);
        return new GetManyByFiltersSubjectQuery(filters);
    }
}