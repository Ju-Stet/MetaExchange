using FluentAssertions;
using MetaExchange.Models;
using MetaExchange.Models.Enums;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MetaExchange.Services.Tests.OrderBooks
{
    public class OrderBookServiceTests
    {
        private readonly OrderBookService _orderBookService;
        private readonly IOrderService _orderService;
        private readonly Mock<IInputDataService> _inputDataServiceMock;
        private readonly Mock<IExchangeMapper> _exchangeMapperMock;

        public OrderBookServiceTests()
        {
            _inputDataServiceMock = new Mock<IInputDataService>();
            _orderService = new OrderService(new OrderMapper());
            _exchangeMapperMock = new Mock<IExchangeMapper>();
            _orderBookService = new OrderBookService(_orderService, 
                _inputDataServiceMock.Object, 
                _exchangeMapperMock.Object);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfExchangeDTOIsNullAndRequestInfo_Buy()
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
                .Returns(new ServiceObjectResult<List<ExchangeDTO>>(TestHelper.GetExchangeDTOs()));
            _exchangeMapperMock.Setup(m => m.MapRequestInfoOntoExchangeDTOList(It.IsAny<RequestInfo>(), It.IsAny<List<ExchangeDTO>>()))
                .Returns(TestHelper.GetExchangeDTOs());

            var expectedResult = TestHelper.GetFitForBuyRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfExchangeDTONotNullAndRequestInfo_Buy()
        {
            // Arrange
            var exchangeDTOs = TestHelper.GetExchangeDTOs();
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Buy,
                BTCAmount = 0.3M,
                BTCBalance = 1M,
                EuroBalance = 1000M
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePath(It.IsAny<string>()))
                .Returns(new ServiceObjectResult<List<ExchangeDTO>>(TestHelper.GetExchangeDTOs()));
            _exchangeMapperMock.Setup(m => m.MapRequestInfoOntoExchangeDTOList(It.IsAny<RequestInfo>(), It.IsAny<List<ExchangeDTO>>()))
                .Returns(TestHelper.GetExchangeDTOs());

            var expectedResult = TestHelper.GetFitForBuyRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo, exchangeDTOs) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfExchangeDTOIsNullAndRequestInfo_Sell()
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
                .Returns(new ServiceObjectResult<List<ExchangeDTO>>(TestHelper.GetExchangeDTOs()));
            _exchangeMapperMock.Setup(m => m.MapRequestInfoOntoExchangeDTOList(It.IsAny<RequestInfo>(), It.IsAny<List<ExchangeDTO>>()))
                .Returns(TestHelper.GetExchangeDTOs());

            var expectedResult = TestHelper.GetFitForSellRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void FindBestFit_ReturnsCorrectDataIfExchangeDTONotNullAndRequestInfo_Sell()
        {
            // Arrange
            var exchangeDTOs = TestHelper.GetExchangeDTOs();
            var requestInfo = new RequestInfo()
            {
                OrderType = OrderTypeEnum.Sell,
                BTCAmount = 0.33M,
                BTCBalance = 1M,
                EuroBalance = 1000M
            };
            _inputDataServiceMock.Setup(m => m.ProcessOrderBooksDataFilePath(It.IsAny<string>()))
                 .Returns(new ServiceObjectResult<List<ExchangeDTO>>(TestHelper.GetExchangeDTOs()));
            _exchangeMapperMock.Setup(m => m.MapRequestInfoOntoExchangeDTOList(It.IsAny<RequestInfo>(), It.IsAny<List<ExchangeDTO>>()))
                .Returns(TestHelper.GetExchangeDTOs());

            var expectedResult = TestHelper.GetFitForSellRequest();

            // Act
            var response = _orderBookService.FindBestFit(requestInfo) as ServiceObjectResult<List<GetOrderResponse>>;

            // Assert
            response.Value.Should().BeEquivalentTo(expectedResult);
        }
    }
}
