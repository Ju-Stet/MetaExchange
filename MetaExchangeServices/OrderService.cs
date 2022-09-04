using MetaExchange.Models;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderMapper _orderMapper;

        public OrderService(IOrderMapper orderBookMapper)
        {
            _orderMapper = orderBookMapper;
        }

        public ServiceObjectResult<List<GetOrderResponse>> GetBuyOrdersFromExchangeDTO(ExchangeDTO exchangeDTO)
        {
            if (exchangeDTO == null)
            {
                return null;
            }

            var orders = _orderMapper.MapBuyOrderList(exchangeDTO);

            return new ServiceObjectResult<List<GetOrderResponse>>(orders);
        }

        public ServiceObjectResult<List<GetOrderResponse>> GetSellOrdersFromExchangeDTO(ExchangeDTO exchangeDTO)
        {
            if (exchangeDTO == null)
            {
                return null;
            }

            var orders = _orderMapper.MapSellOrderList(exchangeDTO);

            return new ServiceObjectResult<List<GetOrderResponse>>(orders);
        }
    }
}
