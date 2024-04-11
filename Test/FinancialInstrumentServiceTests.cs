using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Services;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;

namespace TradeSystem.UnitTests
{
    public class FinancialInstrumentServiceTests
    {
        private Mock<IDeletableEntityRepository<Client>> mockClientRepozitory;
        private Mock<IDeletableEntityRepository<Order>> mockOrderRepozitory;
        private Mock<IDeletableEntityRepository<ClientFinancialInstrument>> mockClientFinancialInstrumentRepozitory;
        private Mock<IDeletableEntityRepository<FinancialInstrument>> mockFinInstrRepozitory;
        private Mock<IClientService> mockClientService;
        private IFinancialInstrumentService financialInstrumentService;

        [OneTimeSetUp]

        public void Setup()
        {
            mockClientRepozitory = new Mock<IDeletableEntityRepository<Client>>();

            mockClientRepozitory
                .Setup(x => x.All().Where(x => x.Id == Guid.Parse("2c67aae6-a962-4c2f-9de7-529813865bb7")).FirstOrDefault())
                .Returns(null);
                {

                });

            financialInstrumentService = new FinancialInstrumentService();
        }
    }
}
