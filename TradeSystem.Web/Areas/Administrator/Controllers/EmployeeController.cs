using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Administrator;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Core.Services;

namespace TradeSystem.Web.Areas.Administrator.Controllers
{
    public class EmployeeController : AdministratorBaseController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]

        public async Task<IActionResult> AllEmployees([FromQuery] AllEmployeesQueryModel query)
        {
            var userId = User.Id();

            var model = await employeeService.AllAsyn(
                userId
                , query.EmployeeId
                , query.IsApproved
                , query.CurrentPage
                , query.EmployeesPerPage);

            query.TotalEmployeesCount = model.TotalEmployeeCount;
            query.Employees = model.Employees;

            return View(query);
        }
    }
}
