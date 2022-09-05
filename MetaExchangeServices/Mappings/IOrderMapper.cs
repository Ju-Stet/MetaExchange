using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public interface IOrderMapper
    {
        List<GetOrderResponse> MapBuyOrderList(ExchangeDTO exchangeDTO);
        List<GetOrderResponse> MapSellOrderList(ExchangeDTO exchangeDTO);
    }
}
