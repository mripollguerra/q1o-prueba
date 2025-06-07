namespace Q10.StudentManagement.Infrastructure.EntityFramework.Entities.RegistrationSubject;

public class RegistrationSubject
{
    public int Id { get; set; }
    public required int StudentId { get; set; }
    public Student.Student Student { get; set; }
    public required int SubjectId { get; set; }
    public Subject.Subject Subject { get; set; }

    public Domain.RegistrationSubject.RegistrationSubject ToDomain()
    {
        return new Domain.RegistrationSubject.RegistrationSubject()
        {
            Id = Id,
            StudentId = StudentId,
            SubjectId = SubjectId,
            Subject = Subject.ToDomain(),
            Student = Student.ToDomain()
        };
    }
}