namespace Q10.StudentManagement.Infrastructure.EntityFramework.Entities.Student;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string DocumentNumber { get; set; }
    public string Email { get; set; }
    public IEnumerable<RegistrationSubject.RegistrationSubject> RegistrationSubjects { get; set; }

    public Domain.Student.Student ToDomain()
    {
        return new Domain.Student.Student()
        {
            Id = Id,
            FullName = FullName,
            DocumentNumber = DocumentNumber,
            Email = Email
        };
    }
}