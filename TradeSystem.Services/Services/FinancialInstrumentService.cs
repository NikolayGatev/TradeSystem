using Microsoft.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using static TradeSystem.Common.ExceptionMessages;

namespace TradeSystem.Core.Services
{
    public class FinancialInstrumentService : IFinancialInstrumentService
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
        private readonly IClientService clientService;

        public FinancialInstrumentService(
                   IDeletableEntityRepository<Employee> employeeRepozitory
                   , IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory
                   , IDeletableEntityRepository<Client> clientRepozitory
                   , IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory
                   , IRepository<Country> countryRepozitory
                   , IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory
                   , IRepository<DataOfIndividualClient> dataIndividualClientRepozitory
                   , IDeletableEntityRepository<DepositedMoney> depositMoneyRepozitory
                   , IRepository<Division> divisionRepozitory
                   , IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory
                   , IRepository<IdentityDocument> identityDocRepozitory
                   , IDeletableEntityRepository<Order> orderRepozitory
                   , IDeletableEntityRepository<Town> townRepozitory
                   , IDeletableEntityRepository<Trade> tradeRepozitory
                   , IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory
                   , IClientService clientService)

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
            this.clientService = clientService;
        }

        public async Task<int> CreateAsync(FinacialInstrumentFormModel model)
        {
            if(await finInstrRepozitory.AllAsNoTracking().AnyAsync(f => f.ISIN == model.ISIN 
                                                                    || f.Name == model.Name))
            {
                throw new ExistFinancialInstrumentWithThisNameOrISIN(MessageNotVacantNameOrISIN);
            }

            var finInstrument = new FinancialInstrument()
            {
                Name = model.Name,
                Description = model.Description,
                ISIN = model.ISIN,
            };

            await finInstrRepozitory.AddAsync(finInstrument);
            await finInstrRepozitory.SaveChangesAsync();

            return finInstrument.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetFinancialInstrumentByIdAsync(id);

            if (entity == null)
            {
                throw new Exception(MessageNotDataException);
            }

            finInstrRepozitory.Delete(entity);

            await finInstrRepozitory.SaveChangesAsync();
        }

        public async Task EditAsyn(int id, FinacialInstrumentFormModel model)
        {
            var entity = await GetFinancialInstrumentByIdAsync(id);

            if (entity == null)
            {
                throw new Exception(MessageNotDataException);
            }

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ISIN = model.ISIN;

            await finInstrRepozitory.SaveChangesAsync();
        }

        public async Task<bool> ExixtFinancialInstrumentAsync(int Id)
        {
            return await finInstrRepozitory.AllAsNoTracking().AnyAsync(f => f.Id == Id);
        }

        public async Task<FinInstrumentDetailsServiceModel> GetFinInstrumentDetailsByIdAsync(int id)
        {
            var entity = await GetFinancialInstrumentByIdAsync(id);

            if (entity == null)
            {
                throw new Exception(MessageNotDataException);
            }

            return new FinInstrumentDetailsServiceModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ISIN = entity.ISIN,
            };
        }

        public async Task<FinacialInstrumentFormModel> GetEditAsync(int id)
        {
            var entity = await GetFinancialInstrumentByIdAsync(id);

            if (entity == null)
            {
                throw new Exception(MessageNotDataException);
            }

            return new FinacialInstrumentFormModel()
            {
                Name = entity.Name,
                Description = entity.Description,
                ISIN = entity.ISIN,
            };
        }

        public async Task<FinancialInstrument?> GetFinancialInstrumentByIdAsync(int Id)
        {
            return await finInstrRepozitory.All().Where(f => f.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<FinancialInstrumentQueryServiceModel> AllAsyn(
                                                    string? ISIN = null
                                                    , string? searchTerm = null
                                                    , FinInstrumentsSorting sorting = FinInstrumentsSorting.Newest
                                                    , int currentPage = 1
                                                    , int finInstrumentsPerPage = 1)
        {
            var finInstrumentsToShow = finInstrRepozitory.AllAsNoTracking();

            if(ISIN != null)
            {
                finInstrumentsToShow = finInstrumentsToShow
                    .Where(f => f.ISIN == ISIN);
            }

            if (searchTerm != null)
            {
                string normalizedSearcTerm = searchTerm.ToLower();

                finInstrumentsToShow = finInstrumentsToShow
                    .Where(f => f.Name.ToLower().Contains(normalizedSearcTerm)
                        || f.ISIN.ToLower().Contains(normalizedSearcTerm)
                        || f.Description.ToLower().Contains(normalizedSearcTerm));
            }

            finInstrumentsToShow = sorting switch
            {
                FinInstrumentsSorting.Name => finInstrumentsToShow
                    .OrderBy(f => f.Name)
                    .ThenByDescending(f => f.CreatedOn),
                FinInstrumentsSorting.Sherholders => finInstrumentsToShow
                    .OrderByDescending(f => f.OwnersOfThisInstruments.Count())
                    .ThenByDescending(f => f.CreatedOn),
                _ => finInstrumentsToShow
                    .OrderByDescending(f => f.CreatedOn),
            };

            var financialInstruments = await finInstrumentsToShow
                .Skip((currentPage - 1) * finInstrumentsPerPage)
                .Take(finInstrumentsPerPage)
                .Select(f => new FinInstrumentDetailsServiceModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    ISIN = f.ISIN,
                    Description = f.Description,
                })
                .ToListAsync();

            int totalFinancialInstruments = await finInstrumentsToShow.CountAsync();

            return new FinancialInstrumentQueryServiceModel()
            {
                FinancialInstruments = financialInstruments,
                TotalFinInstrumentCount = totalFinancialInstruments,
            };
        }

        public async Task<IEnumerable<string>> AllISINsAsync()
        {
            return await finInstrRepozitory.AllAsNoTracking().Select(f => f.ISIN).OrderBy(n => n).ToListAsync();
        }
    }
}
