namespace Q10.StudentManagement.Domain.RegistrationSubject;

public class RegistrationSubject
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student.Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject.Subject Subject { get; set; }
}