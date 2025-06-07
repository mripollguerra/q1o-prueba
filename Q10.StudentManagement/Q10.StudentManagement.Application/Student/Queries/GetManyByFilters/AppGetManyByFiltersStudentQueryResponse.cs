using Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;

namespace Q10.StudentManagement.Application.Student.Queries.GetManyByFilters;

public record AppGetManyByFiltersStudentQueryResponse(IEnumerable<Domain.Student.Student> Students) :
    GetManyByFiltersStudentQueryResponse(Students);