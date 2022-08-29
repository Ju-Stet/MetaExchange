using FluentAssertions;
using MetaExchange.Models;
using MetaExchange.Services.Mappings;
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
            Dictionary<string, OrderBook> orderDictionary = null;
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetSellOrdersFromOrderBooks(orderDictionary);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetSellOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsEmpty()
        {
            // Arrange
            var orderBookDictionary = new Dictionary<string, OrderBook>();
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetSellOrdersFromOrderBooks(orderBookDictionary);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetSellOrdersFromOrderBooks_ReturnsCorrectData()
        {
            // Arrange
            var orderBookDictionary = TestHelper.GetOrderBookDictionary();
            var expectedResult = TestHelper.GetOrderedSellOrders();
            _orderMapperMock.Setup(m => m.MapSellOrderList(orderBookDictionary)).Returns(TestHelper.GetSellOrders);

            // Act
            var response = _orderService.GetSellOrdersFromOrderBooks(orderBookDictionary).Value;

            // Assert
            response.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetBuyOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsNull()
        {
            // Arrange
            Dictionary<string, OrderBook> orderDictionary = null;
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetBuyOrdersFromOrderBooks(orderDictionary);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetBuyOrdersFromOrderBooks_ReturnsNullIfOrderDictionaryIsEmpty()
        {
            // Arrange
            var orderBookDictionary = new Dictionary<string, OrderBook>();
            ServiceResult expectedResult = null;

            // Act
            var response = _orderService.GetBuyOrdersFromOrderBooks(orderBookDictionary);

            // Assert
            Assert.Equal(expectedResult, response);
        }

        [Fact]
        public void GetBuyOrdersFromOrderBooks_ReturnsCorrectData()
        {
            // Arrange
            var orderBookDictionary = TestHelper.GetOrderBookDictionary();
            var expectedResult = TestHelper.GetOrderedBuyOrders();
            _orderMapperMock.Setup(m => m.MapBuyOrderList(orderBookDictionary)).Returns(TestHelper.GetBuyOrders);

            // Act
            var response = _orderService.GetBuyOrdersFromOrderBooks(orderBookDictionary).Value;

            // Assert
            response.Should().BeEquivalentTo(expectedResult);
        }
    }
}
