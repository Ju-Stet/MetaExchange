using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public interface IOrderBookService
    {
        ServiceObjectResult<List<GetOrderResponse>> FindBestFit(RequestInfo requestInfo, List<IdOrderBookDTO> idOrderBookDTOs = null);
    }
}
