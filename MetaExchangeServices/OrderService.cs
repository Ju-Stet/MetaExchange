using MetaExchange.Models;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaExchange.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderMapper _orderMapper;

        public OrderService(IOrderMapper orderBookMapper)
        {
            _orderMapper = orderBookMapper;
        }

        public ServiceObjectResult<IEnumerable<GetOrderResponse>> GetSellOrdersFromOrderBooks(Dictionary<string, OrderBook> orderBookDictionary)
        {
            if (orderBookDictionary == null || orderBookDictionary.Count == 0)
            {
                return null;
            }

            var orders = _orderMapper.MapSellOrderList(orderBookDictionary);

            orders = orders.OrderBy(o => o.Price)
                    .ThenByDescending(o => o.Amount)
                    .ToList();

            return new ServiceObjectResult<IEnumerable<GetOrderResponse>>(orders);
        }

        public ServiceObjectResult<IEnumerable<GetOrderResponse>> GetBuyOrdersFromOrderBooks(Dictionary<string, OrderBook> orderBookDictionary)
        {
            if (orderBookDictionary == null || orderBookDictionary.Count == 0)
            {
                return null;
            }

            var orders = _orderMapper.MapBuyOrderList(orderBookDictionary);

            orders = orders.OrderByDescending(o => o.Price)
                    .ThenByDescending(o => o.Amount)
                    .ToList();

            return new ServiceObjectResult<IEnumerable<GetOrderResponse>>(orders);
        }
    }
}
