using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TradeSystem.Core.Contracts;

namespace TradeSystem.Web.Attributes
{
    public class HaveNotClientDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IClientService? clientService = context.HttpContext.RequestServices.GetService<IClientService>();

            if (clientService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if(clientService != null
                && (clientService.ExistDataIndividualClientByUserIdAsync(context.HttpContext.User.Id()).Result
                || clientService.ExistDataCorporativeClientByUserIdAsync(context.HttpContext.User.Id()).Result))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }
    }
}
