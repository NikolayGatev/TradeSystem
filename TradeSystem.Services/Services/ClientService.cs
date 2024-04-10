using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Models.Enumerations;
using static TradeSystem.Common.ExceptionMessages;
using static TradeSystem.Common.GeneralApplicationConstants;


namespace TradeSystem.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepozitory;
        private readonly IDeletableEntityRepository<Client> clientRepozitory;
        private readonly IRepository<Country> countryRepozitory;
        private readonly IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory;
        private readonly IRepository<DataOfIndividualClient> dataIndividualClientRepozitory;
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Town> townRepozitory;

        public ClientService(
           IDeletableEntityRepository<Employee> employeeRepozitory
           ,IDeletableEntityRepository<Client> clientRepozitory
           ,IRepository<Country> countryRepozitory
           ,IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory
           ,IRepository<DataOfIndividualClient> dataIndividualClientRepozitory
           ,IDeletableEntityRepository<Order> orderRepozitory
           ,IDeletableEntityRepository<Town> townRepozitory)
        {
            this.employeeRepozitory = employeeRepozitory;
            this.clientRepozitory = clientRepozitory;
            this.countryRepozitory = countryRepozitory;
            this.dataCorporativeClientRepozitory = dataCorporativeClientRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
            this.orderRepozitory = orderRepozitory;
            this.townRepozitory = townRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
        }

        public async Task<IEnumerable<ClientsForAddFinancialInstumentFormServiceModel>> AllClientsAsync()
        {
            var dataOfIndividualClient = await dataIndividualClientRepozitory.AllAsNoTracking()
                .Where(d => d.ClientId != null)
                .Select(d => new ClientsForAddFinancialInstumentFormServiceModel()
                {
                    ClientId = d.ClientId ?? new Guid(),
                    ClientName = $"{d.FirstName} {d.Surname}",
                })
                .ToListAsync();
            var dataOfCorporativeClients = await dataCorporativeClientRepozitory.AllAsNoTracking()
                .Where(d => d.ClientId != null)
                .Select(d => new ClientsForAddFinancialInstumentFormServiceModel()
                {
                    ClientId = d.ClientId ?? new Guid(),
                    ClientName = d.Name,
                })
                .ToListAsync();
            var result = new List<ClientsForAddFinancialInstumentFormServiceModel>();

            result.AddRange(dataOfIndividualClient);
            result.AddRange(dataOfCorporativeClients);

            return result.OrderBy(x => x.ClientName);
                ;
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

        public async Task<Guid> CreateDataOfCorporativeClientAsync(CorporativeDataClentFormModel model, string userId)
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

        public async Task<Guid> CreateDataOfIndividualClientAsync(IndividualDataClentFormModel model, string userId)
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

                string filename = Path.Combine(path, $"{userId}.{identityDoc.Extension}");

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
                throw new NonDataOfClientException(MessageNotDataException);
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

        public async Task<ClientAcountServiceModel> DetailsOfAcountOnClientAsync(string userId)
        {
            var clientId = await GetClientIdByUserIdAsync(userId);

            if(clientId == null)
            {
                throw new UnauthorizedAccessException(MessageUnauthoriseActionException);
            }

            var model = await clientRepozitory.AllAsNoTrackingWithDeleted()
                .Where(d => d.Id == clientId)
                .Select(c => new ClientAcountServiceModel()
                {
                    Balance = c.Balance,
                    BlockedSum = c.BlockedSum,
                })
                .FirstAsync();

            return model;
        }

        public async Task<DataOfClientServiceModel>  DetailsOfDataOnClientAsync(string userId)
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
                throw new NonDataOfClientException(MessageNotDataException);
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
                throw new NonDataOfClientException(MessageNotDataException);
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

        public async Task<bool> ExistClientByIdAsync(Guid clientId)
        {
            return await clientRepozitory.AllAsNoTrackingWithDeleted().AnyAsync(c => c.Id == clientId);
        }

        public async Task<bool> ExistClientByUserIdAsync(string userId)
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

        public async Task<bool> ExistDataCorporativeClientByUserIdAsync(string userId)
        {
            return await dataCorporativeClientRepozitory.AllAsNoTracking()
                .AnyAsync(d => d.ApplicationUserId == userId);
        }

        public async Task<bool> ExistDataIndividualClientByUserIdAsync(string userId)
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

        public async Task<Guid?> GetClientIdByUserIdAsync(string userId)
        {
            Guid? result = new Guid();

            if (await ExistDataCorporativeClientByUserIdAsync(userId))
            {
                result = await dataCorporativeClientRepozitory.AllAsNoTracking()
                    .Where(d => d.ApplicationUserId == userId && d.ClientId != null)
                    .Select(d => d.ClientId)
                    .FirstOrDefaultAsync();
            }
            else if (await ExistDataIndividualClientByUserIdAsync(userId))
            {
                result = await dataIndividualClientRepozitory.AllAsNoTracking()
                    .Where(d => d.ApplicationUserId == userId && d.ClientId != null)
                    .Select(d => d.ClientId)
                    .FirstOrDefaultAsync();
            }

            return result;
        }

        public async Task<CorporativeDataClentFormModel> GetDataOfCorporativeClientFormByIdAsync(Guid dataId)
        {
            if(await ExixtByCorporativeClientDataIdAsync(dataId) == false)
            {
                throw new NonDataOfClientException(MessageNotDataException);
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
                throw new NonDataOfClientException(MessageNotDataException);
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

        public async Task<Guid?> GetIdOfDataOfCorporativelClientByUserIdAsync(string userId)
        {
            return (await dataCorporativeClientRepozitory.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId))?.Id;
        }

        public async Task<Guid?> GetIdOfDataOfIndividualClientByUserIdAsync(string userId)
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

        public async Task<ClientsDataQueryServiceModel> AllClientsDataAsync(
                                                                        string? nationality = null
                                                                        , string? status = null
                                                                        , string? searchTerm = null
                                                                        , string? typeOfClient = null
                                                                        , int currentPage = 1
                                                                        , int datasPerPage = 1)
        {
            var dataOfIndividualClient = dataIndividualClientRepozitory.AllAsNoTracking();
            var dataOfCorporativeClients = dataCorporativeClientRepozitory.AllAsNoTracking();

            if (status != null)
            {
                dataOfCorporativeClients = dataOfCorporativeClients
                    .Where(d => d.DataChecking == Enum.Parse<ResultFromChecking>(status));

                dataOfIndividualClient = dataOfIndividualClient
                    .Where(d => d.DataChecking == Enum.Parse<ResultFromChecking>(status));
            }

            if (nationality != null)
            {
                dataOfCorporativeClients = dataOfCorporativeClients
                    .Where(d => d.Nationality.Name == nationality);

                dataOfIndividualClient = dataOfIndividualClient
                    .Where(d => d.Nationality.Name == nationality);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                dataOfCorporativeClients = dataOfCorporativeClients
                    .Where(d => d.Name.ToLower().Contains(normalizedSearchTerm)
                        || d.Address.ToLower().Contains(normalizedSearchTerm)
                        || d.LegalForm.ToLower().Contains(normalizedSearchTerm)
                        || d.NationalIdentityNumber.ToLower().Contains(normalizedSearchTerm)
                        || d.PhoneNumber.ToLower().Contains(normalizedSearchTerm));

                dataOfIndividualClient = dataOfIndividualClient
                    .Where(d => d.FirstName.ToLower().Contains(normalizedSearchTerm)
                        || d.Surname.ToLower().Contains(normalizedSearchTerm)
                        || d.Address.ToLower().Contains(normalizedSearchTerm)
                        || d.NationalIdentityNumber.ToLower().Contains(normalizedSearchTerm)
                        || d.PhoneNumber.ToLower().Contains(normalizedSearchTerm));
            }

            var dataOfClientToshow = new List<DataOfClientServiseModelForCheching>();

            if (typeOfClient == AllTypeOfClientsName()[0] || typeOfClient == null)
            {
                var dataOfIndividualClientToshow = await dataOfIndividualClient
                .Select(d => new DataOfClientServiseModelForCheching()
                {
                    Id = d.Id,
                    UserId = d.ApplicationUserId,
                    ClientId = d.ClientId,
                    DataChecking = d.DataChecking.ToString(),
                    ApplicationName = d.ApplicationUser.UserName,
                    Nationality = d.Nationality.Name,
                    Address = d.Address,
                    PhoneNumber = d.PhoneNumber,
                    TypeOfClient = TypeOfDataClients.IndividualClient.ToString(),
                    FirstName = d.FirstName,
                    SecondName = d.SecondName,
                    Surname = d.Surname,
                    NationalIdentityNumberIndividual = d.NationalIdentityNumber,
                })
                .ToListAsync();

                dataOfClientToshow.AddRange(dataOfIndividualClientToshow);
            }

            if (typeOfClient == AllTypeOfClientsName()[1] || typeOfClient == null)
            {
                var dataOfCorporativeClientToshow = await dataOfCorporativeClients
               .Select(d => new DataOfClientServiseModelForCheching()
               {
                   Id = d.Id,
                   UserId = d.ApplicationUserId,
                   ClientId = d.ClientId,
                   DataChecking = d.DataChecking.ToString(),
                   ApplicationName = d.ApplicationUser.UserName,
                   Nationality = d.Nationality.Name,
                   Address = d.Address,
                   PhoneNumber = d.PhoneNumber,
                   TypeOfClient = TypeOfDataClients.CorporativeClient.ToString(),
                   FirstName = d.Name,
                   SecondName = d.LegalForm,
                   NationalIdentityNumber = d.NationalIdentityNumber,
               })
               .ToListAsync();

                dataOfClientToshow.AddRange(dataOfCorporativeClientToshow);
            }

            dataOfClientToshow
                .Skip((currentPage - 1) * datasPerPage)
                .Take(datasPerPage)
                .ToList();

            int totalDateOfClient = dataOfClientToshow.Count();

            return new ClientsDataQueryServiceModel()
            {
                ClientsData = dataOfClientToshow,
                TotalClientsDataCount = totalDateOfClient
            };
        }

        public List<string> AllTypeOfClientsName()
        {
            return Enum.GetNames(typeof(TypeOfDataClients)).ToList();
        }

        public async Task AddMoneyAsync(string userId, decimal amount)
        {
            var clientId = await GetClientIdByUserIdAsync(userId);

            if (clientId == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            if (amount < 0)
            {
                throw new Exception(MessageNegativeSum);
            }

            var client = await clientRepozitory.All().FirstAsync(c => c.Id == clientId);

            client.Balance += amount;

            await clientRepozitory.SaveChangesAsync();
        }

        public async Task<ClientAddMoneyModel> GetClintDetailsAsync(string userId)
        {
            var clientId = await GetClientIdByUserIdAsync(userId);

            if(clientId == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            var result =  await clientRepozitory.AllAsNoTracking()
                .Where(c => c.Id == clientId)
                .Select(c => new ClientAddMoneyModel()
                {
                    Id = c.Id,
                    Balance = c.Balance,
                    BlockedSum = c.BlockedSum,
                })
                .ToListAsync();

            return result[0];
        }

        public async Task<IEnumerable<string>> AllClintsIdAsync(string userId)
        {
            var clientId = await GetClientIdByUserIdAsync(userId);

            return clientId != null
                ? new List<string>() { clientId.ToString() }
                : await clientRepozitory.AllAsNoTrackingWithDeleted()
                .Select(c => c.Id.ToString())
                .OrderBy(c => c)
                .ToListAsync();
        }

        public async Task<Client?> GetClientByClientIdAcync(Guid clientId)
        {
            return await clientRepozitory.All()
                .Where(c => c.Id == clientId)
                .FirstOrDefaultAsync();
        }
    }
}
