using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public interface IOrderMapper
    {
        IEnumerable<GetOrderResponse> MapBuyOrderList(Dictionary<string, OrderBook> orderBookDictionary);
        IEnumerable<GetOrderResponse> MapSellOrderList(Dictionary<string, OrderBook> orderBookDictionary);
    }
}
