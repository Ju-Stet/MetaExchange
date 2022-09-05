using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public interface IOrderService
    {
        ServiceObjectResult<List<GetOrderResponse>> GetBuyOrdersFromExchangeDTO(ExchangeDTO exchangeDTO);
        ServiceObjectResult<List<GetOrderResponse>> GetSellOrdersFromExchangeDTO(ExchangeDTO exchangeDTO);
    }
}
