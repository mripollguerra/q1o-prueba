using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Configurations.RegistrationSubject;

public class
    RegistrationSubjectConfiguration : IEntityTypeConfiguration<Entities.RegistrationSubject.RegistrationSubject>
{
    public void Configure(EntityTypeBuilder<Entities.RegistrationSubject.RegistrationSubject> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(x => x.Student)
            .WithMany(s => s.RegistrationSubjects)
            .HasForeignKey(x => x.StudentId);
        builder.HasOne(x => x.Subject)
            .WithMany(s => s.RegistrationSubjects)
            .HasForeignKey(x => x.SubjectId);
    }
}