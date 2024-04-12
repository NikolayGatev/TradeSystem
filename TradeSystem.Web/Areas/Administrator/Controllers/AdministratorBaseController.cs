using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TradeSystem.Common.AdministratorConstants;

namespace TradeSystem.Web.Areas.Administrator.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]

    public class AdministratorBaseController : Controller
    {
    }
}
