using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Data.Models;
using TradeSystem.Web.Attributes;
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
        [NotEmployee]

        public async Task<IActionResult> AddNewEmployee()
        {
            var model = new EmployeeFormModel()
            {
                Divisions = await employeeServise.AllDivisionsAsync(),
            };

           return View(model);
        }

        [HttpPost]
        [NotEmployee]

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
            
            var newEmployeeId = await employeeServise.CreateEmployeeAsync(model, userId);

            return RedirectToAction(nameof(EmployeeDetails), new {employeeId = newEmployeeId});
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> EmployeeDetails(Guid employeeId)
        {           
            var model = await employeeServise.DetailsOfEmployeeByIdAsync(employeeId);

            return View(model);
        }        
    }
}
