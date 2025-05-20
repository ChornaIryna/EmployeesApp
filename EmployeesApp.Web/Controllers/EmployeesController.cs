using EmployeesApp.Web.Models;
using EmployeesApp.Web.Services;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Web.Controllers;

public class EmployeesController : Controller
{
    static EmployeeService service = new EmployeeService();

    [HttpGet("")]
    public IActionResult Index()
    {
        var model = service.GetAll();
        var viewModel = model.Select(e => new IndexVM
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            ShowAsHighlighted = service.IsAdmin(e.Email)
        }).ToArray();

        return View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        var employee = new Employee
        {
            Name = viewModel.Name,
            Email = viewModel.Email
        };
        service.Add(employee);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("details/{id}")]
    public IActionResult Details(int id)
    {
        var model = service.GetById(id);
        return View(model);
    }
}
