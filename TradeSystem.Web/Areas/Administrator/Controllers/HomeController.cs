using Microsoft.AspNetCore.Mvc;

namespace TradeSystem.Web.Areas.Administrator.Controllers
{
    public class HomeController : AdministratorBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
