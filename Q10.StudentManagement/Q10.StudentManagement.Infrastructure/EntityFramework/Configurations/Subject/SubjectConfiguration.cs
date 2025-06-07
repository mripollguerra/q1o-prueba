using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Configurations.Subject;

public class SubjectConfiguration : IEntityTypeConfiguration<Entities.Subject.Subject>
{
    public void Configure(EntityTypeBuilder<Entities.Subject.Subject> builder)
    {
        builder.HasKey(c => c.Id);
    }
}