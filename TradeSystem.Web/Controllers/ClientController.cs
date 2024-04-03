using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Data.Models;
using TradeSystem.Web.Attributes;
using static TradeSystem.Common.ErrorConstants;

namespace TradeSystem.Web.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;
        private readonly ILogger<ClientController> logger;

        public ClientController(
            IClientService clientService
            ,IEmployeeService employeeService
            ,ILogger<ClientController> logger)
        {
            this.clientService = clientService;
            this.employeeService = employeeService;
            this.logger = logger;
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
            Guid userId = User.Id();

            if (await clientService.GetIdOfDataOfIndividualClientByUserIdAsync(userId) != null)
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

            Guid newClientId = await clientService.CreateDataOfIndividualClientAsync(model, userId);
            
            return RedirectToAction(nameof(DetailsDataOfClient), new { dataOfClientId = newClientId });
        }

        [HttpGet]
        [HaveNotIndividualClientData]

        public async Task<IActionResult> AddDataNewCorporativeClient()
        {
            var model = new CorporativeDataClentFormModel()
            {
                Nationalities = await clientService.AllCountriesAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [HaveNotIndividualClientData]

        public async Task<IActionResult> AddDataNewCorporativeClient(CorporativeDataClentFormModel model)
        {
            Guid userId = User.Id();

            if (await clientService.GetIdOfDataOfCorporativelClientByUserIdAsync(userId) != null)
            {
                ModelState.AddModelError(nameof(model.Name), ExistClient);
            }

            if (await clientService.CountryExistsAsync(model.NationalityId) == false)
            {
                ModelState.AddModelError(nameof(model.NationalityId), NationalityRestricted);
            }

            if (ModelState.IsValid == false)
            {
                model.Nationalities = await clientService.AllCountriesAsync();

                return View(model);
            }

            Guid newClientId = await clientService.CreateDataOfCorporativeClientAsync(model, userId);

            return RedirectToAction(nameof(DetailsDataOfClient), new { dataOfClientId = newClientId });
        }

        [HttpGet]

        public async Task<IActionResult> DetailsDataOfClient(Guid? userId)
        {    
            try
            {
                var model = await clientService.DetailsOfDataOnClientAsync(userId ?? User.Id());

                return View(model);
            }
            catch (UnauthorizedAccessException uae)
            {
                logger.LogError(uae, "ClientController/DetailsDataOfClient");
                return Unauthorized();
            }
        }

        public async Task<IActionResult> Download(string filename)
        {
            bool isGuid = Guid.TryParse(filename.Substring(0, filename.LastIndexOf('.') - 1), out Guid userId);

            if(!isGuid 
                || (userId != User.Id()) 
                    || (await employeeService.ExistsByUserIdAsync(User.Id()) == false))
            {
                BadRequest();
            }

            string path = Path.Combine(Environment.CurrentDirectory, "FilesWhitIdDicuments");

            IFileProvider fileProvider = new PhysicalFileProvider(path);

            IFileInfo fileInfo = fileProvider.GetFileInfo(filename.Substring(filename.LastIndexOf('\\') + 1));

            var stream = fileInfo.CreateReadStream();

            var mineType = "application/octet-stream";

            return File(stream, mineType, filename);
        }

        [NotEmployee]
        [HttpGet]

        public async Task<IActionResult> EditIndividual(Guid dataId)
        {
            if (await clientService.ExixtByIndividualClientDataIdAsync(dataId) == false)
            {
                return BadRequest();
            }

            try
            {
                var model = await clientService.GetDataOfIdividualClientFormByIdAsync(dataId);

                return View(model);
            }
            catch (NonDataOfClientException nde)
            {
                logger.LogError(nde, "ClientController/EditIndividual");
                return BadRequest();
            }
        }

        [NotEmployee]
        [HttpPost]

        public async Task<IActionResult> EditIndividual(
            Guid dataId
            , IndividualDataClentFormModel individualDataModel)
        {
            if(await clientService.ExixtByIndividualClientDataIdAsync(dataId) == false)
            {
                return BadRequest();
            }

            if (await clientService.CountryExistsAsync(individualDataModel.NationalityId) == false)
            {
                ModelState.AddModelError(nameof(individualDataModel.NationalityId), NationalityRestricted);
            }

            if (ModelState.IsValid == false)
            {
                individualDataModel.Nationalities = await clientService.AllCountriesAsync();
                return View(individualDataModel);
            }

            try
            {
                await clientService.EditDataOfIndividualClientAsync(dataId, individualDataModel);

                return RedirectToAction(nameof(DetailsDataOfClient), new { userId = User.Id() });
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "ClientController/EditIndividual");
                return BadRequest();
            }
        }

        [NotEmployee]
        [HttpGet]

        public async Task<IActionResult> EditCorporative(Guid dataId)
        {
            if (await clientService.ExixtByCorporativeClientDataIdAsync(dataId) == false)
            {
                return BadRequest();
            }

            try
            {
                var model = await clientService.GetDataOfCorporativeClientFormByIdAsync(dataId);

                return View(model);
            }
            catch (NonDataOfClientException nde)
            {
                logger.LogError(nde, "ClientController/EditCorporative");
                return BadRequest();
            }
        }

        [NotEmployee]
        [HttpPost]

        public async Task<IActionResult> EditCorporative(
            Guid dataId
            , CorporativeDataClentFormModel corporativeDataModel)
        {
            if (await clientService.ExixtByCorporativeClientDataIdAsync(dataId) == false)
            {
                return BadRequest();
            }

            if (await clientService.CountryExistsAsync(corporativeDataModel.NationalityId) == false)
            {
                ModelState.AddModelError(nameof(corporativeDataModel.NationalityId), NationalityRestricted);
            }

            if (ModelState.IsValid == false)
            {
                corporativeDataModel.Nationalities = await clientService.AllCountriesAsync();
                return View(corporativeDataModel);
            }

            try
            {
                await clientService.EditDataOfCorporativeClientAsync(dataId, corporativeDataModel);

                return RedirectToAction(nameof(DetailsDataOfClient), new { userId = User.Id() });
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "ClientController/EditCorporative");
                return BadRequest();
            }            
        }

        [NotEmployee]
        [HttpGet]

        public async Task<IActionResult> Delete(Guid dataId)
        {
            if ((await clientService.ExixtByCorporativeClientDataIdAsync(dataId) == false)
                && (await clientService.ExixtByIndividualClientDataIdAsync(dataId) == false))
            {
                return BadRequest();
            }

            try
            {
                var model = await clientService.DetailsOfDataOnClientAsync(User.Id());
                return View(model);
            }
            catch (NonDataOfClientException nee)
            {
                logger.LogError(nee, "ClientController/Delete");
                return BadRequest();
            }
        }

        [NotEmployee]
        [HttpPost]

        public async Task<IActionResult> Delete(DataOfClientServiceModel model, Guid dataId)
        {
            if ((await clientService.ExixtByCorporativeClientDataIdAsync(dataId) == false)
                && (await clientService.ExixtByIndividualClientDataIdAsync(dataId) == false))
            {
                return BadRequest();
            }

            try
            {
                await clientService.DeleteAsync(dataId);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (NonDataOfClientException nee)
            {
                logger.LogError(nee, "ClientController/Delete");
                return BadRequest();
            }
        }

        [HttpGet]

        public async Task<IActionResult> DetailsAcauntOfClient(Guid? userId)
        {
            try
            {
                var model = await clientService.DetailsOfAcountOnClientAsync(userId ?? User.Id());

                return View(model);
            }
            catch (UnauthorizedAccessException uae)
            {
                logger.LogError(uae, "ClientController/DetailsDataOfClient");
                return Unauthorized();
            }
        }

        [HttpGet]
        [MustBeClientAccount]

        public async Task<IActionResult> AddMoney()
        {
            try
            {
                var model = await clientService.GetClintDetailsAsync(User.Id());
                return View(model);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "ClientController/DetailsDataOfClient");
                return Unauthorized();
            }
        }

        [HttpPost]
        [MustBeClientAccount]

        public async Task<IActionResult> AddMoney(ClientAddMoneyModel model)
        {
            try
            {
                await clientService.AddMoneyAsync(User.Id(), model.AddedSum);

                return RedirectToAction(nameof(DetailsAcauntOfClient));
            }
            catch (UnauthorizedAccessException uae)
            {
                logger.LogError(uae, "ClientController/AddMoney");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "ClientController/AddMoney");
                return Unauthorized();
            }
        }
    }
}
