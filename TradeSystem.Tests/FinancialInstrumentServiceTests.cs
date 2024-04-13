using Moq;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Services;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class FinancialInstrumentServiceTests : UnitTestsBase
    {

        [OneTimeSetUp]
       
        
        [Test]

        public async Task CheckAllFinancialInstrumentsOfClientAsync()
        {

            mockRepoClient.Setup(x => x.AllAsNoTracking()).Returns(listClient.AsQueryable);
            mockRepoOrder.Setup(x => x.AllAsNoTracking()).Returns(listOrder.AsQueryable);
            mockRepoClientFinancialInstrument.Setup(x => x.AllAsNoTracking()).Returns(listClientFinancialInstrument.AsQueryable);
            mockRepoFinancialInstrument.Setup(x => x.AllAsNoTracking()).Returns(listFinancialInstrument.AsQueryable);

            mockClientService.Setup(x => x.GetClientIdByUserIdAsync(new Guid().ToString()))
                .ReturnsAsync(new Guid());
            
            //var financialInstrumentService = new FinancialInstrumentService(
            //                                                                    mockRepoClient.Object
            //                                                                    , mockRepoOrder.Object
            //                                                                    , mockRepoClientFinancialInstrument.Object
            //                                                                    , mockRepoFinancialInstrument.Object
            //                                                                    , mockClientService.Object);

            //var result = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync(null);

            //Assert.IsTrue(result.Count() == 4);


        }
    }
}
