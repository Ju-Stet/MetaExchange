using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public interface IOrderService
    {
        ServiceObjectResult<List<GetOrderResponse>> GetBuyOrdersFromOrderBooks(Dictionary<string, OrderBook> orderBookDictionary);
        ServiceObjectResult<List<GetOrderResponse>> GetSellOrdersFromOrderBooks(Dictionary<string, OrderBook> orderBookDictionary);
    }
}
