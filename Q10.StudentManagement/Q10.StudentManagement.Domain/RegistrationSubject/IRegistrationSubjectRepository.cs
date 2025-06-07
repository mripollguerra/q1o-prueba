using Q10.StudentManagement.Domain.RegistrationSubject.Queries.GetManyByFilters;

namespace Q10.StudentManagement.Domain.RegistrationSubject;

public interface IRegistrationSubjectRepository
{
    Task<int> AddAsync(RegistrationSubject registrationSubject);
    Task<bool> CanRegisterSubjectByStudentIdAsync(int studentId);
    Task<bool> IsSubjectAlreadyRegisteredAsync(int studentId, int subjectId);
    Task<IEnumerable<RegistrationSubject>> GetManyByFiltersAsync(RegistrationSubjectFilters filters);
}