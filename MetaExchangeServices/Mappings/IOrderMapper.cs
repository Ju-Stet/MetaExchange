using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public interface IOrderMapper
    {
        List<GetOrderResponse> MapBuyOrderList(Dictionary<string, OrderBook> orderBookDictionary);
        List<GetOrderResponse> MapSellOrderList(Dictionary<string, OrderBook> orderBookDictionary);
    }
}
