using Q10.StudentManagement.Domain.RegistrationSubject;
using Q10.StudentManagement.Domain.Student;
using Q10.StudentManagement.Domain.Subject;

namespace Q10.StudentManagement.Domain;

public interface IUnitOfWork
{
    public IStudentRepository StudentRepository { get; }
    public ISubjectRepository SubjectRepository { get; }
    public IRegistrationSubjectRepository RegistrationSubjectRepository { get; }
}