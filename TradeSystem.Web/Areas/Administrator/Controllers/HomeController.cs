using Microsoft.AspNetCore.Mvc;

namespace TradeSystem.Web.Areas.Administrator.Controllers
{
    public class HomeController : AdministratorBaseController
    {
       public IActionResult DashBoard()
        {
            return View();
        }

        public async Task<IActionResult> TradeForReview()
        {
            return View();
        }
    }
}
