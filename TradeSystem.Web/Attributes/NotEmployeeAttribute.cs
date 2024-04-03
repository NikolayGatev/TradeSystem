using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TradeSystem.Core.Contracts;
using System.Security.Claims;

namespace TradeSystem.Web.Attributes
{
    public class NotEmployeeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IEmployeeService? employeeService = context.HttpContext.RequestServices.GetService<IEmployeeService>();

            if (employeeService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (employeeService != null
                && employeeService.ExistsByUserIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
