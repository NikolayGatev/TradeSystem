using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Web.Controllers;

namespace TradeSystem.Web.Attributes
{
    public class MustBeClientAccount : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IClientService? clientService = context.HttpContext.RequestServices.GetService<IClientService>();

            if (clientService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (clientService != null
                && clientService.ExistClientByUserIdAsync(Guid.Parse(context.HttpContext.User.Id())).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
