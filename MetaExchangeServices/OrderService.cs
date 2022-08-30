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

        public ServiceObjectResult<List<GetOrderResponse>> GetSellOrdersFromOrderBooks(List<IdOrderBookDTO> idOrderBookDTOs)
        {
            if (idOrderBookDTOs == null || idOrderBookDTOs.Count == 0)
            {
                return null;
            }

            var orders = _orderMapper.MapSellOrderList(idOrderBookDTOs);

            orders = orders.OrderBy(o => o.Price)
                    .ThenByDescending(o => o.Amount)
                    .ToList();

            return new ServiceObjectResult<List<GetOrderResponse>>(orders);
        }

        public ServiceObjectResult<List<GetOrderResponse>> GetBuyOrdersFromOrderBooks(List<IdOrderBookDTO> idOrderBookDTOs)
        {
            if (idOrderBookDTOs == null || idOrderBookDTOs.Count == 0)
            {
                return null;
            }

            var orders = _orderMapper.MapBuyOrderList(idOrderBookDTOs);

            orders = orders.OrderByDescending(o => o.Price)
                    .ThenByDescending(o => o.Amount)
                    .ToList();

            return new ServiceObjectResult<List<GetOrderResponse>>(orders);
        }
    }
}
