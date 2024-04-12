using Microsoft.AspNetCore.Mvc;

namespace TradeSystem.Web.Areas.Administrator.Components
{
    public class AdministratorMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
