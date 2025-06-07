using Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;

namespace Q10.StudentManagement.Domain.Subject;

public interface ISubjectRepository
{
    Task<int> AddAsync(Subject subject);
    Task<bool> UpdateByIdAsync(Subject subject);
    Task<bool> RemoveByIdAsync(int id);
    Task<Subject?> GetByIdAsync(int id);
    Task<IEnumerable<Subject>> GetManyByFiltersAsync(SubjectFilters filters);
}