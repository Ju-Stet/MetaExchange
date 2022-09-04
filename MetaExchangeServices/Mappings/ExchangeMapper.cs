using MetaExchange.Services.Models;
using System.Collections.Generic;

namespace MetaExchange.Services.Mappings
{
    public class ExchangeMapper : IExchangeMapper
    {
        public List<ExchangeDTO> MapRequestInfoOntoExchangeDTOList(RequestInfo requestInfo, List<ExchangeDTO> exchangeDTOs)
        {
            foreach (var dto in exchangeDTOs)
            {
                dto.EuroBalance = requestInfo.EuroBalance;
                dto.BTCBalance = requestInfo.BTCBalance;
            }

            return exchangeDTOs;
        }
    }
}
