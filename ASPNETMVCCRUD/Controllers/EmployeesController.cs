using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDBContext mVCDemoDBContext;

        public EmployeesController(MVCDemoDBContext mVCDemoDBContext)
        {
            this.mVCDemoDBContext = mVCDemoDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mVCDemoDBContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeesViewModel addEmployeesRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeesRequest.Name,
                Email = addEmployeesRequest.Email,
                Salary = addEmployeesRequest.Salary,
                DateOfBirth = addEmployeesRequest.DateOfBirth,
                Department = addEmployeesRequest.Department
            };

            await mVCDemoDBContext.Employees.AddAsync(employee);
            await mVCDemoDBContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await mVCDemoDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department
                };
                return await Task.Run(() =>View("View", viewModel));
            }

            return RedirectToAction("View");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await mVCDemoDBContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name; 
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;

                await mVCDemoDBContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await mVCDemoDBContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                mVCDemoDBContext.Employees.Remove(employee);
                await mVCDemoDBContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
} 
