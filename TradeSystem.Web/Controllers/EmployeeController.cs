using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Employees;
using static TradeSystem.Common.ErrorConstants;

namespace TradeSystem.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService employeeServise;

        public EmployeeController(IEmployeeService employeeServise)
        {
            this.employeeServise = employeeServise;
        }

        [HttpGet]

        public async Task<IActionResult> AddNewEmployee()
        {
            var model = new EmployeeFormModel()
            {
                Divisions = await employeeServise.AllDivisionsAsync(),
            };

           return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> AddNewEmployee(EmployeeFormModel model)
        {
            Guid userId = Guid.Parse(User.Id());

            if(await employeeServise.DivisionExistsAsync(model.DivisionId) == false)
            {
                ModelState.AddModelError(nameof(model.DivisionId), UnknownDivision);
            }

            if(ModelState.IsValid == false)
            {
                model.Divisions = await employeeServise.AllDivisionsAsync();

                return View(model);
            }
            var newEmployee = await employeeServise.CreateEmployeeAsync(model, userId);

            return View();
        }
    }
}
