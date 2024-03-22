﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Web.Attributes;
using static TradeSystem.Common.ErrorConstants;

namespace TradeSystem.Web.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;

        public ClientController(
            IClientService clientService
            ,IEmployeeService employeeService)
        {
            this.clientService = clientService;
            this.employeeService = employeeService;
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

        public async Task<IActionResult> DetailsDataOfIndividualClient(Guid dataOfdIndividualClientId)
        {
            var model = await clientService.DetailsOfDataOnIndividualClientAsync(dataOfdIndividualClientId);

            return View(model);
        }

        public async Task<IActionResult> Download(string filename)
        {
            bool isGuid = Guid.TryParse(filename.Substring(0, filename.LastIndexOf('.') - 1), out Guid userId);

            if(!isGuid 
                || (userId != Guid.Parse(User.Id())) 
                    || (await employeeService.ExistsByUserIdAsync(Guid.Parse(User.Id())) == false))
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

    }
}
