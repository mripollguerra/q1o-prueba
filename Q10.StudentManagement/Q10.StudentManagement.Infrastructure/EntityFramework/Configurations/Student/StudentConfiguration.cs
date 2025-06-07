using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q10.StudentManagement.Infrastructure.EntityFramework.Configurations.Student;

public class StudentConfiguration : IEntityTypeConfiguration<Entities.Student.Student>
{
    public void Configure(EntityTypeBuilder<Entities.Student.Student> builder)
    {
        builder.HasKey(c => c.Id);
    }
}