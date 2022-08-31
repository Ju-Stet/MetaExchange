using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public interface IOrderMapper
    {
        List<GetOrderResponse> MapBuyOrderList(List<IdOrderBookDTO> idOrderBookDTOs);
        List<GetOrderResponse> MapSellOrderList(List<IdOrderBookDTO> idOrderBookDTOs);
    }
}
