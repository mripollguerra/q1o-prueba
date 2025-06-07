using Q10.StudentManagement.Domain;
using Q10.StudentManagement.Domain.RegistrationSubject;
using Q10.StudentManagement.Domain.Student;
using Q10.StudentManagement.Domain.Subject;
using Q10.StudentManagement.Infrastructure.EntityFramework.Repositories.RegistrationSubject;
using Q10.StudentManagement.Infrastructure.EntityFramework.Repositories.Student;
using Q10.StudentManagement.Infrastructure.EntityFramework.Repositories.Subject;
using Q10.StudentManagement.Library.Repository;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Repositories;

public sealed class UnitOfWork(IRepository repository) : IUnitOfWork
{
    private IStudentRepository? _studentRepository;
    private ISubjectRepository? _subjectRepository;
    private IRegistrationSubjectRepository? _registrationSubjectRepository;

    public IStudentRepository StudentRepository
    {
        get { return _studentRepository ??= new StudentRepository(repository); }
    }

    public ISubjectRepository SubjectRepository
    {
        get { return _subjectRepository ??= new SubjectRepository(repository); }
    }

    public IRegistrationSubjectRepository RegistrationSubjectRepository
    {
        get {return _registrationSubjectRepository ??= new RegistrationSubjectRepository(repository);}
    }
}