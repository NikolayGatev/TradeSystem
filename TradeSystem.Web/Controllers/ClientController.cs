using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Clients;
using static TradeSystem.Common.ErrorConstants;

namespace TradeSystem.Web.Controllers
{    
    public class ClientController : BaseController
    {
        private readonly IClientService clientService;

        public ClientController(
            IClientService clientService)
        {
            this.clientService = clientService;
        }
        [HttpGet]

        public async Task<IActionResult> AddDataNewIndividualClient()
        {
            var model = new IndividualDataClentFormModel()
            {
                Nationalities = await clientService.AllCountriesAsync(),
            }; 
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> AddDataNewIndividualClient(IndividualDataClentFormModel model)
        {
            Guid user = Guid.Parse(User.Id());

            if (await clientService.GetIdOfDataOfIndividualClientByUserIdAsync(user) != null)
            {
                ModelState.AddModelError(nameof(model.Surname), ExistClient);
            }

            if (await clientService.CountryExistsAsync(model.NationalityId) == false)
            {
                ModelState.AddModelError(nameof(model.NationalityId), NationalityRestricted);
            }

            if(ModelState.IsValid == false)
            {
                model.Nationalities = await clientService.AllCountriesAsync();

                return View(model);
            }

            Guid newClient = await clientService.CreateDataOfIndividualClientAsync(model, user);
            
            return View();
        }

    }
}
