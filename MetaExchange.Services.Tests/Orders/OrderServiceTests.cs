using FluentAssertions;
using MetaExchange.Models;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MetaExchange.Services.Tests.Orders
{
    public class OrderServiceTests
    {
        private readonly OrderService _orderService;
        private readonly Mock<IOrderMapper> _orderMapperMock;

        public OrderServiceTests()
        {
            _orderMapperMock = new Mock<IOrderMapper>();
            _orderService = new OrderService(_orderMapperMock.Object);
        }

        [Fact]
        public void GetSellOrdersFromExchangeDTO_ReturnsNullIfExchangeDTOIsNull()
        {
            // Arrange
            ExchangeDTO exchangeDTO = null;
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetSellOrdersFromExchangeDTO(exchangeDTO);

            // Assert
            Assert.Equal(expectedResult, response);
        }
        

        [Fact]
        public void GetSellOrdersFromExchangeDTO_ReturnsCorrectData()
        {
            // Arrange
            var exchangeDTO = TestHelper.GetExchangeDTO();
            var expectedResult = new ServiceObjectResult<List<GetOrderResponse>>(TestHelper.GetSellOrdersFromExchangeDTO());
            _orderMapperMock.Setup(m => m.MapSellOrderList(exchangeDTO)).Returns(TestHelper.GetSellOrdersFromExchangeDTO());

            // Act
            var response = _orderService.GetSellOrdersFromExchangeDTO(exchangeDTO);

            // Assert
            response.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetBuyOrdersFromExchangeDTO_ReturnsNullIfExchangeDTOIsNull()
        {
            // Arrange
            ExchangeDTO exchangeDTO = null;
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetBuyOrdersFromExchangeDTO(exchangeDTO);

            // Assert
            Assert.Equal(expectedResult, response);
        }
        
        [Fact]
        public void GetBuyOrdersFromExchangeDTO_ReturnsCorrectData()
        {
            // Arrange
            var exchangeDTO = TestHelper.GetExchangeDTO();
            var expectedResult = new ServiceObjectResult<List<GetOrderResponse>>(TestHelper.GetBuyOrdersFromExchangeDTO());
            _orderMapperMock.Setup(m => m.MapBuyOrderList(exchangeDTO)).Returns(TestHelper.GetBuyOrdersFromExchangeDTO());

            // Act
            var response = _orderService.GetBuyOrdersFromExchangeDTO(exchangeDTO);

            // Assert
            response.Should().BeEquivalentTo(expectedResult);
        }
    }
}
