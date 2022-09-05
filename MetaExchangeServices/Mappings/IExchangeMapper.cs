using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public interface IExchangeMapper
    {
        List<ExchangeDTO> MapRequestInfoOntoExchangeDTOList(RequestInfo requestInfo, List<ExchangeDTO> exchangeDTOs);
    }
}
