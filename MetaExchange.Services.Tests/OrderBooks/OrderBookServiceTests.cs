using FluentAssertions;
using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MetaExchange.Services.Tests.OrderBooks
{
    public class OrderBookServiceTests
    {
        private readonly OrderBookService _orderBookService;
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<IInputDataService> _inputDataServiceMock;

        public OrderBookServiceTests()
        {
            _inputDataServiceMock = new Mock<IInputDataService>();
            _orderServiceMock = new Mock<IOrderService>();
            _orderBookService = new OrderBookService(_orderServiceMock.Object, _inputDataServiceMock.Object);
        }

        [Fact]
        public async Task FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryIsNullAndRequestInfo_Buy()
        {
            // Arrange
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Buy,
                BTCAmount = 0.3,
                BTCBalance = 1,
                EuroBalance = 1000
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePathAsync(It.IsAny<string>()))
                .ReturnsAsync(new ServiceObjectResult<Dictionary<string, OrderBook>>(TestHelper.GetOrderBookDictionary()));
            _orderServiceMock.Setup(m => m.GetSellOrdersFromOrderBooks(It.IsAny<Dictionary<string, OrderBook>>()))
                .Returns(new ServiceObjectResult<IEnumerable<GetOrderResponse>>(TestHelper.GetOrderedSellOrders()));

            var expectedResult = TestHelper.GetFitForBuyRequest();

            // Act
            var response = await _orderBookService.FindBestFit(requestInfo);

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryNotNullAndRequestInfo_Buy()
        {
            // Arrange
            var orderBookDictionary = TestHelper.GetOrderBookDictionary();
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Buy,
                BTCAmount = 0.3,
                BTCBalance = 1,
                EuroBalance = 1000
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePathAsync(It.IsAny<string>()))
                .ReturnsAsync(new ServiceObjectResult<Dictionary<string, OrderBook>>(TestHelper.GetOrderBookDictionary()));
            _orderServiceMock.Setup(m => m.GetSellOrdersFromOrderBooks(It.IsAny<Dictionary<string, OrderBook>>()))
                .Returns(new ServiceObjectResult<IEnumerable<GetOrderResponse>>(TestHelper.GetOrderedSellOrders()));

            var expectedResult = TestHelper.GetFitForBuyRequest();

            // Act
            var response = await _orderBookService.FindBestFit(requestInfo, orderBookDictionary);

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryIsNullAndRequestInfo_Sell()
        {
            // Arrange
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Sell,
                BTCAmount = 0.33,
                BTCBalance = 1,
                EuroBalance = 1000
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePathAsync(It.IsAny<string>()))
                .ReturnsAsync(new ServiceObjectResult<Dictionary<string, OrderBook>>(TestHelper.GetOrderBookDictionary()));
            _orderServiceMock.Setup(m => m.GetBuyOrdersFromOrderBooks(It.IsAny<Dictionary<string, OrderBook>>()))
                .Returns(new ServiceObjectResult<IEnumerable<GetOrderResponse>>(TestHelper.GetOrderedBuyOrders()));

            var expectedResult = TestHelper.GetFitForSellRequest();

            // Act
            var response = await _orderBookService.FindBestFit(requestInfo);

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryNotNullAndRequestInfo_Sell()
        {
            // Arrange
            var orderBookDictionary = TestHelper.GetOrderBookDictionary();
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Sell,
                BTCAmount = 0.33,
                BTCBalance = 1,
                EuroBalance = 1000
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePathAsync(It.IsAny<string>()))
                .ReturnsAsync(new ServiceObjectResult<Dictionary<string, OrderBook>>(TestHelper.GetOrderBookDictionary()));
            _orderServiceMock.Setup(m => m.GetBuyOrdersFromOrderBooks(It.IsAny<Dictionary<string, OrderBook>>()))
                .Returns(new ServiceObjectResult<IEnumerable<GetOrderResponse>>(TestHelper.GetOrderedBuyOrders()));

            var expectedResult = TestHelper.GetFitForSellRequest();

            // Act
            var response = await _orderBookService.FindBestFit(requestInfo, orderBookDictionary);

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }
    }
}
