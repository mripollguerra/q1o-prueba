using Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Queries;

namespace Q10.StudentManagement.Application.Student.Queries.GetManyByFilters;

public record AppGetManyByFiltersStudentQuery(
    string OrderBy,
    int Page,
    int ItemPerPage
) : IQuery
{
    public GetManyByFiltersStudentQuery QueryDomain()
    {
        var filters = new StudentFilters(OrderBy, Page, ItemPerPage);
        return new GetManyByFiltersStudentQuery(filters);
    }
}