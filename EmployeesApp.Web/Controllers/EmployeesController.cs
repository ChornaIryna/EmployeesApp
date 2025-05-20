using EmployeesApp.Web.Models;
using EmployeesApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Web.Controllers
{
    public class EmployeesController : Controller
    {
        static EmployeeService service = new EmployeeService();

        [HttpGet("")]
        public IActionResult Index()
        {
            var model = service.GetAll();

            //foreach (var emp in model)
            //    Console.WriteLine($"{emp.Name}: {emp.Id}");

            return View(model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();

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
}
