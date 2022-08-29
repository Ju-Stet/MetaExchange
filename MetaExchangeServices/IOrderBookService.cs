using MetaExchange.Models;
using MetaExchange.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetaExchange.Services
{
    public interface IOrderBookService
    {
        Task<ServiceObjectResult<IEnumerable<GetOrderResponse>>> FindBestFit(RequestInfo requestInfo, Dictionary<string, OrderBook> orderBookDictionary = null);
    }
}
