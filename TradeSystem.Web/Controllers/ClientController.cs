using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Services;
using TradeSystem.Data.Models;
using TradeSystem.Web.Attributes;
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
        [HaveNotIndividualClientData]

        public async Task<IActionResult> AddDataNewIndividualClient()
        {
            var model = new IndividualDataClentFormModel()
            {
                Nationalities = await clientService.AllCountriesAsync(),
            }; 
            return View(model);
        }

        [HttpPost]
        [HaveNotIndividualClientData]

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

            Guid newClientId = await clientService.CreateDataOfIndividualClientAsync(model, user);
            
            return RedirectToAction(nameof(DetailsDataOfIndividualClient), new { dataOfdIndividualClientId = newClientId });
        }

        [HttpGet]
        [MustHaveIndividualClientData]

        public async Task<IActionResult> DetailsDataOfIndividualClient(Guid dataOfdIndividualClientId)
        {
            var model = await clientService.DetailsOfDataOnIndividualClientAsync(dataOfdIndividualClientId);

            return View(model);
        }

        public IActionResult Download(string filename)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "FilesWhitIdDicuments");
           
            IFileProvider fileProvider = new PhysicalFileProvider(path);
            
            IFileInfo fileInfo = fileProvider.GetFileInfo(filename.Substring(filename.LastIndexOf('\\') + 1));
            
            var stream = fileInfo.CreateReadStream();
            
            var mineType = "application/octet-stream";

            return File(stream, mineType, filename);
        }

    }
}
