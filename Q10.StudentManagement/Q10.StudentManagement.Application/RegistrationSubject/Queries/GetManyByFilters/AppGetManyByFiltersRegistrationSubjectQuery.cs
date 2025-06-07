using Q10.StudentManagement.Domain.RegistrationSubject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.RegistrationSubject.Queries.GetManyByFilters;

public record AppGetManyByFiltersRegistrationSubjectQuery(
    string OrderBy,
    int Page,
    int ItemPerPage
) : IQuery
{
    public GetManyByFiltersRegistrationSubjectQuery QueryDomain()
    {
        var filters = new RegistrationSubjectFilters(OrderBy, Page, ItemPerPage);
        return new GetManyByFiltersRegistrationSubjectQuery(filters);
    }
}