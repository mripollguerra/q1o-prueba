using Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;

namespace Q10.StudentManagement.Domain.Student;

public interface IStudentRepository
{
    Task<int> AddAsync(Student student);
    Task<bool> UpdateByIdAsync(Student student);
    Task<bool> RemoveByIdAsync(int id);
    Task<Student?> GetByIdAsync(int id);
    Task<IEnumerable<Student>> GetManyByFiltersAsync(StudentFilters filters);
}