using EmployeesApp.Web.Models;
using EmployeesApp.Web.Services;
using EmployeesApp.Web.Views.Employees;

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
      
            var viewModel = new IndexVM
            {
                ListOfIndexVmItems = [..model.Select(e => new IndexVM.IndexVMItems
                {
                    Id = e.Id,
                    Name = e.Name,
                    ShowAsHighlighted = service.SetHighlight(e.Email),
                    Email = e.Email,

                })]
            };

            //foreach (var emp in model)
            //    Console.WriteLine($"{emp.Name}: {emp.Id}");

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

            var model = new Employee()
            {
                Name = viewModel.Name,
                Email = viewModel.Email

            };

            service.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var model = service.GetById(id);
            var viewModel = new DetailsVM
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
            };
            return View(viewModel);
        }
    }
}
