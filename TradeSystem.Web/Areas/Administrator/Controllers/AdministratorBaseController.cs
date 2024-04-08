using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TradeSystem.Common.RoleConstants;

namespace TradeSystem.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = AdminRole)]

    public class AdministratorBaseController : Controller
    {
    }
}
