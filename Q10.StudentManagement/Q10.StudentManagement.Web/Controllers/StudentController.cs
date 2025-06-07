using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Application.Student.Commands.Create;
using Q10.StudentManagement.Application.Student.Commands.Update;
using Q10.StudentManagement.Application.Student.Queries.GetById;
using Q10.StudentManagement.Application.Student.Queries.GetManyByFilters;
using Q10.StudentManagement.Domain.Student.Commands.Remove;
using Q10.StudentManagement.Library.Cqrs.Commands;
using Q10.StudentManagement.Library.Cqrs.Queries;
using Q10.StudentManagement.Web.Models.Student;

namespace Q10.StudentManagement.Web.Controllers;

[Route("student")]
public class StudentController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public StudentController(
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
            AppGetManyByFiltersStudentQuery,
            AppGetManyByFiltersStudentQueryResponse>(
            new AppGetManyByFiltersStudentQuery("desc", 1, 20)
        );

        return View(result.Students);
    }
    
    [HttpGet("create")]
    public IActionResult Create() => View();

    [HttpPost("create")]
    public async Task<IActionResult> Create(StudentCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _commandDispatcher.ExecAsync<
            AppCreateStudentCommand,
            AppCreateStudentCommandResponse>(
            new AppCreateStudentCommand(model.FullName, model.Document, model.Email)
        );

        return RedirectToAction("Index");
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _queryDispatcher.QueryAsync<
            AppGetByIdStudentQuery,
            AppGetByIdStudentQueryResponse>(
            new AppGetByIdStudentQuery(id)
        );

        if (result?.Student == null)
        {
            return NotFound();
        }
        
        var model = new StudentEditViewModel
        {
            Id = result.Student.Id,
            FullName = result.Student.FullName,
            Document = result.Student.DocumentNumber,
            Email = result.Student.Email
        };

        return View(model);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(StudentEditViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _commandDispatcher.ExecAsync<
            AppUpdateStudentCommand,
            AppUpdateStudentCommandResponse>(
            new AppUpdateStudentCommand(model.Id, model.FullName, model.Document, model.Email)
        );

        return RedirectToAction("Index");
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _commandDispatcher.ExecAsync<
            RemoveStudentCommand,
            RemoveStudentCommandResponse>(
            new RemoveStudentCommand(id)
        );

        return RedirectToAction("Index");
    }
}