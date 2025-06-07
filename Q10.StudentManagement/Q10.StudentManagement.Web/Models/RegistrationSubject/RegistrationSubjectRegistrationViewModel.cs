using Microsoft.AspNetCore.Mvc.Rendering;

namespace Q10.StudentManagement.Web.Models.RegistrationSubject;

public class RegistrationSubjectRegistrationViewModel
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    
    public IEnumerable<SelectListItem>? Students { get; set; }
    public IEnumerable<SelectListItem>? Subjects { get; set; }
}