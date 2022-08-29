using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public interface IOrderService
    {
        ServiceObjectResult<IEnumerable<GetOrderResponse>> GetBuyOrdersFromOrderBooks(Dictionary<string, OrderBook> orderBookDictionary);
        ServiceObjectResult<IEnumerable<GetOrderResponse>> GetSellOrdersFromOrderBooks(Dictionary<string, OrderBook> orderBookDictionary);
    }
}
