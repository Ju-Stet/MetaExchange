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
        public void GetSellOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsNull()
        {
            // Arrange
            List<IdOrderBookDTO> orderBooks = null;
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetSellOrdersFromOrderBooks(orderBooks);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetSellOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsEmpty()
        {
            // Arrange
            var orderBooks = new List<IdOrderBookDTO>();
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetSellOrdersFromOrderBooks(orderBooks);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetSellOrdersFromOrderBooks_ReturnsCorrectData()
        {
            // Arrange
            var orderBooks = TestHelper.GetOrderBooks();
            var expectedResult = TestHelper.GetOrderedSellOrders();
            _orderMapperMock.Setup(m => m.MapSellOrderList(orderBooks)).Returns(TestHelper.GetSellOrders());

            // Act
            var response = _orderService.GetSellOrdersFromOrderBooks(orderBooks).Value;

            // Assert
            response.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetBuyOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsNull()
        {
            // Arrange
            List<IdOrderBookDTO> orderBooks = null;
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetBuyOrdersFromOrderBooks(orderBooks);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetBuyOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsEmpty()
        {
            // Arrange
            var orderBooks = new List<IdOrderBookDTO>();
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetBuyOrdersFromOrderBooks(orderBooks);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetBuyOrdersFromOrderBooks_ReturnsCorrectData()
        {
            // Arrange
            var orderBooks = TestHelper.GetOrderBooks();
            var expectedResult = TestHelper.GetOrderedBuyOrders();
            _orderMapperMock.Setup(m => m.MapBuyOrderList(orderBooks)).Returns(TestHelper.GetBuyOrders);

            // Act
            var response = _orderService.GetBuyOrdersFromOrderBooks(orderBooks).Value;

            // Assert
            response.Should().BeEquivalentTo(expectedResult);
        }
    }
}
