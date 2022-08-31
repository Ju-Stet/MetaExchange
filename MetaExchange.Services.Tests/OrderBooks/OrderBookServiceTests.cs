using FluentAssertions;
using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Models;
using Moq;
using System.Collections.Generic;
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
        public void FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryIsNullAndRequestInfo_Buy()
        {
            // Arrange
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Buy,
                BTCAmount = 0.3M,
                BTCBalance = 1M,
                EuroBalance = 1000M
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePath(It.IsAny<string>()))
                .Returns(new ServiceObjectResult<List<IdOrderBookDTO>>(TestHelper.GetOrderBooks()));
            _orderServiceMock.Setup(m => m.GetSellOrdersFromOrderBooks(It.IsAny<List<IdOrderBookDTO>>()))
                .Returns(new ServiceObjectResult<List<GetOrderResponse>>(TestHelper.GetOrderedSellOrders()));

            var expectedResult = TestHelper.GetFitForBuyRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryNotNullAndRequestInfo_Buy()
        {
            // Arrange
            var orderBooks = TestHelper.GetOrderBooks();
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Buy,
                BTCAmount = 0.3M,
                BTCBalance = 1M,
                EuroBalance = 1000M
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePath(It.IsAny<string>()))
                .Returns(new ServiceObjectResult<List<IdOrderBookDTO>>(TestHelper.GetOrderBooks()));
            _orderServiceMock.Setup(m => m.GetSellOrdersFromOrderBooks(It.IsAny<List<IdOrderBookDTO>>()))
                .Returns(new ServiceObjectResult<List<GetOrderResponse>>(TestHelper.GetOrderedSellOrders()));

            var expectedResult = TestHelper.GetFitForBuyRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo, orderBooks) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryIsNullAndRequestInfo_Sell()
        {
            // Arrange
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Sell,
                BTCAmount = 0.33M,
                BTCBalance = 1M,
                EuroBalance = 1000M
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePath(It.IsAny<string>()))
                .Returns(new ServiceObjectResult<List<IdOrderBookDTO>>(TestHelper.GetOrderBooks()));
            _orderServiceMock.Setup(m => m.GetBuyOrdersFromOrderBooks(It.IsAny<List<IdOrderBookDTO>>()))
                .Returns(new ServiceObjectResult<List<GetOrderResponse>>(TestHelper.GetOrderedBuyOrders()));

            var expectedResult = TestHelper.GetFitForSellRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfOrderBookDictionaryNotNullAndRequestInfo_Sell()
        {
            // Arrange
            var orderBooks = TestHelper.GetOrderBooks();
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Sell,
                BTCAmount = 0.33M,
                BTCBalance = 1M,
                EuroBalance = 1000M
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePath(It.IsAny<string>()))
                .Returns(new ServiceObjectResult<List<IdOrderBookDTO>>(TestHelper.GetOrderBooks()));
            _orderServiceMock.Setup(m => m.GetBuyOrdersFromOrderBooks(It.IsAny<List<IdOrderBookDTO>>()))
                .Returns(new ServiceObjectResult<List<GetOrderResponse>>(TestHelper.GetOrderedBuyOrders()));

            var expectedResult = TestHelper.GetFitForSellRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo, orderBooks) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }
    }
}
