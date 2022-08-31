using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public interface IOrderService
    {
        ServiceObjectResult<List<GetOrderResponse>> GetBuyOrdersFromOrderBooks(List<IdOrderBookDTO> idOrderBookDTOs);
        ServiceObjectResult<List<GetOrderResponse>> GetSellOrdersFromOrderBooks(List<IdOrderBookDTO> idOrderBookDTOs);
    }
}
