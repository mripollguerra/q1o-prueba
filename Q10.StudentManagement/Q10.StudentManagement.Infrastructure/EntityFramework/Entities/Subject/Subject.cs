namespace Q10.StudentManagement.Infrastructure.EntityFramework.Entities.Subject;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Credits { get; set; }
    public IEnumerable<RegistrationSubject.RegistrationSubject> RegistrationSubjects { get; set; }

    public Domain.Subject.Subject ToDomain()
    {
        return new Domain.Subject.Subject()
        {
            Id = Id,
            Name = Name,
            Code = Code,
            Credits = Credits
        };
    }
}