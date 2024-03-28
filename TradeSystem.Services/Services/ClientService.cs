using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Models.Enumerations;
using static TradeSystem.Common.GeneralApplicationConstants;
using static TradeSystem.Common.ExceptionMessages;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Exeptions;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;


namespace TradeSystem.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepozitory;
        private readonly IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory;
        private readonly IDeletableEntityRepository<Client> clientRepozitory;
        private readonly IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory;
        private readonly IRepository<Country> countryRepozitory;
        private readonly IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory;
        private readonly IRepository<DataOfIndividualClient> dataIndividualClientRepozitory;
        private readonly IDeletableEntityRepository<DepositedMoney> depositMoneyRepozitory;
        private readonly IRepository<Division> divisionRepozitory;
        private readonly IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private readonly IRepository<IdentityDocument> identityDocRepozitory;
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Town> townRepozitory;
        private readonly IDeletableEntityRepository<Trade> tradeRepozitory;
        private readonly IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;

        public ClientService(
           IDeletableEntityRepository<Employee> employeeRepozitory
           , IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory
           ,IDeletableEntityRepository<Client> clientRepozitory
           ,IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory
           ,IRepository<Country> countryRepozitory
           ,IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory
           ,IRepository<DataOfIndividualClient> dataIndividualClientRepozitory
           ,IDeletableEntityRepository<DepositedMoney> depositMoneyRepozitory
           ,IRepository<Division> divisionRepozitory
           ,IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory
           ,IRepository<IdentityDocument> identityDocRepozitory
           ,IDeletableEntityRepository<Order> orderRepozitory
           ,IDeletableEntityRepository<Town> townRepozitory
           ,IDeletableEntityRepository<Trade> tradeRepozitory
           ,IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory)
        {
            this.employeeRepozitory = employeeRepozitory;
            this.aplicationUserRepozitory = aplicationUserRepozitory;
            this.clientRepozitory = clientRepozitory;
            this.clientFinancialInstrumentRepozitory = clientFinancialInstrumentRepozitory;
            this.countryRepozitory = countryRepozitory;
            this.dataCorporativeClientRepozitory = dataCorporativeClientRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
            this.depositMoneyRepozitory = depositMoneyRepozitory;
            this.divisionRepozitory = divisionRepozitory;
            this.finInstrRepozitory = finInstrRepozitory;
            this.identityDocRepozitory = identityDocRepozitory;
            this.orderRepozitory = orderRepozitory;
            this.townRepozitory = townRepozitory;
            this.tradeRepozitory = tradeRepozitory;
            this.tradeOrderRepozitory = tradeOrderRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
        }
        public async Task<IEnumerable<CountryServiceModel>> AllCountriesAsync()
        {
            return await countryRepozitory.AllAsNoTracking()
                .Select(c => new CountryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> CountryExistsAsync(int countryId)
        {
            return await countryRepozitory.AllAsNoTracking()
                .AnyAsync(c => c.Id == countryId);
        }

        public async Task<Guid> CreateDataOfCorporativeClientAsync(CorporativeDataClentFormModel model, Guid userId)
        {
            DataOfCorporateveClient client = new DataOfCorporateveClient()
            {
                Name = model.Name,
                LegalForm = model.LegalForm,
                NameOfRepresentative = model.NameOfRepresentative,
                NationalityId = model.NationalityId,
                DataChecking = 0,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                TownId = await GetTownIdAsync(model.Town.ToUpper().Trim(), model.NationalityId),
                NationalIdentityNumber = model.NationalIdentityNumber,
                ApplicationUserId = userId,
            };

            if(model.File != null )
            {
                string path = Path.Combine(Environment.CurrentDirectory, "FilesWhitIdDicuments");

                var file = model.File;

                var identityDoc = new IdentityDocument();
                identityDoc.Extension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);

                string filename = Path.Combine(path, $"{userId.ToString()}.{identityDoc.Extension}");

                using (var filestream = new FileStream(filename, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }

                identityDoc.CreatedOn = DateTime.UtcNow;
                identityDoc.UserId = userId;
                identityDoc.RemoteImageUrl = filename;

                client.IdentityDocument = identityDoc;
            }

            await dataCorporativeClientRepozitory.AddAsync(client);
            await dataCorporativeClientRepozitory.SaveChangesAsync();

            return client.Id;
        }

        public async Task<Guid> CreateDataOfIndividualClientAsync(IndividualDataClentFormModel model, Guid userId)
        {            
            DataOfIndividualClient client = new DataOfIndividualClient()
            {                
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Surname = model.Surname,
                NationalityId = model.NationalityId,
                DataChecking = 0,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                TownId = await GetTownIdAsync(model.Town.ToUpper().Trim(), model.NationalityId),
                NationalIdentityNumber = model.NationalIdentityNumber,
                DateOfBirth = DateTime.ParseExact(model.DateOfBirth, DateFormat, CultureInfo.InvariantCulture),
                ApplicationUserId = userId,
            };

            if (model.File != null)
            {
                string path = Path.Combine(Environment.CurrentDirectory, "FilesWhitIdDicuments");

                var file = model.File;

                var identityDoc = new IdentityDocument();
                identityDoc.Extension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);

                string filename = Path.Combine(path, $"{userId.ToString()}.{identityDoc.Extension}");

                using (var filestream = new FileStream(filename, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }

                identityDoc.CreatedOn = DateTime.UtcNow;
                identityDoc.UserId = userId;
                identityDoc.RemoteImageUrl = filename;

                client.IdentityDocument = identityDoc;
            }

            await dataIndividualClientRepozitory.AddAsync(client);
            await dataIndividualClientRepozitory.SaveChangesAsync();

            return client.Id;
        }

        public async Task DeleteAsync(Guid dataId)
        {            
            var isCorporativ = await ExixtByCorporativeClientDataIdAsync(dataId);
            var Isindividua = await ExixtByIndividualClientDataIdAsync(dataId);

            if (isCorporativ == false && Isindividua == false)
            {
                throw new NotDataOfClientException(MessageNotDataException);
            }
            var clientId = isCorporativ
                ? await dataCorporativeClientRepozitory.All().Where(d => d.Id == dataId)
                    .Select(d => d.ClientId)
                    .FirstOrDefaultAsync()
                : await dataIndividualClientRepozitory.All().Where(d => d.Id == dataId)
                    .Select(d => d.ClientId)
                    .FirstOrDefaultAsync();

            if(clientId != null)
            {
                var orders = await orderRepozitory.All().Where(o => o.ClientId == clientId).ToListAsync();

                foreach(var order in orders)
                {
                    order.IsDeleted = true;
                }

                await orderRepozitory.SaveChangesAsync();

                var client = await clientRepozitory.All().FirstAsync(c => c.Id == clientId);
                clientRepozitory.Delete(client);
                await clientRepozitory.SaveChangesAsync();
            }

            if(isCorporativ)
            {
                var data = await dataCorporativeClientRepozitory.All().FirstAsync(d => d.Id == dataId);

                dataCorporativeClientRepozitory.Delete(data);
                await dataCorporativeClientRepozitory.SaveChangesAsync();
            }
            else if(Isindividua)
            {
                var data = await dataIndividualClientRepozitory.All().FirstAsync(d => d.Id == dataId);

                dataIndividualClientRepozitory.Delete(data);
                await dataIndividualClientRepozitory.SaveChangesAsync();
            }
        }

        public async Task<DataOfClientServiceModel>  DetailsOfDataOnClientAsync(Guid userId)
        {
            var IdDataIndividualClient = await GetIdOfDataOfIndividualClientByUserIdAsync(userId);
            var IdDataCorporativeClient = await GetIdOfDataOfCorporativelClientByUserIdAsync(userId);

            if (IdDataIndividualClient != null)
            {
                var model = await dataIndividualClientRepozitory.AllAsNoTracking()
                    .Where(d => d.Id == IdDataIndividualClient)
                    .Select(d => new DataOfClientServiceModel()
                    {
                        Id = d.Id,
                        UserId = userId,
                        TypeOfClient = TypeOfDataClients.IndividualClient.ToString(),
                        DataChecking = d.DataChecking,
                        ApplicationName = d.ApplicationUser.UserName,
                        Nationality = d.Nationality.Name,
                        FirstName = d.FirstName,
                        SecondName = d.SecondName,
                        Surname = d.Surname,
                        NationalityId = d.NationalityId,
                        Address = d.Address,
                        Town = d.Town.Name,
                        PhoneNumber = d.PhoneNumber,
                        DateOfBirth = d.DateOfBirth.ToString(DateFormat),
                        NationalIdentityNumberIndividual = d.NationalIdentityNumber,
                        UrlToIDCart = d.IdentityDocument != null ? d.IdentityDocument.RemoteImageUrl : null,
                        ExtentionIdCardFile = d.IdentityDocument != null ? d.IdentityDocument.Extension : null,
                    })
                    .FirstAsync();

                return model;
            }

            else if (IdDataCorporativeClient != null)
            {
                var model = await dataCorporativeClientRepozitory.AllAsNoTracking()
                    .Where(d => d.Id == IdDataCorporativeClient)
                    .Select(d => new DataOfClientServiceModel()
                    {
                        Id = d.Id,
                        UserId = userId,
                        TypeOfClient = TypeOfDataClients.CorporativeClient.ToString(),
                        ApplicationName = d.ApplicationUser.UserName,
                        Nationality = d.Nationality.Name,
                        Name = d.Name,
                        NationalityId = d.NationalityId,
                        Address = d.Address,
                        Town = d.Town.Name,
                        PhoneNumber = d.PhoneNumber,
                        NationalIdentityNumber = d.NationalIdentityNumber,
                        LegalForm = d.LegalForm,
                        NameOfRepresentative = d.NameOfRepresentative,
                        UrlToIDCart = d.IdentityDocument != null ? d.IdentityDocument.RemoteImageUrl : null,
                        ExtentionIdCardFile = d.IdentityDocument != null ? d.IdentityDocument.Extension : null,
                        DataChecking = d.DataChecking,
                    })
                    .FirstAsync();

                return model;
            }

            throw new UnauthorizedAccessException(MessageUnauthoriseActionException);
        }

        public async Task EditDataOfCorporativeClientAsync(Guid dataOfClientId, CorporativeDataClentFormModel corporativeDataModel)
        {
            var data = await dataCorporativeClientRepozitory.All()
                .Where(d => d.Id == dataOfClientId)
                .FirstOrDefaultAsync();

            if (data == null)
            {
                throw new NotDataOfClientException(MessageNotDataException);
            }

            data.Name = corporativeDataModel.Name;
            data.LegalForm = corporativeDataModel.LegalForm;
            data.NameOfRepresentative = corporativeDataModel.NameOfRepresentative;
            data.NationalityId = corporativeDataModel.NationalityId;
            data.TownId = await GetTownIdAsync(corporativeDataModel.Town.ToUpper().Trim(), corporativeDataModel.NationalityId);
            data.Address = corporativeDataModel.Address;
            data.PhoneNumber = corporativeDataModel.PhoneNumber;
            data.NationalIdentityNumber = corporativeDataModel.NationalIdentityNumber;

            await employeeRepozitory.SaveChangesAsync();
        }

        public async Task EditDataOfIndividualClientAsync(Guid dataOfClientId, IndividualDataClentFormModel individualDataModel)
        {
            var data = await dataIndividualClientRepozitory.All()
               .Where(d => d.Id == dataOfClientId)
               .FirstOrDefaultAsync();

            if (data == null)
            {
                throw new NotDataOfClientException(MessageNotDataException);
            }

            data.FirstName = individualDataModel.FirstName;
            data.SecondName = individualDataModel.SecondName;
            data.Surname = individualDataModel.Surname;
            data.DateOfBirth = DateTime.ParseExact(individualDataModel.DateOfBirth, DateFormat, CultureInfo.InvariantCulture);
            data.NationalityId = individualDataModel.NationalityId;
            data.TownId = await GetTownIdAsync(individualDataModel.Town.ToUpper().Trim(), individualDataModel.NationalityId);
            data.Address = individualDataModel.Address;
            data.PhoneNumber = individualDataModel.PhoneNumber;
            data.NationalIdentityNumber = individualDataModel.NationalIdentityNumber;

            await employeeRepozitory.SaveChangesAsync();
        }

        public async Task<bool> ExistClientByUserIdAsync(Guid userId)
        {
            var result = false;

            if(await ExistDataCorporativeClientByUserIdAsync(userId))
            {
                result = await dataCorporativeClientRepozitory.AllAsNoTracking()
                    .Where(d => d.ApplicationUserId == userId && d.ClientId != null)
                    .FirstOrDefaultAsync() == null ? false : true;
            }
            else if(await ExistDataIndividualClientByUserIdAsync(userId))
            {
                result = await dataIndividualClientRepozitory.AllAsNoTracking()
                    .Where(d => d.ApplicationUserId == userId && d.ClientId != null)
                    .FirstOrDefaultAsync() == null ? false : true;
            }

            return result;
        }

        public async Task<bool> ExistDataCorporativeClientByUserIdAsync(Guid userId)
        {
            return await dataCorporativeClientRepozitory.AllAsNoTracking()
                .AnyAsync(d => d.ApplicationUserId == userId);
        }

        public async Task<bool> ExistDataIndividualClientByUserIdAsync(Guid userId)
        {
            return await dataIndividualClientRepozitory.AllAsNoTracking()
                .AnyAsync(d => d.ApplicationUserId == userId);
        }

        public async Task<bool> ExixtByCorporativeClientDataIdAsync(Guid dataOfCorporativeId)
        {
            return await dataCorporativeClientRepozitory.AllAsNoTracking()
                .AnyAsync(d => d.Id == dataOfCorporativeId);
        }

        public async Task<bool> ExixtByIndividualClientDataIdAsync(Guid dataOfIndividualId)
        {
            return await dataIndividualClientRepozitory.AllAsNoTracking()
                .AnyAsync(d => d.Id == dataOfIndividualId);
        }

        public async Task<CorporativeDataClentFormModel> GetDataOfCorporativeClientFormByIdAsync(Guid dataId)
        {
            if(await ExixtByCorporativeClientDataIdAsync(dataId) == false)
            {
                throw new NotDataOfClientException(MessageNotDataException);
            }

            var data =  await dataCorporativeClientRepozitory.AllAsNoTracking()
                .Where(d => d.Id == dataId)
                .FirstAsync();

            var model = new CorporativeDataClentFormModel()
            {
                NationalityId = data.NationalityId,
                Address = data.Address,
                Town = await townRepozitory.AllAsNoTracking().Where(t => t.Id == data.TownId).Select(t => t.Name).FirstAsync(),
                PhoneNumber = data.PhoneNumber,
                NationalIdentityNumber = data.NationalIdentityNumber,
                Name = data.Name,
                LegalForm = data.LegalForm,
                NameOfRepresentative = data.NameOfRepresentative,
            };

            model.Nationalities = await AllCountriesAsync();

            return model;
        }

        public async Task<IndividualDataClentFormModel> GetDataOfIdividualClientFormByIdAsync(Guid dataId)
        {
            if (await ExixtByIndividualClientDataIdAsync(dataId) == false)
            {
                throw new NotDataOfClientException(MessageNotDataException);
            }

            var data = await dataIndividualClientRepozitory.AllAsNoTracking()
                .Where(d => d.Id == dataId)
                .FirstAsync();

            var model = new IndividualDataClentFormModel()
            {
                NationalityId = data.NationalityId,
                Address = data.Address,
                Town = await townRepozitory.AllAsNoTracking().Where(t => t.Id == data.TownId).Select(t => t.Name).FirstAsync(),
                PhoneNumber = data.PhoneNumber,
                NationalIdentityNumber = data.NationalIdentityNumber,
                FirstName = data.FirstName,
                SecondName = data.SecondName,
                Surname = data.Surname,
                DateOfBirth = data.DateOfBirth.ToString(DateFormat),
            };

            model.Nationalities = await AllCountriesAsync();

            return model;
        }

        public async Task<Guid?> GetIdOfDataOfCorporativelClientByUserIdAsync(Guid userId)
        {
            return (await dataCorporativeClientRepozitory.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId))?.Id;
        }

        public async Task<Guid?> GetIdOfDataOfIndividualClientByUserIdAsync(Guid userId)
        {
            return (await dataIndividualClientRepozitory.AllAsNoTracking().Where(c => c.ApplicationUserId == userId)
                .FirstOrDefaultAsync())?.Id;
        }

        public async Task<int> GetTownIdAsync(string townName, int countryId)
        {
            var town = await townRepozitory.AllAsNoTracking()
                .Where(t => t.CountryId == countryId && t.Name == townName)
                .FirstOrDefaultAsync();

            if(town == null)
            {
                town = new Town()
                {
                    Name = townName,
                    CountryId = countryId,
                };

                await townRepozitory.AddAsync(town);
                await townRepozitory.SaveChangesAsync();
            }

            return town.Id;
        }
    }
}
