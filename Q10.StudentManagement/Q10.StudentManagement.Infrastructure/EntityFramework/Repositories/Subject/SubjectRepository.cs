using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Domain.Subject;
using Q10.StudentManagement.Domain.Subject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Repository;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Repositories.Subject;

public class SubjectRepository(IRepository repository) : ISubjectRepository
{
    public async Task<int> AddAsync(Domain.Subject.Subject subject)
    {
        var entity = new Entities.Subject.Subject()
        {
            Name = subject.Name,
            Code = subject.Code,
            Credits = subject.Credits
        };

        repository.Set<Entities.Subject.Subject>().Add(entity);
        await repository.Context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<bool> UpdateByIdAsync(Domain.Subject.Subject subject)
    {
        var subjectEntity = await repository.Set<Entities.Subject.Subject>().FindAsync(subject.Id);
        if (subjectEntity == null) return false;

        subjectEntity.Name = subject.Name;
        subjectEntity.Code = subject.Code;
        subjectEntity.Credits = subject.Credits;

        repository.Set<Entities.Subject.Subject>().Update(subjectEntity);
        await repository.Context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveByIdAsync(int id)
    {
        var subjectEntity = await repository.Set<Entities.Subject.Subject>().FindAsync(id);
        if (subjectEntity == null) return false;

        repository.Set<Entities.Subject.Subject>().Remove(subjectEntity);
        await repository.Context.SaveChangesAsync();

        return true;
    }

    public async Task<Domain.Subject.Subject?> GetByIdAsync(int id)
    {
        var subject = await repository.Context.FindAsync<Entities.Subject.Subject>(id);
        return subject?.ToDomain();
    }

    public async Task<IEnumerable<Domain.Subject.Subject>> GetManyByFiltersAsync(SubjectFilters filters)
    {
        var query = repository.Context.Set<Entities.Subject.Subject>().AsQueryable();

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