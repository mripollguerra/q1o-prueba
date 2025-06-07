using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Domain.RegistrationSubject;
using Q10.StudentManagement.Domain.RegistrationSubject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Repository;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Repositories.RegistrationSubject;

public class RegistrationSubjectRepository(IRepository repository) : IRegistrationSubjectRepository
{
    public async Task<int> AddAsync(Domain.RegistrationSubject.RegistrationSubject registrationSubject)
    {
        var entity = new Entities.RegistrationSubject.RegistrationSubject()
        {
            StudentId = registrationSubject.StudentId,
            SubjectId = registrationSubject.SubjectId
        };

        repository.Set<Entities.RegistrationSubject.RegistrationSubject>().Add(entity);
        await repository.Context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<bool> CanRegisterSubjectByStudentIdAsync(int studentId)
    {
        var registrationSubjects = await repository.Context.Set<Entities.RegistrationSubject.RegistrationSubject>()
            .Include(rs => rs.Subject)
            .Where(rs => rs.StudentId == studentId)
            .ToListAsync();

        return registrationSubjects.Count(r=> r.Subject.Credits >= 4) >= 3;
    }

    public async Task<bool> IsSubjectAlreadyRegisteredAsync(int studentId, int subjectId)
    {
        return await repository.Set<Entities.RegistrationSubject.RegistrationSubject>()
            .AnyAsync(rs => rs.StudentId == studentId && rs.SubjectId == subjectId);
    }

    public async Task<IEnumerable<Domain.RegistrationSubject.RegistrationSubject>> GetManyByFiltersAsync(
        RegistrationSubjectFilters filters)
    {
        var query = repository.Context.Set<Entities.RegistrationSubject.RegistrationSubject>().AsQueryable();

        var orderedQuery = filters.OrderBy.ToLower() switch
        {
            "asc" => query.OrderBy(item => item.Id),
            "desc" => query.OrderByDescending(item => item.Id),
            _ => query.OrderBy(item => item.Id)
        };

        var registrationSubjects = await orderedQuery
            .Include(s => s.Subject)
            .Include(s => s.Student)
            .Skip((filters.Page - 1) * filters.ItemPerPage)
            .Take(filters.ItemPerPage)
            .ToListAsync();

        return registrationSubjects.Select(item => item.ToDomain());
    }
}