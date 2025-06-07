using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Domain.Student;
using Q10.StudentManagement.Domain.Student.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Repository;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Repositories.Student;

public class StudentRepository(IRepository repository) : IStudentRepository
{
    public async Task<int> AddAsync(Domain.Student.Student student)
    {
        var entity = new Entities.Student.Student()
        {
            FullName = student.FullName,
            Email = student.Email,
            DocumentNumber = student.DocumentNumber
        };

        repository.Set<Entities.Student.Student>().Add(entity);
        await repository.Context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<bool> UpdateByIdAsync(Domain.Student.Student student)
    {
        var studentEntity = await repository.Set<Entities.Student.Student>().FindAsync(student.Id);
        if (studentEntity == null) return false;

        studentEntity.FullName = student.FullName;
        studentEntity.Email = student.Email;
        studentEntity.DocumentNumber = student.DocumentNumber;

        repository.Set<Entities.Student.Student>().Update(studentEntity);
        await repository.Context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveByIdAsync(int id)
    {
        var studentEntity = await repository.Set<Entities.Student.Student>().FindAsync(id);
        if (studentEntity == null) return false;

        repository.Set<Entities.Student.Student>().Remove(studentEntity);
        await repository.Context.SaveChangesAsync();

        return true;
    }

    public async Task<Domain.Student.Student?> GetByIdAsync(int id)
    {
        var student = await repository.Context.FindAsync<Entities.Student.Student>(id);
        return student?.ToDomain();
    }

    public async Task<IEnumerable<Domain.Student.Student>> GetManyByFiltersAsync(StudentFilters filters)
    {
        var query = repository.Context.Set<Entities.Student.Student>().AsQueryable();

        var orderedQuery = filters.OrderBy.ToLower() switch
        {
            "asc" => query.OrderBy(item => item.Id),
            "desc" => query.OrderByDescending(item => item.Id),
            _ => query.OrderBy(item => item.Id)
        };

        var students = await orderedQuery
            .Skip((filters.Page - 1) * filters.ItemPerPage)
            .Take(filters.ItemPerPage)
            .ToListAsync();

        return students.Select(item => item.ToDomain());
    }
}