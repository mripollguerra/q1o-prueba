using Microsoft.EntityFrameworkCore;
using Q10.StudentManagement.Infrastructure.EntityFramework.Entities.Student;
using Q10.StudentManagement.Library.Options;
using Q10.StudentManagement.Library.Repository.Abstracts;
using Microsoft.Extensions.Options;
using Q10.StudentManagement.Infrastructure.EntityFramework.Entities.RegistrationSubject;
using Q10.StudentManagement.Infrastructure.EntityFramework.Entities.Subject;

namespace Q10.StudentManagement.Infrastructure.EntityFramework;

public class Q10Context(
    DbContextOptions<Q10Context> dbContextOptions,
    IOptions<RepositoryOptions> repositoryOptions,
    IServiceProvider serviceProvider) : BaseContext(dbContextOptions, serviceProvider, repositoryOptions)
{
    public required DbSet<Student> Students { get; set; }
    public required DbSet<Subject> Subjects { get; set; }
    public required DbSet<RegistrationSubject> RegistrationSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Q10Context).Assembly);
    }
}