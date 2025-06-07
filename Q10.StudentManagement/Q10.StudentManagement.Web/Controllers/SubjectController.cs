using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Application.Subject.Commands.Create;
using Q10.StudentManagement.Application.Subject.Commands.Update;
using Q10.StudentManagement.Application.Subject.Queries.GetById;
using Q10.StudentManagement.Application.Subject.Queries.GetManyByFilters;
using Q10.StudentManagement.Domain.Subject.Commands.Remove;
using Q10.StudentManagement.Library.Cqrs.Commands;
using Q10.StudentManagement.Library.Cqrs.Queries;
using Q10.StudentManagement.Web.Models.Subject;

namespace Q10.StudentManagement.Web.Controllers;

[Route("subject")]
public class SubjectController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public SubjectController(
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
            AppGetManyByFiltersSubjectQuery,
            AppGetManyByFiltersSubjectQueryResponse>(
            new AppGetManyByFiltersSubjectQuery("desc", 1, 20)
        );

        return View(result.Subjects);
    }
    
    [HttpGet("create")]
    public IActionResult Create() => View();

    [HttpPost("create")]
    public async Task<IActionResult> Create(SubjectCreateViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _commandDispatcher.ExecAsync<
            AppCreateSubjectCommand,
            AppCreateSubjectCommandResponse>(
            new AppCreateSubjectCommand(model.Name, model.Code, model.Credits)
        );

        return RedirectToAction("Index");
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _queryDispatcher.QueryAsync<
            AppGetByIdSubjectQuery,
            AppGetByIdSubjectQueryResponse>(
            new AppGetByIdSubjectQuery(id)
        );

        if (result?.Subject == null)
        {
            return NotFound();
        }
        
        var model = new SubjectEditViewModel
        {
            Id = result.Subject.Id,
            Name = result.Subject.Name,
            Code = result.Subject.Code,
            Credits = result.Subject.Credits
        };

        return View(model);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(SubjectEditViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _commandDispatcher.ExecAsync<
            AppUpdateSubjectCommand,
            AppUpdateSubjectCommandResponse>(
            new AppUpdateSubjectCommand(model.Id, model.Name, model.Code, model.Credits)
        );

        return RedirectToAction("Index");
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _commandDispatcher.ExecAsync<
            RemoveSubjectCommand,
            RemoveSubjectCommandResponse>(
            new RemoveSubjectCommand(id)
        );

        return RedirectToAction("Index");
    }
}