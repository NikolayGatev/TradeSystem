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
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory;
        private readonly IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private readonly IClientService clientService;

        public FinancialInstrumentService(
                   IDeletableEntityRepository<Order> orderRepozitory
                   , IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory
                   , IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory
                   , IClientService clientService)

        {
            this.orderRepozitory = orderRepozitory;
            this.clientFinancialInstrumentRepozitory = clientFinancialInstrumentRepozitory;
            this.finInstrRepozitory = finInstrRepozitory;
            this.clientService = clientService;
        }
        public async Task<IEnumerable<FinInstrumentServiceModel>> AllFinancialInstrumentsOfClientAsync(string? userId)
        {
            if (userId != null)
            {
                var clientId = await clientService.GetClientIdByUserIdAsync(userId ?? string.Empty) ?? new Guid();

                var ordersSum = await orderRepozitory.AllAsNoTracking().Where(o => o.ClientId == clientId && o.IsBid == false)
                    .ToListAsync();

                var result = await finInstrRepozitory.AllAsNoTracking().Select(f => new FinInstrumentServiceModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    SharesHeld = (uint)f.OwnersOfThisInstruments.Where(o => o.ClientId == clientId).Sum(o => o.Volume),
                })
                  .OrderBy(f => f.Name)
                  .ToListAsync();

                foreach (var fin in result)
                {
                    fin.SumOfAllOrdersSell = ordersSum.Select(x => x.FinancialInstrumentId).Contains(fin.Id)
                    ? (uint)ordersSum.Where(x => x.FinancialInstrumentId == fin.Id).Sum(x => x.InitialVolume)
                    : 0;
                }

                return result;
            }
            else
            {
                return await finInstrRepozitory.AllAsNoTracking().Select(f => new FinInstrumentServiceModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    ISIN = f.ISIN
                })
                .OrderBy(f => f.Name)
                .ToListAsync();
            }
        }

        public async Task<int> CreateAsync(FinacialInstrumentFormModel model)
        {
            if(await finInstrRepozitory.AllAsNoTracking().AnyAsync(f => f.ISIN == model.ISIN 
                                                                    || f.Name == model.Name))
            {
                throw new NonExistFinancialInstrumentWithThisNameOrISIN(MessageNotVacantNameOrISIN);
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

        public async Task DeleteAsync(int id, string userId)
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
                FinInstrumentsSorting.Sharesholders => finInstrumentsToShow
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

        public async Task FundedAccountWithFinancialInstruments(Guid clientId, int financialInstrumentId, uint count)
        {
            var client = await clientService.GetClientByClientIdAcync(clientId);

            if(client == null)
            {
                throw new Exception(MessageUnauthoriseActionException);
            }
            if(await ExixtFinancialInstrumentAsync(financialInstrumentId) == false)
            {
                throw new NonFinancialInstrumentException(MessageNotFinancialInstrumentException);
            } 

            if (client.FinancialInstruments.Any(si => si.FinancialInstrumentId == financialInstrumentId))
            {
                var clientFinInsr = await clientFinancialInstrumentRepozitory.All()
                         .Where(f => f.FinancialInstrumentId == financialInstrumentId
                             && f.ClientId == client.Id)
                .FirstAsync();

                clientFinInsr.Volume += count;
            }
            else
            {
                var clientFinInstr = new ClientFinancialInstrument()
                {
                    ClientId = client.Id,
                    FinancialInstrumentId = financialInstrumentId,
                    Volume = count,
                };

                await clientFinancialInstrumentRepozitory.AddAsync(clientFinInstr);
            }

            await clientFinancialInstrumentRepozitory.SaveChangesAsync();
        }

        public async Task<IEnumerable<FinInstrumentServiceModel>> AllFinancialInstrumentsAsync()
        {
            return await finInstrRepozitory.AllAsNoTracking()
                .Select(f => new FinInstrumentServiceModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    ISIN = f.ISIN
                })
                .OrderBy(f => f.Name)
                .ToListAsync();
        }

        public async Task<int> GetCountOfOwnerFinancialInstrumentOnClientByIdAsync(Guid? clientId, int finInstrId)
        {
            return await clientFinancialInstrumentRepozitory.AllAsNoTracking()
                .Where(cfi => cfi.FinancialInstrumentId == finInstrId && cfi.ClientId == clientId)
                .Select(cfi => (int)cfi.Volume).SumAsync();
        }
    }
}
