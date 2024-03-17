using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradeSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
