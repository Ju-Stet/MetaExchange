using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services
{
    public interface IOrderBookService
    {
        ServiceResult FindBestFit(RequestInfo requestInfo, List<ExchangeDTO> exchangeDTOs = null);
    }
}
