using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using static TradeSystem.Common.GeneralApplicationConstants;

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

        public async Task<Guid> CreateDataOfIndividualClientAsync(IndividualDataClentFormModel model, Guid userId)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "FilesWhitIdDicuments");
            var identityDoc = new IdentityDocument();

            var file = model.File;

            string filename = Path.Combine(path, userId.ToString());

            using (var filestream = new FileStream(filename, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }

            identityDoc.CreatedOn = DateTime.UtcNow;
            identityDoc.UserId = userId;
            identityDoc.Extension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
            
            
            DataOfIndividualClient client = new DataOfIndividualClient()
            {
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Surname = model.Surname,
                IdentityDocument = identityDoc,
                NationalityId = model.NationalityId,
                DataChecking = 0,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                TownId = await GetTownIdAsync(model.Town.ToUpper().Trim(), model.NationalityId),
                NationalIdentityNumber = model.NationalIdentityNumber,
                DateOfBirth = DateTime.ParseExact(model.DateOfBirth, DateFormat, CultureInfo.InvariantCulture),
                ApplicationUserId = userId,
            };

            await dataIndividualClientRepozitory.AddAsync(client);
            await dataIndividualClientRepozitory.SaveChangesAsync();

            return client.Id;
        }

        public async Task<Guid?> GetIdOfDataOfCorporativelClientByUserIdAsync(Guid userId)
        {
            return (await dataCorporativeClientRepozitory.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId))?.Id;
        }

        public async Task<Guid?> GetIdOfDataOfIndividualClientByUserIdAsync(Guid userId)
        {
            return (await dataIndividualClientRepozitory.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId))?.Id;
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
