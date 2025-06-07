using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Q10.StudentManagement.Application.RegistrationSubject.Commands.RegistrationSubject;
using Q10.StudentManagement.Application.RegistrationSubject.Queries.GetManyByFilters;
using Q10.StudentManagement.Application.Student.Queries.GetManyByFilters;
using Q10.StudentManagement.Application.Subject.Queries.GetManyByFilters;
using Q10.StudentManagement.Library.Cqrs.Commands;
using Q10.StudentManagement.Library.Cqrs.Queries;
using Q10.StudentManagement.Web.Models.RegistrationSubject;

namespace Q10.StudentManagement.Web.Controllers;

[Route("registration-subjects")]
public class RegistrationSubjectController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public RegistrationSubjectController(
        [FromServices] ICommandDispatcher commandDispatcher,
        [FromServices] IQueryDispatcher queryDispatcher
    )
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var result = await _queryDispatcher.QueryAsync<
            AppGetManyByFiltersRegistrationSubjectQuery,
            AppGetManyByFiltersRegistrationSubjectQueryResponse>(
            new AppGetManyByFiltersRegistrationSubjectQuery("desc", 1, 20)
        );

        return View(result.RegistrationSubjects);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var model = new RegistrationSubjectRegistrationViewModel();
        await LoadSelectListsAsync(model);

        return View(model);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(RegistrationSubjectRegistrationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadSelectListsAsync(model);
            return View(model);
        }

        var resultResponse = await _commandDispatcher.ExecAsync<
            AppRegistrationSubjectCommand,
            AppRegistrationSubjectCommandResponse>(
            new AppRegistrationSubjectCommand(model.StudentId, model.SubjectId)
        );

        if (resultResponse.IsRegistration) return RedirectToAction("Index");
        
        await LoadSelectListsAsync(model);
        TempData["ErrorMessage"] = resultResponse.Message;
        return View(model);
    }
    
    private async Task LoadSelectListsAsync(RegistrationSubjectRegistrationViewModel model)
    {
        var students = await _queryDispatcher.QueryAsync<
            AppGetManyByFiltersStudentQuery,
            AppGetManyByFiltersStudentQueryResponse>(
            new AppGetManyByFiltersStudentQuery("desc", 1, 1000)
        );

        var subjects = await _queryDispatcher.QueryAsync<
            AppGetManyByFiltersSubjectQuery,
            AppGetManyByFiltersSubjectQueryResponse>(
            new AppGetManyByFiltersSubjectQuery("desc", 1, 1000)
        );

        model.Students = students.Students.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.FullName
        }).ToList();
        
        model.Subjects = subjects.Subjects.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToList();
    }
}